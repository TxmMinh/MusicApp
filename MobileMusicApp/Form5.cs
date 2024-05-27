using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class Form5 : Form
    {
        string connectionString = "Data Source=DESKTOP-U3OF399\\TXMMINH;Initial Catalog=MOBILE_APP;Integrated Security=True";

        private string playlistID;

        public Form5(string playlistID)
        {
            this.playlistID = playlistID;
            InitializeComponent();
            string query = "SELECT * FROM songs " +
                           "JOIN playlist_song ON songs.song_id = playlist_song.song_id " +
                           "WHERE playlist_song.playlist_id = @playlistId";
            LoadSongs(query);
        }
         
        public string Name
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SongControl.HandleCommand("stop");
            this.Close();
        }

        private void LoadSongs(string query)
        {
            SongControl.HandleCommand("stop");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm tham số @playlistId vào câu lệnh SQL
                    command.Parameters.AddWithValue("@playlistId", playlistID);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Reset flowLayoutPanel1
                        ResetFlowLayoutPanel();

                        while (reader.Read())
                        {
                            SongControl songControl = new SongControl("playlist");
                            songControl.SongId = reader["song_id"].ToString();
                            songControl.SongPath = reader["path"].ToString();
                            songControl.SongName = reader["song_name"].ToString();
                            songControl.Singer = reader["singer"].ToString();
                            songControl.IsLoveSong = (int)reader["is_love"];
                            songControl.ImagePath = reader["image_path"].ToString();
                            songControl.PlaylistId = playlistID;
                            
                            songControl.UpdateStatusLoveSong(songControl.IsLoveSong);
                            flowLayoutPanel1.Controls.Add(songControl);
                        }
                    }
                }
            }
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
    }
}
