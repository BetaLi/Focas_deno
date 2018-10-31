using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // 全局的CNC handle；
        ushort Flibhndl = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            
            string ip = textBox1.Text;
            string _port = textBox2.Text;
            int port;
            int.TryParse(_port,out port);
            int timeout;
            int.TryParse(textBox3.Text,out timeout);
            
            int ret = Focas1.cnc_allclibhndl3(ip, (ushort)port, timeout,out Flibhndl);
            if(ret != Focas1.EW_OK)
            {
                MessageBox.Show("ERROR code is:"+ret);
                //return;
            }
            MessageBox.Show("连接成功");

            Form2 form2 = new Form2(Flibhndl);
            form2.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ret = Focas1.cnc_freelibhndl(Flibhndl);
            if(ret != Focas1.EW_OK)
            {
                MessageBox.Show("ERROR code is:" + ret);
                return;
            }
            MessageBox.Show("断开连接成功");
        }
    }
}
