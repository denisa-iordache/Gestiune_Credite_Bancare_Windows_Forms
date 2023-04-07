using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_CrediteBancare
{
    public partial class Form1 : Form
    {
        string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
        DataSet DSAngajati = new DataSet();
        DataSet DSClienti = new DataSet();
        string SelectCommandA = "Select * from dbo.Angajati_Banca";
        string SelectCommandC = "Select * from dbo.Clienti_Banca";
        DataTable dtA;
        DataTable dtC;
        public Form1()
        {
            InitializeComponent();

            /*Angajat_Banca a1 = new Angajat_Banca("Popescu", "Ion", "+40745217503", "popescui@bank.ro");

            ListViewItem lvi1 = new ListViewItem(a1.Nume);
            lvi1.SubItems.Add(a1.Prenume);
            lvi1.SubItems.Add(a1.Telefon);
            lvi1.SubItems.Add(a1.Email);
            lvi1.UseItemStyleForSubItems = false;
            lvi1.Tag = a1;
            listViewAngajati.Items.Add(lvi1);

            Client_Banca c1 = new Client_Banca("Gheorghe", "Mihai", new DateTime(1993,05,02,0,0,0), "5930502152486", "+40753927462", "gheorghemihai03@gmail.com", 28, 4500, "Casatorit", 'M');

            ListViewItem lvi2 = new ListViewItem(c1.Nume);
            lvi2.SubItems.Add(c1.Prenume);
            lvi2.SubItems.Add(c1.DataNasterii.ToString());
            lvi2.SubItems.Add(c1.Cnp);
            lvi2.SubItems.Add(a1.Telefon);
            lvi2.SubItems.Add(a1.Email);
            lvi2.SubItems.Add(c1.Varsta.ToString());
            lvi2.SubItems.Add(c1.VenitNet.ToString());
            lvi2.SubItems.Add(c1.StareCivila);
            lvi2.SubItems.Add(c1.Sex.ToString());
            lvi2.UseItemStyleForSubItems = false;
            lvi2.Tag = c1;
            listViewClienti.Items.Add(lvi2);*/

            SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
            conexiune.Open(); //o deschid
            SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommandA, conexiune); //isi construieste comanda din stringul de mai sus
            adaptor.Fill(DSAngajati, "Angajati_Banca"); //am in dataset tabela
            DSAngajati.Tables["Angajati_Banca"].PrimaryKey = new DataColumn[1] //setez primaryKey
                {DSAngajati.Tables["Angajati_Banca"].Columns["Id"] }; //se seteaza un vector de coloane al acestei tabele
            conexiune.Close(); //o inchid

            dtA = DSAngajati.Tables["Angajati_Banca"];
            for (int i=0;i<dtA.Rows.Count;i++)
            {
                Angajat_Banca a1 = new Angajat_Banca(dtA.Rows[i].ItemArray[1].ToString(), dtA.Rows[i].ItemArray[2].ToString(), dtA.Rows[i].ItemArray[3].ToString(), dtA.Rows[i].ItemArray[4].ToString());
                ListViewItem lvi1 = new ListViewItem(a1.Nume);
                lvi1.SubItems.Add(a1.Prenume);
                lvi1.SubItems.Add(a1.Telefon);
                lvi1.SubItems.Add(a1.Email);
                lvi1.UseItemStyleForSubItems = false;
                lvi1.Tag = a1;
                listViewAngajati.Items.Add(lvi1);

                //listViewAngajati.Items.Add(dtA.Rows[i].ItemArray[1].ToString());
                //listViewAngajati.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[2].ToString());
                //listViewAngajati.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[3].ToString());
                //listViewAngajati.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[4].ToString());
            }

            SqlConnection conexion = new SqlConnection(stringConexiune); //creez conexiunea
            conexion.Open(); //o deschid
            SqlDataAdapter adapt= new SqlDataAdapter(SelectCommandC, conexion); //isi construieste comanda din stringul de mai su
            adapt.Fill(DSClienti, "Clienti_Banca"); //am in dataset tabela

            DSClienti.Tables["Clienti_Banca"].PrimaryKey = new DataColumn[1] //setez primaryKey
                {DSClienti.Tables["Clienti_Banca"].Columns["Id"] }; //se seteaza un vector de coloane al acestei tabele
            conexion.Close(); //o inchid

            dtC = DSClienti.Tables["Clienti_Banca"];
            for (int i = 0; i < dtC.Rows.Count; i++)
            {
                Client_Banca c1 = new Client_Banca(dtC.Rows[i].ItemArray[1].ToString(), dtC.Rows[i].ItemArray[2].ToString(), (DateTime)dtC.Rows[i].ItemArray[5], dtC.Rows[i].ItemArray[3].ToString(), dtC.Rows[i].ItemArray[4].ToString(), dtC.Rows[i].ItemArray[6].ToString(), Convert.ToInt32(dtC.Rows[i].ItemArray[7]), Convert.ToInt32(dtC.Rows[i].ItemArray[8]), dtC.Rows[i].ItemArray[9].ToString(), dtC.Rows[i].ItemArray[10].ToString());

                ListViewItem lvi2 = new ListViewItem(c1.Nume);
                lvi2.SubItems.Add(c1.Prenume);
                lvi2.SubItems.Add(c1.DataNasterii.ToString());
                lvi2.SubItems.Add(c1.Cnp);
                lvi2.SubItems.Add(c1.Telefon);
                lvi2.SubItems.Add(c1.Email);
                lvi2.SubItems.Add(c1.Varsta.ToString());
                lvi2.SubItems.Add(c1.VenitNet.ToString());
                lvi2.SubItems.Add(c1.StareCivila);
                lvi2.SubItems.Add(c1.Sex);
                lvi2.UseItemStyleForSubItems = false;
                lvi2.Tag = c1;
                listViewClienti.Items.Add(lvi2);

                //listViewClienti.Items.Add(dtC.Rows[i].ItemArray[1].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[2].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[3].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[4].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[5].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[6].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[7].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[8].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[9].ToString());
                //listViewClienti.Items[i].SubItems.Add(dtC.Rows[i].ItemArray[10].ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_DB_1053DataSet1.Angajati_Banca' table. You can move, or remove it, as needed.
            //this.angajati_BancaTableAdapter.Fill(this._DB_1053DataSet1.Angajati_Banca);

        }

        public void UpdateItemsAngajat()
        {
            foreach (ListViewItem lvia in listViewAngajati.Items)
            {
                Angajat_Banca a = (Angajat_Banca)lvia.Tag;
                lvia.Text = a.Nume;
                lvia.SubItems[1].Text = a.Prenume;
                lvia.SubItems[2].Text = a.Telefon;
                lvia.SubItems[3].Text = a.Email;
            }
        }

        public void UpdateItemsClient()
        {
            foreach (ListViewItem lvi in listViewClienti.Items)
            {
                Client_Banca c = (Client_Banca)lvi.Tag;
                lvi.Text = c.Nume;
                lvi.SubItems[1].Text = c.Prenume;
                lvi.SubItems[2].Text = c.DataNasterii.ToString();
                lvi.SubItems[3].Text = c.Cnp;
                lvi.SubItems[4].Text = c.Telefon;
                lvi.SubItems[5].Text = c.Email;
                lvi.SubItems[6].Text = c.Varsta.ToString();
                lvi.SubItems[7].Text = c.VenitNet.ToString();
                lvi.SubItems[8].Text = c.StareCivila;
                lvi.SubItems[9].Text = c.Sex;
            }
        }

        private void adaugaAngajatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(new string[] { "", "", "", "" });
            listViewAngajati.Items.Add(lvi);
            Angajat_Banca a = new Angajat_Banca("", "", "", "");
            lvi.Tag = a;

            FormAngajat fa = new FormAngajat();
            fa.angajat = a;
            fa.parent = this;

            fa.Text = "Adaugare angajat";
            fa.button2.Visible = false;

            fa.ShowDialog();

            if (fa.DialogResult != DialogResult.OK) lvi.Remove();
        }

        private void modificaAngajatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewAngajati.SelectedItems.Count > 0)
            {
                FormAngajat fa = new FormAngajat();

                listViewAngajati.SelectedIndexChanged += new EventHandler(fa.ActualizeazaAngajat);

                fa.ActualizeazaAngajat(listViewAngajati, e);
                fa.parent = this;
                fa.Text = "Modificare date angajat";
                fa.button1.Visible = false;
                fa.ShowDialog();
            }
        }

        private void stergeAngajatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewAngajati.SelectedItems.Count > 0)
            {
                Angajat_Banca a = (Angajat_Banca)listViewAngajati.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti stergerea angajatului " + a.Nume + " ?", "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes)
                {
                    string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
                    DataSet DSAngajati = new DataSet();
                    string SelectCommandD = "delete from dbo.Angajati_Banca where Nume = @Nume";
                    SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
                    try
                    {
                        conexiune.Open(); //o deschid
                        using (SqlCommand cmd = new SqlCommand(SelectCommandD, conexiune))
                        {
                            cmd.Parameters.AddWithValue("@Nume", listViewAngajati.SelectedItems[0].SubItems[0].Text);
                            //cmd.Parameters.AddWithValue("@Prenume", SqlDbType.NVarChar).Value = textBoxPrenume.Text;
                            //cmd.Parameters.AddWithValue("@Telefon", SqlDbType.NVarChar).Value = textBoxTelefon.Text;
                            //cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = textBoxEmail.Text;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            //conexiune.Close();
                            MessageBox.Show("S-a sters inregistrarea!");

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    listViewAngajati.SelectedItems[0].Remove();
                }

            }
        }

        private void adaugaClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem lvi = new ListViewItem(new string[] { "", "", "", "","","","","","",""});
            listViewClienti.Items.Add(lvi);
            Client_Banca c = new Client_Banca("", "", DateTime.Now, "","","", 0,0,"","");
            lvi.Tag = c;

            FormClient fc = new FormClient();
            fc.client = c;
            fc.parent = this;

            fc.Text = "Adaugare client";
            fc.button2.Visible = false;

            fc.ShowDialog();

            if (fc.DialogResult != DialogResult.OK) lvi.Remove();
        }

        private void modificaClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewClienti.SelectedItems.Count > 0)
            {
                FormClient fc = new FormClient();

                listViewClienti.SelectedIndexChanged += new EventHandler(fc.ActualizeazaClient);

                fc.ActualizeazaClient(listViewClienti, e);
                fc.parent = this;
                fc.Text = "Modificare date client";
                fc.button1.Visible = false;
                fc.ShowDialog();
            }
        }

        private void stergeClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewClienti.SelectedItems.Count > 0)
            {
                Client_Banca a = (Client_Banca)listViewClienti.SelectedItems[0].Tag;
                DialogResult rezultat = MessageBox.Show("Sunteti sigur ca doriti stergerea clientului " + a.Nume + " ?", "Confirmare stergere", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (rezultat == DialogResult.Yes)
                {
                    string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
                    DataSet DSClienti = new DataSet();
                    string SelectCommandD = "delete from dbo.Clienti_Banca where Nume = @Nume";
                    SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
                    try
                    {
                        conexiune.Open(); //o deschid
                        using (SqlCommand cmd = new SqlCommand(SelectCommandD, conexiune))
                        {
                            cmd.Parameters.AddWithValue("@Nume", listViewClienti.SelectedItems[0].SubItems[0].Text);
                            //cmd.Parameters.AddWithValue("@Prenume", SqlDbType.NVarChar).Value = textBoxPrenume.Text;
                            //cmd.Parameters.AddWithValue("@Telefon", SqlDbType.NVarChar).Value = textBoxTelefon.Text;
                            //cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = textBoxEmail.Text;
                            cmd.CommandType = CommandType.Text;
                            cmd.ExecuteNonQuery();
                            //conexiune.Close();
                            MessageBox.Show("S-a sters inregistrarea!");

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    listViewClienti.SelectedItems[0].Remove();
                }

            }
        }

        private void creareContractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Angajat_Banca a = new Angajat_Banca("", "", "", "");
            Client_Banca cl = new Client_Banca("", "", DateTime.Now, "", "", "", 0, 0, "", "");
            Contract_Credit c = new Contract_Credit("", "", DateTime.Now, DateTime.Now, 0, 0, 0, a, cl);
            FormContract fc = new FormContract(c);
            fc.Show();
        }

        private void listViewAngajati_MouseDown(object sender, MouseEventArgs e)
        {
            if (listViewAngajati.SelectedItems.Count > 0)
            {
                listViewAngajati.DoDragDrop(listViewAngajati.SelectedItems[0], DragDropEffects.Copy | DragDropEffects.Move);
            }
        }

        private void listViewClienti_MouseDown(object sender, MouseEventArgs e)
        {
            if (listViewClienti.SelectedItems.Count > 0)
            {
                listViewClienti.DoDragDrop(listViewClienti.SelectedItems[0], DragDropEffects.Copy | DragDropEffects.Move);
            }
        }
    }
}
