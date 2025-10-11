// Activity.cs
// CSE 210 - Week07 Final Foundation: Inheritance & Polymorphism
// Core base class for all activities.
// Author: Zhili Zhong (Yang Liao)
// Date: 2025-10-11

using System;

namespace ExerciseTracking
{
    /// <summary>
    /// Abstract base class representing a generic activity.
    /// Shared data and behavior go here; subclasses override calculation methods.
    /// </summary>
    public abstract class Activity
    {
        private readonly DateTime _date;
        private readonly int _minutes;

        protected Activity(DateTime date, int minutes)
        {
            if (minutes <= 0)
                throw new ArgumentOutOfRangeException(nameof(minutes), "Minutes must be positive.");
            _date = date;
            _minutes = minutes;
        }

        /// <summary>Date of the activity.</summary>
        public DateTime Date => _date;

        /// <summary>Duration in minutes.</summary>
        public int Minutes => _minutes;

        // --- Units policy (consistent across program) ---
        // Distance: miles
        // Speed: miles per hour (mph)
        // Pace: minutes per mile

        /// <summary>Returns the total distance in miles.</summary>
        public abstract double GetDistance();

        /// <summary>Returns the average speed in miles per hour.</summary>
        public abstract double GetSpeed();

        /// <summary>Returns the pace in minutes per mile.</summary>
        public abstract double GetPace();

        /// <summary>
        /// Returns a formatted one-line summary that leverages polymorphism:
        /// Calls subclass overrides for distance/speed/pace.
        /// </summary>
        public virtual string GetSummary()
        {
            // Example: "03 Oct 2025 Running (30 min) - Distance 3.0 miles, Speed 6.0 mph, Pace 5.00 min/mi"
            return $"{Date:dd MMM yyyy} {GetType().Name} ({Minutes} min) - " +
                   $"Distance {GetDistance():0.0} miles, " +
                   $"Speed {GetSpeed():0.0} mph, " +
                   $"Pace {GetPace():0.00} min/mi";
        }
    }
}
