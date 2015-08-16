using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;



namespace win10privacyfix2
{
    public partial class win10privacyfix2 : Form
    {
        public win10privacyfix2()
        {
            InitializeComponent();
            
        }
        //todo: admin check to read/write from HKLM

        

        private void b_check_Click(object sender, EventArgs e)
        {
            //ToolStripProgressBar;

            b_check.Text = "checking...";
            b_diag.Enabled = true;
            b_dmw.Enabled = true;
            b_geo.Enabled = true;
            b_p2p.Enabled = true;
            b_pri_ads.Enabled = true;
            b_pri_freq.Enabled = true;
            b_pri_local.Enabled = true;
            b_pri_smart.Enabled = true;
            b_pri_tele.Enabled = true;
            b_pri_write.Enabled = true;
            //b_winup_start.Enabled = true;
            //b_winup_stop.Enabled = true;
            b_defender_net.Enabled = true;
            b_defender_sam.Enabled = true;
            b_def_c.Enabled = true;

            ///
            // Check Service
            ///

            ///
            // Check Pri
            ///

            //string string_p2p = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config", "DODownloadMode", null);


            ///
            // Check Apps
            ///

            ///
            // Check Misc
            ///
            b_check.Text = "check";

        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //bool isgerman = true;
            //b_us.Enable = false;
            b_check.Text = "überprüfen";
            c_pri_ads.Text = "Werbung....";
            c_pri_freq.Text = "blaaaaa";
            c_pri_local.Text = "blaaaaa";
            c_pri_smart.Text = "blaaaaa";
            c_pri_tele.Text = "blaaaaa";
            c_pri_write.Text = "blaaaaa";
        }
        
        private void b_us_Click(object sender, EventArgs e)
        {
            //todo
            //if (!isgerman)
            //{
             //   MessageBox.Show("To switch to english, start the app again");
           // }

           // if (isgerman)
             //   {
          //      MessageBox.Show("To switch to english, start the app again");
           // }

            
        }

        private void b_blog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://wiiare.in/windows-10-privacy-fixer/");
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.reddit.com/r/conspiracy/comments/3fhy27/how_do_disable_all_privacy_leaks_in_windows_10/ctq3p3m");
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://creativecommons.org/licenses/by-nc-sa/4.0/"); 
        }
    }
}
