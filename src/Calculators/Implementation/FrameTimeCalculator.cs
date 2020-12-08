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

using FrafsuallyLib.Calculators.Definition;

namespace FrafsuallyLib.Calculators.Implementation
{
    /// <summary>
    /// A class to implement the IFrameTimeCalculator interface.
    /// </summary>
    public class FrameTimeCalculator : IFrameTimeCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fps"></param>
        /// <returns></returns>
        public double CalculateSecondsPerFrame(double fps)
        {
            return (1.0 / fps);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public double CalculateSecondsPerFrame(long frames, double seconds)
        {
            var framesToDouble = Convert.ToDouble(frames);

            return (seconds / framesToDouble);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public double CalculateFramesPerSecond(long frames, double seconds)
        {
            var framesToDouble = Convert.ToDouble(frames);

            return (framesToDouble / seconds);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frametimes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public double CalculateFramesPerSecondWithFrameTimes(double frametimes, double seconds)
        {
            return ((seconds * 1000.0) / frametimes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fps"></param>
        /// <returns></returns>
        public double CalculateFrameTimesMilliseconds(double fps)
        {
            return (1000.0 / fps);
        }
    }
}