using System.Collections.Generic;

namespace Port
{
    internal class Mesure : Base
    {
        public int min { get; set; }
        public int max { get; set; }
        public double dataConverti { get; set; }
        public int alarmeMin { get; set; }
        public int alarmeMax { get; set; }

        public List<double> valuesConverti = new List<double>();

        public Mesure(int min, int max, int dataConverti, int alarmeMin, int alarmeMax) : base(0, 0, 0, 0, 0)
        {
            this.min = min;
            this.max = max;
            this.dataConverti = dataConverti;
            this.alarmeMin = alarmeMin;
            this.alarmeMax = alarmeMax;
        }
    }
}