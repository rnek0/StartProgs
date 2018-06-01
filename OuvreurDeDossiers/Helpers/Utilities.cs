using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OuvreurDeDossiers.Helpers
{
    public class Utilities
    {
        private static Utilities _instance;
        static readonly object instanceLock = new object();

        private Utilities(){}

        public static Utilities GetInstance()
        {
            lock (instanceLock)
            {
                if (_instance == null)
                    _instance = new Utilities();
                return _instance;
            }
        }


    }
}
