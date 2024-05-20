using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class DownloadControl : UserControl
    {
        public DownloadControl()
        {
            InitializeComponent();
        }

        public string SongId { get; set; } 
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

        public string DateDownLoad
        {
            get { return lblDate.Text; }
            set { lblDate.Text = value; }
        }
    }
}
