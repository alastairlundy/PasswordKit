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
    public static class CharExtensions
    {
        /// <summary>
        /// Checks to see whether a character is a number from 0 to 9.
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static bool IsCharacterANumber(this char chr)
        {
            for (int i = 0; i < 10; i++)
            {
                if (chr.ToString().Equals(i.ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see whether a character is a Capital/Upper Case letter.
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static bool IsCharacterAnUpperCaseLetter(this char chr)
        {
            foreach (string s in enumsAndConstants.Constants.EnglishAlphabetLower)
            {
                if (chr.ToString().Equals(s.ToUpper()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks to see if a character is a Lower Case letter.
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static bool IsCharacterALowerCaseLetter(this char chr)
        {
            foreach (string s in enumsAndConstants.Constants.EnglishAlphabetLower)
            {
                if (chr.ToString().Equals(s.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks to see if a character is a Special Character
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        public static bool IsCharacterASpecialCharacter(this char chr)
        {
            foreach (string s in enumsAndConstants.Constants.SpecialCharacters)
            {
                if (chr.ToString().Equals(s) == false)
                {
                    return false;
                }
            }

            return true;
        }
    }
}