using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.SmartHouseMVC
{
    [Serializable]
    public class Louvers : Device
    {
        public bool isLower { get; set; }
        private byte angle;
        public byte Angel 
        { 
            get 
            {
                return angle;
            }
            set 
            {
                if (value >= 0 && value <= 180)
                {
                    angle = value;
                }
            } 
        }
        public Louvers()
        { }
        public Louvers(string name, bool status = false, bool isLower = false, byte angle = 90)
            : base(name, status)
        {
            this.Status = status;
            this.Name = name;
            this.isLower = isLower;
            this.Angel = angle;
        }

        public void LowerUp()
        {
            if (isLower)
                isLower = false;
            else
                isLower = true;
        }

        public void AngelUp()
        {
            Angel++;
        }

        public void AngelDown()
        {
            Angel--;
        }

        public override string ToString()
        {
            string state = "Жалюзи " + this.Name + " ";
            if (this.Status)
                state += "Включены";
            else
                state += "Выключены";

            if (isLower)
                state += " Опущены ";
            else
                state += " Подняты ";
            state += " под углом  " + this.Angel;
            return state;
        }
    }
}