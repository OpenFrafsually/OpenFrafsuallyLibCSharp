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

using System.Collections.Generic;
using OpenFrafsuallyLib.Calculators.Implementation;

namespace OpenFrafsuallyLib.Models
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