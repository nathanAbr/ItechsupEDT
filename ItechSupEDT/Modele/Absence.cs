using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItechSupEDT.Modele
{
    public class Absence
    {
        private Eleve eleve;
        private Session session;
        public Eleve Eleve
        {
            get { return this.eleve; }
            set { this.eleve = value; }
        }
        public Session Session
        {
            get { return this.session; }
            set { this.session = value; }
        }
        public Absence(Eleve _eleve, Session _session)
        {
            this.Eleve = _eleve;
            this.Session = _session;
        }
    }
}
