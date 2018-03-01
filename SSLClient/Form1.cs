using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SSLClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            Uri uri = new Uri("http://localhost:8050/api/v1/testConnection");
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            try
            {
                WebResponse webResponse = request.GetResponse();
                Stream webStream = webResponse.GetResponseStream();
                StreamReader responseReader = new StreamReader(webStream);
                string response = responseReader.ReadToEnd();
                this.statusResult.Text = response;
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Exception Caught: " + ex.ToString());
            }
        }
    }
}
