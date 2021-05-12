using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_form
{
    public static class Globals
    {
        public static int GlobalUserID { get; private set; }
        public static void SetGlobalUserID(int a)
        {
            GlobalUserID = a;
        }
    }
}
