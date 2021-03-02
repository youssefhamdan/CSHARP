using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Port
{
    class Alarme:Base
    {
        int idAlarme { get; set; }
        int typeAlarme { get; set; }
        int etatAlarme { get; set; }

        public Alarme(int idAlarme,int typeAlarme,int etatAlarme) : base(50, 0, 0, 0, 0) {
            this.idAlarme = idAlarme;
            this.typeAlarme = typeAlarme;
            this.etatAlarme = etatAlarme;
            
        }

    }
}
