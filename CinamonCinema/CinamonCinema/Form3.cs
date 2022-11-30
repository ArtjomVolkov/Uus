using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace CinamonCinema
{
    public partial class Form3 : Form
    {
        string name;
        Random rnd = new Random();
        List<string> arr = new List<string>();
        public Form3(string nAme)
        {
            name = nAme;
            InitializeComponent();
            this.Text = "Seansid";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (!File.Exists("../../Seanses/" + name + "Seanses.txt"))
            {
                int A = 0;
                string text = "";
                StreamWriter file1 = new StreamWriter("../../Seanses/" + name + "Seanses.txt");
                for (int i = 0; i < 7; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        int ind = rnd.Next(59);
                        text += rnd.Next(23).ToString() + ":" + ((ind < 10) ? "0"+ind.ToString() : ind.ToString()) + ",";
                        text += A + ",";
                        text += rnd.Next(5,10) + ",";
                        text += rnd.Next(5,10) + ";";
                        A++;
                    }
                    text = text.Substring(0, text.Length - 1);
                    text += "\n";
                }
                file1.Write(text);
                file1.Close();
            }
            StreamReader file = new StreamReader("../../Seanses/" + name + "Seanses.txt");
            string[] ar = file.ReadToEnd().Split('\n');
            foreach (var item in ar)
            {
                arr.Add(item);
            }
            foreach (var item in arr[0].Split(';'))
            {
                comboBox2.Items.Insert(0, item.Split(',')[0]);
            }
            comboBox2.SelectedIndex = 0;

            comboBox1.Items.Insert(0, "Pühapäev");
            comboBox1.Items.Insert(0, "Laupäev");
            comboBox1.Items.Insert(0, "Reede");
            comboBox1.Items.Insert(0, "Neljapäev");
            comboBox1.Items.Insert(0, "Kolmapäev");
            comboBox1.Items.Insert(0, "Teisipäev");
            comboBox1.Items.Insert(0, "Esmaspäev");
            comboBox1.SelectedIndex = 0;

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach (var item in arr[comboBox1.SelectedIndex].Split(';'))
            {
                comboBox2.Items.Insert(0, item.Split(',')[0]);
            }
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form4;
            form4 = new Form2(
                name, 
                Convert.ToInt32(arr[comboBox1.SelectedIndex].Split(';')[comboBox2.SelectedIndex].Split(',')[2]), 
                Convert.ToInt32(arr[comboBox1.SelectedIndex].Split(';')[comboBox2.SelectedIndex].Split(',')[3]), 
                Convert.ToInt32(arr[comboBox1.SelectedIndex].Split(';')[comboBox2.SelectedIndex].Split(',')[1])
            );
            form4.Show();
        }

        public void InToBD(int t, int i, int j) {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\CinamonUus\Cinamon\CinamonCinema\CinamonCinema\Database1.mdf;Integrated Security=True");
            conn.Open();
            SqlCommand sqlCommand = new SqlCommand("INSERT INTO Piletid(Id,Rida,Koht) VALUES (" + t + "," + i + "," + j + ")", conn);
            sqlCommand.ExecuteNonQuery();
            sqlCommand.Dispose();
            conn.Close();
        }
    }
}
