using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BPMS02.Models
{
    public class Class
    {
        public int Add(int a,int b)
        {
            if (a < 10)
                a = a + 1;
            else
            {
                a = a - 1;
            }

            return a + b;
        }
    }
}
