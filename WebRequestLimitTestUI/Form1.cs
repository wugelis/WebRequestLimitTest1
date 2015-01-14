using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebRequestLimitTestUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = int.Parse(textBox1.Text);

            for(int i =0;i<count;i++)
            {
                Task.Factory.StartNew(() => {
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://localhost/WebRequestLimitTest1/UTK0201_.aspx");
                    WebResponse response = request.GetResponse();
                    StreamReader sr = new StreamReader(response.GetResponseStream());
                    //textBox2.Text = sr.ReadToEnd();
                    string Html = sr.ReadToEnd();
                });
                Thread.Sleep(10);
                this.BeginInvoke(new Action(() => { label1.Text = i.ToString(); }));
            }
            MessageBox.Show("執行成功！");
        }
    }
}
