using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CinamonCinema
{
    public partial class Kodu : Form
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
        public Kodu()
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
            tabPage1.AutoScroll = true;
            MaximizeBox = false;
            MinimizeBox = false;
            FormBorderStyle = FormBorderStyle.FixedSingle;

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
                    Info form3 = new Info(pictureBox1.Tag.ToString() + "");
                    form3.Show();
                };
                tabPage1.Controls.Add(pictureBox);
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
                tabPage1.Controls.Add(pictureBox3);
            }
        }
        private void btn_admin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\Uus\CinamonCinema\CinamonCinema\Database1.mdf;Integrated Security=True"); // making connection   
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM login WHERE username='" + box_user.Text + "' AND password='" + box_pas.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                AdminPanel f = new AdminPanel();
                f.ShowDialog();
            }
            else
                MessageBox.Show("Invalid Admin või salasõna","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
    }
}
