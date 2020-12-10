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
using OpenFrafsuallyLib.Calculators.Definition;
using OpenFrafsuallyLib.Models;

namespace OpenFrafsuallyLib.Calculators.Implementation
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
            return PercentileOf(percentage, frameTimes).FrameTimeMilliseconds;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="frameTimes"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public FrameTime PercentileOf(double percentage, FrameTime[] frameTimes)
        {
            if(percentage > 100){
                throw new Exception("Error: Inappropriate percentage value (over 100%) provided as parameter.");
            }
            if(percentage < 0){
                throw new Exception("Error: Inappropriate percentage value (less than 0%) provided as parameter.");
            }

            Array.Sort(frameTimes);
            
            //No rounding necessary cos Int32.
            //percentileIndex = Math.Round(percentileIndex, 0, MidpointRounding.ToEven);
            return frameTimes[Convert.ToInt32(percentage / 100) * frameTimes.Length];
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
    }
}