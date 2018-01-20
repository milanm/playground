using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class SingletonStandard
    {

        private static SingletonStandard instance;

        private SingletonStandard() { }

        public static SingletonStandard GetInstance()
        {
            if(instance == null)
            {
                instance = new SingletonStandard();
            }

            return instance;
        }

    }
}
