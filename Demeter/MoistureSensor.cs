using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter
{
    public class MoistureSensor : IMoistureSensor
    {
        public int GetLevelInPourcentage()
        {
            var random = new Random();
            return random.Next(0, 100);
        }
    }
}
