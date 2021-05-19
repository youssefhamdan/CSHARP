namespace Port
{
    internal class Alarme : Base
    {
        private int idAlarme { get; set; }
        private int typeAlarme { get; set; }
        private int etatAlarme { get; set; }

        public Alarme(int idAlarme, int typeAlarme, int etatAlarme) : base(50, 0, 0, 0, 0)
        {
            this.idAlarme = idAlarme;
            this.typeAlarme = typeAlarme;
            this.etatAlarme = etatAlarme;
        }
    }
}