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

using System.Collections.Generic;

using FrafsuallyLib.Calculators.Implementation;

namespace FrafsuallyLib.Models
{
    /// <summary>
    ///  A class to model average frame rates made up from a number of frametimes.
    /// </summary>
    public class AverageFrameRate
    {
        protected AverageFrameRateCalculator _averageFrameRateCalculator;

        public AverageFrameRate()
        {
            _averageFrameRateCalculator = new AverageFrameRateCalculator();
        }

        /// <summary>
        /// Calculate average framerate using the Arithmetic Mean.
        /// </summary>
        public double ArithmeticMeanAverageFps => _averageFrameRateCalculator.GetAverageFpsUsingArithmeticMean(FrameTimesToArray);
        
        /// <summary>
        /// Calculate average framerate using the Geometric Mean.
        /// </summary>
        public double GeometricMeanAverageFps => _averageFrameRateCalculator.GetAverageFpsUsingGeometricMean(FrameTimesToArray);
        
        
        /// <summary>
        /// 1.0% Percentile Frame rates
        /// </summary>
        public double OnePercentLows => _averageFrameRateCalculator.CalculatePercentile(1.0, FrameTimesToArray);
        
        /// <summary>
        /// 0.1% Percentile Frame rates
        /// </summary>
        public double ZeroPointOnePercentLows => _averageFrameRateCalculator.CalculatePercentile(0.1, FrameTimesToArray);

        
        
        /// <summary>
        /// 25% Percentile Frame rates
        /// </summary>
        public double LowerQuartileFps => _averageFrameRateCalculator.CalculatePercentile(25.0, FrameTimesToArray);
        
        /// <summary>
        /// 50% Percentile Frame rates
        /// </summary>
        public double MedianFps => _averageFrameRateCalculator.CalculatePercentile(50.0, FrameTimesToArray);

        
        /// <summary>
        /// 75% Percentile Frame rates
        /// </summary>
        public double UpperQuartileFps => _averageFrameRateCalculator.CalculatePercentile(75.0, FrameTimesToArray);
        
        /// <summary>
        /// 
        /// </summary>
        public FrameTime[] FrameTimesToArray => FrameTimes.ToArray();
        
        public List<FrameTime> FrameTimes { get; set; }

        public int NumberOfFrames => FrameTimes.Count;
    }
}