using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_CrediteBancare
{
    public partial class FormAngajat : Form
    {
        public Angajat_Banca angajat;
        public Form1 parent;
        public FormAngajat()
        {
            InitializeComponent();
        }

        public void ActualizeazaAngajat(object sender, EventArgs e)
        {
            ListView lvi = (ListView)sender;

            angajat = null;

            if (lvi.SelectedItems.Count > 0)
                angajat = (Angajat_Banca)lvi.SelectedItems[0].Tag;

            if (angajat != null)
            {
                textBoxNume.Text = angajat.Nume;
                textBoxPrenume.Text = angajat.Prenume;
                textBoxTelefon.Text = angajat.Telefon;
                textBoxEmail.Text = angajat.Email;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (angajat != null)
            {
                angajat.Nume = textBoxNume.Text;
                angajat.Prenume = textBoxPrenume.Text;
                angajat.Telefon = textBoxTelefon.Text;
                angajat.Email = textBoxEmail.Text;
            }
            parent.UpdateItemsAngajat();
            this.DialogResult = DialogResult.OK;

            string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
            DataSet DSAngajati = new DataSet();
            string SelectCommandA = "insert into Angajati_Banca ([Nume], [Prenume], [Telefon], [Email]) values(@first, @middle1, @middle2, @last)";
            SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
            try
            {
                conexiune.Open(); //o deschid
                using (SqlCommand cmd = new SqlCommand(SelectCommandA, conexiune))
                {
                    cmd.Parameters.Add("@first", SqlDbType.NVarChar).Value = textBoxNume.Text;
                    cmd.Parameters.Add("@middle1", SqlDbType.NVarChar).Value = textBoxPrenume.Text;
                    cmd.Parameters.Add("@middle2", SqlDbType.NVarChar).Value = textBoxTelefon.Text;
                    cmd.Parameters.Add("@last", SqlDbType.NVarChar).Value = textBoxEmail.Text;

                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Salvare cu succes!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (angajat != null)
            {
                angajat.Nume = textBoxNume.Text;
                angajat.Prenume = textBoxPrenume.Text;
                angajat.Telefon = textBoxTelefon.Text;
                angajat.Email = textBoxEmail.Text;
            }
            parent.UpdateItemsAngajat();
            this.DialogResult = DialogResult.OK;

            string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
            DataSet DSAngajati = new DataSet();
            string SelectCommandA = "update dbo.Angajati_Banca set Nume=@Nume, " + "Prenume=@Prenume, Telefon=@Telefon, Email=@Email " + " where Nume=@Nume";
            SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
            try
            {
                conexiune.Open(); //o deschid
                using (SqlCommand cmd = new SqlCommand(SelectCommandA, conexiune))
                {
                    cmd.Parameters.AddWithValue("@Nume", SqlDbType.NVarChar).Value = textBoxNume.Text;
                    cmd.Parameters.AddWithValue("@Prenume", SqlDbType.NVarChar).Value = textBoxPrenume.Text;
                    cmd.Parameters.AddWithValue("@Telefon", SqlDbType.NVarChar).Value = textBoxTelefon.Text;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = textBoxEmail.Text;

                    cmd.ExecuteNonQuery();
                    conexiune.Close();
                    MessageBox.Show("Datele au fost actualizate cu succes!");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void textBoxTelefon_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxTelefon.Text == "")
            {
                errorProvider1.SetError(textBoxTelefon, "Trebuie completat numarul de telefon.");
                e.Cancel = true;
            }
            else if (!textBoxTelefon.Text.StartsWith("40") )
            {
                errorProvider1.SetError(textBoxTelefon, "Numarul introdus trebuie sa contina prefixul 40.");
                e.Cancel = true;
            }
            else if(textBoxTelefon.Text.Length < 11 || textBoxTelefon.Text.Length > 11)
            {
                errorProvider1.SetError(textBoxTelefon, "Numarul introdus trebuie sa contina 11 caractere.");
                e.Cancel = true;
            }
            else if (Regex.IsMatch(textBoxTelefon.Text, @"[0-9]") == false)
            {
                errorProvider1.SetError(textBoxTelefon, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxTelefon, "");
            }
        }

        private void textBoxEmail_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                errorProvider1.SetError(textBoxEmail, "Trebuie completat email-ul.");
                e.Cancel = true;
            }
            else if (!textBoxEmail.Text.Contains("@bank.ro"))
            {
                errorProvider1.SetError(textBoxEmail, "Email-ul trebuie sa fie de tipul ...@bank.ro.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxEmail, "");
            }
        }

        private void textBoxNume_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxNume.Text == "")
            {
                errorProvider1.SetError(textBoxNume, "Trebuie completat numele angajatului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxNume, "");
            }
        }

        private void textBoxPrenume_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxPrenume.Text == "")
            {
                errorProvider1.SetError(textBoxPrenume, "Trebuie completat prenumele angajatului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxPrenume, "");
            }
        }

        
    }
}
