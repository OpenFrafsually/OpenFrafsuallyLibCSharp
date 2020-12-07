/*
MIT License

Copyright (c) 2020 AluminiumTech

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
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using FrafsuallyLib.DataSources.Definition;
using FrafsuallyLib.Models;

namespace FrafsuallyLib.DataSources.Implementation
{
    /// <summary>
    /// 
    /// </summary>
    public class CsvDataSourceProvider : ICsvDataSourceProvider
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pathToDataSource"></param>
        /// <param name="timeColumnName"></param>
        /// <param name="frameNumberColumnName"></param>
        /// <returns></returns>
        public FrameTime[] GetDataFromColumns(string pathToDataSource, string timeColumnName, string frameNumberColumnName)
        {
            try
            {
                List<FrameTime> frameTimes = new List<FrameTime>();
            
                double previousTime = 0.0;
            
                using var reader = new StreamReader(pathToDataSource);
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Read();
                    csv.ReadHeader();
                    while (csv.Read())
                    {
                        var currentTime = csv.GetField<double>(timeColumnName);
                        var frameNumber = csv.GetField<long>(frameNumberColumnName);

                        FrameTime frameTime = new FrameTime
                        {
                            FrameNumber = frameNumber,
                            StartTimeMilliseconds = previousTime,
                            EndTimeMilliseconds = currentTime
                        };

                        previousTime = currentTime;
                    
                        frameTimes.Add(frameTime);
                    }
                }

                return frameTimes.ToArray();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.ToString());
            }
        }
    }
}