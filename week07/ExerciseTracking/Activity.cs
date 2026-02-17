namespace ExerciseTracking
{
    public abstract class Activity(int minutes, string date)
    {
        // centralized shared unit constants
        protected const double _metersPerLap = 50.0;
        protected const double _metersPerKm = 1000.0;
        protected const double _kmToMiles = 0.62;
        protected const double _minsInHour = 60.0;

        // data needed for calculations and storage
        private readonly int _minutes = minutes;
        private readonly string _date = date;

        // expose a way to get Minutes and Date to the derived classes
        protected int Minutes => _minutes;
        protected string Date => _date;

        // provide abstract classes to allow the method to calculate
        // distance, speed, and pace based on the respective activity
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        /// <summary>
        /// Get the summary of the activity.
        /// </summary>
        /// <returns>A summary of the activity performed</returns>
        public virtual string GetSummary()
        {
            return $"{_date} {GetType().Name} ({_minutes} min) - " +
                $"Distance: {GetDistance():0.0} miles, " +
                $"Speed: {GetSpeed():0.0} mph, " +
                $"Pace: {GetPace():0.0} min per mile";
        }
    }
}