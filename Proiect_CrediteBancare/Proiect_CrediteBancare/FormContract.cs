using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Proiect_CrediteBancare
{
    public partial class FormContract : Form
    {
        public Form1 formular;
        Contract_Credit contract;

        ArrayList listaPct;
        bool mouseApasat;
        Graphics context;
        Bitmap img;

        int nrobs;
        int[] y;
        string[] x;

        public FormContract(Contract_Credit c)
        {
            InitializeComponent();
            contract = c;
            textBoxAngajat.Text = c.Angajat.Nume;
            textBoxClient.Text = c.Client.Nume;

            listaPct = new ArrayList();
            img = new Bitmap(panel1.Width, panel1.Height);
            context = Graphics.FromImage(img);

            string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
            DataSet DSContracte = new DataSet();
            string SelectCommandA = "Select * from dbo.Contracte";
            DataTable dtA;
            SqlConnection conexiune = new SqlConnection(stringConexiune);
            conexiune.Open();
            SqlDataAdapter adaptor = new SqlDataAdapter(SelectCommandA, conexiune);
            adaptor.Fill(DSContracte, "Contracte");
            DSContracte.Tables["Contracte"].PrimaryKey = new DataColumn[1] 
                {DSContracte.Tables["Contracte"].Columns["Id"] };
            conexiune.Close();

            dtA = DSContracte.Tables["Contracte"];
            for (int i = 0; i < dtA.Rows.Count; i++)
            {
                listView1.Items.Add(dtA.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[3].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[4].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[5].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[6].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[7].ToString());
                listView1.Items[i].SubItems.Add(dtA.Rows[i].ItemArray[8].ToString());
            }

            this.ResizeRedraw = true;
            this.ResizeRedraw = true;
            nrobs = 3;
            int valLeas=0;
            int valNP = 0;
            int valIM = 0;
            x = new string[] { "Credit leasing", "Credit NP", "Credit imobiliar"};
            foreach(ListViewItem lvi in listView1.Items)
            {
                if(lvi.SubItems[1].Text== "Credit leasing                ")
                {
                    valLeas += Convert.ToInt32(lvi.SubItems[4].Text);
                }
            }
            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.SubItems[1].Text == "Credit de nevoi personale     ")
                {
                    valNP += Convert.ToInt32(lvi.SubItems[4].Text);
                }
            }
            foreach (ListViewItem lvi in listView1.Items)
            {
                if (lvi.SubItems[1].Text == "Credit imobiliar              ")
                {
                    valIM += Convert.ToInt32(lvi.SubItems[4].Text);
                }
            }
            y = new int[] { valLeas, valNP, valIM};
        }

        private void textBoxAngajat_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
                return;
            }
        }

        private void textBoxAngajat_DragDrop(object sender, DragEventArgs e)
        {
            Angajat_Banca a = (Angajat_Banca)((ListViewItem)e.Data.GetData(typeof(ListViewItem))).Tag;
            textBoxAngajat.Text = a.Nume;
        }

        private void textBoxClient_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(ListViewItem)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
                return;
            }
        }

        private void textBoxClient_DragDrop(object sender, DragEventArgs e)
        {
            Client_Banca c = (Client_Banca)((ListViewItem)e.Data.GetData(typeof(ListViewItem))).Tag;
            textBoxClient.Text = c.Nume;
        }

        private void textBoxID_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxID.Text == "")
            {
                errorProvider1.SetError(textBoxID, "Trebuie completat Id-ul contractului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxID, "");
            }
        }

        private void dateTimePicker1_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimePicker1.Value > DateTime.Now)
            {
                errorProvider1.SetError(dateTimePicker1, "Data semnarii contractului nu poate fi o data din viitor.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker1, "");
            }
        }

        private void dateTimePicker2_Validating(object sender, CancelEventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                errorProvider1.SetError(dateTimePicker2, "Data scadenta nu poate fi mai indepartata decat data semnarii.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(dateTimePicker2, "");
            }
        }

        private void textBoxValoare_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxValoare.Text == "")
            {
                errorProvider1.SetError(textBoxValoare, "Trebuie completata valoarea creditului.");
                e.Cancel = true;
            }
            else if (Convert.ToInt32(textBoxValoare.Text) <1000)
            {
                errorProvider1.SetError(textBoxValoare, "Nu se poate obtine un credit cu aceasta valoare.");
                e.Cancel = true;
            }
            else if (Regex.IsMatch(textBoxValoare.Text, @"[0-9]") == false)
            {
                errorProvider1.SetError(textBoxValoare, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxValoare, "");
            }
        }

        private void textBoxNrRate_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxNrRate.Text == "")
            {
                errorProvider1.SetError(textBoxNrRate, "Trebuie completat numarul de rate aferent creditului.");
                e.Cancel = true;
            }
            else if (Regex.IsMatch(textBoxNrRate.Text, @"[0-9]") == false)
            {
                errorProvider1.SetError(textBoxNrRate, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else if (Convert.ToInt32(textBoxNrRate.Text) % 12 != 0)
            {
                errorProvider1.SetError(textBoxNrRate, "Numarul de rate trebuie sa fie mutiplu de 12.");
                e.Cancel = true;
            }
            else if (Convert.ToInt32(textBoxNrRate.Text) != (dateTimePicker2.Value.Year - dateTimePicker1.Value.Year) * 12)
            {
                errorProvider1.SetError(textBoxNrRate, "Numarul de rate nu corespunde cu durata creditului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxNrRate, "");
            }
        }

        private void textBoxRata_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxRata.Text == "")
            {
                errorProvider1.SetError(textBoxRata, "Trebuie completata rata dobanzii");
                e.Cancel = true;
            }
            else if (Regex.IsMatch(textBoxRata.Text, @"[0-9]") == false)
            {
                errorProvider1.SetError(textBoxRata, "Se pot introduce doar valori numerice.");
                e.Cancel = true;
            }
            else if (Convert.ToInt32(textBoxRata.Text) % 12 > 100)
            {
                errorProvider1.SetError(textBoxRata, "Rata dobanzii nu poate fi mai mare de 100%");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxRata, "");
            }
        }

        private void textBoxAngajat_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxAngajat.Text == "")
            {
                errorProvider1.SetError(textBoxAngajat, "Trebuie completat angajatul responsabil cu incheierea contractului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxAngajat, "");
            }
        }

        private void textBoxClient_Validating(object sender, CancelEventArgs e)
        {
            if (textBoxClient.Text == "")
            {
                errorProvider1.SetError(textBoxClient, "Trebuie completat clientul.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(textBoxClient, "");
            }
        }

        private void comboBoxCredit_Validating(object sender, CancelEventArgs e)
        {
            if (comboBoxCredit.Text == "")
            {
                errorProvider1.SetError(comboBoxCredit, "Trebuie completat tipul de credit aferent contractului.");
                e.Cancel = true;
            }
            else
            {
                errorProvider1.SetError(comboBoxCredit, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Angajat_Banca a = new Angajat_Banca(textBoxAngajat.Text, "", "", "");
            Client_Banca cl = new Client_Banca(textBoxClient.Text, "", DateTime.Now, "", "", "", 0, 0, "", "");
            Contract_Credit c = new Contract_Credit(textBoxID.Text, comboBoxCredit.Text, dateTimePicker1.Value, dateTimePicker2.Value, Convert.ToInt32(textBoxValoare.Text), Convert.ToInt32(textBoxNrRate.Text), Convert.ToInt32(textBoxRata.Text), a, cl);

            ListViewItem item = new ListViewItem(c.IdContract);
            item.SubItems.Add(c.TipContract);
            item.SubItems.Add(c.DataSemnarii.ToString());
            item.SubItems.Add(c.DataScadenta.ToString());
            item.SubItems.Add(c.ValoareCredit.ToString());
            item.SubItems.Add(c.NrRate.ToString());
            item.SubItems.Add(c.RataDobanzii.ToString());
            item.SubItems.Add(c.Angajat.Nume.ToString());
            item.SubItems.Add(c.Client.Nume.ToString());
            listView1.Items.Add(item);

            string stringConexiune = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB-1053;Integrated Security=True";
            DataSet DSContract = new DataSet();
            string SelectCommandC = "insert into Contracte ([Tip_credit], [Data_Semnarii], [Data_Scadenta], [Valoare_credit], [Numar_rate], [Rata_dobanzii], [Angajat], [Client], [Id_contract]) values(@middle1, @middle2, @middle3, @middle4, @middle5,@middle6, @middle7, @last, @first)";
            SqlConnection conexiune = new SqlConnection(stringConexiune); //creez conexiunea
            try
            {
                conexiune.Open(); //o deschid
                using (SqlCommand cmd = new SqlCommand(SelectCommandC, conexiune))
                {
                    cmd.Parameters.Add("@middle1", SqlDbType.NVarChar).Value = comboBoxCredit.Text;
                    cmd.Parameters.Add("@middle2", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    cmd.Parameters.Add("@middle3", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                    cmd.Parameters.Add("@middle4", SqlDbType.Real).Value = Convert.ToInt32(textBoxValoare.Text);
                    cmd.Parameters.Add("@middle5", SqlDbType.Int).Value = Convert.ToInt32(textBoxNrRate.Text);
                    cmd.Parameters.Add("@middle6", SqlDbType.Int).Value = Convert.ToInt32(textBoxRata.Text);
                    cmd.Parameters.Add("@middle7", SqlDbType.NVarChar).Value = textBoxAngajat.Text;
                    cmd.Parameters.Add("@last", SqlDbType.NVarChar).Value = textBoxClient.Text;
                    cmd.Parameters.Add("@first", SqlDbType.NVarChar).Value = textBoxID.Text;

                    int rowsAdded = cmd.ExecuteNonQuery();
                    if (rowsAdded > 0)
                        MessageBox.Show("Salvare cu succes!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBoxID.Clear();
            textBoxValoare.Clear();
            textBoxNrRate.Clear();
            textBoxRata.Clear();
            textBoxAngajat.Clear();
            textBoxClient.Clear();

            
        }

        private void FormContract_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                listaPct.Add(p);
                mouseApasat = true;
            }
        }

        private void FormContract_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point p = new Point(e.X, e.Y);
                listaPct.Add(p);
                mouseApasat = true;
                Pen creion = new Pen(this.ForeColor);
                if (mouseApasat == true)
                {
                    context.DrawLine(creion, (Point)listaPct[listaPct.Count - 2], (Point)listaPct[listaPct.Count - 1]);
                    panel1.Invalidate();
                }
            }
            
        }

        private void FormContract_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseApasat = false;
            }
        }

        private void FormContract_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);
        }

        private void salvare(Control c)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.bmp)|*.bmp";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Graphics g = c.CreateGraphics();
                Bitmap bmp = new Bitmap(c.Width, c.Height);
                c.DrawToBitmap(bmp, new Rectangle(c.ClientRectangle.X, c.ClientRectangle.Y, c.Width, c.Height));
                bmp.Save(dlg.FileName);
                bmp.Dispose();
            }
        }

        private void salveazaSemnaturaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            salvare(panel1);
            MessageBox.Show("Semnatura clientului a fost salvata.");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);
        }

        private void pd_print(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem lvi = listView1.SelectedItems[0];
                g.DrawString("Contract " + lvi.SubItems[1].Text, new Font("Times New Roman", 25, FontStyle.Bold), new SolidBrush(Color.Black), new Point(220, 40));
                g.DrawString("Incheiat astazi, " + lvi.SubItems[2].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 120));
                g.DrawString("cu numarul " + listView1.SelectedItems[0].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(430, 120));
                Bitmap myBitmap1 = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                pictureBox1.DrawToBitmap(myBitmap1, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
                e.Graphics.DrawImage(myBitmap1, 330, 700);
                myBitmap1.Dispose();
                g.DrawString(lvi.SubItems[8].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 160));
                g.DrawString("si SC Bank Romania SRL, cu sediul in Targoviste,", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 200));
                g.DrawString("Strada Radu Popescu, nr. 3, CIF 123498, in calitatea de debitor", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 240));
                g.DrawString("au convenit sa incheie prezentul contract de credit,", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 280));
                g.DrawString("in temeiul art. 100 din Legea nr 99/1999 si in conformitate cu Legea 31/1990,", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 320));
                g.DrawString("cu respectare urmatoarelor clauze:", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 360));
                g.DrawString("Data scadenta: " + lvi.SubItems[3].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 400));
                g.DrawString("Valoare credit: " + lvi.SubItems[4].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 440));
                g.DrawString("Numar rate: " + lvi.SubItems[5].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 480));
                g.DrawString("Rata dobanzii: " + lvi.SubItems[6].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 520));
                g.DrawString("Angajatul care a incheiat prezentul contract: " + lvi.SubItems[7].Text, new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 560));
                g.DrawString("Semnatura clientului platitor: ", new Font("Times New Roman", 15, FontStyle.Bold), new SolidBrush(Color.Black), new Point(100, 600));
                Image img = Image.FromFile(lvi.SubItems[8].Text + ".bmp");
                pictureBox2.Image = img;
                Bitmap myBitmap2 = new Bitmap(pictureBox2.Width, pictureBox2.Height);
                pictureBox2.DrawToBitmap(myBitmap2, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height));
                e.Graphics.DrawImage(myBitmap2, 100, 640);
                myBitmap2.Dispose();
            }
        }

        private void printPreviewContractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
        }

        private void printContractToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(this.pd_print);
            PrintPreviewDialog dlg = new PrintPreviewDialog();
            dlg.Document = pd;
            dlg.ShowDialog();
            pd.PrinterSettings.PrinterName = "Epson L3160 series";
            if (pd.PrinterSettings.IsValid)
            {
                pd.Print();
            }
            else
            {
                MessageBox.Show("Imprimanta nu a putut fi gasita.");
            }
        }

        private void salvaretxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();

            dlg.Filter = "(*.txt)|*.txt";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                foreach (ListViewItem item in listView1.Items)
                {
                    sw.WriteLine(item.Text);
                    for (int i = 1; i < item.SubItems.Count; i++)
                    {
                        sw.WriteLine(item.SubItems[i].Text);
                    }
                    sw.WriteLine();

                }
                sw.Close();
                fs.Close();
            }
        }

        private void salvarebinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.bin)|*.bin";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ListViewItem[] items = new ListViewItem[listView1.Items.Count];
                listView1.Items.CopyTo(items, 0);
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, items);
                sw.Close();
                fs.Close();
            }
        }

        private void restaurarebinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "(*.bin)|*.bin";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ListViewItem[] items = null;
                FileStream fs = new FileStream(dlg.FileName, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(fs);
                BinaryFormatter bf = new BinaryFormatter();
                items = (ListViewItem[])bf.Deserialize(fs);
                listView1.Items.Clear();
                listView1.Items.AddRange(items);
                sr.Close();
                fs.Close();
            }
        }

        private void salvarexmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "(*.xml)|*.xml";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dlg.FileName, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);
                XmlTextWriter xmlTextWriter = new XmlTextWriter(sw);
                xmlTextWriter.Formatting = Formatting.Indented;
                xmlTextWriter.WriteStartDocument();
                xmlTextWriter.WriteStartElement("Lista-contracte");

                foreach (ListViewItem item in listView1.Items)
                {
                    xmlTextWriter.WriteStartElement("Contract-credit");

                    xmlTextWriter.WriteElementString("ID", item.SubItems[0].Text.ToString());
                    xmlTextWriter.WriteElementString("Tip-credit", item.SubItems[1].Text.ToString());
                    xmlTextWriter.WriteElementString("Data-semnarii", item.SubItems[2].Text.ToString());
                    xmlTextWriter.WriteElementString("Data-scadenta", item.SubItems[3].Text.ToString());
                    xmlTextWriter.WriteElementString("Valoare-credit", item.SubItems[4].Text.ToString());
                    xmlTextWriter.WriteElementString("Numar-rate", item.SubItems[5].Text.ToString());
                    xmlTextWriter.WriteElementString("Rata-dobanzii", item.SubItems[6].Text.ToString());
                    xmlTextWriter.WriteElementString("Angajat", item.SubItems[7].Text.ToString());
                    xmlTextWriter.WriteElementString("Client", item.SubItems[8].Text.ToString());

                    xmlTextWriter.WriteEndElement();

                }

                xmlTextWriter.WriteEndElement();
                xmlTextWriter.WriteEndDocument();
                xmlTextWriter.Close();
            }
        }

        private void restaurarexmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*StreamReader sr = new StreamReader("D:\\SCOALA\\An 2 Semestrul 2\\PAW\\Contracte.xml");
            string str = sr.ReadToEnd();

            List<Contract_Credit> lista = new List<Contract_Credit>();

            XmlReader reader = XmlReader.Create(new StringReader(str));

            while (reader.Read())
            {
                if (reader.Name == "Contract-credit" && reader.NodeType == XmlNodeType.Element)
                {
                    Contract_Credit mlocal;

                    while (reader.Read() && reader.Name != "ID") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string cnp = reader.Value;

                    while (reader.Read() && reader.Name != "Tip-credit") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string nume = reader.Value;

                    while (reader.Read() && reader.Name != "Data-semnarii") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string datan = reader.Value;

                    while (reader.Read() && reader.Name != "Data-scadenta") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string an = reader.Value;

                    while (reader.Read() && reader.Name != "Valoare-credit") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string spec = reader.Value;

                    while (reader.Read() && reader.Name != "Numar-rate") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string nr = reader.Value;

                    while (reader.Read() && reader.Name != "Rata-dobanzii") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string rat = reader.Value;

                    while (reader.Read() && reader.Name != "Angajat") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string ang = reader.Value;

                    while (reader.Read() && reader.Name != "Client") { } //while se termina cand ajunge la CNP
                    reader.Read();
                    string cl = reader.Value;

                    mlocal = new Contract_Credit(cnp, nume, DateTime.Parse(datan), DateTime.Parse(an), int.Parse(spec), int.Parse(nr), int.Parse(rat), (Angajat_Banca.)ang, (Client_Banca)cl);
                    lista.Add(mlocal);
                }
            }
            listView1.Items.Clear();

            foreach (Contract_Credit m in lista)
            {
                ListViewItem lvi = new ListViewItem(new string[] { "", "", "", "" });
                lvi.Tag = m;
                listView1.Items.Add(lvi);
            }
            UpdateItems();
            sr.Close();*/
        }

        public void UpdateItems()
        {
            foreach (ListViewItem lvi in listView1.Items)
            {
                Contract_Credit m = (Contract_Credit)lvi.Tag;
                lvi.Text = m.IdContract;
                lvi.SubItems[1].Text = m.TipContract;
                lvi.SubItems[2].Text = m.DataSemnarii.ToString();
                lvi.SubItems[3].Text = m.DataScadenta.ToString();
                lvi.SubItems[4].Text = m.ValoareCredit.ToString();
                lvi.SubItems[5].Text = m.NrRate.ToString();
                lvi.SubItems[6].Text = m.RataDobanzii.ToString();
                lvi.SubItems[7].Text = m.Angajat.Nume;
                lvi.SubItems[8].Text = m.Client.Nume;
            }
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;  //e.Graphics.DrawLine

            Rectangle zonaClient = e.ClipRectangle;
            SolidBrush fundal = new SolidBrush(Color.White);
            g.FillRectangle(fundal, zonaClient);

            zonaClient.X += 20; zonaClient.Y += 20;
            zonaClient.Width -= 40; zonaClient.Height -= 40;

            Pen creionRosu = new Pen(Color.Red, 3);
            g.DrawRectangle(creionRosu, zonaClient);

            int vl = zonaClient.Left, vb = zonaClient.Bottom, vr = zonaClient.Right, vt = zonaClient.Top;

            float rap_dist_lat = 0.2f, max;
            float lat, dist;

            SolidBrush[] pensule = new SolidBrush[]
            {
                new SolidBrush(Color.Orange),
                new SolidBrush(Color.Violet),
                new SolidBrush(Color.Green)
            };

            SolidBrush pensulaCurenta;
            Pen creionCurent;

            lat= (vr - vl)*0.8f / (int)((nrobs + 1) * rap_dist_lat + nrobs);
            dist = (int)(lat * rap_dist_lat);

            max = y[0];
            int i;
            for (i = 1; i < nrobs; i++)
                if (max < y[i]) max = y[i];

            creionCurent = new Pen(Color.Magenta);
            g.DrawLine(creionCurent, vl, vt, vl, vb);
            g.DrawLine(creionCurent, vl, vb, vr, vb);

            for (i = 0; i < nrobs; i++)
            {
                pensulaCurenta = pensule[i % 6];
                PointF pnt = new PointF(vl + dist + i * (lat + dist), vb - y[i] * (vb - vt) / max);

                SizeF sz = new SizeF(lat, y[i] * (vb - vt) / max);

                g.FillRectangle(pensulaCurenta, new RectangleF(pnt, sz));

                string denx = x[i];
                string deny = y[i].ToString();
                g.DrawString(denx, new Font("Broadway", 10, FontStyle.Bold), pensulaCurenta, vl + dist + i * (lat + dist) + lat / 50, vb + 5);
                g.DrawString(deny, new Font("Broadway", 10, FontStyle.Bold), new SolidBrush(Color.Black), pnt);
            }
        }

        private void panel2_Resize_1(object sender, EventArgs e)
        {
            panel2.Invalidate();
        }
    }
}

