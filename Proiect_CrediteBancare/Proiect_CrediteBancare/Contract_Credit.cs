using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect_CrediteBancare
{
    public class Contract_Credit
    {
        private string idContract;
        private string tipContract;
        private DateTime dataSemnarii;
        private DateTime dataScadenta;
        private float valoareCredit;
        private int nrRate;
        private float rataDobanzii;
        private Angajat_Banca angajat;
        private Client_Banca client;

        public Contract_Credit(string idContract, string tipContract, DateTime dataSemnarii, DateTime dataScadenta, float valoareCredit, int nrRate, float rataDobanzii, Angajat_Banca angajat, Client_Banca client)
        {
            this.idContract = idContract;
            this.tipContract = tipContract;
            this.dataSemnarii = dataSemnarii;
            this.dataScadenta = dataScadenta;
            this.valoareCredit = valoareCredit;
            this.nrRate = nrRate;
            this.rataDobanzii = rataDobanzii;
            this.angajat = angajat;
            this.client = client;
        }

        public string IdContract
        {
            get { return idContract; }
            set { if (value.Length > 0) idContract = value; }
        }

        public string TipContract
        {
            get { return tipContract; }
            set { if (value.Length > 0) tipContract = value; }
        }

        public DateTime DataSemnarii
        {
            get { return dataSemnarii; }
            set { if (value <= DateTime.Now) dataSemnarii = value; }
        }
        public DateTime DataScadenta
        {
            get { return dataScadenta; }
            set { if (value > DateTime.Now) dataScadenta = value; }
        }

        public float ValoareCredit
        {
            get { return valoareCredit; }
            set { if (value > 0) valoareCredit = value; }
        }

        public int NrRate
        {
            get { return nrRate; }
            set { if (value > 0) nrRate = value; }
        }

        public float RataDobanzii
        {
            get { return rataDobanzii; }
            set { if (value > 0) rataDobanzii = value; }
        }

        public Angajat_Banca Angajat
        {
            get { return angajat; }
            set { angajat = value; }
        }

        public Client_Banca Client
        {
            get { return client; }
            set { client = value; }
        }
    }
}
