using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.SmartHouseMVC
{
    public struct TVSettings
    {
        public TV tv;
        public void AddVolume()
        {
            tv.Volume += 1;
        }

        public void AddContrast()
        {
            tv.Contrast += 1;
        }

        public void AddAbruptness()
        {
            tv.Abruptness += 1;
        }

        public void SubVolume()
        {
            tv.Volume -= 1;
        }

        public void SubContrast()
        {
            tv.Contrast -= 1;
        }

        public void SubAbruptness()
        {
            tv.Abruptness -= 1;
        }
    }
}