using System;
using System.Windows.Forms;

namespace FinalProject40S
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //place random paths, planes, and airports
            Data one = new Data(null, new System.Drawing.Point(1, 1), 100, 100, "aaa");

            //Aircraft test = new Aircraft(one);

            List list = new List();
        }
    }
}
