using System;
using System.Collections.Generic;

namespace Phone
{
    public class Nokia : Phone, IRingable 
    {
    public Nokia(string versionNumber, int batteryPercentage, string carrier, string ringTone) 
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
            string unlock = "Nokia " + _versionNumber + " unlocked with passcode";
            return unlock;
        }
    public override void DisplayInfo() 
        {
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("Nokia " + _versionNumber);
            Console.WriteLine("Battery Percentage: " + _batteryPercentage);
            Console.WriteLine("Carrier: " + _carrier);
            Console.WriteLine("Ringtone " + _ringTone);
            Console.WriteLine("$$$$$$$$$$$$$$$$$$$$$$$$$");
            Console.WriteLine("");
        }
    }
}