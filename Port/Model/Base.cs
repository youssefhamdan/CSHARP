namespace Port
{
    internal class Base
    {
        public int id;
        public int nbrData { get; set; }
        public int type { get; set; }
        public ulong data { get; set; }
        public int alarme { get; set; }

        public Base(int id, int nbrData, int type, ulong data, int alarme)
        {
            this.id = id;
            this.nbrData = nbrData;
            this.type = type;
            this.data = data;
            this.alarme = alarme;
        }
    }
}