using System;
using Microsoft.VisualBasic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinamonCinema
{
    public partial class Pilet : Form
    {
        string name;
        int maxRows, maxColumns;
        List<string> arr_poilet;
        PictureBox[,] _arr;
        int hind = 10;
        private double result = 0f;
        Image img_seat = Image.FromFile("../../Koht/" + "seat.jpg"),
        img_seat_choose = Image.FromFile("../../Koht/" + "seat_choose.jpg"),
        img_seat_bought = Image.FromFile("../../Koht/" + "seat_bought.jpg");
        public Pilet(string nAme, int maxRowsS, int maxColumnsS, int seans)
        {
            name = nAme;
            maxRows = maxRowsS;
            maxColumns = maxColumnsS;
            _arr = new PictureBox[maxRows, maxColumns];
            if (!File.Exists("../../Pilet/" + name + ".txt"))
            {
                string text = "";
                StreamWriter file1 = new StreamWriter("../../Pilet/" + name + ".txt");
                for (int i = 0; i < maxRows; i++)
                {
                    for (int j = 0; j < maxColumns; j++)
                    {
                        text += i + "," + j + ",vale;";
                    }
                    text += "\n";
                }
                file1.Write(text);
                file1.Close();
            }
            StreamReader file = new StreamReader("../../Pilet/" + name + ".txt");
            string[] ar = file.ReadToEnd().Split('\n');
            InitializeComponent();
            this.Size = new Size(maxColumns * 40 + 40, maxRows * 50 + 90);
            button1.Location = new Point(12, maxRows * 50 + 25);
            button2.Location = new Point(82, maxRows * 50 + 25);
            textBox1.Location = new Point(150, maxRows * 50 + 25);
            textBox1.Text = string.Format("{0:f2} $", result);
            this.Text = name;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            for (int i = 0; i < maxRows; i++)
            {
                Label label = new Label() { 
                    Text = (i+1).ToString(), 
                    Size = new Size(20, 20),
                    Location = new Point(0, i * 50 + 50)
                };
                for (int j = 0; j < maxColumns; j++)
                {
                    Label label1 = new Label() { 
                        Text = (j+1).ToString(), 
                        Size = new Size(20,20),
                        Location = new Point(j * 40 + 40, 0)
                    };
                    _arr[i, j] = new PictureBox();
                    _arr[i, j].SizeMode = PictureBoxSizeMode.Zoom;


                    string[] ards = ar[i].Split(';');
                    string[] ardNum = ards[j].Split(',');
                    if (ardNum[2] == "oige")
                    {
                        _arr[i, j].Image = img_seat_bought;
                    }
                    else
                    {
                        _arr[i, j].Image = img_seat;
                    }


                    _arr[i, j].Size = new Size(40, 50);
                    _arr[i, j].Location = new Point(j * 40 + 20, i * 50 + 20);
                    _arr[i, j].Click += Form2_Click;
                    this.Controls.Add(_arr[i, j]);
                    this.Controls.Add(label1);
                }
                this.Controls.Add(label);
            }
            file.Close();
        }
        private void Result()
        {
            result += hind;
        }
        private void Form2_Click(object s, EventArgs e)
        {
            PictureBox pic = s as PictureBox;
            if (pic.Image != img_seat_bought)
            {
                if (pic.Image == img_seat_choose)
                {
                    pic.Image = img_seat;
                    var breakk = true;
                    for (int i = 0; i < maxRows; i++)
                    {
                        for (int j = 0; j < maxColumns; j++)
                        {
                            if (_arr[i, j].Image == img_seat_choose)
                            {
                                breakk = false;
                            }
                        }
                    }
                    if (breakk)
                        button1.Enabled = false;
                }
                else
                {
                    pic.Image = img_seat_choose;
                    button1.Enabled = true;
                }
            }
        }

        void Ask()
        {
            string text = "";
            arr_poilet = new List<string>();
            var vastus = MessageBox.Show("Kas oled kindel?", "Cinamon kusib", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (vastus == DialogResult.Yes)
            {
                int t = 0;
                for (int i = 0; i < maxRows; i++)
                {
                    for (int j = 0; j < maxColumns; j++)
                    {
                        if (_arr[i, j].Image == img_seat_choose)
                        {
                            Result();
                            t++;
                            _arr[i, j].Image = img_seat_bought;
                            StreamWriter pilet = new StreamWriter("../../Pilet/" + "Pilet" + t.ToString() + "rida" + i.ToString() + "koht" + j.ToString() + ".txt");
                            pilet.Write("Pilet: " + t.ToString() + " rida: " + (i+1).ToString() + " koht: " + (j+1).ToString());
                            pilet.Close();
                            arr_poilet.Add("Pilet" + t.ToString() + "rida" + i.ToString() + "koht" + j.ToString() + ".txt");
                        }
                    }
                }
                SaadaBilet();
                for (int i = 0; i < maxRows; i++)
                {
                    for (int j = 0; j < maxColumns; j++)
                    {
                        if (_arr[i, j].Image == img_seat_bought)
                        {
                            text += i + "," + j + ",oige;";
                        }
                        else
                        {
                            text += i + "," + j + ",vale;";
                        }
                    }
                    text += "\n";
                }
                using (StreamWriter file = new StreamWriter("../../Saal/" + name + ".txt"))
                {
                    file.WriteLine(text);
                    file.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void SaadaBilet()
        {
            try
            {
                Email osta = new Email(name);
                osta.Show();
                foreach (var item in arr_poilet)
                {
                    File.Delete(item);
                }
            }
            catch (Exception)
            {
                foreach (var item in arr_poilet)
                {
                    File.Delete(item);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Ask();
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
