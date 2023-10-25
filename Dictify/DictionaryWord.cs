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

using Newtonsoft.Json;
using System.Collections.Generic;

namespace Dictify.Models
{
    /// <summary>
    /// A dictionary word
    /// </summary>
    public partial class DictionaryWord
    {
        /// <summary>
        /// The definition class
        /// </summary>
        public partial class DefinitionType
        {
            /// <summary>
            /// Word definition
            /// </summary>
            [JsonProperty("definition")]
            public string Definition { get; set; }

            /// <summary>
            /// List of synonyms based on the definition
            /// </summary>
            [JsonProperty("synonyms")]
            public string[] Synonyms { get; set; }

            /// <summary>
            /// List of antonyms based on the definition
            /// </summary>
            [JsonProperty("antonyms")]
            public string[] Antonyms { get; set; }

            /// <summary>
            /// Example in sentence
            /// </summary>
            [JsonProperty("example")]
            public string Example { get; set; }
        }

        /// <summary>
        /// The license class
        /// </summary>
        public partial class License
        {
            /// <summary>
            /// License name
            /// </summary>
            [JsonProperty("name")]
            public string Name { get; set; }

            /// <summary>
            /// License URL
            /// </summary>
            [JsonProperty("url")]
            public string Url { get; set; }
        }

        /// <summary>
        /// Word meaning class
        /// </summary>
        public partial class Meaning
        {
            /// <summary>
            /// Part of speech, usually noun, verb, adjective, adverb, interjection, etc.
            /// </summary>
            [JsonProperty("partOfSpeech")]
            public string PartOfSpeech { get; set; }

            /// <summary>
            /// List of word definitions. Words usually come with one or more definitions.
            /// </summary>
            [JsonProperty("definitions")]
            public DefinitionType[] Definitions { get; set; }

            /// <summary>
            /// List of synonyms based on the word meaning
            /// </summary>
            [JsonProperty("synonyms")]
            public string[] Synonyms { get; set; }

            /// <summary>
            /// List of antonyms based on the word meaning
            /// </summary>
            [JsonProperty("antonyms")]
            public string[] Antonyms { get; set; }
        }

        /// <summary>
        /// Phonetic class
        /// </summary>
        public partial class Phonetic
        {
            /// <summary>
            /// Phonetic representation of the word
            /// </summary>
            [JsonProperty("text")]
            public string Text { get; set; }

            /// <summary>
            /// Link to the pronounciation, usually in MP3 format. Use NAudio (Windows) to play it.
            /// </summary>
            [JsonProperty("audio")]
            public string Audio { get; set; }

            /// <summary>
            /// From where did we get the audio from?
            /// </summary>
            [JsonProperty("sourceUrl")]
            public string SourceUrl { get; set; }

            /// <summary>
            /// License information for the source
            /// </summary>
            [JsonProperty("license")]
            public License License { get; set; }
        }

        /// <summary>
        /// The actual word
        /// </summary>
        [JsonProperty("word")]
        public string Word { get; set; }

        /// <summary>
        /// The base phonetic representation of the word
        /// </summary>
        [JsonProperty("phonetic")]
        public string PhoneticWord { get; set; }

        /// <summary>
        /// The alternative phonetic representations
        /// </summary>
        [JsonProperty("phonetics")]
        public Phonetic[] Phonetics { get; set; }

        /// <summary>
        /// Word meanings
        /// </summary>
        [JsonProperty("meanings")]
        public Meaning[] Meanings { get; set; }

        /// <summary>
        /// License information
        /// </summary>
        [JsonProperty("license")]
        public License LicenseInfo { get; set; }

        /// <summary>
        /// List of where we got the word information from
        /// </summary>
        [JsonProperty("sourceUrls")]
        public string[] SourceUrls { get; set; }
    }
}
