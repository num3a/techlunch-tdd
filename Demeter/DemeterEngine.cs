using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demeter
{
    public class DemeterEngine
    {
        private readonly IMoistureSensor _moistureSensor;

        public DemeterEngine( IMoistureSensor moistureSensor)
        {
            _moistureSensor = moistureSensor;
        }
        public MoistureLevel GetMoistureLevel()
        {
            var level = _moistureSensor.GetLevelInPourcentage();
            if (level < 50)
            {
                return MoistureLevel.Low;
            }
            return MoistureLevel.High;
        }

        public enum MoistureLevel
        {
            VeryLow,
            Low,
            High,
            VeryHigh

        }
    }
}
