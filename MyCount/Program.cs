using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Configuration;


namespace MyCount
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            Application.EnableVisualStyles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            int tag = 0;
            int.TryParse(System.Configuration.ConfigurationManager.AppSettings["type"], out tag);
            //Application.Run(new FormDataSelect(0));
            Application.Run(new MDIParent());
        }
    }
}
