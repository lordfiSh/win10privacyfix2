using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Win32;
using System.Net.NetworkInformation;
using System.IO;
//using System.Management;
using System.Diagnostics;
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
            b_misc_god.Enabled = true;

            ///
            // Check Service
            ///

            

            //RegistryKey rk = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Wow6432Node\\Policies\\Microsoft\\Windows Defender\\DisableAntiSpyware");

          

            ///
            // Check Pri
            ///

            //string string_p2p = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\DeliveryOptimization\Config", "DODownloadMode", null);
            Microsoft.Win32.RegistryKey AdvertisingInfo;
            AdvertisingInfo = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", true);
            if (AdvertisingInfo.GetValue("Enabled").ToString() == "1")
            {
                c_pri_ads.Checked = true;
                c_pri_ads.Text = "You have a personalisied advert ID (?)";
               
            }
            if (AdvertisingInfo.GetValue("Enabled").ToString() == "0")
            {
                c_pri_ads.Checked = false;
                c_pri_ads.Text = "You don't have a personalisied advert ID";
            }


            Microsoft.Win32.RegistryKey EnableWebContentEvaluation;
            EnableWebContentEvaluation = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost", true);
            if (EnableWebContentEvaluation.GetValue("EnableWebContentEvaluation").ToString() == "1")
            {
                c_pri_smart.Checked = true;
                c_pri_smart.Text = "SmartScreen Filter is active";
            }
            if (EnableWebContentEvaluation.GetValue("EnableWebContentEvaluation").ToString() == "0")
            {
                c_pri_smart.Checked = false;
                c_pri_smart.Text = "SmartScreen Filter is disabled";
            }


            Microsoft.Win32.RegistryKey TIPC;
            TIPC = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Input\\TIPC", true);
            if (TIPC.GetValue("Enabled").ToString() == "1")
            {
                c_pri_write.Checked = true;
                c_pri_write.Text = "Send Infos about typing and writing is enabled";
            }
            if (TIPC.GetValue("Enabled").ToString() == "0")
            {
                c_pri_write.Checked = false;
                c_pri_write.Text = "Send Infos about typing and writing is disabled";
            }


            Microsoft.Win32.RegistryKey HttpAcceptLanguageOptOut;
            HttpAcceptLanguageOptOut = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Control Panel\\International\\User Profile", true);
            //todo: handle error, if key issnt there
            if (HttpAcceptLanguageOptOut.GetValue("HttpAcceptLanguageOptOut").ToString() == "1")
            {
                c_pri_local.Checked = false;
                c_pri_local.Text = "Websites cant access lanmguage list";
            } 
            else {
                c_pri_local.Checked = true;
                c_pri_local.Text = "Websites can access lanmguage list";
            }

            Microsoft.Win32.RegistryKey NumberOfSIUFInPeriod;
            NumberOfSIUFInPeriod = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Siuf\\Rules", true);
            //todo: handle error, if key issnt there
            if (NumberOfSIUFInPeriod.GetValue("NumberOfSIUFInPeriod").ToString() == "0")
            {
                c_pri_freq.Checked = false;
                c_pri_freq.Text = "Feedback frequency disabled";
            }
            if(NumberOfSIUFInPeriod.GetValue("NumberOfSIUFInPeriod").ToString() == "1")
            {
                c_pri_freq.Checked = true;
                c_pri_freq.Text = "Feedback frequency not disabled";
            }

            Microsoft.Win32.RegistryKey lfsvc;
            lfsvc = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\lfsvc", true);
            //todo: handle error, if key issnt there
            if (lfsvc.GetValue("Start").ToString() == "4")
            {
                c_service_geo1.Checked = false;
                c_service_geo1.Text = "Geolocation Service Startup type: disabled";
            }
            if (lfsvc.GetValue("Start").ToString() == "3")
            {
                c_service_geo1.Checked = true;
                c_service_geo1.Text = "Geolocation Service Startup type: manual";


            }

            Microsoft.Win32.RegistryKey dmwappushservice;
            dmwappushservice = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\dmwappushservice", true);
            //todo: handle error, if key issnt there
            if (dmwappushservice.GetValue("Start").ToString() == "4")
            {
                c_service_dmw1.Checked = false;
                c_service_dmw1.Text = "dmwappush Service Startup type: disabled";
            }
            if (dmwappushservice.GetValue("Start").ToString() == "3")
            {
                c_service_dmw1.Checked = true;
                c_service_dmw1.Text = "dmwappush Service Startup type: manual";


            }

            Microsoft.Win32.RegistryKey DiagTrack;
            DiagTrack = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\DiagTrack", true);
            //todo: handle error, if key issnt there
            if (DiagTrack.GetValue("Start").ToString() == "4")
            {
                c_service_diag1.Checked = false;
                c_service_diag1.Text = "DiagTrack Service Startup type: disabled";
            }
            if (DiagTrack.GetValue("Start").ToString() == "3")
            {
                c_service_diag1.Checked = true;
                c_service_diag1.Text = "DiagTrack Service Startup type: manual";


            }

            Microsoft.Win32.RegistryKey CurrentVersion;
            CurrentVersion = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", true);
            //todo: handle error, if key issnt there
            infotext.Text = "Windows 10 " + CurrentVersion.GetValue("EditionID").ToString();


            Ping myPing = new Ping();
            string host = "vortex.data.microsoft.com";
            byte[] buffer = new byte[32];
            int timeout = 1000;

            // PingOptions übernimmt alle notwendigen Optionen
            PingOptions pingOptions = new PingOptions();

            try
            {
                // Den Ping mit Hilfe von PingReply ausführen
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);

                // Den zurückgelieferten Wert von PingReply abfragen
                if (reply.Address.ToString() == "127.0.0.1")
                {
                    // erfolgreich
                    c_pri_tele.Checked = false;
                    c_pri_tele.Text = "Mircosoft Telemetry Hosts blocked";
                }
                if (reply.Address.ToString() == "191.232.139.254")
                {
                    // erfolgreich
                    c_pri_tele.Checked = true;
                    c_pri_tele.Text = "Mircosoft Telemetry Hosts not blocked";
                }
                else if (reply.Status == IPStatus.TimedOut)
                {
                    // fehlgeschlagen
                    MessageBox.Show("Ping fehlgeschlagen", "Fehler");
                }
            }

            catch (Exception ex)
            {
                // weitere Fehler abfangen
                MessageBox.Show(ex.Message);
            }


            string curFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts_pre_win10privacyfix2");
            if (File.Exists(curFile))
            {
                b_pri_tele.Text = "restore";
                // todo

           
            }




            // todo Service Klasse geht nicht
            // var msDtcSvc = new System.ServiceProcess.ServiceController("DiagTrack");
            // { 
            //     if (msDtcSvc.Status == System.ServiceProcess.ServiceControllerStatus.Stopped)
            //     {
            //         c_service_diag1.Checked = false;
            //         c_service_diag1.Text = "DiagTrack Service is not running"; 
            //     }
            // }


            // Microsoft.Win32.RegistryKey DODownloadMode;
            // DODownloadMode = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\DeliveryOptimization\\Config", true);
            // //todo: handle error, if key issnt there
            // //todo: read for 64
            // if (DODownloadMode.GetValue("NumberOfSIUFInPeriod").ToString() == "0")
            // {
            //     c_p2p.Checked = false;
            //     c_p2p.Text = "P2P Updates are disabled";
            // }
            // if (DODownloadMode.GetValue("NumberOfSIUFInPeriod").ToString() == "1")
            // {
            //     c_p2p.Checked = true;
            //     c_p2p.Text = "P2P Updates are enabled for: local network";
            // }
            // if (DODownloadMode.GetValue("NumberOfSIUFInPeriod").ToString() == "3")
            // {
            //     c_p2p.Checked = true;
            //     c_p2p.Text = "P2P Updates are enabled for: internet & network";
            // }





            ///
            // Check Apps
            ///

            ///
            // Check Misc
            ///
            
            //MessageBox.Show(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Local\\Microsoft\\OneDrive\\OneDrive.exe"));
            //string onedrivepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Local\\Microsoft\\OneDrive\\OneDrive.exe");
            string onedrivepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "AppData\\Local\\Microsoft\\OneDrive\\OneDrive.exe");
            if (File.Exists(onedrivepath))
            {
                bool onedriveexethere = true;
                c_misc_onedrive.Checked = true;
                c_misc_onedrive.Text = "OneDrive installed";
            }

            // todo, check if process is running

            // todo fix Ordner Check
            string godmode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop\\GodMode.{ED7BA470-8E54-465E-825C-99712043E01C}");
            if (Directory.Exists(godmode)) {
                c_misc_god.Checked = true;
                c_misc_god.Text = "Godmode on Desktop";
                b_misc_god.Enabled = false;
            }





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

        private void b_pri_smart_Click(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppHost", true);
            if (key.GetValue("EnableWebContentEvaluation").ToString() == "0")
            { MessageBox.Show("Yes");
            }
            //RegWrite("HKCU\SOFTWARE\Microsoft\Windows\CurrentVersion\AppHost\", "EnableWebContentEvaluation", "REG_DWORD", "0")
        }

        private void c_pri_ads_MouseHover(object sender, EventArgs e)
        {
            Microsoft.Win32.RegistryKey AdvertisingInfo;
            AdvertisingInfo = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AdvertisingInfo", true);
            if (AdvertisingInfo.GetValue("Enabled").ToString() == "1")
            {
                c_pri_ads.Enabled = true;
                infotext.Text = AdvertisingInfo.GetValue("ID").ToString();
            }
          
        }

        private void c_pri_ads_MouseLeave(object sender, EventArgs e)
        {
            infotext.Text = "";
        }

        private void b_pri_tele_Click(object sender, EventArgs e)
        {
            string curFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts_pre_win10privacyfix2");
            if (File.Exists(curFile)) {
                b_pri_tele.Text = "restore";
            }
            else {
               File.Copy((Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts")), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts_pre_win10privacyfix2"), true);
            }
             



            using (StreamWriter w = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts")))
            {
                w.WriteLine("");
                w.WriteLine("### Block MS Telemetry Hosts - win10privacyfix2");
                w.WriteLine("127.0.0.1 vortex.data.microsoft.com");
                w.WriteLine("127.0.0.1 vortex-win.data.microsoft.com");
                w.WriteLine("127.0.0.1 telecommand.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 telecommand.telemetry.microsoft.com.nsatc.net");
                w.WriteLine("127.0.0.1 oca.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 oca.telemetry.microsoft.com.nsatc.net");
                w.WriteLine("127.0.0.1 sqm.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 sqm.telemetry.microsoft.com.nsatc.net");
                w.WriteLine("127.0.0.1 watson.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 watson.telemetry.microsoft.com.nsatc.net");
                w.WriteLine("127.0.0.1 redir.metaservices.microsoft.com");
                w.WriteLine("127.0.0.1 choice.microsoft.com");
                w.WriteLine("127.0.0.1 choice.microsoft.com.nsatc.net");
                w.WriteLine("127.0.0.1 df.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 reports.wes.df.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 services.wes.df.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 sqm.df.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 watson.ppe.telemetry.microsoft.com");
                w.WriteLine("127.0.0.1 telemetry.appex.bing.net");
                w.WriteLine("127.0.0.1 telemetry.urs.microsoft.com");
                w.WriteLine("127.0.0.1 settings-sandbox.data.microsoft.com");
                w.WriteLine("127.0.0.1 vortex-sandbox.data.microsoft.com");
            }

    }

        private void b_misc_god_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop\\GodMode.{ED7BA470-8E54-465E-825C-99712043E01C}"));
            string godmode = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Desktop\\GodMode.{ED7BA470-8E54-465E-825C-99712043E01C}");
            Directory.CreateDirectory(godmode);
        }
    }
}
