using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CinamonCinema
{
    public partial class Form1 : Form
    {
        List<string> arr = new List<string>()
        {
            "odin_doma",
            "ma4o",
            "time_for_me",
            "devnaja_smena",
            "vegas",
        };
        List<string> son = new List<string>()
        {
            "son_era",
            "son_requin",
            "son_artek",
            "son_crush",
        };
        public Form1()
        {
            InitializeComponent();
            PictureBox pictur1 = new PictureBox()
            {
                Size = new Size(800, 100),
                Location = new Point(1, 1),
                Image = Image.FromFile("../../Images/cinamon.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
            };
            panel2.Controls.Add(pictur1);
            panel1.AutoScroll = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            for (int i = 0; i < arr.Count; i++)
            {
                PictureBox pictureBox = new PictureBox() {
                    Size = new Size(220, 300),
                    Location = new Point(i * 250, 11),
                    Image = Image.FromFile("../../Images/" + arr[i] + ".jpg"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Tag = arr[i]
                };
                pictureBox.Click += (e, s) => {
                    PictureBox pictureBox1 = (e as PictureBox);
                    Form5 form3 = new Form5(pictureBox1.Tag.ToString() + "");
                    form3.Show();
                };
                panel1.Controls.Add(pictureBox);
            }
            for (int i = 0; i < son.Count; i++)
            {
                PictureBox pictureBox3 = new PictureBox()
                {
                    Size = new Size(220, 300),
                    Location = new Point(i * 250, 333),
                    Image = Image.FromFile("../../Soon_film/" + son[i] + ".jpg"),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Tag = son[i]
                };
                pictureBox3.Click += (e, s) =>
                {
                    MessageBox.Show("Seda filmi ei saa vaadata, kuna see pole veel meie kinos linastunud.","Varsti...",MessageBoxButtons.OKCancel,MessageBoxIcon.Error);
                };
                panel1.Controls.Add(pictureBox3);
            }
        }
    }
}
