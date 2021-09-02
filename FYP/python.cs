using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;

namespace FYP
{
    public partial class python : Form
    {
        public python()
        {
            InitializeComponent();
        }

 

        private void button1_Click_1(object sender, EventArgs e)
        {
            var py = Python.CreateEngine();
            try
            {


                py.ExecuteFile("C:\\Users\\mbhba\\Desktop\\Gmap\\Gmap\\AI project\\app.py");


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
        }
    }
}
