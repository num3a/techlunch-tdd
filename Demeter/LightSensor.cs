using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter
{
   public class LightSensor : ILightSensor
    {
       public bool AmbiantLuminosityIsDark()
       {
           return true;
       }
    }
}
