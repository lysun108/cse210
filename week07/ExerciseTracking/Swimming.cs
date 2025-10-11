// Swimming.cs
// Subclass that stores lap count (50m per lap) and converts to miles.
// Author: Zhili Zhong (Yang Liao)
// Date: 2025-10-11

using System;

namespace ExerciseTracking
{
    public sealed class Swimming : Activity
    {
        private readonly int _laps;

        // Constant conversion: 50 meters per lap to miles.
        // 1 mile = 1609.344 meters -> 50 / 1609.344 = 0.0310685596119 miles
        private const double MilesPerLap50m = 50.0 / 1609.344;

        /// <param name="laps">Number of 50-meter pool laps.</param>
        public Swimming(DateTime date, int minutes, int laps) : base(date, minutes)
        {
            if (laps <= 0)
                throw new ArgumentOutOfRangeException(nameof(laps), "Laps must be positive.");
            _laps = laps;
        }

        public override double GetDistance() => _laps * MilesPerLap50m;

        public override double GetSpeed() => (GetDistance() / Minutes) * 60.0;

        public override double GetPace() => Minutes / GetDistance();
    }
}
