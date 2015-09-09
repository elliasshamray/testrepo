using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Models.SmartHouseMVC
{
    public class DevicesDbInitializer : DropCreateDatabaseAlways<DevicesContext>
    {
        protected override void Seed(DevicesContext dc)
        {
            dc.heatings.Add(new Heating("Зал", true, 13));
            dc.heatings.Add(new Heating("Кухня", false, 15));
            dc.heatings.Add(new Heating("Спальня", false, 18));
            dc.heatings.Add(new Heating("Коридор", false, 21));

            dc.lamps.Add(new Lamp("Зал", true));
            dc.lamps.Add(new Lamp("Кухня", false));
            dc.lamps.Add(new Lamp("Спальня", false));
            dc.lamps.Add(new Lamp("Коридор", false));

            dc.tvsets.Add(new TV("Sony KDL-32W503A", Channels.FOX, true, 5, 5, 5));
            dc.tvsets.Add(new TV("Samsung JS9500", Channels.ICTV, true, 6, 7, 4));
            dc.tvsets.Add(new TV("Sony KDL-42W705B", Channels.УТ1, true, 6, 7, 4));
            dc.tvsets.Add(new TV("Samsung JS8500", Channels.Украина, true, 6, 7, 4));

            dc.boilers.Add(new Boiler("1"));
            dc.boilers.Add(new Boiler("2"));
            dc.boilers.Add(new Boiler("3"));
            dc.boilers.Add(new Boiler("4"));

            dc.louvers.Add(new Louvers("Зал"));
            dc.louvers.Add(new Louvers("Кухня"));
            dc.louvers.Add(new Louvers("Спальня"));
            dc.louvers.Add(new Louvers("Коридор"));

            dc.SaveChanges();

        }
    }
}