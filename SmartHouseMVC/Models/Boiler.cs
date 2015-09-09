using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.SmartHouseMVC
{
    [Serializable]
    public class Boiler : Device
    {
        public bool isFull{get;set;}
        public bool isBoils{get;set;}
        public Boiler()
        { }
        public Boiler(string name, bool status = false, bool isFull = false,bool isBoils = false)
            : base(name, status)
        {
            this.Status = status;
            this.Name = name;
            this.isFull = isFull;
            this.isBoils = isBoils;
        }

        public void MakeFull()
        {
            if (!isFull)
            {
                isFull = true;
            }
        }

        public void MakeEmpty()
        {
            if (isFull)
            {
                isFull = false;
                isBoils = false;
            }
        }

        public void MakeBoils()
        {
            if (isFull && Status)
            {
                isBoils = true;
            }
        }
        
        public override string ToString()
        {
            string state = "Бойлер " + Name + " ";
            
            if (this.Status)
                state += "Включен";
            else
                state += "Выключен";
            if (isFull)
                state += " Наполнен ";
            else
            {
                state += " Пустой ";
                return state;
            }
            if (isBoils)
                state += "Кипеток ";
            else
                state += "Не кипеток";
            return state;
        }
    }
}