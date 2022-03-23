﻿using System;
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
        public static ModernMenu ModernMenu => _modernmenu ?? (_modernmenu = new ModernMenu());
        private static ModernMenu _modernmenu;
    }

}
