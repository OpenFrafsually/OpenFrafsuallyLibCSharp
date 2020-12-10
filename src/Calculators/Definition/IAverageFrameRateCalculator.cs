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

using OpenFrafsuallyLib.Models;

namespace OpenFrafsuallyLib.Calculators.Definition
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

        public FrameTime PercentileOf(double percentage, FrameTime[] frameTimes);
        
        public AverageFrameRate FrameTimesToAverageFrameRate(FrameTime[] frameTimes);

        

    }
}