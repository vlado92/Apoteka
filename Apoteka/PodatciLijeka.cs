using System;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace APOTEKA
{
    public partial class PodatciLijeka : Form
    {
        private SqlCeConnection conn = new SqlCeConnection(Apoteka.connString);
        private SqlCeCommand command = new SqlCeCommand();
        private Boolean updateIt;
        private int Identitet;
        private int selectedID;

        public PodatciLijeka(int ID = -1, int selected = -1, Boolean update = false)
        {
            Apoteka.write = new System.IO.StreamWriter(Apoteka.filePath, true);
               
            InitializeComponent();
            Identitet = ID;
            selectedID = selected;
            updateIt = update;
            if (updateIt)
            {
                command.Connection = conn;
                command.CommandText = "SELECT cijena_saPDV, cijena_bezPDV, naziv, latinski_naziv FROM Lijekovi WHERE id = " + Identitet + ";";
                conn.Open();
                SqlCeDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    saPDVText.Text = reader.GetString(0);
                    bezPDVText.Text = reader.GetString(1);
                    nazivText.Text = reader.GetString(2);
                    latinskiText.Text = reader.GetString(3);
                }
                conn.Close();
            }
            
        }

        private void unesiButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nazivText.Text))
            {
                MessageBox.Show("Molim Vas unesite naziv artikla.");
                nazivText.Focus();
            }
            else if (string.IsNullOrEmpty(latinskiText.Text))
            {
                MessageBox.Show("Molim Vas unesite latinski naziv artikla.");
                latinskiText.Focus();
            }
            else if (string.IsNullOrEmpty(saPDVText.Text))
            {
                MessageBox.Show("Molim Vas unesite cijenu sa PDV-om");
                saPDVText.Focus();
            }
            else if (string.IsNullOrEmpty(bezPDVText.Text))
            {
                MessageBox.Show("Molim Vas unesite cijenu bez PDV-a");
                bezPDVText.Focus();
            }
            else
            {
                if (!ProvjeriInput()){}
                else
                {
                    KorigujInput();
                    command.Connection = conn;
                    if (!updateIt)
                    {
                        command.CommandText = "INSERT INTO Lijekovi(naziv, latinski_naziv,"
                            + "cijena_saPDV, cijena_bezPDV) VALUES ("
                            + "'" + nazivText.Text + "', '" + latinskiText.Text + "', '"
                            + saPDVText.Text + "', '" + bezPDVText.Text + "');";
                        Apoteka.write.WriteLine(command.CommandText);

                    }
                    else
                    {
                        command.CommandText = "UPDATE Lijekovi SET "
                            + "naziv =  '" + nazivText.Text + "',"
                            + "latinski_naziv = '" + latinskiText.Text + "',"
                            + "cijena_saPDV = '" + saPDVText.Text + "',"
                            + "cijena_bezPDV = '" + bezPDVText.Text + "'"
                            + " WHERE id = " + Identitet + ";";
                        Apoteka.text[selectedID] = "INSERT INTO Lijekovi(naziv, latinski_naziv,cijena_saPDV, cijena_bezPDV) VALUES ("
                                +"'" + nazivText.Text + "', '" + latinskiText.Text +  "', '" + saPDVText.Text + "', '" + bezPDVText.Text + "');";
                        Apoteka.write.Close();
                        using (var stream = System.IO.File.OpenWrite(Apoteka.filePath))
                        using (System.IO.StreamWriter writer = new System.IO.StreamWriter(stream))
                        {
                            if (Apoteka.text.Length > 0)
                            {
                                for (int i = 0; i < Apoteka.text.Length - 1; i++)
                                {
                                    writer.WriteLine(Apoteka.text[i]);
                                }
                                writer.Write(Apoteka.text[Apoteka.text.Length - 1]);
                            }
                        }
                    }
                    try
                    {
                        conn.Close();
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Unešeno u bazu.");
                        saPDVText.Clear();
                        bezPDVText.Clear();
                        nazivText.Clear();
                        latinskiText.Clear();
                        conn.Close();
                    }
                    catch (SqlCeException ee)
                    {
                        MessageBox.Show("Greška pri unosu u bazu!\n" + ee.ToString());
                    }
                    if (updateIt)
                        this.Dispose();
                }
            }
        }

        private Boolean ProvjeriInput()
        {
            int zareza = 0;
            for (int i = 0; i < saPDVText.Text.Length; i++)
            {

                if (saPDVText.Text[i].Equals('.') || saPDVText.Text[i].Equals(','))
                {
                    zareza++;
                }
                if (zareza > 1)
                {
                    MessageBox.Show("Unesite ispravno cijenu sa PDV-om.");
                    saPDVText.Clear();
                    saPDVText.Focus();
                    return false;
                }
            }
            
            zareza = 0;
            for (int i = 0; i < bezPDVText.Text.Length; i++)
            {
                if (bezPDVText.Text[i].Equals('.') || bezPDVText.Text[i].Equals(','))
                {
                    zareza++;
                }                
                if (zareza > 1)
                {
                    MessageBox.Show("Unesite ispravno cijenu bez PDV-a.");
                    bezPDVText.Clear();
                    bezPDVText.Focus();
                    return false;
                }
            }

            float f;
            if(!float.TryParse(saPDVText.Text, out f))
            {
                MessageBox.Show("Unesite ispravno cijenu sa PDV-om.");
                saPDVText.Clear();
                saPDVText.Focus();
                return false;
            }
            else if (!float.TryParse(bezPDVText.Text, out f))
            {
                MessageBox.Show("Unesite ispravno cijenu bez PDV-a.");
                bezPDVText.Clear();
                bezPDVText.Focus();
                return false;
            }
            else if(float.Parse(bezPDVText.Text) > float.Parse(saPDVText.Text))
            {
                DialogResult result = MessageBox.Show(this, "Da li ste sigurni da je cijena bez PDV-a je veca od cijene sa PDV-om?",
                    "Pitanje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == System.Windows.Forms.DialogResult.Yes)
                    return true;
                bezPDVText.Clear();
                saPDVText.Clear();
                bezPDVText.Focus();
                return false;
            }
            
            return true;
        }         
        private void KorigujInput()
        {
            for (int i = 0; i < saPDVText.Text.Length; i++)
                if (saPDVText.Text[i] == '.')
                {
                    if (saPDVText.Text.Substring(i + 1).Length > 1)
                        saPDVText.Text = saPDVText.Text.Substring(0, i) + "," + saPDVText.Text.Substring(i + 1);
                    else
                        saPDVText.Text = saPDVText.Text.Substring(0, i);
                }
            for (int i = 0; i < bezPDVText.Text.Length; i++)
                if (bezPDVText.Text[i] == '.')
                {
                    if (bezPDVText.Text.Substring(i + 1).Length > 1)
                        bezPDVText.Text = bezPDVText.Text.Substring(0, i) + "," + bezPDVText.Text.Substring(i + 1);
                    else
                        bezPDVText.Text = bezPDVText.Text.Substring(0, i);
                }
            if (saPDVText.Text.Contains(','))
            {
                if (saPDVText.Text.Substring(saPDVText.Text.IndexOf(',') + 1).Length >= 2)
                    saPDVText.Text = saPDVText.Text.Substring(0, saPDVText.Text.IndexOf(',') + 3);
                else
                    saPDVText.Text += "0";
            }
            else
                saPDVText.Text += ",00";
            if (bezPDVText.Text.Contains(','))
            {
                if (bezPDVText.Text.Substring(bezPDVText.Text.IndexOf(',') + 1).Length >= 2)
                    bezPDVText.Text = bezPDVText.Text.Substring(0, bezPDVText.Text.IndexOf(',') + 3);
                else
                    bezPDVText.Text += "0";
            }
            else
                bezPDVText.Text += ",00";
        }

        private void PodatciLijeka_Load(object sender, EventArgs e)
        {

        }

        private void PodatciLijeka_Deactivate(object sender, EventArgs e)
        {
        }

        private void PodatciLijeka_FormClosing(object sender, FormClosingEventArgs e)
        {
            Apoteka.write.Close();
            Apoteka.updateText();
        }
    }
}
