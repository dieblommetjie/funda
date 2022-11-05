using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Funda
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OpeningPage());
        }

        private static int _applIndex;
        public static int ApplIndex {
            get { return _applIndex; }
            set { _applIndex = value; }
        }

        private static int _donIndex;
        public static int DonIndex
        {
            get { return _donIndex; }
            set { _donIndex = value; }
        }

        private static string _user;
        public static string User
        {
            get { return _user; }
            set { _user = value; }
        }

    }
}
