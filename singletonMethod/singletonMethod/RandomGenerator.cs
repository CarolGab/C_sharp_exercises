using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singletonMethod
{
    class RandomGenerator
    {
        private static Random myInstance;
        public RandomGenerator() { }
        public static Random GetInstance()
        {
            if (myInstance == null)
            {
                myInstance = new Random();
            }
            return myInstance;
        }
    }

}

