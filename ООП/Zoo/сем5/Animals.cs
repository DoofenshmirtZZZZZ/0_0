using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace сем5
{
    public abstract class Animals
    {
        public string ShowInfo()
        {
            return   GetType().Name;
        }

    }
}
