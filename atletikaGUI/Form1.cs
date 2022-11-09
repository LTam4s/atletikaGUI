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
using MySql.Data.MySqlClient;


namespace atletikaGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<atletika> atletaList = new List<atletika>();
        private void Form1_Load(object sender, EventArgs e)
        {
            MySqlBaseConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "localhost";
            builder.UserID = "root";
            builder.Password = "";
            builder.Database = "atletikavb2017";

            MySqlConnection connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT NemzetId, Nemzet, Versenyszam, Nem, NemzetKod, VersenyzoNev, Eredmeny, Csucs, Helyezes  FROM `nemzetek` JOIN `versenyekszamok` on NemzetId = versenyekszamok.NemzetKod;";
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(7))
                        {
                            var value = dr.GetString("Csucs");
                        atletika atl = new atletika(dr.GetInt32("NemzetId"), dr.GetString("Nemzet"), dr.GetString("Versenyszam"), dr.GetChar("Nem"), dr.GetInt32("NemzetKod"), dr.GetString("VersenyzoNev"), dr.GetString("Eredmeny"), dr.GetString("Csucs"), dr.GetInt32("Helyezes"));
                            atletaList.Add(atl);
                            listBox2.Items.Add(dr.GetString("Versenyszam"));
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + "A program leáll");
                Environment.Exit(0);
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            if (listBox2.SelectedIndex < 0)
            {
                return;
            }

            foreach (atletika at in atletaList)
            {
                if (at.Versenyszam == listBox2.SelectedItem.ToString() && at.Helyezes == numericUpDown1.Value)
                {
                    label3.Text = "neve: "+ at.VersenyzoNev;
                    label4.Text = "eredménye: " + at.Eredmeny;
                    label5.Text = "nemzete: " + at.Nemzet;
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (atletika at in atletaList)
            {
                if (!listBox1.Items.Contains(at.Nemzet))
                {
                    listBox1.Items.Add(at.Nemzet);
                }
            }
        }
    }
}
