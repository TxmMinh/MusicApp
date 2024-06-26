﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class SongControl : UserControl
    {
        string connectionString = "Data Source=DESKTOP-U3OF399\\TXMMINH;Initial Catalog=MOBILE_APP;Integrated Security=True";

        private static SongControl currentlyPlayingControl = null;

        public string SongId { get; set; }
        public string SongPath { get; set; }
        public string ImagePath { get; set; }

        public string Isplaylist { get; set; }

        public string PlaylistId { get; set; }

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
        public int IsLoveSong { get; set; }


        public static SongControl CurrentlyPlayingControl
        {
            get { return currentlyPlayingControl; }
            set
            {
                if (currentlyPlayingControl != null && currentlyPlayingControl != value)
                {
                    currentlyPlayingControl.Stop();
                }
                currentlyPlayingControl = value;
            }
        }

        public SongControl()
        {
            InitializeComponent();
            pcBoxDelete.Hide();
            btnPlaylist.Show();
        }

        public SongControl(string isplaylist)
        {
            InitializeComponent(); 
            pcBoxDelete.Show();
            btnPlaylist.Hide(); 

        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (currentlyPlayingControl != null && currentlyPlayingControl != this)
            {
                currentlyPlayingControl.Stop();
            }

            if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                axWindowsMediaPlayer1.Ctlcontrols.pause();
                btnPlay.Image = Properties.Resources._352074_circle_play_icon;
            }
            else
            {
                axWindowsMediaPlayer1.URL = SongPath;
                axWindowsMediaPlayer1.Ctlcontrols.play();
                btnPlay.Image = Properties.Resources._809530_pause_icon;
                currentlyPlayingControl = this;
                // insert song to recents
                DeleteValueInRecents();
                InsertRecents();
            }
        }

        public void Stop()
        {
            try
            {
                if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
                {
                    axWindowsMediaPlayer1.Ctlcontrols.stop();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            btnPlay.Image = Properties.Resources._352074_circle_play_icon;

        }

        public static void HandleCommand(string command)
        {
            if (command.ToLower() == "stop")
            {
                if (CurrentlyPlayingControl != null)
                {
                    CurrentlyPlayingControl.Stop();
                }
            }
        }
         

        private void btnLove_Click(object sender, EventArgs e)
        {
            if (IsLoveSong == 0) // set to love song
            {
                IsLoveSong = 1;
                btnLove.Image = Properties.Resources._2203510_favorite_black_icon;
                UpdateLoveStatus(IsLoveSong);
            }
            else // set to not love song
            {
                IsLoveSong = 0;
                btnLove.Image = Properties.Resources._3643770_favorite_white_icon;
                UpdateLoveStatus(IsLoveSong);
            }

        }

        public void UpdateStatusLoveSong(int isLove)
        {
            if (isLove == 1)  
            {
                btnLove.Image = Properties.Resources._2203510_favorite_black_icon;
            }
            else  
            {
                btnLove.Image = Properties.Resources._3643770_favorite_white_icon;
            }

        }

        private void UpdateLoveStatus(int loveSong)
        {
            string query = "UPDATE songs SET is_love = @isLove WHERE song_id = @songId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@isLove", IsLoveSong);
                    command.Parameters.AddWithValue("@songId", SongId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }   
        }
        private void DeleteValueInRecents()
        {
            string query = "DELETE FROM recents WHERE song_id = @songId";
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

        private void InsertDownload()
        {
            string query = "INSERT INTO download VALUES (@songId, GETDATE())";
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

        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = Path.GetFileName(SongPath);
                string savePath = Path.Combine("E:\\Music-Download\\", fileName);

                int count = 0;
                string newFileName = fileName;
                while (File.Exists(Path.Combine("E:\\Music-Download\\", newFileName)))
                {
                    count++;
                    string extension = Path.GetExtension(fileName);
                    string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                    newFileName = $"{fileNameWithoutExtension}({count}){extension}";
                }

                savePath = Path.Combine("E:\\Music-Download\\", newFileName);   

                File.Copy(SongPath, savePath);

                InsertDownload();

                MessageBox.Show("Download Successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Download Error: " + ex.Message);
            }
        }

        private static Boolean showDetail = false; 
        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            Stop();
            Form2 detailSong = new Form2();
            detailSong.SongId = SongId;
            detailSong.SongName = SongName;
            detailSong.Singer = Singer;
            detailSong.SongPath = SongPath;
            detailSong.ImagePath = ImagePath;
            detailSong.ShowDialog();
        }

        private void btnPlaylist_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.SongId = SongId;
            form3.ShowDialog();
        }

        private void SongControl_Load(object sender, EventArgs e)
        {

        }

        private void pcBoxDelete_Click(object sender, EventArgs e)
        {
            string query_delete = "DELETE FROM playlist_song WHERE song_id = @songId and playlist_id = @playlist_id";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query_delete, connection))
                {
                    command.Parameters.AddWithValue("@playlist_id", PlaylistId);
                    command.Parameters.AddWithValue("@songId", SongId);
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
            MessageBox.Show("Delete Playlist succesfully. Please returns to the main screen to load!", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
