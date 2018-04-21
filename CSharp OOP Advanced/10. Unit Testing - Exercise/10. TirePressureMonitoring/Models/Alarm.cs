namespace _10.TirePressureMonitoring.Models
{
    public class Alarm
    {
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;

        private readonly Sensor _sensor = new Sensor();

        bool _alarmOn = false;

        public bool AlarmOn
        {
            get { return this._alarmOn; }
        }

        public void Check()
        {
            double psiPressureValue = this._sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                this._alarmOn = true;
            }
        }
    }
}
