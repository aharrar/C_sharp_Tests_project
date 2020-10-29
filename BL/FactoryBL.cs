using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL//SINGLETON
{
    public sealed class MyFactoryBL
    {
        private static IBL instance;
        public static IBL Instance
        {
            get
            {
                if (instance == null)
                { instance = new BL_imp(); }
                return instance;
            }
        }


    }
}