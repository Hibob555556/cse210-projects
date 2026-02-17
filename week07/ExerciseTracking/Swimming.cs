namespace ExerciseTracking
{
    public class Swimming(int minutes, string date, int laps) : Activity(minutes, date)
    {
        private readonly int _laps = laps;

        /// <summary>
        /// Convert kilometers to miles
        /// </summary>
        /// <param name="km">distance traveled in kilometers</param>
        /// <returns>distance traveled in miles</returns>
        private static double GetMiles(double km) => km * _kmToMiles;

        /// <summary>
        /// Get distance in miles
        /// </summary>
        /// <returns>Distance traveled in miles</returns>
        public override double GetDistance()
        {
            double kilometers = _laps * _metersPerLap / _metersPerKm;
            return GetMiles(kilometers);
        }

        /// <summary>
        /// Get speed in miles per hour
        /// </summary>
        /// <returns>Speed in miles per hour</returns>
        public override double GetSpeed()
        {
            return GetDistance() / Minutes * _minsInHour;
        }

        /// <summary>
        /// Get pace in minutes per mile
        /// </summary>
        /// <returns>Pace in minutes per mile</returns>
        public override double GetPace()
        {
            return Minutes / GetDistance();
        }
    }
}