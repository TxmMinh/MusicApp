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
        private string songPath;

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
        public string ImagePath
        {
            get; set;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
            this.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter Name!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else if (string.IsNullOrEmpty(txtMessage.Text))
            {
                MessageBox.Show("Please enter message!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
            }
            else
            {
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string sql;

                sql = "insert into chats(name, message, date_created, song_id) values " +
                    "(@name, @message, @date_created, @song_id)";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@name", txtName.Text);
                cmd.Parameters.AddWithValue("@message", txtMessage.Text);
                cmd.Parameters.AddWithValue("@date_created", DateTime.Now);
                cmd.Parameters.AddWithValue("@song_id", SongId);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageChat();
                txtName.Clear();
                txtMessage.Clear();
            }
        }
         
        private void MessageChat()
        {
            string query = "select * from chats where song_id = @song_id order by date_created";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@song_id", SongId);
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
            MessageChat();

            string songPath = lblSongPath.Text;

            // Check if the song path is not empty and the file exists
            if (!string.IsNullOrEmpty(songPath) && System.IO.File.Exists(songPath))
            {
                axWindowsMediaPlayer1.URL = songPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                InsertRecents();
            }
            else
            {
                MessageBox.Show("The song path is invalid or the file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Kiểm tra và hiển thị hình ảnh
            if (!string.IsNullOrEmpty(ImagePath) && System.IO.File.Exists(ImagePath))
            {
                pictureBoxImage.Image = Image.FromFile(ImagePath);
            }
            else
            {
                MessageBox.Show("The image path is invalid or the file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertRecents()
        {
            string query_delete = "DELETE FROM recents WHERE song_id = @songId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query_delete, connection))
                {
                    command.Parameters.AddWithValue("@songId", SongId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            string query = "INSERT INTO recents (song_id) VALUES (@songId)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@songId", SongId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        private void lblSongName_Click(object sender, EventArgs e)
        {

        }
    }
}
