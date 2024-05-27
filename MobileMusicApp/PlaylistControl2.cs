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
    public partial class PlaylistControl2 : UserControl
    {
        public PlaylistControl2()
        {
            InitializeComponent();
        }

        string connectionString = "Data Source=DESKTOP-U3OF399\\TXMMINH;Initial Catalog=MOBILE_APP;Integrated Security=True";

        public string Name
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        public string PlaylistID { get; set; }

        private void btnDeletePlaylist_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM playlist_song WHERE playlist_id = @playlist_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@playlist_id", PlaylistID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }

            string query_delete = "DELETE FROM playlist WHERE playlist_id = @playlist_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query_delete, connection))
                {
                    command.Parameters.AddWithValue("@playlist_id", PlaylistID);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            MessageBox.Show("Delete Playlist succesfully. Please returns to the main screen to load!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void ShowPlaylist_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(PlaylistID); 
            form5.Name = Name;
            form5.ShowDialog();
        }
    }
}
