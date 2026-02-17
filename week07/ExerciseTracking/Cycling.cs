namespace ExerciseTracking
{
    public class Cycling(int minutes, string date, double speed) : Activity(minutes, date)
    {
        private readonly double _speed = speed;

        /// <summary>
        /// Get the speed at which the user was cycling
        /// </summary>
        /// <returns>Speed at which the user was cycling</returns>
        public override double GetSpeed() => _speed;

        /// <summary>
        /// Get the distance traveled 
        /// </summary>
        /// <returns>distance traveled</returns>
        public override double GetDistance()
        {
            return GetSpeed() * (Minutes / _minsInHour);
        }

        /// <summary>
        /// Get pace in minutes per mile. 
        /// </summary>
        /// <returns>The pace traveled in minutes per mile</returns>
        public override double GetPace()
        {
            return _minsInHour / GetSpeed();
        }
    }
}