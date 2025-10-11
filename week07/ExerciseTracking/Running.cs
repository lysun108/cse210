// Running.cs
// Subclass that stores distance directly and derives speed/pace.
// Author: Zhili Zhong (Yang Liao)
// Date: 2025-10-11

using System;

namespace ExerciseTracking
{
    public sealed class Running : Activity
    {
        private readonly double _miles;

        /// <param name="miles">Total distance in miles.</param>
        public Running(DateTime date, int minutes, double miles) : base(date, minutes)
        {
            if (miles <= 0)
                throw new ArgumentOutOfRangeException(nameof(miles), "Miles must be positive.");
            _miles = miles;
        }

        public override double GetDistance() => _miles;

        public override double GetSpeed() => (_miles / Minutes) * 60.0;

        public override double GetPace() => Minutes / _miles;
    }
}
