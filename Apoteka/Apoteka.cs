using System;
using System.Data.SqlServerCe;
using System.Windows.Forms;

namespace APOTEKA
{
    public partial class Apoteka : Form
    {
        static public string connString;
        SqlCeConnection conn = new SqlCeConnection();
        static public string filePath = @"c:\\Apoteka\\Apoteka.txt";
        static public System.IO.StreamWriter write = null;
        static public string[] text = null;

        public Apoteka(string path)
        {
            InitializeComponent();
            connString = @"Data Source=C:\\Apoteka\\Apoteka.sdf";

            try
            {
                if(!System.IO.Directory.Exists("C:\\Apoteka\\"))
                    System.IO.Directory.CreateDirectory("C:\\Apoteka\\");
                if (!System.IO.File.Exists(filePath))
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(filePath))
                    { }
                
                }
                conn.ConnectionString = connString;

                updateText();
                
                conn.Open();
                conn.Close();
           }
            catch (SqlCeException)
            {
                SqlCeEngine en = new SqlCeEngine(connString);
                en.CreateDatabase();
                try
                {
                    conn.ConnectionString = connString;
                    conn.Open();
                    SqlCeCommand command = new SqlCeCommand();
                    command.Connection = conn;

                    command.CommandText = "CREATE TABLE Lijekovi("
                        + "id INT NOT NULL PRIMARY KEY IDENTITY(0,1),"
                        + "naziv nvarchar(50) NOT NULL,"
                        + "latinski_naziv nvarchar(50) NOT NULL, "
                        + "cijena_saPDV nvarchar(20) NOT NULL, "
                        + "cijena_bezPDV nvarchar(20) NOT NULL);";
                    command.ExecuteNonQuery();
                    for (int i = 0; i < text.Length; i++)
                    {
                        MessageBox.Show(i + "\n" + text[i]); 
                        command.CommandText = text[i];
                        if(!string.IsNullOrEmpty(text[i]))
                            command.ExecuteNonQuery();
                    }

                    conn.Close();
                }
                catch (SqlCeException)
                {
                    DialogResult button = MessageBox.Show(this, "Nije moguće uspostaviti konekciju sa bazom. Želite da nastavite?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                    if (button == System.Windows.Forms.DialogResult.No)
                        this.Dispose();
                }
            }
        }
        
        private void Apoteka_Activated(object sender, EventArgs e)
        {
            Opacity = 1;
            Apoteka_Load(sender, e); 
        }
        private void Apoteka_Deactivate(object sender, EventArgs e)
        {
            Opacity = 0;
        }
        private void Apoteka_Load(object sender, EventArgs e)
        {
            Ocisti();
            conn.Close();
            conn.Open();
            SqlCeCommand command = new SqlCeCommand();
            command.Connection = conn;
            command.CommandText = "SELECT * FROM Lijekovi;";
            SqlCeDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Popuni(reader);
            }
            conn.Close();
        }

        private void naziv_SelectedIndexChanged(object sender, EventArgs e)
        {
            bezPDV.SelectedIndex = saPDV.SelectedIndex = latinski_naziv.SelectedIndex = naziv.SelectedIndex;
        }
        private void latinski_naziv_SelectedIndexChanged(object sender, EventArgs e)
        {
            bezPDV.SelectedIndex = saPDV.SelectedIndex = naziv.SelectedIndex = latinski_naziv.SelectedIndex;
        }
        private void bezPDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            saPDV.SelectedIndex = naziv.SelectedIndex = latinski_naziv.SelectedIndex = bezPDV.SelectedIndex;
        }
        private void saPDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            bezPDV.SelectedIndex = naziv.SelectedIndex = latinski_naziv.SelectedIndex = saPDV.SelectedIndex;
        }

        private void dodajLijekButton_Click(object sender, EventArgs e)
        {
            Apoteka_Deactivate(sender, e);
            new PodatciLijeka().Show();
        }
        private void ukloniLijekButton_Click(object sender, EventArgs e)
        {
            if (naziv.SelectedIndex != -1)
            {
                int i = naziv.SelectedIndex;

                DialogResult result = MessageBox.Show(this, "Da li ste sigurni da želite da uklonite "
                    + naziv.Items[i].ToString() + " (" + latinski_naziv.Items[i].ToString() + ")?", "Upozorenje!", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    SqlCeConnection conn = new SqlCeConnection(connString);
                    SqlCeCommand command = new SqlCeCommand();
                    command.CommandText = "DELETE FROM Lijekovi WHERE naziv = '" + naziv.Items[i].ToString() + "'"
                                     + " AND latinski_naziv = '" + latinski_naziv.Items[i].ToString() + "';";
                    command.Connection = conn;
                    conn.Open();
                    command.ExecuteNonQuery();
                    conn.Close();
                    Apoteka_Load(sender, e);
                }
            }
        }
        private void izmjeniPodatkeButton_Click(object sender, EventArgs e)
        {
            if (naziv.SelectedIndex != -1)
            {
                int i = naziv.SelectedIndex;
                conn.Open();
                SqlCeCommand command = new SqlCeCommand("SELECT id FROM Lijekovi WHERE naziv = '" + naziv.Items[i].ToString()
                    + "' AND latinski_naziv = '" + latinski_naziv.Items[i].ToString() + "';", conn);

                SqlCeDataReader read = command.ExecuteReader();
                read.Read();
                int index = read.GetInt32(0);
                conn.Close();
                new PodatciLijeka(index, naziv.SelectedIndex, true).Show();
            }
        }
        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                pretraga_Click(sender, e);
        }
        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            pretraga_Click(sender, e);
        }
        private void pretraga_Click(object sender, EventArgs e)
        {
            if (!(nazivCheck.Checked || latinskiCheck.Checked))
                MessageBox.Show("Izaberite po čemu želite da pretražite");
            else
            {
                if (string.IsNullOrEmpty(searchBox.Text))
                    Apoteka_Load(sender, e);
                else
                {
                    Ocisti();
                    conn.Close();
                    conn.Open();
                    SqlCeCommand command = new SqlCeCommand();
                    SqlCeDataReader reader;

                    command.Connection = conn;
                    if (tacno.Checked)
                    {
                        if (nazivCheck.Checked)
                        {
                            command.CommandText = "SELECT * FROM Lijekovi WHERE naziv = '" + searchBox.Text + "';";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Popuni(reader);
                            }
                        }
                        if (latinskiCheck.Checked)
                        {
                            command.CommandText = "SELECT * FROM Lijekovi WHERE naziv = '" + searchBox.Text + "';";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Popuni(reader);
                            }
                        }
                    }
                    else if (sadrzano.Checked)
                    {
                        if (nazivCheck.Checked)
                        {
                            command.CommandText = "SELECT * FROM Lijekovi WHERE latinski_naziv LIKE '%" + searchBox.Text + "%';";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Popuni(reader);
                            }
                        }
                        if (latinskiCheck.Checked)
                        {
                            command.CommandText = "SELECT * FROM Lijekovi WHERE latinski_naziv LIKE '%" + searchBox.Text + "%';";
                            reader = command.ExecuteReader();
                            while (reader.Read())
                            {
                                Popuni(reader);
                            }
                        }
                    }
                    else
                        MessageBox.Show("Nisu ispunjeni uslovi za pretragu");
                    conn.Close();
                }
            }
        }

        private void Ocisti()
        {
            saPDV.Items.Clear();
            bezPDV.Items.Clear();
            naziv.Items.Clear();
            latinski_naziv.Items.Clear();
            saPDV.SelectedItem = bezPDV.SelectedItem = naziv.SelectedItem = latinski_naziv.SelectedItem = -1;
        }
        private void Popuni(SqlCeDataReader reader)
        {
            naziv.Items.Add(reader.GetString(1));
            latinski_naziv.Items.Add(reader.GetString(2));
            saPDV.Items.Add(reader.GetString(3));
            bezPDV.Items.Add(reader.GetString(4));
        }
       
        private void About_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show(this, "Programer: Vladimir Kunarac\nNapravljeno: 14.10.2016. godine\nKontakt: Vladimir.kunarac@gmail.com", "O programeru", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void updateText()
        {
            text = System.IO.File.ReadAllLines(filePath);
        }

        private void Apoteka_FormClosing(object sender, FormClosingEventArgs e)
        {
          //  MessageBox.Show("DOSLO");
        //   System.Net.WebClient client = new System.Net.WebClient();
          //  System.IO.Stream stream = client.OpenRead("https://drive.google.com/file/d/0B7HxUII5udHVMHVQbnBKaUNPLXM/view");
         //   System.IO.StreamReader reader = new System.IO.StreamReader(stream);
         //   String content = reader.ReadToEnd();
           //     this.Dispose();
                //client.UploadFile("https://drive.google.com/drive/folders/0B7HxUII5udHVcmxuOXVBbE9yeEk?usp=sharing", filePath);
            
        }
    }
}
