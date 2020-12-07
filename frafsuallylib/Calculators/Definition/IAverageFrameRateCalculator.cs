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

using FrafsuallyLib.Models;

namespace FrafsuallyLib.Calculators.Definition
{
    /// <summary>
    /// An interface to describe what types of calculations need to be performed on AverageFrameRate. 
    /// </summary>
    public interface IAverageFrameRateCalculator
    {   
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        public double GetAverageFpsUsingGeometricMean(FrameTime[] frameTimes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        public double GetAverageFpsUsingArithmeticMean(FrameTime[] frameTimes);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        public double CalculatePercentile(double percentage, FrameTime[] frameTimes);

        public AverageFrameRate FrameTimesToAverageFrameRate(FrameTime[] frameTimes);
    }
}