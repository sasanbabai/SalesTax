using System;

namespace SalesTax
{
    public class RoundingStrategy : IRoundingStrategy
    {
        private RoundingStrategy()
        {
        }

        private static IRoundingStrategy _instance;

        public static IRoundingStrategy Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RoundingStrategy();
                }
                return _instance;
            }
        }

        public virtual decimal Round(decimal value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
