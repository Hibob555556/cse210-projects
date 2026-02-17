using System.Diagnostics;
namespace ExerciseTracking
{
    public class Running(int minutes, string date, double distance) : Activity(minutes, date)
    {
        private readonly double _dist = distance;

        public override double GetDistance()
        {
            return _dist;
        }

        /// <summary>
        /// Get the pace in minutes per mile
        /// </summary>
        /// <returns>The pace in minutes per mile.</returns>
        public override double GetPace()
        {
            return Minutes / GetDistance();
        }

        /// <summary>
        /// Get the speed in miles per hour
        /// </summary>
        /// <returns>The speed in miles per hour.</returns>
        public override double GetSpeed()
        {
            return (GetDistance() / Minutes) * 60;
        }
    }
}