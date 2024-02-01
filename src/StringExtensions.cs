/* MIT License

Copyright (c) 2019-2024 Alastair Lundy

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
    */

namespace PasswordKit
{
    public static class StringExtensions
    {
        /// <summary>
        /// Returns the number of special characters in a Password.
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfSpecialCharacters(this string str)
        {
            int numberOfSpecialCharacters = 0;

            for (int scLower = 0; scLower < enumsAndConstants.Constants.SpecialCharacters.Length; scLower++)
            {
                if (str.Equals(enumsAndConstants.Constants.EnglishAlphabetLower[scLower].ToUpper()))
                {
                    numberOfSpecialCharacters++;
                }
            }
            
            return numberOfSpecialCharacters;
        }
        
        /// <summary>
        /// Returns the number of upper case characters in a Password.
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfUpperCaseCharacters(this string str)
        {
            int numberOfUpperCase = 0;

            foreach (string s in enumsAndConstants.Constants.EnglishAlphabetLower)
            {
                for (int aLower = 0; aLower <  enumsAndConstants.Constants.SpecialCharacters.Length; aLower++)
                {
                    if (str.Equals(enumsAndConstants.Constants.EnglishAlphabetLower[aLower].ToUpper()))
                    {
                        numberOfUpperCase++;
                    }
                }
            }
            
            return numberOfUpperCase;
        }

        /// <summary>
        /// Returns the number of numbers in a Password.
        /// </summary>
        /// <returns></returns>
        public static int GetNumberOfNumbers(this string str)
        {
            int numberOfNumbers = 0;

            for(int index = 0;  index < str.Length; index++)
            {
                for (int nLower = 0; nLower < 10; nLower++)
                {
                    if (str[index].ToString().Equals(nLower.ToString()))
                    {
                        numberOfNumbers++;
                    }
                }
            }
            
            return numberOfNumbers;
        }
    }
}