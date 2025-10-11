// Cycling.cs
// Subclass that stores speed (mph) and derives distance/pace.
// Author: Yang Liao
// Date: 2025-10-11

using System;

namespace ExerciseTracking
{
    public sealed class Cycling : Activity
    {
        private readonly double _mph;

        /// <param name="mph">Average speed in miles per hour.</param>
        public Cycling(DateTime date, int minutes, double mph) : base(date, minutes)
        {
            if (mph <= 0)
                throw new ArgumentOutOfRangeException(nameof(mph), "Speed must be positive.");
            _mph = mph;
        }

        public override double GetDistance() => _mph * Minutes / 60.0;

        public override double GetSpeed() => _mph;

        public override double GetPace() => 60.0 / _mph;
    }
}
