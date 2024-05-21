using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileMusicApp
{
    public partial class ChatControl : UserControl
    {
        public ChatControl()
        {
            InitializeComponent();
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; txtMess.Text = value; }
        }

        private string _dateCreated;

        public string DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; lblDateCreated.Text = value; }
        }


        public string Name
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }

        private void ChatControl_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblDateCreated_Click(object sender, EventArgs e)
        {

        }
    }
}
