using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CinamonCinema
{
    public partial class AdminPanel : Form
    {
        private DataGridView login_data;
        private DataGridView film_data;
        private DataGridView dataGridView4;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView1;
        private Label label4;
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\Uus\CinamonCinema\CinamonCinema\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_kat;//adapter
        private Button btn_admin;
        private TextBox box_pas;
        private Label label5;
        private TextBox box_user;
        private Label label6;
        private Button Kustuta_button_Click;
        OpenFileDialog openfiledialog1;
        public AdminPanel()
        {
            InitializeComponent();
            Naita_Andmed();
            Naita_Andmed1();
        }
        public void Naita_Andmed()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM login", connect);
            adapter_toode.Fill(dt_toode);
            login_data.DataSource = dt_toode;
            login_data.Columns[0].Visible = false;

            connect.Close();
        }
        public void Naita_Andmed1()
        {
            connect.Open();
            DataTable dt_toode = new DataTable();
            adapter_toode = new SqlDataAdapter("SELECT * FROM film", connect);
            adapter_toode.Fill(dt_toode);
            film_data.DataSource = dt_toode;
            film_data.Columns[0].Visible = false;

            connect.Close();
        }

        private void btn_admin_Click(object sender, EventArgs e)
        {
            if (box_user.Text.Trim() != String.Empty && box_pas.Text.Trim() != String.Empty)
            {
                try
                {
                    cmd = new SqlCommand("INSERT INTO login (username,password) VALUES (@user,@pass)", connect);
                    connect.Open();
                    cmd.Parameters.AddWithValue("@user", box_user.Text);
                    cmd.Parameters.AddWithValue("@pass", box_pas.Text);
                    cmd.ExecuteNonQuery();
                    connect.Close();
                    Naita_Andmed();

                }
                catch (Exception)
                {

                    MessageBox.Show("Andmebaasiga viga!");
                }
            }
            else
            {
                MessageBox.Show("Sisesta andmeid!");
            }
        }

        private void Kustuta_button_Click_Click(object sender, EventArgs e)
        {
            if (login_data.SelectedRows.Count == 0)
                return;

            string sql = "DELETE FROM login WHERE Id = @rowID";

            using (SqlCommand deleteRecord = new SqlCommand(sql, connect))
            {
                connect.Open();
                int selectedIndex = login_data.SelectedRows[0].Index;
                int rowID = Convert.ToInt32(login_data[0, selectedIndex].Value);

                deleteRecord.Parameters.Add("@rowID", SqlDbType.Int).Value = rowID;
                deleteRecord.ExecuteNonQuery();

                login_data.Rows.RemoveAt(selectedIndex);
                connect.Close();
            }
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.login_data = new System.Windows.Forms.DataGridView();
            this.film_data = new System.Windows.Forms.DataGridView();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_admin = new System.Windows.Forms.Button();
            this.box_pas = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.box_user = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Kustuta_button_Click = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.login_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.film_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // login_data
            // 
            this.login_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.login_data.Location = new System.Drawing.Point(12, 12);
            this.login_data.Name = "login_data";
            this.login_data.Size = new System.Drawing.Size(243, 216);
            this.login_data.TabIndex = 1;
            // 
            // film_data
            // 
            this.film_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.film_data.Location = new System.Drawing.Point(12, 234);
            this.film_data.Name = "film_data";
            this.film_data.Size = new System.Drawing.Size(403, 216);
            this.film_data.TabIndex = 2;
            // 
            // dataGridView4
            // 
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Location = new System.Drawing.Point(12, 456);
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.Size = new System.Drawing.Size(403, 216);
            this.dataGridView4.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(261, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Login Admin";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(424, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Film";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(422, 456);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(27, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Pilet";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 678);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(403, 216);
            this.dataGridView1.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(424, 678);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Seanss";
            // 
            // btn_admin
            // 
            this.btn_admin.Location = new System.Drawing.Point(342, 145);
            this.btn_admin.Name = "btn_admin";
            this.btn_admin.Size = new System.Drawing.Size(75, 23);
            this.btn_admin.TabIndex = 13;
            this.btn_admin.Text = "Lisa";
            this.btn_admin.UseVisualStyleBackColor = true;
            this.btn_admin.Click += new System.EventHandler(this.btn_admin_Click);
            // 
            // box_pas
            // 
            this.box_pas.Location = new System.Drawing.Point(268, 109);
            this.box_pas.Name = "box_pas";
            this.box_pas.Size = new System.Drawing.Size(147, 20);
            this.box_pas.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(265, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Salasõna";
            // 
            // box_user
            // 
            this.box_user.Location = new System.Drawing.Point(268, 59);
            this.box_user.Name = "box_user";
            this.box_user.Size = new System.Drawing.Size(147, 20);
            this.box_user.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 43);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Admin";
            // 
            // Kustuta_button_Click
            // 
            this.Kustuta_button_Click.Location = new System.Drawing.Point(342, 174);
            this.Kustuta_button_Click.Name = "Kustuta_button_Click";
            this.Kustuta_button_Click.Size = new System.Drawing.Size(75, 23);
            this.Kustuta_button_Click.TabIndex = 14;
            this.Kustuta_button_Click.Text = "Delete";
            this.Kustuta_button_Click.UseVisualStyleBackColor = true;
            this.Kustuta_button_Click.Click += new System.EventHandler(this.Kustuta_button_Click_Click);
            // 
            // AdminPanel
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(926, 524);
            this.Controls.Add(this.Kustuta_button_Click);
            this.Controls.Add(this.btn_admin);
            this.Controls.Add(this.box_pas);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.box_user);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView4);
            this.Controls.Add(this.film_data);
            this.Controls.Add(this.login_data);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            ((System.ComponentModel.ISupportInitialize)(this.login_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.film_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
