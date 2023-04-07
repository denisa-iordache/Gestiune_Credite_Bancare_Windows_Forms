using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_CrediteBancare
{
    public class Angajat_Banca
    {
        private string nume;
        private string prenume;
        private string telefon;
        private string email;

        public Angajat_Banca(string nume, string prenume, string telefon, string email)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.telefon = telefon;
            this.email = email;
        }

        public string Nume
        {
            get { return nume; }
            set { if (value.Length > 0) nume = value; }
        }

        public string Prenume
        {
            get { return prenume; }
            set { if (value.Length > 0) prenume = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { if (value.Length > 0) telefon = value; }
        }

        public string Email
        {
            get { return email; }
            set { if (value.Length > 0) email = value; }
        }
    }
}
