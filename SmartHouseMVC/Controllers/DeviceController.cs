using Models.SmartHouseMVC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartHouseMVC.Controllers
{
    public class DeviceController : Controller
    {
        //
        // GET: /Main/
        Device d;

        DevicesContext dc = new DevicesContext();

        [HttpGet]
        public ActionResult Index()
        {
           // dc = new DevicesContext();
            
            return View(dc);
        }

        [HttpPost]
        public ActionResult Index(string addName, string addDev)
        {
           // dc = new DevicesContext();
            if (addName != "" && addDev != "")
            {
                if (addDev == "Светильник")
                {
                    dc.lamps.Add(new Lamp(addName));
                }
                else if (addDev == "Обогрев")
                {
                    dc.heatings.Add(new Heating(addName));
                }

                else if (addDev == "Телевизор")
                {
                    dc.tvsets.Add(new TV(addName));
                }

                else if (addDev == "Бойлер")
                {
                    dc.boilers.Add(new Boiler(addName));
                }

                else if (addDev == "Жалюзи")
                {
                    dc.louvers.Add(new Louvers(addName));
                }
            }
            dc.SaveChanges();
            return View(dc);
        }
        public ActionResult OnOff(int id, string type, Device d)
        {
          //  dc = new DevicesContext();
            if (typeof(Lamp).ToString() == type)
            {
                dc.lamps.Find(id).OnOff();
            }
            else if (typeof(Heating).ToString() == type)
            {
                dc.heatings.Find(id).OnOff();
            }
            else if (typeof(TV).ToString() == type)
            {
                dc.tvsets.Find(id).OnOff();
            }
            else if (typeof(Boiler).ToString() == type)
            {
                dc.boilers.Find(id).OnOff();
            }
            else if (typeof(Louvers).ToString() == type)
            {
                dc.louvers.Find(id).OnOff();
            }
            dc.SaveChanges();
            return RedirectToAction("Index");// Redirect("~/Device/Index");
        }

        public ActionResult Delete(int id, string type)
        {
          //  dc = new DevicesContext();
            if (typeof(Lamp).ToString() == type)
            {
                d = dc.lamps.Find(id);
                dc.lamps.Remove((Lamp)d);
            }
            else if (typeof(Heating).ToString() == type)
            {
                d = dc.heatings.Find(id);
                dc.heatings.Remove((Heating)d);
            }
            else if (typeof(TV).ToString() == type)
            {
                d = dc.tvsets.Find(id);
                dc.tvsets.Remove((TV)d);
            }
            else if (typeof(Boiler).ToString() == type)
            {
                d = dc.boilers.Find(id);
                dc.boilers.Remove((Boiler)d);
            }
            else if (typeof(Louvers).ToString() == type)
            {
                d = dc.louvers.Find(id);
                dc.louvers.Remove((Louvers)d);
            }
            dc.SaveChanges();
            return Redirect("Index");
        }


        public ActionResult Edit(int id, string type)
        {
           // dc = new DevicesContext();
            if (typeof(Heating).ToString() == type)
            {
                d = dc.heatings.Find(id);
            }
            else if (typeof(TV).ToString() == type)
            {
                d = dc.tvsets.Find(id);
            }
            else if (typeof(Boiler).ToString() == type)
            {
                d = dc.boilers.Find(id);
            }
            else if (typeof(Louvers).ToString() == type)
            {
                d = dc.louvers.Find(id);
            }
            else
            {
                d = dc.lamps.Find(id);
            }
            return View(d);
        }

        [HttpPost]
        public ActionResult Edit(int id, string TypeDev, string Com)
        {
           // dc = new DevicesContext();
            if (typeof(Heating).ToString() == TypeDev)
            {
                Heating h = dc.heatings.Find(id);
                if (Com == "+")
                    h.Temperature += 1;
                else if (Com == "-")
                    h.Temperature -= 1;
                else if (Com == "Вкл/Выкл")
                    h.OnOff();
                dc.Entry(h).State = EntityState.Modified;
                dc.SaveChanges();
                return View(h);
            }
            else if (typeof(TV).ToString() == TypeDev)
            {
                TV tv = dc.tvsets.Find(id);
                tv.tvsettings.tv = tv;
                if (Com == "Вкл/Выкл")
                    tv.OnOff();
                else if (tv.Status)
                {
                    if (Com == "Громкость+")
                        tv.tvsettings.AddVolume();

                    else if (Com == "Громкость-")
                        tv.tvsettings.SubVolume();

                    else if (Com == "Резкость+")
                        tv.tvsettings.AddAbruptness();

                    else if (Com == "Резкость-")
                        tv.tvsettings.SubAbruptness();

                    else if (Com == "Контраст+")
                        tv.tvsettings.AddContrast();

                    else if (Com == "Контраст-")
                        tv.tvsettings.SubContrast();

                    else if (Com == "<-")
                        tv.PreviousChannel();

                    else if (Com == "->")
                        tv.NextChannel();
                }
                else ViewBag.Error = "Телевизор не включен";
                dc.Entry(tv).State = EntityState.Modified;
                dc.SaveChanges();
                return View(tv);
            }
            else if (typeof(Boiler).ToString() == TypeDev)
            {
                Boiler b = dc.boilers.Find(id);
                if (Com == "Вкл/Выкл")
                    b.OnOff();
                else if (b.Status)
                {
                    if (Com == "Наполнить")
                    {
                        b.MakeFull();
                    }

                    else if (Com == "Закипетить")
                    {
                        b.MakeBoils();
                    }
                    else if (Com == "Слить Воду")
                    {
                        b.MakeEmpty();
                    }
                }
                else ViewBag.Error = "Бойлер не включен";
                dc.Entry(b).State = EntityState.Modified;
                dc.SaveChanges();
                return View(b);
            }
            else
            {
                Louvers l = dc.louvers.Find(id);
                if (Com == "Вкл/Выкл")
                    l.OnOff();
                else if (l.Status)
                {
                    if (Com == "Угол+")
                    {
                        l.AngelUp();
                    }

                    else if (Com == "Угол-")
                    {
                        l.AngelDown();
                    }
                    else if (Com == "Поднять/Опустить")
                    {
                        l.LowerUp();
                    }
                }
                else ViewBag.Error = "Жалюзи не включены";
                dc.Entry(l).State = EntityState.Modified;
                dc.SaveChanges();
                return View(l);
            }


        }
    }
}
