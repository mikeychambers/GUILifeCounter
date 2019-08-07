using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LifeCounterGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>B
    public partial class MainWindow : Window
    {

        bool Sec = false;
        bool Min = false;
        bool Hor = false;
        bool Day = false;

        public MainWindow()
        {
            InitializeComponent();
            textBox.Clear();
            
        }
       
        private void Calender_Open(object sender, RoutedEventArgs e)
        {
            DatePicker datepicker = (DatePicker)sender;
            Popup popup = (Popup)datepicker.Template.FindName("PART_Popup", datepicker);
            Calendar cal = (Calendar)popup.Child;
            cal.DisplayMode = CalendarMode.Decade;
        }
        private void Seconds_Checked(object sender, RoutedEventArgs e)
        {
            Sec = true;
            Min = false;
            Hor = false;
            Day = false;
        }

        private void Minutes_Checked(object sender, RoutedEventArgs e)
        {
            Sec = false;
            Min = true;
            Hor = false;
            Day = false;
        }

        private void Hours_Checked(object sender, RoutedEventArgs e)
        {
            Sec = false;
            Min = false;
            Hor = true;
            Day = false;
        }

        private void Days_Checked(object sender, RoutedEventArgs e)
        {
            Sec = false;
            Min = false;
            Hor = false;
            Day = true;
        }

        
        public void Generate_Click(object sender, RoutedEventArgs e)
        {
            textBox.Clear();
            
            String theDate = dp.ToString();
            string newDate = DateTime.Parse(theDate).ToShortDateString();
            DateTime ageX = DateTime.Parse(newDate);
            TimeSpan userAge = DateTime.Now.Subtract(ageX);
            SoundPlayer lol = new SoundPlayer(Properties.Resources.ticktock);
            lol.Play();

            if (Sec == true)
            {
                textBox.AppendText(userAge.TotalSeconds.ToString("0"));
                
            }
            else if (Min == true)
            {
                textBox.AppendText(userAge.TotalMinutes.ToString("0"));
            }
            else if (Hor == true)
            {
                textBox.AppendText(userAge.TotalHours.ToString("0"));
            }
            else if (Day == true)
            {
                textBox.AppendText(userAge.TotalDays.ToString("0"));
            }
            else
            {
                textBox.AppendText("Please Choose a measurment of time");
            }

            
        }

    }
}
