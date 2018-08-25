using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsSysTrayNotificationApp
{
    public class NotificationApp : ApplicationContext
    {
        private NotifyIcon trayIcon;
        public NotificationApp()
        {
            StartProcess();

            LoadCache();

            
            StopProcess();
            Shutdown();

        }
    void StartProcess()
        {
            SetRunningIcon();
        }
    void StopProcess()
        {
            SetFinishedIcon();
        }
    void LoadCache()
        {
            Thread.Sleep(30000);
        }
    void CreateNotifyIcon()
        {
            if (trayIcon == null)
            {
                trayIcon = new NotifyIcon()
                {
                    Icon = WindowsSysTrayNotificationApp.Properties.Resources.Tally,
                    ContextMenu = new ContextMenu(new MenuItem[] {
                        new MenuItem("Info",Info)


            }),
                    Visible = true
                };
                trayIcon.Text = "BizBrain Agent Cache Loader";
               
            }
        }


        void Info(Object sender, EventArgs e) { }
        void SetRunningIcon()
        {

            try
            {
                CreateNotifyIcon();
                trayIcon.Icon = WindowsSysTrayNotificationApp.Properties.Resources.Tally;
                trayIcon.Text = "Loading Cache";
                trayIcon.BalloonTipTitle = "BizBrain Agent Cache Loader";
                trayIcon.BalloonTipText = "Caching Started";
                trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                trayIcon.ShowBalloonTip(5000);
            }
            catch (Exception e)
            {
                MessageBox.Show("SetRegisteredIcon:" + e.Message);
             
            }


        }
        void SetFinishedIcon()
        {
            try
            {
                CreateNotifyIcon();
                trayIcon.Icon = WindowsSysTrayNotificationApp.Properties.Resources.Tally;
                trayIcon.Text = "Finished Loading Cache";
                trayIcon.BalloonTipTitle = "BizBrain Agent Cache Loader";
                trayIcon.BalloonTipText = "Caching Completed";
                trayIcon.BalloonTipIcon = ToolTipIcon.Info;
                trayIcon.ShowBalloonTip(5000);
            }
            catch (Exception e)
            {
                MessageBox.Show("StopProcess:" + e.Message);
              
            }

        }
        public void Shutdown()
        {

            try
            {
                if (trayIcon != null)
                {

                    trayIcon.Visible = false;

                    trayIcon.Dispose();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //EventLog.WriteEntry(source, ex.Message);
            }
            finally
            {


               // Application.Exit();
                ExitThread();
                this.Dispose();
                System.Environment.Exit(0);
            }
        }
    }
    }
