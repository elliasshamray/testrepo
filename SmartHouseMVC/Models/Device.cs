using System;
namespace Models.SmartHouseMVC
{
    [Serializable]
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Status { get; set; }
        public Device()
        { }

        public Device(string name, bool status = false)
        {
            Name = name;
            Status = status;
        }

        public void OnOff()
        {
            Status = !Status;
        }
    }
}