using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public sealed class MyFactoryDal
    {
        private static Idal instance;
        public static Idal Instance
        {
            get
            {
                if (instance == null)
                { instance = new Dal_imp(); }
                return instance;
            }
        }
    }
}
