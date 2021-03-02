using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port
{
    class Mesure : Base
    {
        public int min { get; set; }
        public int max { get; set; }
        public int dataConverti { get; set; }
        public int alarmeMin { get; set; }
        public int alarmeMax { get; set; }
        public Mesure(int min,int max,int dataConverti,int alarmeMin,int alarmeMax):base(0,0,0,0,0) {
            this.min = min;
            this.max = max;
            this.dataConverti = dataConverti;
            this.alarmeMin = alarmeMin;
            this.alarmeMax = alarmeMax;
        }
    }
}
