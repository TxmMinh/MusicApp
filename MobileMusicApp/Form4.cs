using AxWMPLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=DESKTOP-U3OF399\\TXMMINH;Initial Catalog=MOBILE_APP;Integrated Security=True";

        private void btnExit_Click(object sender, EventArgs e)
        { 
            this.Close();
        }

        private void addNewPlaylist_Click(object sender, EventArgs e)
        {
            panel1.Hide();
            flowLayoutPanel1.Hide();
        }

        private void btnCreatePlaylist_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNamePlaylist.Text))
            {
                MessageBox.Show("Please enter Name!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamePlaylist.Focus();
            }
            else
            {
                string query = "INSERT INTO playlist VALUES (@name_playlist)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@name_playlist", txtNamePlaylist.Text);
                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Create successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    connection.Close();
                }
                txtNamePlaylist.Clear();
                panel1.Show();
                flowLayoutPanel1.Show();
                LoadPlaylist();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            panel1.Show();
            flowLayoutPanel1.Show();
            LoadPlaylist();
        }

        private void LoadPlaylist()
        {
            string query = "select * from playlist order by playlist_id desc";
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
                            PlaylistControl2 playlistControl2 = new PlaylistControl2
                            {
                                Name = reader["name_playlist"].ToString(),
                                PlaylistID = reader["playlist_id"].ToString(),
                                Dock = DockStyle.Top
                            };
                            flowLayoutPanel1.Controls.Add(playlistControl2);
                            flowLayoutPanel1.ScrollControlIntoView(playlistControl2);
                        }
                    }
                }
                connection.Close();
            }
        }

    }
}
