using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=DESKTOP-U3OF399\\TXMMINH;Initial Catalog=MOBILE_APP;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            string query = "SELECT * FROM songs";
            LoadSongs(query);
        }

        private void ResetFlowLayoutPanel()
        {
            // Dispose all controls in flowLayoutPanel1
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                control.Dispose();
            }
            flowLayoutPanel1.Controls.Clear();
        }

        private void LoadSongs(string query)
        {
            SongControl.HandleCommand("stop");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        // Reset flowLayoutPanel1
                        ResetFlowLayoutPanel();
                        while (reader.Read())
                        {
                            SongControl songControl = new SongControl
                            {
                                SongId = reader["song_id"].ToString(),
                                SongPath = reader["path"].ToString(),
                                SongName = reader["song_name"].ToString(),
                                Singer = reader["singer"].ToString(),
                                IsLoveSong = (int)reader["is_love"],
                                Dock = DockStyle.Top
                            };
                            songControl.UpdateStatusLoveSong(songControl.IsLoveSong);
                            flowLayoutPanel1.Controls.Add(songControl);
                        }
                    }
                }
                connection.Close();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pcBoxSongs_Click(object sender, EventArgs e)
        {
            panelSongs.Visible = true; 
            panelTitle.Visible = false;
            panelSongs.BringToFront();
            string query = "SELECT * FROM songs";
            LoadSongs(query);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM songs";
            LoadSongs(query);
        }

        private void btnVN_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM songs where category='VN'";
            LoadSongs(query);
        }

        private void btnEn_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM songs where category='EN'";
            LoadSongs(query);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnFindSong_Click(object sender, EventArgs e)
        {
            string searchText = txtBoxFindSong.Text;
            SearchSongs(searchText);
        }

        private void SearchSongs(string searchText)
        {
            SongControl.HandleCommand("stop"); 

            string query = "SELECT * FROM songs " +
                       "WHERE song_name LIKE @searchText or singer LIKE @searchText";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@searchText", "%" + searchText + "%");

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        ResetFlowLayoutPanel();

                        while (reader.Read())
                        {
                            SongControl songControl = new SongControl
                            {
                                SongId = reader["song_id"].ToString(),
                                SongPath = reader["path"].ToString(),
                                SongName = reader["song_name"].ToString(),
                                Singer = reader["singer"].ToString(),
                                IsLoveSong = (int)reader["is_love"],
                                Dock = DockStyle.Top
                            };
                            songControl.UpdateStatusLoveSong(songControl.IsLoveSong);
                            flowLayoutPanel1.Controls.Add(songControl);
                        }
                    }
                }
                connection.Close();
            }
        }

        private void pcBoxLove_Click(object sender, EventArgs e)
        {
            panelTitle.Visible = true;
            lblTitle.Text = "Your Favorite Song";
            panelTitle.BringToFront();
            string query = "SELECT * FROM songs WHERE is_love=1";
            LoadSongs(query);
        }

        private void pcBoxHome_Click(object sender, EventArgs e)
        {
            panelTitle.Visible = true;
            lblTitle.Text = "Listening history";
            panelTitle.BringToFront();
            string query = "SELECT * FROM songs INNER JOIN recents on songs.song_id = recents.song_id ORDER BY recents.id DESC";
            LoadSongs(query);

        }

        private void pcBoxDownload_Click(object sender, EventArgs e)
        {
            panelTitle.Visible = true;
            lblTitle.Text = "Your DownLoad Song";
            panelTitle.BringToFront();
            string query = "SELECT * FROM songs INNER JOIN download on songs.song_id = download.song_id";
            LoadDownLoad(query);
        }

        private void LoadDownLoad(string query)
        { 
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        // Reset flowLayoutPanel1
                        ResetFlowLayoutPanel();
                        while (reader.Read())
                        {
                            DownloadControl downloadControl = new DownloadControl
                            {
                                SongId = reader["song_id"].ToString(), 
                                SongName = reader["song_name"].ToString(),
                                Singer = reader["singer"].ToString(),
                                DateDownLoad = reader["download_date"].ToString(),
                                Dock = DockStyle.Top
                            }; 
                            flowLayoutPanel1.Controls.Add(downloadControl);
                        }
                    }
                }
                connection.Close();
            }

        }

    }
}
