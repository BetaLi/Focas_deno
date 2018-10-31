using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public ushort Flibhndl;
        public long count;
        public Form2(ushort handle)
        {
            InitializeComponent();
            this.Flibhndl = handle;
            this.count = 0;
        }

        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public MySqlConnection connSql()
        {
            string connString = "Server=127.0.0.1;database=FANUC_focas;port=3306;uid=root;pwd=com163@lijun.;";
            MySqlConnection conn = new MySqlConnection(connString);
 
            return conn;
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Tick += new EventHandler(Callback);
            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();

        }

        public void Callback(object sender, EventArgs e)
        {
            MySqlConnection conn = connSql();
            conn.Open();
            #region cnc_machine
            Focas1.ODBAXIS odbaxis = new Focas1.ODBAXIS();
            for (short i = 0; i < 3; i++)
            {
                int ret = Focas1.cnc_machine(Flibhndl, (short)(i + 1), 8, odbaxis);
                Console.WriteLine(odbaxis.data[0] * Math.Pow(10, -3));
                listView1.Items.Add(new ListViewItem(i.ToString()));

                try
                {   
                    //MessageBox.Show("已经建立与数据库之间的连接");
                    string sql = "insert into user(username,password,registerdate) values('"+count++.ToString()+"','123','" + DateTime.Now + "')";
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    int result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("发生错误：" + ex.Message);
                    //Console.WriteLine("发生错误："+ex.Message); //在控制台下使用这种方式
                }

            }
            #endregion


        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
