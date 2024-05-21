using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=DESKTOP-U3OF399\\TXMMINH;Initial Catalog=MOBILE_APP;Integrated Security=True";

        public string SongId { get; set; }
        public string SongPath
        {
            get { return lblSongPath.Text; }
            set { 
                lblSongPath.Text = value;
                axWindowsMediaPlayer1.URL = value;
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }
        public string SongName
        {
            get { return lblSongName.Text; }
            set { lblSongName.Text = value; }
        }
        public string Singer
        {
            get { return lblSinger.Text; }
            set { lblSinger.Text = value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); 
            form1.Show(); 
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string sql;

            sql = "insert into chats(name, message, date_created) values " +
                "(@name, @message, @date_created)";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@name", txtName.Text);
            cmd.Parameters.AddWithValue("@message", txtMessage.Text);
            cmd.Parameters.AddWithValue("@date_created", DateTime.Now);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageChat();
            txtName.Clear();
            txtMessage.Clear();
        }

        private void MessageChat()
        {
            string query = "select * from chats order by date_created";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        flowLayoutPanel1.Controls.Clear();

                        while (reader.Read())
                        {
                            ChatControl chatControl = new ChatControl
                            {
                                Name = reader["name"].ToString(),
                                Title = reader["message"].ToString(),
                                DateCreated = reader["date_created"].ToString(), 
                                Dock = DockStyle.Top
                            }; 
                            flowLayoutPanel1.Controls.Add(chatControl);
                            flowLayoutPanel1.ScrollControlIntoView(chatControl);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
/*            string songPath = lblSongPath.Text;

            axWindowsMediaPlayer1.URL = songPath;
            axWindowsMediaPlayer1.Ctlcontrols.play();*/
        }

        private void lblSongName_Click(object sender, EventArgs e)
        {

        }
    }
}
