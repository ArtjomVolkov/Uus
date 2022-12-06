using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CinamonCinema.Properties;

namespace CinamonCinema
{
    public partial class Info : Form
    {
        string name;
        SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\opilane\Source\Repos\Uus\CinamonCinema\CinamonCinema\Database1.mdf;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adapter_toode, adapter_kat;//adapter
        string str;
        SqlCommand com;
        string arrs;
        //string pikkus;
        List<string> arr = new List<string>()
        {
            "odin_doma",
            "ma4o",
            "time_for_me",
            "devnaja_smena",
            "vegas",
        };
        List<string> sa = new List<string>();

        public Info(string nAme)
        {
            
            name = nAme;
            this.Text = name;
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            for (int i = 0; i < arr.Count; i++)
            {
                PictureBox pictureBox = new PictureBox()
                {
                    Size = new Size(200, 400),
                    Location = new Point(10, 10),
                    Image = Image.FromFile("../../Images/" + name + ".jpg"),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                };
                Controls.Add(pictureBox);
            };
            if (name=="odin_doma")
            {
                lbl_film.Text = "Üksinda kodus";
                kestus.Text = "1:38 tundi";
                zanr.Text = "Komöödia";
                treiler_btn.Click += (e, s) => {
                    var prs = new ProcessStartInfo("chrome.exe");
                    prs.Arguments = "https://www.youtube.com/watch?v=bBU_64CTNsw";
                    Process.Start(prs);
                };
                rus.Click += (e, s) => {
                    info_lbl.Text = "«Один дома» – знаменитая семейная рождественская комедия от режиссера Криса Коламбуса о приключениях восьмилетнего Кевина, которого родители забыли дома в Рождество. Фильм «Один дома» является рекордсменом по кассовым сборам в жанре комедии. В главной роли снялся Маколей Калкин.";
                };
                est.Click += (e, s) =>
                {
                    info_lbl.Text = "Üksinda kodus on režissöör Chris Columbuse kuulus kogupere jõulukomöödia kaheksa-aastase Kevini seiklustest, kelle vanemad ta jõulude ajal koju jätsid.";
                };
                eng.Click += (e, s) =>
                {
                    info_lbl.Text = "Home Alone is a acclaimed family Christmas comedy from director Chris Columbus about the adventures of 8-year-old Kevin, whose parents forgot him at home on Christmas Day. Home Alone is the highest-grossing comedy movie starring Macaulay Culkin .";
                };
            }
            else if (name == "ma4o"){
                lbl_film.Text = "Macho ja nohik";
                kestus.Text = "1:33 tundi";
                zanr.Text = "Komöödia";
                treiler_btn.Click += (e, s) => {
                    var prs = new ProcessStartInfo("chrome.exe");
                    prs.Arguments = "https://www.youtube.com/watch?v=_p-Its6AzM4";
                    Process.Start(prs);
                };
                rus.Click += (e, s) => {
                    info_lbl.Text = "Двое новоиспеченных полицейских отправляются на сверхсекретное задание. Один – дока в том, чтобы физически подавить любого наглого правонарушителя, другой может спланировать любую операцию, предусмотрев все ее тонкости. Им предстоит заново стать учениками средней школы, в которой процветает наркоторговля.";
                };
                est.Click += (e, s) =>
                {
                    info_lbl.Text = "Kaks äsja vermitud politseinikku saadetakse ülisalajasele missioonile. Üks suudab iga jultunud kurjategija füüsiliselt maha võtta, teine ​​suudab planeerida mis tahes operatsiooni selle keerukustega. Nad kehastatakse ümber keskkoolina. õppijad, kellel on edukas narkokaubandus.";
                };
                eng.Click += (e, s) =>
                {
                    info_lbl.Text = "Two newly minted cops are sent on a top-secret mission. One is good at taking down any brazen offender physically, the other is able to plan any operation with the intricacies of it. They will be reincarnated as high school students with a thriving drug trade. ";
                };
            }
            else if (name == "time_for_me")
            {
                lbl_film.Text = "Aega iseendale";
                kestus.Text = "1:51 tundi";
                zanr.Text = "Komöödia";
                treiler_btn.Click += (e, s) => {
                    var prs = new ProcessStartInfo("chrome.exe");
                    prs.Arguments = "https://www.youtube.com/watch?v=Mmq_NVwLN_g";
                    Process.Start(prs);
                };
                rus.Click += (e, s) => {
                    info_lbl.Text = "Сонни и Майя — счастливая пара с двумя детьми. Она работает в архитектурном агентстве, он следит за хозяйством и воспитывает сына с дочерью. Когда друг юности Хак зовет Сонни на уик-энд в честь дня рождения, в размеренной жизни мужчины начинаются приключения.";
                };
                est.Click += (e, s) =>
                {
                    info_lbl.Text = "Sonny ja Maya on õnnelik paar, kellel on kaks last. Ta töötab arhitektuuribüroos, ta juhib majapidamist ning kasvatab poega ja tütart. Kui tema nooruspõlve sõber Hak kutsub Sonny sünnipäeva nädalavahetusele, mehe mõõdetud elus seiklus algab.";
                };
                eng.Click += (e, s) =>
                {
                    info_lbl.Text = "Sonny and Maya are a happy couple with two children. She works in an architectural agency, he runs the household and raises a son and daughter. When a friend of his youth, Hak, invites Sonny for a birthday weekend, in the measured life of a man the adventure begins.";
                };
            }
            else if (name == "devnaja_smena")
            {
                lbl_film.Text = "Päevane vahetus";
                kestus.Text = "1:03 tundi";
                zanr.Text = "Komöödia";
                treiler_btn.Click += (e, s) => {
                    var prs = new ProcessStartInfo("chrome.exe");
                    prs.Arguments = "https://www.youtube.com/watch?v=GN_IwBptKi4";
                    Process.Start(prs);
                };
                rus.Click += (e, s) => {
                    info_lbl.Text = "Долина Сан-Фернандо. С виду Бад Яблонски — обычный чистильщик бассейнов, но на самом деле он выслеживает и убивает вампиров, а также выдирает у них клыки, чтобы потом повыгоднее продать. Этим и живёт. Ещё Бад души не чает в 10-летней дочке, поэтому когда он узнаёт, что из-за нехватки денег бывшая жена собирается продать дом и увезти девочку к маме во Флориду, то решает быстро раздобыть необходимую сумму. А для этого Баду нужно срочно вернуться в профсоюз истребителей вампиров, из которого его выперли за многочисленные нарушения кодекса.";
                };
                est.Click += (e, s) =>
                {
                    info_lbl.Text = "San Fernando Valley. Bud Jablonski näeb välja nagu tavaline basseinipuhastaja, kuid tegelikult jahib ja tapab ta vampiire ning rebib ka nende kihvad välja, et neid parema hinnaga müüa. Nii ta elab. 10-aastane tütar, seega kui ta saab teada, et rahapuudusel kavatseb eksnaine maja maha müüa ja tüdruku Floridasse ema juurde viia, otsustab ta kiiresti vajaliku summa hankida.kes sai mitme koodirikkumise eest välja visatud.";
                };
                eng.Click += (e, s) =>
                {
                    info_lbl.Text = "San Fernando Valley. Bud Jablonski looks like a common pool cleaner, but in reality he hunts down and kills vampires, and also rips out their fangs to sell them for a better price. This is how he lives. in a 10-year-old daughter, so when he finds out that due to lack of money, the ex-wife is going to sell the house and take the girl to her mother in Florida, he decides to quickly get the necessary amount. who got kicked out for multiple code violations.";
                };
            }
            else if (name == "vegas")
            {
                lbl_film.Text = "Pohmelus";
                kestus.Text = "1:30 tundi";
                zanr.Text = "Komöödia";
                treiler_btn.Click += (e, s) => {
                    var prs = new ProcessStartInfo("chrome.exe");
                    prs.Arguments = "https://www.youtube.com/watch?v=QqVFXyaRL90";
                    Process.Start(prs);
                };
                rus.Click += (e, s) => {
                    info_lbl.Text = "Они мечтали устроить незабываемый мальчишник в Вегасе. Но теперь им необходимо вспомнить, что именно произошло: что за ребенок сидит в шкафу номера отеля? Как в ванную попал тигр? Почему у одного из них нет зуба? И, самое главное, куда делся жених? То, что парни вытворяли на вечеринке, не идет ни в какое сравнение с тем, что им придется сделать на трезвую голову, когда они будут шаг за шагом восстанавливать события прошлой ночи.";
                };
                est.Click += (e, s) =>
                {
                    info_lbl.Text = "Nad unistasid unustamatust poissmeesteõhtust Vegases. Nüüd aga peavad nad meeles pidama, mis täpselt juhtus: milline laps istub hotellitoa kapis? Kuidas tiiger vannituppa sattus? Miks kas ühel neist on hammas puudu? Ja mis kõige tähtsam: Kuhu on kihlatu kadunud? See, mida poisid peol tegid, pole midagi võrreldes sellega, mida nad peavad tegema, kui nad on kained, sündmusi samm-sammult uuesti looma eilsest õhtust.";
                };
                eng.Click += (e, s) =>
                {
                    info_lbl.Text = "They dreamed of having an unforgettable bachelor party in Vegas. But now they need to remember what exactly happened: what kind of child is sitting in the closet of the hotel room? How did the tiger get into the bathroom? Why is one of them missing a tooth? And, most importantly Where is the fiance gone? What the guys did at the party is nothing compared to what they will have to do when the are sober, step by step re-creating the events of last night.";                
                    };
            }
            Label fimlinimi = new Label()
            {
                Location = new Point(270, 30),
                Font = new Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186))),
            };
            Label date = new Label()
            {
                Text = DateTime.Now.ToString(),
                Location = new Point(470, 530),
                Font = new Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186))),
            };
            Label date1 = new Label()
            {
                Text = "Täna päev:",
                Location = new Point(410, 530),
            };
            Controls.Add(fimlinimi);
            Controls.Add(date);
            Controls.Add(date1);
        }
        private void pb_str5_Click(object sender, EventArgs e)
        {
            pb_str1.Image = Resources.yellow_star;
            pb_str2.Image = Resources.yellow_star;
            pb_str3.Image = Resources.yellow_star;
            pb_str4.Image = Resources.yellow_star;
            pb_str5.Image = Resources.yellow_star;
        }

        private void pb_str4_Click(object sender, EventArgs e)
        {
            //change yellow star to white
            pb_str5.Image = Resources.white_star;

            pb_str1.Image = Resources.yellow_star;
            pb_str2.Image = Resources.yellow_star;
            pb_str3.Image = Resources.yellow_star;
            pb_str4.Image = Resources.yellow_star;
        }

        private void pb_str3_Click(object sender, EventArgs e)
        {
            //change yellow stars to white
            pb_str4.Image = Resources.white_star;
            pb_str5.Image = Resources.white_star;

            pb_str1.Image = Resources.yellow_star;
            pb_str2.Image = Resources.yellow_star;
            pb_str3.Image = Resources.yellow_star;
        }

        private void pb_str2_Click(object sender, EventArgs e)
        {
            //change yellow stars to white
            pb_str3.Image = Resources.white_star;
            pb_str4.Image = Resources.white_star;
            pb_str5.Image = Resources.white_star;

            pb_str1.Image = Resources.yellow_star;
            pb_str2.Image = Resources.yellow_star;
        }

        private void pb_str1_Click(object sender, EventArgs e)
        {
            //change yellow stars to white
            pb_str2.Image = Resources.white_star;
            pb_str3.Image = Resources.white_star;
            pb_str4.Image = Resources.white_star;
            pb_str5.Image = Resources.white_star;

            pb_str1.Image = Resources.yellow_star;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Info_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Seanss form3 = new Seanss(name);
            form3.Show();
        }

        /*private void Info_Load(object sender, EventArgs e)
        {
            if (name.ToString() == label7.Text)
            {
            connect.Open();
            str = "select * from film";
            com = new SqlCommand(str, connect);
            SqlDataReader reader = com.ExecuteReader();

            reader.Read();
            lbl_film.Text = reader["nimetus_film"].ToString();
            reader.Close();
            connect.Close();

            
            connect.Open();
            SqlDataReader reader1 = com.ExecuteReader();
            reader1.Read();
            zanr.Text = reader1["zanr"].ToString();
            reader1.Close();
            connect.Close();

            
            connect.Open();
            SqlDataReader reader2 = com.ExecuteReader();
            reader2.Read();
            kestus.Text = reader2["kestus"].ToString();
            reader2.Close();
            connect.Close();

            
            connect.Open();
            SqlDataReader reader3 = com.ExecuteReader();
            reader3.Read();
            info_lbl.Text = reader3["info"].ToString();
            reader3.Close();
            connect.Close();
            }
        }*/
    }
}
