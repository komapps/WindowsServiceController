using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsServiceController
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var services = ServiceController.GetServices().Select(a => a.ServiceName).ToList();
            listBox1.DataSource = services;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedNames = listBox1.SelectedItems.Cast<string>();
            var selectedServices = ServiceController.GetServices().Where(a => selectedNames.Contains(a.ServiceName));

            foreach (var serviceController in selectedServices)
            {
                serviceController.Start();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedNames = listBox1.SelectedItems.Cast<string>();
            var selectedServices = ServiceController.GetServices().Where(a => selectedNames.Contains(a.ServiceName));

            foreach (var serviceController in selectedServices)
            {
                serviceController.Stop();
            }
        }
    }
}
