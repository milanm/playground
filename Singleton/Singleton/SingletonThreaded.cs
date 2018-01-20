using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public sealed class SingletonThreaded
    {
        private static SingletonThreaded instance = null;
        private static readonly object Instancelock = new object();

        private SingletonThreaded() { }

        public static SingletonThreaded GetInstance
        {
            get
            {
                lock(Instancelock)
                {
                    if(instance == null)
                    {
                        instance = new SingletonThreaded();
                    }
                    return instance;
                }
            }
        }
    }
}
