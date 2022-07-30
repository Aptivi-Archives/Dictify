/*
 * MIT License
 *
 * Copyright (c) 2022 Aptivi
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 * 
 */

using Dictify.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;

namespace Dictify.Manager
{
    /// <summary>
    /// Dictionary management module
    /// </summary>
    public static partial class DictionaryManager
    {
        private static readonly List<DictionaryWord> CachedWords = new List<DictionaryWord>();
        private static readonly HttpClient DictClient = new HttpClient();

        /// <summary>
        /// Gets the word information and puts it into an array of dictionary words
        /// </summary>
        public static DictionaryWord[] GetWordInfo(string Word)
        {
            if (CachedWords.Any((word) => word.Word == Word))
            {
                // We already have a word, so there is no reason to download it again
                return CachedWords.Where((word) => word.Word == Word).ToArray();
            }
            else
            {
                // Download the word information
                HttpResponseMessage Response = DictClient.GetAsync($"https://api.dictionaryapi.dev/api/v2/entries/en/{Word}").Result;
                Response.EnsureSuccessStatusCode();
                Stream WordInfoStream = Response.Content.ReadAsStreamAsync().Result;
                string WordInfoString = new StreamReader(WordInfoStream).ReadToEnd();

                // Serialize it to DictionaryWord to cache it so that we don't have to download it again
                DictionaryWord[]? Words = (DictionaryWord[]?)JsonConvert.DeserializeObject(WordInfoString, typeof(DictionaryWord[]));
                CachedWords.AddRange(Words);

                // Return the word
                return CachedWords.ToArray();
            }
        }
    }
}