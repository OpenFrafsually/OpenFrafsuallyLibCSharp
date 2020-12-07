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