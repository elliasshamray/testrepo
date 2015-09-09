using System;

namespace Models.SmartHouseMVC
{ 
    [Serializable]
    public class Heating : Device
    {
        public Heating()
        { }
        private byte temperatura;
        public byte Temperature
        {
            get
            {
                return temperatura;
            }
            set
            {
                if (value >= 0 && value <= 25)
                {
                    temperatura = value;
                }
            }
        }
        public Heating(string name, bool status = false, byte temperatura = 15)
            : base(name, status)
        {
            this.Status = status;
            this.Temperature = temperatura;
            this.Name = name;
        }

        public override string ToString()
        {
            string state;
            if (this.Status)
                state = "Включен";
            else
                state = "Выключен";
            return String.Format("Обогреватель {0} {1} температура {2}", this.Name, state, this.Temperature);
        }
    }
}