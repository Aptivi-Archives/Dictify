/*
 * MIT License
 *
 * Copyright (c) 2022 EoflaOE and its companies
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

using Dictify.Manager;
using Dictify.Models;

namespace Dictify.Demo
{
    internal class DictionaryDemo
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Specify a word to define in the command-line. \"Dictify.Demo.exe <word>\"");
                return;
            }
            else
            {
                Console.WriteLine("Depending on the font and console, you may see question marks on the phonetic word representation. It's recommended to put them on the GUI.");
                foreach (string word in args)
                {
                    try
                    {
                        DictionaryWord[] words = DictionaryManager.GetWordInfo(word);
                        foreach (DictionaryWord dictWord in words)
                        {
                            // First, print the license out
                            Console.WriteLine("License information");
                            Console.WriteLine($"dictionaryapi.dev API is licensed under {dictWord.LicenseInfo?.Name}: {dictWord.LicenseInfo?.Url}");

                            // Print the word out
                            Console.WriteLine($"{dictWord.Word} {dictWord.PhoneticWord}");

							// Meanings...
							if (dictWord.Meanings == null)
								continue;
							Console.WriteLine($"Word meanings:");
							foreach (DictionaryWord.Meaning MeaningBase in dictWord.Meanings)
							{
								// Base part of speech
								Console.WriteLine($"Part of Speech: {MeaningBase.PartOfSpeech}");

								// Get the definitions
								if (MeaningBase.Definitions == null)
									continue;
								foreach (DictionaryWord.DefinitionType DefinitionBase in MeaningBase.Definitions)
								{
									// Write definition and, if applicable, example
									Console.WriteLine($"  - Definition: {DefinitionBase.Definition}");
									Console.WriteLine($"  - Example in Sentence: {DefinitionBase.Example}");

									// Now, write the specific synonyms (usually blank)
									if (DefinitionBase.Synonyms == null)
										continue;
									if (DefinitionBase.Synonyms.Any())
									{
										Console.WriteLine($"  - Synonyms: {string.Join(", ", DefinitionBase.Synonyms)}");
									}

									// ...and the specific antonyms (usually blank)
									if (DefinitionBase.Antonyms == null)
										continue;
									if (DefinitionBase.Antonyms.Any())
									{
										Console.WriteLine($"  - Antonyms: {string.Join(", ", DefinitionBase.Antonyms)}");
									}
								}

								// Now, write the base synonyms (usually blank))
								if (MeaningBase.Synonyms == null)
									continue;
								if (MeaningBase.Synonyms.Any())
								{
									Console.WriteLine($"  - Synonyms: {string.Join(", ", MeaningBase.Synonyms)}");
								}

								// ...and the base antonyms (usually blank)
								if (MeaningBase.Antonyms == null)
									continue;
								if (MeaningBase.Antonyms.Any())
								{
									Console.WriteLine($"  - Antonyms: {string.Join(", ", MeaningBase.Antonyms)}");
								}
							}

							// Sources...
							if (dictWord.SourceUrls == null)
								continue;
							Console.WriteLine($"Sources used: {string.Join(", ", dictWord.SourceUrls)}");
						}
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Can't define word {0}: {1}", word, ex.Message);
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
        }
    }
}