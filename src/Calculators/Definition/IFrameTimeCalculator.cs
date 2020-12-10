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

namespace OpenFrafsuallyLib.Calculators.Definition
{
    /// <summary>
    /// An interface to describe what types of calculations need to be performed on FrameTime. 
    /// </summary>
    public interface IFrameTimeCalculator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fps"></param>
        /// <returns></returns>
        public double CalculateSecondsPerFrame(double fps);
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public double CalculateSecondsPerFrame(long frames, double seconds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frames"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public double CalculateFramesPerSecond(long frames, double seconds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frametimes"></param>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public double CalculateFramesPerSecondWithFrameTimes(double frametimes, double seconds);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fps"></param>
        /// <returns></returns>
        public double CalculateFrameTimesMilliseconds(double fps);
    }
}