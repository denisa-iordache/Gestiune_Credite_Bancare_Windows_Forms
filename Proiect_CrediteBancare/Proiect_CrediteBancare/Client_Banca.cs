using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_CrediteBancare
{
    public class Client_Banca 
    {
        private string nume;
        private string prenume;
        private string telefon;
        private string email;
        private DateTime dataNasterii;
        private string CNP;
        private int varsta;
        private float venitNet;
        private string sex;
        private string stareCivila;
        //private Card_De_Credit card;

        public Client_Banca(string nume, string prenume, DateTime dataNasterii, string CNP, string telefon, string email, int varsta, float venitNet,string stareCivila, string sex)//, Card_De_Credit card)
        {
            this.nume = nume;
            this.prenume = prenume;
            this.telefon = telefon;
            this.email = email;
            this.dataNasterii = dataNasterii;
            this.CNP = CNP;
            this.varsta = varsta;
            this.venitNet = venitNet;
            this.sex = sex;
            this.stareCivila = stareCivila;
            //this.card = card;
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

        public DateTime DataNasterii
        {
            get { return dataNasterii; }
            set { if (value < DateTime.Now) dataNasterii = value; }
        }

        public string Cnp
        {
            get { return CNP; }
            set { if (value.Length > 0) CNP = value; }
        }

        public int Varsta
        {
            get { return varsta; }
            set { if (value > 0) varsta = value; }
        }

        public float VenitNet
        {
            get { return venitNet; }
            set { if (value > 0) venitNet = value; }
        }

        public string Sex
        {
            get { return sex; }
            set { if (value.ToString() != "") sex = value; }
        }

        public string StareCivila
        {
            get { return stareCivila; }
            set { if (value.Length > 0) stareCivila = value; }
        }

        /*public Card_De_Credit Card
        {
            get { return card; }
            set { card = value; }
        }*/
    }
}
