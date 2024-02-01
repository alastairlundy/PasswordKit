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
using PasswordKit.Models;

namespace PasswordKit.Generation{
    /// <summary>
    /// A class to help generate secure passwords.
    /// </summary>
    public class PasswordGenerator{
        
        protected CharacterGenerator characterGenerator;
        protected SecureRandom secureRandom;

        public PasswordGenerator()
        {
            characterGenerator = new CharacterGenerator();
            secureRandom = new SecureRandom();
        }

        /// <summary>
        /// Create a salt
        /// This method may be changed substantially in the future.
        /// </summary>
        /// <returns></returns>
        public byte[] GenerateSalt()
        {
            return new SecureRNGWrapper().NextByteArray(16);
        }

        /// <summary>
        /// Generate a new password based on the requirements of the password as specified by the parameters.
        /// </summary>
        /// <param name="passwordLength"></param>
        /// <param name="includeUpperCase"></param>
        /// <param name="includeNumbers"></param>
        /// <param name="includeSpecialCharacters"></param>
        /// <returns></returns>
        public string GeneratePassword(int passwordLength, bool includeUpperCase, bool includeNumbers, bool includeSpecialCharacters){
            int maxUpper = 0;
            int maxNumbers = 0;
            int maxSpecial = 0;

            if (includeUpperCase)
            {
                maxUpper = secureRandom.NextInt(1, Convert.ToInt32( 0.25 * passwordLength));
            }
            if (includeNumbers)
            {
                maxNumbers = secureRandom.NextInt(1, Convert.ToInt32(0.25 * passwordLength));
            }
            if (includeSpecialCharacters)
            {
                maxSpecial = secureRandom.NextInt(1, Convert.ToInt32(0.25 * passwordLength));
            }

            return GeneratePassword(passwordLength, maxUpper, maxNumbers, maxSpecial);
        }

        /// <summary>
        /// Generate a new password based on the requirements of the password as specified by the parameters.
        /// </summary>
        /// <param name="passwordLength"></param>
        /// <param name="numberOfUpperCaseToInclude"></param>
        /// <param name="numberOfNumbersToInclude"></param>
        /// <param name="numberOfSpecialCharactersToInclude"></param>
        /// <returns></returns>
        public string GeneratePassword(int passwordLength, int numberOfUpperCaseToInclude, int numberOfNumbersToInclude, int numberOfSpecialCharactersToInclude) {
            string password = "";

            if ((numberOfNumbersToInclude + numberOfSpecialCharactersToInclude + numberOfUpperCaseToInclude) > passwordLength){
                throw new ArgumentOutOfRangeException();
            }

            // Do some validation
            if ((numberOfNumbersToInclude < 0) || (numberOfNumbersToInclude > passwordLength) ||
                (numberOfSpecialCharactersToInclude < 0) || (numberOfSpecialCharactersToInclude > passwordLength) ||
                (numberOfUpperCaseToInclude < 0) || (numberOfUpperCaseToInclude > passwordLength))
            {
                throw new ArgumentOutOfRangeException();
            }

            bool includeNumbers = (numberOfNumbersToInclude > 0);
            bool includeUpperCase = (numberOfUpperCaseToInclude > 0);
            bool includeSpecialCharacters = (numberOfSpecialCharactersToInclude > 0);
            
            for (int i = 0; i < passwordLength; i++){
                password += characterGenerator.GenerateRandomCharacterToString(includeUpperCase, includeNumbers, includeSpecialCharacters);     
            }
            
            if(password.GetNumberOfNumbers() < numberOfNumbersToInclude){
               ReplaceCharsWithNumbers(password, (numberOfNumbersToInclude - password.GetNumberOfNumbers()));
            }

            if (password.GetNumberOfUpperCaseCharacters() < numberOfUpperCaseToInclude){
               ReplaceCharsWithUpperCaseLetters(password, (numberOfUpperCaseToInclude - password.GetNumberOfUpperCaseCharacters()));
            }

            if (password.GetNumberOfSpecialCharacters() < numberOfSpecialCharactersToInclude){
               ReplaceCharsWithSpecialChars(password, (numberOfSpecialCharactersToInclude - password.GetNumberOfSpecialCharacters()));
            }

            return password;
        }

        /// <summary>
        /// Add a lower case letter to the password if there aren't enough.
        /// </summary>
        /// <param name="existingWord"></param>
        /// <param name="numberOfLettersToChange"></param>
        /// <returns></returns>
        public string ReplaceCharsWithALowerCaseLetter(string existingWord, int numberOfLettersToChange)
        {
            string newPassword = "";
            char[] letters = existingWord.ToCharArray();
            int lettersChanges = 0;

            while (lettersChanges < numberOfLettersToChange)
            {
                for (int letterIndex = 0; letterIndex < existingWord.Length; letterIndex++)
                {
                    if (letters[letterIndex].IsCharacterALowerCaseLetter())
                    {
                        lettersChanges++;
                        newPassword += letters[letterIndex].ToString().ToLower();
                    }
                    else if (letters[letterIndex].IsCharacterAnUpperCaseLetter() &&
                             letters[letterIndex].IsCharacterALowerCaseLetter())
                    {
                        lettersChanges++;
                        newPassword += characterGenerator.GenerateRandomLowerCaseCharacterToString();
                    }
                    else
                    {
                        newPassword += letters[letterIndex].ToString();
                    }
                }
            }

            return newPassword;
        }

        /// <summary>
        /// Add upper case letters to the password if there aren't enough.
        /// </summary>
        /// <param name="existingWord"></param>
        /// <param name="numberOfLettersToChange"></param>
        /// <returns></returns>
        public string ReplaceCharsWithUpperCaseLetters(string existingWord, int numberOfLettersToChange){
            string newPassword = "";
            char[] letters = existingWord.ToCharArray();
            int lettersChanges = 0;

            while (lettersChanges < numberOfLettersToChange)
            {
                for (int letterIndex = 0; letterIndex < existingWord.Length; letterIndex++)
                {
                    if (letters[letterIndex].IsCharacterAnUpperCaseLetter())
                    {
                        lettersChanges++;
                        newPassword += letters[letterIndex].ToString().ToUpper();
                    }
                    else if (letters[letterIndex].IsCharacterAnUpperCaseLetter() &&
                             letters[letterIndex].IsCharacterALowerCaseLetter())
                    {
                        lettersChanges++;
                        newPassword += characterGenerator.GenerateRandomUpperCaseCharacterToString();
                    }
                    else
                    {
                        newPassword += letters[letterIndex].ToString();
                    }
                }
            }

            return newPassword;
        }

        /// <summary>
        /// Add numbers to the password if there aren't enough.
        /// </summary>
        /// <param name="existingWord"></param>
        /// <param name="numberOfLettersToChange"></param>
        /// <returns></returns>
        public string ReplaceCharsWithNumbers(string existingWord, int numberOfLettersToChange){
            string newPassword = "";
            char[] letters = existingWord.ToCharArray();
            int lettersChanges = 0;

            while (lettersChanges < numberOfLettersToChange)
            {
                for (int letterIndex = 0; letterIndex < existingWord.Length; letterIndex++)
                {
                    if (letters[letterIndex].IsCharacterANumber())
                    {
                        lettersChanges++;
                        newPassword += characterGenerator.GenerateRandomNumberCharacterToString();
                    }
                    else
                    {
                        newPassword += letters[letterIndex].ToString();
                    }
                }
            }

            return newPassword;
        }

        /// <summary>
        /// Add special characters to the password if there aren't enough.
        /// </summary>
        /// <param name="existingWord"></param>
        /// <param name="numberOfLettersToChange"></param>
        /// <returns></returns>
        public string ReplaceCharsWithSpecialChars(string existingWord, int numberOfLettersToChange){
            string newPassword = "";
            char[] letters = existingWord.ToCharArray();
            int lettersChanges = 0;

            while (lettersChanges < numberOfLettersToChange)
            {
                for (int letterIndex = 0; letterIndex < existingWord.Length; letterIndex++)
                {
                    if (!letters[letterIndex].IsCharacterASpecialCharacter())
                    {
                        lettersChanges++;
                        newPassword += characterGenerator.GenerateRandomSpecialCharacterToString();
                    }
                    else
                    {
                        newPassword += letters[letterIndex].ToString();
                    }
                }
            }

            return newPassword;
        }

        /// <summary>
        /// Generate a new password based on the requirements of the password as specified by the parameter and return this as a PasswordModel
        /// </summary>
        /// <param name="passwordLength"></param>
        /// <param name="numberOfUpperCaseToInclude"></param>
        /// <param name="numberOfNumbersToInclude"></param>
        /// <param name="numberOfSpecialCharactersToInclude"></param>
        /// <returns></returns>
        public PasswordModel GeneratePasswordToPasswordModel(int passwordLength, int numberOfUpperCaseToInclude, int numberOfNumbersToInclude, int numberOfSpecialCharactersToInclude){
            return new Models.PasswordModel(GeneratePassword(passwordLength, numberOfUpperCaseToInclude, numberOfNumbersToInclude, numberOfSpecialCharactersToInclude));
        }
    }
}