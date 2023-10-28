using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetBLOOD_BOARD.Services
{
    public static class NavigationService
    {
        public static void NavigateTo(Window window)
        {
            Application.Current.MainWindow.Close();
            Application.Current.MainWindow = window;
            window.Show();
        }
    }
}
