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
using PasswordKit.Generation;

namespace PasswordKit.Test{
    class Program{

        static void Main(string[] args){
            PasswordGenerator generator = new PasswordGenerator();
            
            Console.WriteLine("                                                   ");

            Console.WriteLine(generator.GeneratePassword(16, 0, 0, 0));
            Console.WriteLine(generator.GeneratePassword(32, 10, 6, 4));

            Console.WriteLine(generator.GeneratePassword(32, 0, 0, 0));
            Console.WriteLine(generator.GeneratePassword(32, true, false, false));
            Console.WriteLine(generator.GeneratePassword(64, true, false, false));

            Console.WriteLine(generator.GeneratePassword(32, true, true, true));
            Console.WriteLine(generator.GeneratePassword(64, true, true, true));

            Console.WriteLine("                                                   ");

            Console.WriteLine(generator.GeneratePassword(16, 3, 5, 5));
            
            Console.WriteLine(generator.GeneratePassword(128, true, true, true));
            Console.WriteLine(generator.GeneratePassword(256, true, true, true));
            Console.WriteLine(generator.GeneratePassword(512, true, true, true));

            Console.WriteLine("Finished Test");

            Console.ReadLine();
        }
    }
}