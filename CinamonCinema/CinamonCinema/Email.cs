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
using System.IO;

namespace CinamonCinema
{
    public partial class Email : Form
    {
        string name;
        public Email(string nAme)
        {
            name = nAme;
            InitializeComponent();
            this.Text = "Osta pilet";
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            Size = new Size(400, 300);
            Controls.Add(label1);
            button1.Click += button1_Click;
            Controls.Add(email);
            Controls.Add(button1);
            Controls.Add(panel1);

        }
        Panel panel1 = new Panel()
        {
            Size = new Size(240, 160),
            Location = new Point(60, 50),
            BorderStyle = BorderStyle.Fixed3D,
            BackColor = Color.Gray,
            ForeColor = Color.Gray,
        };
        Label label1 = new Label()
        {
            Text = "Sisesta e - mail",
            Location = new Point(130, 70),
            BackColor = Color.Gray,
            ForeColor = Color.White,
        };
        TextBox email = new TextBox()
        {
            Name = "email",
            Text = "artjomvolkov@gmail.com",
            Location = new Point(100, 100),
            Size = new Size(160, 40),
        };
        Button button1 = new Button()
        {
            Text = "Kinnitada",
            Location = new Point(130, 140),
            Size = new Size(80, 25),
            Font = new System.Drawing.Font("Rubik", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186))),
    };
        private static Regex email_validation()
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
                + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
                + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            return new Regex(pattern, RegexOptions.IgnoreCase);
        }
        static Regex validate_emailaddress = email_validation();
        private void button1_Click(object sender, EventArgs e)
        {
            if (validate_emailaddress.IsMatch(email.Text) != true)
            {
                MessageBox.Show("Invalid Email Address!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                email.Focus();
                return;
                
            }
            else
            {
                MessageBox.Show("Edukalt broneeritud!","Hästi!",0,MessageBoxIcon.Information);
                WriteFile();
                this.Hide();

            }

        }

        private void WriteFile()
        {
            Random rnd = new Random();
            int num = rnd.Next();
            try
            {
                using (StreamWriter file = new StreamWriter("../../Email/" + email.Text + "_" + name + ".txt"))
                {
                    file.Write(email.Text);
                    file.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }
    }
}
