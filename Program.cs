using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ushort Flibhndl = 0;
            short ret = Focas1.cnc_allclibhndl3("", 8193, 10, out Flibhndl);
            if(ret != Focas1.EW_OK)
            {
                MessageBox.Show("ERROR code is:"+ret);
                
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
