using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L1FEOutdoors
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormProvider.ModernMenu);
        }
    }

    public class FormProvider
    {
        public static MainMenu MainMenu => _mainMenu ?? (_mainMenu = new MainMenu());
        public static Recount Recount => _recount ?? (_recount = new Recount());
        public static ModernMenu ModernMenu => _modernmenu ?? (_modernmenu = new ModernMenu());
        private static MainMenu _mainMenu;
        private static Recount _recount;
        private static ModernMenu _modernmenu;
    }
}
