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

namespace PasswordKit.Models{

    /// <summary>
    /// 
    /// </summary>
    public class PasswordModel{

        public PasswordModel(string password){
            this.Password = password;
            DateGenerated = DateTime.Now;
        }

        public string Password { get; private set; }

        public DateTime DateGenerated { get; private set; }

        /// <summary>
        /// Checks to see if the password includes numbers.
        /// </summary>
        public bool IncludesNumbers => (Password.GetNumberOfNumbers() > 0);

        /// <summary>
        /// Checks to see if the password includes capitals
        /// </summary>
        public bool IncludesCapitals => (Password.GetNumberOfUpperCaseCharacters() > 0);

        /// <summary>
        /// Checks to see if the password includes special characters.
        /// </summary>
        public bool IncludesSpecialCharacters => (Password.GetNumberOfSpecialCharacters() > 0);
    }
}