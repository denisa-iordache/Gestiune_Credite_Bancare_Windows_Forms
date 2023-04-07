using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace Proiect_CrediteBancare
{
    public partial class FormClient : Form
    {
        public Client_Banca client;
        public Form1 parent;
        public FormClient()
        {
            InitializeComponent();
        }

        public void ActualizeazaClient(object sender, EventArgs e)
        {
            ListView lvi = (ListView)sender;

            client = null;

            if (lvi.SelectedItems.Count > 0)
                client = (Client_Banca)lvi.SelectedItems[0].Tag;

            if (client != null)
            {
                textBoxNume.Text = client.Nume;
                textBoxPrenume.Text = client.Prenume;
                dateTimePicker1.Value = client.DataNasterii;
                textBoxCNP.Text = client.Cnp;
                textBoxTelefon.Text = client.Telefon;
                textBoxEmail.Text = client.Email;
                textBoxVarsta.Text = client.Varsta.ToString();
                textBoxVenit.Text = client.VenitNet.ToString();
                comboBoxStare.Text = client.StareCivila;
                comboBoxSex.Text = client.Sex;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (client != null)
            {
                client.Nume = textBoxNume.Text;
                client.Prenume = textBoxPrenume.Text;
                client.DataNasterii = dateTimePicker1.Value;
                client.Cnp = textBoxCNP.Text;
                client.Telefon = textBoxTelefon.Text;
                client.Email = textBoxEmail.Text;
                client.Varsta = Convert.ToInt32(textBoxVarsta.Text);
                client.VenitNet = Convert.ToInt32(textBoxVenit.Text);
                client.StareCivila = comboBoxStare.Text;
                client.Sex = comboBoxSex.Text;
            }
            parent.UpdateItemsClient();
            this.DialogResult = DialogResult.OK;

            string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
            DataSet DSClienti = new DataSet();
            string SelectCommandC = "insert into Clienti_Banca ([Nume], [Prenume], [Data_nasterii], [CNP], [Telefon], [Email], [Varsta], [Venit_net], [Stare_civila], [Sex]) values(@first, @middle1, @middle2, @middle3, @middle4, @middle5,@middle6, @middle7, @middle8, @last)";
            SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
            try
            {
                conexiune.Open(); //o deschid
                using (SqlCommand cmd = new SqlCommand(SelectCommandC, conexiune))
                {
                    cmd.Parameters.Add("@first", SqlDbType.NVarChar).Value = textBoxNume.Text;
                    cmd.Parameters.Add("@middle1", SqlDbType.NVarChar).Value = textBoxPrenume.Text;
                    cmd.Parameters.Add("@middle2", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@middle3", SqlDbType.NVarChar).Value = textBoxCNP.Text;
                    cmd.Parameters.Add("@middle4", SqlDbType.NVarChar).Value = textBoxTelefon.Text;
                    cmd.Parameters.Add("@middle5", SqlDbType.NVarChar).Value = textBoxEmail.Text;
                    cmd.Parameters.Add("@middle6", SqlDbType.Int).Value = Convert.ToInt32(textBoxVarsta.Text);
                    cmd.Parameters.Add("@middle7", SqlDbType.Int).Value = Convert.ToInt32(textBoxVenit.Text);
                    cmd.Parameters.Add("@middle8", SqlDbType.NVarChar).Value = comboBoxStare.Text;
                    cmd.Parameters.Add("@last", SqlDbType.NVarChar).Value = comboBoxSex.Text;

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
            if (client != null)
            {
                client.Nume = textBoxNume.Text;
                client.Prenume = textBoxPrenume.Text;
                client.DataNasterii = dateTimePicker1.Value;
                client.Cnp = textBoxCNP.Text;
                client.Telefon = textBoxTelefon.Text;
                client.Email = textBoxEmail.Text;
                client.Varsta = Convert.ToInt32(textBoxVarsta.Text);
                client.VenitNet = Convert.ToInt32(textBoxVenit.Text);
                client.StareCivila = comboBoxStare.Text;
                client.Sex = comboBoxSex.Text;
            }
            parent.UpdateItemsClient();
            this.DialogResult = DialogResult.OK;

            string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
            DataSet DSClienti = new DataSet();
            string SelectCommandC = "update dbo.Clienti_Banca set Nume=@Nume, " + "Prenume=@Prenume, Data_nasterii=@DataNasterii, CNP=@CNP, Telefon=@Telefon, Email=@Email, Varsta=@Varsta, Venit_net=@VenitNet, Stare_civila=@StareCivila, Sex=@Sex " + " where Nume=@Nume";
            SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
            try
            {
                conexiune.Open(); //o deschid
                using (SqlCommand cmd = new SqlCommand(SelectCommandC, conexiune))
                {
                    cmd.Parameters.AddWithValue("@Nume", SqlDbType.NVarChar).Value = textBoxNume.Text;
                    cmd.Parameters.AddWithValue("@Prenume", SqlDbType.NVarChar).Value = textBoxPrenume.Text;
                    cmd.Parameters.AddWithValue("@DataNasterii", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.AddWithValue("@CNP", SqlDbType.NVarChar).Value = textBoxCNP.Text;
                    cmd.Parameters.AddWithValue("@Telefon", SqlDbType.NVarChar).Value = textBoxTelefon.Text;
                    cmd.Parameters.AddWithValue("@Email", SqlDbType.NVarChar).Value = textBoxEmail.Text;
                    cmd.Parameters.AddWithValue("@Varsta", SqlDbType.Int).Value = Convert.ToInt32(textBoxVarsta.Text);
                    cmd.Parameters.AddWithValue("@VenitNet", SqlDbType.Int).Value = Convert.ToInt32(textBoxVenit.Text);
                    cmd.Parameters.AddWithValue("@StareCivila", SqlDbType.NVarChar).Value = comboBoxStare.Text;
                    cmd.Parameters.AddWithValue("@Sex", SqlDbType.NVarChar).Value = comboBoxSex.Text;

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
        private void textBoxTelefon_Validating_1(object sender, CancelEventArgs e)
        {
            if (textBoxTelefon.Text == "")
            {
                errorProvider1.SetError(textBoxTelefon, "Trebuie completat numarul de telefon.");
                e.Cancel = true;
            }
            else if (!textBoxTelefon.Text.StartsWith("40"))
            {
                errorProvider1.SetError(textBoxTelefon, "Numarul introdus trebuie sa contina prefixul 40.");
                e.Cancel = true;
            }
            else if (textBoxTelefon.Text.Length < 11 || textBoxTelefon.Text.Length > 11)
            {
                errorProvider1.SetError(textBoxTelefon, "Numarul introdus trebuie sa contina 11 caractere.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(textBoxTelefon.Text, "[ ^ 0-9]"))
            {
                errorProvider1.SetError(textBoxTelefon, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxTelefon, "");
            }
        }

        private void textBoxEmail_Validating_1(object sender, CancelEventArgs e)
        {
            if (textBoxEmail.Text == "")
            {
                errorProvider1.SetError(textBoxEmail, "Trebuie completat email-ul.");
                e.Cancel = true;
            }
            else if (!textBoxEmail.Text.Contains("@gmail.com") && !textBoxEmail.Text.Contains("@yahoo.com"))
            {
                errorProvider1.SetError(textBoxEmail, "Email-ul trebuie sa fie de tipul ...@gmail/yahoo.com.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxEmail, "");
            }
        }

        private void textBoxNume_Validating_1(object sender, CancelEventArgs e)
        {
            if (textBoxNume.Text == "")
            {
                errorProvider1.SetError(textBoxNume, "Trebuie completat numele clientului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxNume, "");
            }
        }

        private void textBoxPrenume_Validating_1(object sender, CancelEventArgs e)
        {
            if (textBoxPrenume.Text == "")
            {
                errorProvider1.SetError(textBoxPrenume, "Trebuie completat prenumele clientului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxPrenume, "");
            }
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if(dateTimePicker1.Value > new DateTime(2003, 01, 01, 0, 0, 0))
            {
                errorProvider1.SetError(dateTimePicker1, "Pentru a beneficia de un credit bancar, este nevoie ca varsta clientului sa fie de minim 18 ani.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker1, "");
            }
        }

        private void textBoxCNP_Validating(object sender, CancelEventArgs e)
        {
            string phone = @"[ ^ 0-9]";
            if (textBoxCNP.Text == "")
            {
                errorProvider1.SetError(textBoxCNP, "Trebuie completat CNP-ul.");
                e.Cancel = true;
            }
            else if (Regex.IsMatch(textBoxCNP.Text, phone)==false)
            {
                errorProvider1.SetError(textBoxTelefon, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else if (textBoxCNP.Text.Length!=13)
            {
                errorProvider1.SetError(textBoxCNP, "CNP-ul trebuie sa aiba 13 cifre.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxCNP, "");
            }
        }

        private void textBoxVarsta_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxVarsta.Text == "")
            {
                errorProvider1.SetError(textBoxVarsta, "Trebuie completata varsta clientului.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(textBoxVarsta.Text, "[ ^ 0-9]"))
            {
                errorProvider1.SetError(textBoxVarsta, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else if (Convert.ToInt32(textBoxVarsta.Text) != DateTime.Today.Year-dateTimePicker1.Value.Year)
            {
                errorProvider1.SetError(textBoxVarsta, "Varsta introdusa nu corespunde cu data nasterii.");
                e.Cancel = true;
            }
            if (Convert.ToInt32(textBoxVarsta.Text) <18)
            {
                errorProvider1.SetError(textBoxVarsta, "Clientul trebuie sa fie major.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxVarsta, "");
            }
        }

        private void textBoxVenit_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxVenit.Text == "")
            {
                errorProvider1.SetError(textBoxVenit, "Trebuie completat venitul clientului.");
                e.Cancel = true;
            }
            else if (!Regex.IsMatch(textBoxVenit.Text, "[ ^ 0-9]"))
            {
                errorProvider1.SetError(textBoxVenit, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else if (textBoxVenit.Text.Length<4)
            {
                errorProvider1.SetError(textBoxVenit, "Venitul este prea mic pentru a obtine un credit.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxVenit, "");
            }
        }

        private void comboBoxStare_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxStare.Text == "")
            {
                errorProvider1.SetError(comboBoxStare, "Trebuie completata starea civila a clientului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(comboBoxStare, "");
            }
        }

        private void comboBoxSex_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxSex.Text == "")
            {
                errorProvider1.SetError(comboBoxSex, "Trebuie completat sexul clientului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(comboBoxSex, "");
            }
        }

        
    }
}
