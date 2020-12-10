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

using FrafsuallyLib.Calculators.Implementation;

using FrafsuallyLib.Models.Definition;

namespace FrafsuallyLib.Models.Implementation
{
    /// <summary>
    /// A class to manage groups of frametimes.
    /// </summary>
    public class FrameTimes : IFrameTimes
    {
        public List<FrameTime> frameTimes { get; set; }

        protected FrameTimeCalculator _frameTimeCalculator;
        
        
        public int NumberOfFrames => frameTimes.Count;

        /// <summary>
        /// 1.0% Lows Frame rates
        /// </summary>
        public double OnePercentLowsFps => CalculatePercentileFps(1.0);
        
        /// <summary>
        /// 0.1% Lows Frame rates
        /// </summary>
        public double ZeroPointOnePercentLowsFps => CalculatePercentileFps(0.1);

        /// <summary>
        /// 25% Percentile Frame rates
        /// </summary>
        public double LowerQuartileFps => CalculatePercentileFps(25.0);
        
        /// <summary>
        /// 50% Percentile Frame rates
        /// </summary>
        public double MedianFps => CalculatePercentileFps(50.0);
        
        /// <summary>
        /// 75% Percentile Frame rates
        /// </summary>
        public double UpperQuartileFps => CalculatePercentileFps(75.0);
        
        public FrameTimes()
        {
            frameTimes = new List<FrameTime>();
            
            _frameTimeCalculator = new FrameTimeCalculator();
        }

        public FrameTimes(FrameTime[] frameTimesArray)
        {
            Add(frameTimesArray);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimesArray"></param>
        public void Add(FrameTime[] frameTimesArray)
        {
            foreach (FrameTime frameTime in frameTimesArray)
            {
               frameTimes.Add(frameTime);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimesList"></param>
        public void Add(List<FrameTime> frameTimesList)
        {
            Add(frameTimes.ToArray());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimesArray"></param>
        public void Remove(FrameTime[] frameTimesArray)
        {
            for (int index = 0; index < frameTimesArray.Length; index++)
            {
                this.frameTimes.Remove(frameTimesArray[index]);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frameTimesList"></param>
        public void Remove(List<FrameTime> frameTimesList)
        {
            Remove(frameTimes.ToArray());
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<FrameTime> ToList()
        {
            return frameTimes;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public FrameTime[] ToArray()
        {
            return frameTimes.ToArray();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetAverageFpsUsingGeometricMean()
        {
            double average = 0.0;

            foreach(FrameTime frameTime in frameTimes)
            {
                var seconds = frameTime.TimeMilliseconds / 1000.0;

                average *= _frameTimeCalculator.CalculateFramesPerSecond(1, seconds);
            }
            
            return Math.Pow(average, (1.0 / Convert.ToDouble(frameTimes.Count)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public double GetAverageFpsUsingArithmeticMean()
        {
            double average = 0.0;
            
            foreach (FrameTime frameTime in frameTimes)
            {
                var seconds = frameTime.TimeMilliseconds / 1000.0;

                average += _frameTimeCalculator.CalculateFramesPerSecond(1, seconds);
            }

            return average / Convert.ToDouble(frameTimes.Count);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public double CalculatePercentileFps(double percentage)
        {
            return PercentileOf(percentage).FrameTimeMilliseconds;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public FrameTime PercentileOf(double percentage)
        {
            if(percentage > 100){
                throw new Exception("Error: Inappropriate percentage value (over 100%) provided as parameter.");
            }
            if(percentage < 0){
                throw new Exception("Error: Inappropriate percentage value (less than 0%) provided as parameter.");
            }

            Array.Sort(frameTimes.ToArray());
            
            //No rounding necessary cos Int32.
            //percentileIndex = Math.Round(percentileIndex, 0, MidpointRounding.ToEven);
            return frameTimes[Convert.ToInt32(percentage / 100) * frameTimes.ToArray().Length];
        }
    }
}