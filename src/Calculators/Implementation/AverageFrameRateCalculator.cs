/*
    Copyright (C) 2020 AluminiumTech

    This library is free software; you can redistribute it and/or
    modify it under the terms of the GNU Lesser General Public
    License as published by the Free Software Foundation; either
    version 2.1 of the License, or (at your option) any later version.

    This library is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
    Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public
    License along with this library; if not, write to the Free Software
    Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301
    USA
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
                int percentileIndex = (Convert.ToInt32(frameNumber / frameTimes.Length) * 100);
                percentile.Add(percentileIndex, fr);
                frameNumber++;
            }

            return percentile;
        }
    }
}