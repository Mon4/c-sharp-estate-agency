using estates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfEstates
{
    /// <summary>
    /// Interaction logic for MeetingsPage.xaml
    /// Page with information about Meetings in datagrid.
    /// </summary>
    public partial class MeetingsPage : Page
    {
        MeetingsRepository meetingsRep;
        /// <summary>
        /// Reads xml file to MeetingsDataGrid.
        /// </summary>
        public MeetingsPage()
        {
            meetingsRep = MeetingsRepository.ReadXML();
            InitializeComponent();
            if (meetingsRep is object)
            {
                MeetingsLabel.Content = meetingsRep.Name;
                MeetingsDataGrid.ItemsSource = new ObservableCollection<Meeting>(meetingsRep.Meetingslist);
            }
        }
        /// <summary>
        /// Deletes row of data from datagrid where selected meeting is.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteBtnClick(object sender, RoutedEventArgs e)
        {
            if (MeetingsDataGrid.SelectedItem != null)
            {
                Meeting m = (Meeting)MeetingsDataGrid.SelectedItem;
                meetingsRep.RemoveMeeting(m);
                meetingsRep.SaveToXML();
                MeetingsDataGrid.ItemsSource = new ObservableCollection<Meeting>(meetingsRep.Meetingslist);
            }
        }
        /// <summary>
        /// Adds meeting to datagrid if result is true(if data is correct and user wants to save it)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Meeting meeting = new Meeting();
            AddMeetingWindow meetingWindow = new AddMeetingWindow(meeting);
            bool? result = meetingWindow.ShowDialog();
            if (result == true)
            {
                meetingsRep.AddMeeting(meeting);
                MeetingsDataGrid.ItemsSource = new ObservableCollection<Meeting>(meetingsRep.Meetingslist);
                meetingsRep.SaveToXML();
            }
        }
    }
}
