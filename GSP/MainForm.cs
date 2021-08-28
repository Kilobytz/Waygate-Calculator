using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GSP
{
    public partial class MainForm : Form
    {
        WaygateManager wgm = new WaygateManager();
        double version = 0.2;
        public MainForm()
        {
            InitializeComponent();
            wgm.loadWaygates();
            comboBox1.Items.AddRange(wgm.getComboList());
            comboBox2.Items.AddRange(wgm.getComboList());
            label3.Text = version.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (comboBox1.SelectedIndex == -1 || comboBox2.SelectedIndex == -1)
            {
                textBox1.Text = "Error. Please input locations before calculating.";
            }
            if(comboBox1.SelectedIndex == comboBox2.SelectedIndex)
            {
                textBox1.Text = "Error. Both inputs are identical.";
            }
            else
            {
                GSCalc calculation = new GSCalc(wgm.getWaygate(comboBox1.Text), wgm.getWaygate(comboBox2.Text), wgm.getWaygates());
                Dictionary<String, String> path = calculation.getEntirePath();
                textBox1.Text += "Total Trips: " + calculation.getTrips();
                textBox1.Text += Environment.NewLine;
                foreach (KeyValuePair<String, String> data in path)
                {
                    textBox1.Text += (data.Key + " - " + data.Value);
                    textBox1.Text += Environment.NewLine;
                }
            }
        }
    }
}
