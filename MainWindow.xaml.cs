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

namespace VacationCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DateTime DefaultStartDate { get; } = new DateTime(2020, 6, 17, 0, 0, 0);

        public MainWindow()
        {
            InitializeComponent();

            futureDatePicker.SelectedDate = DateTime.Now;
            ToggleFutureVacationInformationVisibility();
            startDatePicker.SelectedDate = DefaultStartDate;
            totalHoursValueLabel.Content = Helpers.GetVacationHours(DefaultStartDate, DateTime.Now);

            ToggleErrorMessage();
        }

        private void StartDateChanged(object sender, SelectionChangedEventArgs e)
        {
            totalHoursValueLabel.Content = Helpers.GetVacationHours(startDatePicker!.SelectedDate!.Value, DateTime.Now);
        }

        private void CurrentVacationHoursEntered(object sender, TextChangedEventArgs e)
        {
            if(double.TryParse(currentHoursTextBox.Text, out _))
            {
                ToggleErrorMessage(alwaysHidden: true);
                ToggleFutureVacationInformationVisibility(alwaysVisible: true);
            }
            else
            {
                ToggleFutureVacationInformationVisibility(alwaysHidden: true);
                ToggleErrorMessage(alwaysVisible: true, message: $"'{currentHoursTextBox.Text}' is not a valid number.");
            }
        }

        private void FutureDateChanged(object sender, SelectionChangedEventArgs e)
        {
            GetFutureVacationTime();
        }

        private void PlannedTimeOffEntered(object sender, TextChangedEventArgs e)
        {
            GetFutureVacationTime();
        }

        private void ToggleErrorMessage(bool alwaysVisible = false, bool alwaysHidden = false, string message = "Something went wrong!")
        {
            // Hide
            if(alwaysHidden || errorLabel.Visibility == Visibility.Visible && !alwaysVisible)
            {
                errorLabel.Content = "";
                errorLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                errorLabel.Content = message;
                errorLabel.Visibility = Visibility.Visible;
            }
        }

        private void GetFutureVacationTime()
        {
            if (startDatePicker is not null && futureDatePicker is not null)
                if (startDatePicker.SelectedDate is not null && futureDatePicker.SelectedDate is not null)
                {
                    if (double.TryParse(currentHoursTextBox.Text, out double currentHours))
                    {
                        if (double.TryParse(plannedTimeOffTextBox.Text, out double plannedTimeOff))
                        {
                            ToggleErrorMessage(alwaysHidden: true);
                            totalVacationLeftValueLabel.Content = Helpers.GetFutureVacationHorusFromCurrentVacationTime(
                                startDatePicker.SelectedDate.Value,
                                futureDatePicker.SelectedDate.Value,
                                currentHours,
                                plannedTimeOff);
                        }
                        else
                        {
                            ToggleErrorMessage(alwaysVisible: true, message: $"'{plannedTimeOffTextBox.Text}' is not a valid number.");
                        }
                    }
                    else
                    {
                        ToggleErrorMessage(alwaysVisible: true, message: $"'{currentHoursTextBox.Text}' is not a valid number.");
                    }
                }
        }

        private void ToggleFutureVacationInformationVisibility(bool alwaysVisible = false, bool alwaysHidden = false)
        {
            // Hide
            if (alwaysHidden || futureDateLabel.Visibility == Visibility.Visible && !alwaysVisible)
            {
                futureDateLabel.Visibility = Visibility.Hidden;
                futureDatePicker.Visibility = Visibility.Hidden;

                totalVacationLeftlabel.Visibility = Visibility.Hidden;
                totalVacationLeftValueLabel.Visibility = Visibility.Hidden;

                plannedTimeOffLabel.Visibility = Visibility.Hidden;
                plannedTimeOffTextBox.Visibility = Visibility.Hidden;
            }
            // Show
            else
            {
                futureDateLabel.Visibility = Visibility.Visible;
                futureDatePicker.Visibility = Visibility.Visible;

                totalVacationLeftlabel.Visibility = Visibility.Visible;
                totalVacationLeftValueLabel.Visibility = Visibility.Visible;

                plannedTimeOffLabel.Visibility = Visibility.Visible;
                plannedTimeOffTextBox.Visibility = Visibility.Visible;

                // Set values
                futureDatePicker.SelectedDate = DateTime.Now;
                totalVacationLeftValueLabel.Content = currentHoursTextBox.Text;
                plannedTimeOffTextBox.Text = "0";
            }
        }

    }
}
