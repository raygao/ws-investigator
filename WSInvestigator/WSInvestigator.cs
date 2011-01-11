/////////////////////////////////////////////////////////////////////////////////
/// Author:     Raymond Gao
/// Contact:    rgao@bea.com 
/// Date:       May 21, 2007
/// This mini app lists all "web services" installed in an ALUI app. 
/// This app is compiled with G6 MP1 server libraries.
/// This is an open-source project, no warranty or license available.
/// If you would like to participate in this project, 
/// please contact Ray Gao at mailto:rgao@bea.com or mailto:raygao2000@yahoo.com 
//////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Threading;

using com.plumtree.server.search;
using com.plumtree.server;
using com.plumtree.openkernel.factory;
using com.plumtree.xpshared.config;
using com.plumtree.openkernel;
using com.plumtree.openkernel.util;
using com.plumtree.openkernel.config;
using com.plumtree.server.search.ptapps;
using com.plumtree.openfoundation.util;

namespace wssearch
{
    public partial class WSInvestigator : Form
    {
        String url;
        String username;
        String password;
        Boolean wsStatus;
        DataTable resultDataTable;
        String saveFile;
        AboutWSInvestigator abWs;

        //create session and search request, etc.
        IPTSession ptSession;
        IOKContext oContext;

        // See MSDN documentation on Configuration manager API,
        //http://forums.microsoft.com/MSDN/ShowPost.aspx?PostID=56359&SiteID=1
        //String separator = ConfigurationManager.AppSettings["separator"];
        String separator = ";";

        public WSInvestigator()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            DoSplash(); 
        }

        private void DoSplash()
        {
            // Display the splash screen
            Splash splashScreen = new Splash();
            splashScreen.Show();
            
            Thread.Sleep(1000);

            // Close the splash screen
            splashScreen.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveFileDialog1.ShowDialog();
            saveFile = this.saveFileDialog1.FileName;
            resultBox.Text = "Saving file: " + saveFile;
            resultBox.Text += "Separator for CSV is: " + separator + "\n";

            StringBuilder sbCSV = new StringBuilder();
            //generate headings in the csv file.            
            DataColumnCollection dc = resultDataTable.Columns;
            foreach (DataColumn column in dc)
            {
                sbCSV.Append(column.ColumnName + separator);
                //Console.WriteLine(column.DataType);
            }
            sbCSV.Append("\n");
            //build contents
            int intColCount = resultDataTable.Columns.Count;
            foreach (DataRowView dr in resultDataTable.DefaultView)
            {
                for (int x = 0; x < intColCount; x++)
                {
                    sbCSV.Append(dr[x].ToString());
                    if ((x + 1) != intColCount)
                    {
                        sbCSV.Append(separator);
                    }
                }
                sbCSV.Append("\n");
            }
            using (StreamWriter sw = new StreamWriter(@saveFile))
            {
                sw.Write(sbCSV.ToString());
            }

        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //this.fontDialog1.ShowDialog();
            abWs = new AboutWSInvestigator();
            abWs.Show();

        }

        private void wsSearchBackgroundWorker(object sender, DoWorkEventArgs e)
        {
            DateTime start = DateTime.Now;
            resultBox.Text += "--------Searching Web Services " + start + "--------------------\n";
            try
            {
                Init();
                ////get a PTObjectInfoManager for webservice info look up.                
                WSInfoMgr wsinfoMgr = (WSInfoMgr)InfoMgrFactory.getMgr(Constants.WEBSERVICES, ptSession);
                //DataView wsDV = new DataView(wsinfoMgr.getAllCommunityPagesInfo());
                //resultBox.Text += wsDV.Count;
                //resultBox.Text += wsinfoMgr.getAllWebServicesInfoAsString();
                resultDataTable = wsinfoMgr.getAllWebServicesInfo(wsStatus);

                resultDataGridView.DataSource = new DataView(resultDataTable);
            }
            catch (Exception ee)
            {
                resultBox.Text += "Error occurred.\n";
                Console.Write("Exception occured");
                resultBox.Text += ee.Message;
                resultBox.Text += ee.StackTrace;
            }

            DateTime end = DateTime.Now;
            resultBox.Text += "-------- Done " + end + "--------------------\n";
            resultBox.Text += "-------- Total system time " + end.Subtract(start) + "--------------------\n";
            resultBox.Refresh();
        }

        private void runWSButton_Click(object sender, EventArgs e)
        {
            runWSButton.Enabled = false;
            this.resultBox.Text = "Search started. Please wait....\n";

            // get input from user input boxes.
            url = serverURL.Text;
            username = uname.Text;
            password = pwd.Text;
            wsStatus = activeCheckBox.Checked;

            if (wsStatus == true)
                resultBox.Text += "Showing only enabled webservices.\n";
            else
                resultBox.Text += "Showing all (enabled & disabled) webservices.\n";
            resultBox.Refresh();

            wsSearchBackgroundWorker(sender, null);

            runWSButton.Enabled = true;
        }

        private void runPortletButton_Click(object sender, EventArgs e)
        {
            runWSButton.Enabled = false;
            this.resultBox.Text = "Search started. Please wait....\n";

            // get input from user input boxes.
            url = serverURL.Text;
            username = uname.Text;
            password = pwd.Text;
            wsStatus = activeCheckBox.Checked;

            if (wsStatus == true)
                resultBox.Text += "Showing only portlets.\n";
            else
                resultBox.Text += "Showing all (enabled & disabled) portlets.\n";
            resultBox.Refresh();

            portletSearchBackgroundWorker_DoWork(sender, null);

            runWSButton.Enabled = true;
        }

        private void portletSearchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime start = DateTime.Now;
            resultBox.Text += "--------Searching portlets " + start + "--------------------\n";
            try
            {
                Init();

                ////get a PTObjectInfoManager for webservice info look up.                
                PortletInfoMgr portletInfoMgr = (PortletInfoMgr)InfoMgrFactory.getMgr(Constants.PORTLET, ptSession);
                resultDataTable = portletInfoMgr.getAllportletsInfo(false);

                resultDataGridView.DataSource = new DataView(resultDataTable);
            }
            catch (Exception ee)
            {
                resultBox.Text += "Error occurred.\n";
                Console.Write("Exception occured");
                resultBox.Text += ee.Message;
                resultBox.Text += ee.StackTrace;
            }

            DateTime end = DateTime.Now;
            resultBox.Text += "-------- Done " + end + "--------------------\n";
            resultBox.Text += "-------- Total system time " + end.Subtract(start) + "--------------------\n";
            resultBox.Refresh();
        }

        private void runCommunityButton_Click(object sender, EventArgs e)
        {
            runCommunityButton.Enabled = false;
            this.resultBox.Text = "Search started. Please wait....\n";

            // get input from user input boxes.
            url = serverURL.Text;
            username = uname.Text;
            password = pwd.Text;
            wsStatus = activeCheckBox.Checked;

            //if (wsStatus == true)
            //    resultBox.Text += "Showing only enabled webservices.\n";
            //else
            //    resultBox.Text += "Showing all (enabled & disabled) webservices.\n";
            resultBox.Refresh();

            communitySearchBackgroundWorker_DoWork(sender, null);

            runCommunityButton.Enabled = true;
        }

        private void communitySearchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime start = DateTime.Now;
            resultBox.Text += "--------Searching portlets " + start + "--------------------\n";
            try
            {
                IPTSession ptSession = Init();

                ////get a PTObjectInfoManager for webservice info look up.                
                CommunityInfoMgr communitytInfoMgr = (CommunityInfoMgr)InfoMgrFactory.getMgr(Constants.COMMUNITY, ptSession);
                resultDataTable = communitytInfoMgr.getAllCommunityInfo();

                resultDataGridView.DataSource = new DataView(resultDataTable);
            }
            catch (Exception ee)
            {
                resultBox.Text += "Error occurred.\n";
                Console.Write("Exception occured");
                resultBox.Text += ee.Message;
                resultBox.Text += ee.StackTrace;
            }

            DateTime end = DateTime.Now;
            resultBox.Text += "-------- Done " + end + "--------------------\n";
            resultBox.Text += "-------- Total system time " + end.Subtract(start) + "--------------------\n";
            resultBox.Refresh();
        }

        private IPTSession Init()
        {
            //Server API does not support remote access. Localhost only
            //initialize and create Uri.
            //connection apiserver = new Uri(url);
            //IRemoteSession session = RemoteSessionFactory.GetExplicitLoginContext(
            //                apiserver,
            //                username,
            //                password);
            //resultBox.Text += "session is: " + session + "\n";
            //String strToken =  session.GetLoginToken();
            //resultBox.Text += "logintoken is: " + strToken + "\n";

            String configPath = ConfigPathResolver.GetOpenConfigPath();
            oContext = OKConfigFactory.createInstance(configPath, "portal");
            PortalObjectsFactory.InitLight(oContext);

            ptSession = PortalObjectsFactory.CreateSession();

            //ptSession.Reconnect(strToken); //server api does not support remote access.
            ptSession.Connect(username, password, null);

            return ptSession;
        }

        private void runPageSearchButton_Click(object sender, EventArgs e)
        {
            runPageSearchButton.Enabled = false;
            this.resultBox.Text = "Search started. Please wait....\n";

            // get input from user input boxes.
            url = serverURL.Text;
            username = uname.Text;
            password = pwd.Text;
            wsStatus = activeCheckBox.Checked;

            //if (wsStatus == true)
            //    resultBox.Text += "Showing only enabled webservices.\n";
            //else
            //    resultBox.Text += "Showing all (enabled & disabled) webservices.\n";
            resultBox.Refresh();

            pageSearchBackgroundWorker_DoWork(sender, null);

            runPageSearchButton.Enabled = true;
        }

        private void pageSearchBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DateTime start = DateTime.Now;
            resultBox.Text += "--------Searching portlets " + start + "--------------------\n";
            try
            {
                IPTSession ptSession = Init();

                ////get a PTObjectInfoManager for webservice info look up.                
                CommunityPageInfoMgr communityPagetInfoMgr = (CommunityPageInfoMgr)InfoMgrFactory.getMgr(Constants.COMMUNITYPAGE, ptSession);
                resultDataTable = communityPagetInfoMgr.getAllCommunityPagesInfo();

                resultDataGridView.DataSource = new DataView(resultDataTable);
            }
            catch (Exception ee)
            {
                resultBox.Text += "Error occurred.\n";
                Console.Write("Exception occured");
                resultBox.Text += ee.Message;
                resultBox.Text += ee.StackTrace;
            }

            DateTime end = DateTime.Now;
            resultBox.Text += "-------- Done " + end + "--------------------\n";
            resultBox.Text += "-------- Total system time " + end.Subtract(start) + "--------------------\n";
            resultBox.Refresh();
        }

        private void separatorTextBox_TextChanged(object sender, EventArgs e)
        {
            separator = separatorTextBox.Text;
        }

    }
}