using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ToolStrip strip = new ToolStrip();
            strip.Name = "Test"; 
            ToolStripButton button1 = new ToolStripButton("Test");
            strip.Items.Add(button1);
            this.Controls.Add(strip);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ToolStripButton button1 = new ToolStripButton("Aap");
               
            ToolStrip strip;

            Control[] controls = this.Controls.Find("Test",false);
            if (controls.Any())
            {
                strip = controls[0] as ToolStrip;
            }
            else
            {
                strip = new ToolStrip();
            }

             strip.Items.Add(button1);
            this.Controls.Add(strip);
        }
    }
}
