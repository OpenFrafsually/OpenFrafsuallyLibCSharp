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
using FrafsuallyLib.Calculators.Definition;

using FrafsuallyLib.Models;

namespace FrafsuallyLib.Calculators.Implementation
{
    /// <summary>
    /// A class to implement the IAverageFrameRateCalculator interface.
    /// </summary>
    public class AverageFrameRateCalculator : IAverageFrameRateCalculator
    {
        protected FrameTimeCalculator _frameTimeCalculator;

        /// <summary>
        /// 
        /// </summary>
        public AverageFrameRateCalculator()
        {
            _frameTimeCalculator = new FrameTimeCalculator();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        public double GetAverageFpsUsingGeometricMean(FrameTime[] frameTimes)
        {
            double average = 0.0;

            foreach(FrameTime frameTime in frameTimes)
            {
                var seconds = frameTime.TimeMilliseconds / 1000.0;

                average *= _frameTimeCalculator.CalculateFramesPerSecond(1, seconds);
            }
            
            return Math.Pow(average, (1.0 / Convert.ToDouble(frameTimes.Length)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        public double GetAverageFpsUsingArithmeticMean(FrameTime[] frameTimes)
        {
            double average = 0.0;
            
            foreach (FrameTime frameTime in frameTimes)
            {
                var seconds = frameTime.TimeMilliseconds / 1000.0;

                average += _frameTimeCalculator.CalculateFramesPerSecond(1, seconds);
            }

            return average / Convert.ToDouble(frameTimes.Length);
        }
        
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        public double CalculatePercentile(double percentage, FrameTime[] frameTimes)
        {
            if(!(percentage >= 0 && percentage <= 1.0) || (percentage >= 0 && percentage <= 100)){
                percentage = percentage / 100;
            }
            else if(percentage / 100 < 0){
                percentage = percentage * 100;
            }
            else if(percentage >= 100){
                throw new Exception("Error: Inappropriate percentage value (over 100%) provided as parameter.");
            }

            var auto = SortFrameTimesByPercentile(frameTimes);
            
            //No rounding necessary cos Int32.
            //percentileIndex = Math.Round(percentileIndex, 0, MidpointRounding.ToEven);
            return auto[Convert.ToInt32(percentage)].FrameTimeMilliseconds;
        }

        public AverageFrameRate FrameTimesToAverageFrameRate(FrameTime[] frameTimes)
        {
            AverageFrameRate averageFrameRate = new AverageFrameRate();

            foreach (FrameTime frameTime in frameTimes)
            {
                averageFrameRate.FrameTimes.Add(frameTime);
            }

            return averageFrameRate;
        }

        /// <summary>
        ///
        /// 
        /// </summary>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        public Dictionary<int, FrameTime> SortFrameTimesByPercentile(FrameTime[] frameTimes)
        {
            Dictionary<int, FrameTime> percentile = new Dictionary<int, FrameTime>();

            Array.Sort(frameTimes);
            
            int frameNumber = 0;

            foreach (FrameTime fr in frameTimes)
            {
                int percentileIndex = (Convert.ToInt32(frameNumber / frameTimes.Length) * frameTimes.Length);
                percentile.Add(percentileIndex, fr);
                frameNumber++;
            }

            return percentile;
        }
    }
}