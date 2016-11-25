
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Homework6
{
    
    class WaterHeater
    {
        private int waterTemperature = 20;
      
        public bool Heating()
        {
            if (waterTemperature < 80)
            {
                Console.WriteLine("The temperature of water is " + ++waterTemperature);
                return true;
            }
            else
            {
                Console.WriteLine("Stop!Because the temperature of water is 80 degrees centigrade!");
                return false;
            }
        }
        public static void Main(String[] args)
        {
            WaterHeater waterHeater = new WaterHeater();
            while(waterHeater.Heating());
        }
    }
}