using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class PlaylistControl : UserControl
    {
        public PlaylistControl()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=DESKTOP-U3OF399\\TXMMINH;Initial Catalog=MOBILE_APP;Integrated Security=True";

        public string Name
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string SongId { get; set; }

        private string playlist_id;

        private string GetPlayListID()
        {
            string query = "SELECT playlist_id FROM playlist WHERE name_playlist = @name_playlist";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@name_playlist", Name);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            playlist_id = reader["playlist_id"].ToString();
                        } else
                        {
                            playlist_id = null;
                        }
                    }
                }
                connection.Close();
            } 
            return playlist_id;
        }


        private void addToPlaylist_Click(object sender, EventArgs e)
        {
            playlist_id = GetPlayListID();
            if (playlist_id != null)
            {
                string query = "INSERT INTO playlist_song VALUES (@playlist_id, @song_id)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@playlist_id", playlist_id);
                        command.Parameters.AddWithValue("@song_id", SongId);
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Add successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }
            } else
            {
                MessageBox.Show("An error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
