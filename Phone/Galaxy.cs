using System;
using System.Collections.Generic;

namespace Phone
{
    public class Galaxy : Phone, IRingable 
    {
    public Galaxy(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
        : base(versionNumber, batteryPercentage, carrier, ringTone) 
        {
            _versionNumber = versionNumber;
            _batteryPercentage = batteryPercentage;
            _carrier = carrier;
            _ringTone = ringTone;
        }
    public string Ring() 
        {
            string ring = "..." + _ringTone + "...";
            return ring;
        }
    public string Unlock() 
        {
            string unlock = "Galaxy " + _versionNumber + " unlocked with fingerprint scanner";
            return unlock;
        }
    public override void DisplayInfo() 
        {
            Console.WriteLine("#########################");
            Console.WriteLine("Galaxy " + _versionNumber);
            Console.WriteLine("Battery Percentage: " + _batteryPercentage);
            Console.WriteLine("Carrier: " + _carrier);
            Console.WriteLine("Ringtone " + _ringTone);
            Console.WriteLine("#########################");
            Console.WriteLine("");
        }
    }
}