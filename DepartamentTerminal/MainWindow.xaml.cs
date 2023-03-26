using DepartamentTerminal.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SF2022User00Lib;
using Microsoft.Win32;

namespace DepartamentTerminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //MessageBox.Show(string.Join("\n", GetTimesForConsultations()));
            var a = new ApplicationContext();
            a.Database.EnsureDeleted();
        }

        public List<string> GetTimesForConsultations()
        {
            //время для консультации
            var consultationTime = TimeSpan.FromMinutes(10);
            var beginWorkingTime = TimeSpan.Parse("09:00");
            var endWorkingTime = TimeSpan.Parse("18:00");
            BusySchedule busySchedule = new BusySchedule();
            busySchedule.AddBusyTime(endWorkingTime, TimeSpan.FromMinutes(30));
            return Calculations.FindFreeTimes(beginWorkingTime, endWorkingTime, consultationTime, busySchedule);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel | *.xlsx";
            if(openFileDialog.ShowDialog() == true)
            {
                ExcelInteraction.ImportIndividualVisits(openFileDialog.FileName);
            }
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel | *.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                ExcelInteraction.ImportGroupVisits(openFileDialog.FileName);
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel | *.xlsx";
            if (openFileDialog.ShowDialog() == true)
            {
                ExcelInteraction.ImportEmployee(openFileDialog.FileName);
            }
        }
    }
}
