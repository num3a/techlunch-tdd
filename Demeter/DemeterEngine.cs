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
            if (level <= 10)
            {
                return MoistureLevel.VeryLow;
            }
            if (level <= 30)
            {
                return MoistureLevel.Low;
            }
            if (level <= 40)
            {
                return MoistureLevel.Middle;
            }
            if (level <= 55)
            {
                return MoistureLevel.High;
            }

            return MoistureLevel.VeryHigh;
        }

        public enum MoistureLevel
        {
            VeryLow,
            Low,
            High,
            VeryHigh,
            Middle
        }
    }
}
