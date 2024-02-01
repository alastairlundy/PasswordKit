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

using System;
using AluminiumTech.DevKit.SecureRNGKit;

namespace PasswordKit.Generation{
    /// <summary>
    /// A class to help generate characters which can form a secure password.
    /// </summary>
    public class CharacterGenerator
    {
        protected SecureRandom secureRandom;

        public CharacterGenerator()
        {
            secureRandom = new SecureRandom();
        }

        /// <summary>
        /// Generate a random character.
        /// </summary>
        /// <param name="includeUpperCase"></param>
        /// <param name="includeNumbers"></param>
        /// <param name="includeSpecialCharacters"></param>
        /// <returns></returns>
        public string GenerateRandomCharacterToString(bool includeUpperCase, bool includeNumbers, bool includeSpecialCharacters){
            try
            {
                var random = secureRandom.NextInt(1, 5);

                switch (random)
                {
                    case 1:
                        if (includeUpperCase) { return GenerateRandomUpperCaseCharacterToString(); }
                        else if (includeNumbers) { return GenerateRandomNumberCharacterToString(); }
                        else { return GenerateRandomLowerCaseCharacterToString(); }
                    case 2:
                        if (includeNumbers) { return GenerateRandomNumberCharacterToString(); }
                        else if (includeSpecialCharacters) { return GenerateRandomSpecialCharacterToString(); }                      
                        else { return GenerateRandomLowerCaseCharacterToString(); }
                    case 3:
                        if (includeSpecialCharacters) { return GenerateRandomSpecialCharacterToString(); }
                        else if (includeUpperCase) { return GenerateRandomUpperCaseCharacterToString(); }
                        else { return GenerateRandomLowerCaseCharacterToString(); }
                    case 4:
                        return GenerateRandomLowerCaseCharacterToString();
                    case 5:
                        return GenerateRandomLowerCaseCharacterToString();
                }

                throw new NullReferenceException();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception(ex.ToString());
            }
            
        }

        /// <summary>
        /// Generate a random number from the list of numbers.
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomNumberCharacterToString(){
            return secureRandom.NextInt(0, 9).ToString();
        }

        /// <summary>
        /// Generate a random lower case character from the list of lower case characters.
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomLowerCaseCharacterToString(){
            return enumsAndConstants.Constants.EnglishAlphabetLower[secureRandom.NextInt(0, enumsAndConstants.Constants.EnglishAlphabetLower.Length - 1)].ToLower();
        }

        /// <summary>
        /// Generate a random upper case character from the list of upper case characters.
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomUpperCaseCharacterToString(){
            return GenerateRandomLowerCaseCharacterToString().ToUpper();
        }

        /// <summary>
        /// Generate a random special character from the list of special characters.
        /// </summary>
        /// <returns></returns>
        public string GenerateRandomSpecialCharacterToString(){
            return enumsAndConstants.Constants.SpecialCharacters[secureRandom.NextInt(0, enumsAndConstants.Constants.SpecialCharacters.Length - 1)];
        }
    }
}