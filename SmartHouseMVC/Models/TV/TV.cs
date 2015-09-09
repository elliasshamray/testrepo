using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.SmartHouseMVC
{
    public class TV : Device
    {

        public Channels channel { get; set; }
        private byte volume;
        private byte contrast;
        private byte abruptness;

        public byte Volume
        {
            get
            {
                return volume;
            }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    volume = value;
                }
            }
        }
        public byte Contrast
        {
            get
            {
                return contrast;
            }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    contrast = value;
                }
            }
        }
        public byte Abruptness
        {
            get
            {
                return abruptness;
            }
            set
            {
                if (value >= 0 && value <= 50)
                {
                    abruptness = value;
                }
            }
        }
        public TVSettings tvsettings;
        public TV()
        { }
        public TV(string name, Channels channel = Channels.Discovery, bool status = false, byte volume = 0, byte contrast = 0, byte abruptness = 0 )
            : base(name, status)
        {
            this.Name = name;
            this.Status = status;
            this.channel = channel;
            this.Volume = volume;
            this.Abruptness = abruptness;
            this.Contrast = contrast;
        }

        public void NextChannel()
        {
            if ((int)channel < Enum.GetValues(typeof(Channels)).Length - 1)
            {
                channel++;
            }
        }


        public void PreviousChannel()
        {
            if ((int)channel > 0)
            {
                channel--;
            }
        }
        public override string ToString()
        {
            string state;
            if (this.Status)
                state = "Включен";
            else
                state = "Выключен";
            return String.Format("Телевизор {0}, {1} ,Канал: {2} ,Громкость: {3}, Контраст: {4} ,Резкость: {5}",
                this.Name,
                state,
                (int)this.channel + 1 + " " + this.channel,
                this.Volume,
                this.Contrast,
                this.Abruptness);
        }
    }
}