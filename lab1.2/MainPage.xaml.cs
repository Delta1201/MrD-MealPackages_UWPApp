using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace lab1._2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

		//if one clicked other become invisible: btnVeggie,btnMeat,btnVegan
		// Generic method to handle button states using polymorphism
		private void MealButtonState(Button activeButton)
		{
			// Get all buttons into a list
			var allButtons = new List<Button> { btnVeggie, btnMeat, btnVegan };

			foreach (var button in allButtons)
			{
				if (button == activeButton)
				{
					button.IsEnabled = true;
					button.Opacity = 1.0; // Make the active button fully visible
					lblSelectedMeal.Text = $"Meal type: {button.Content}";
				}
				else
				{
					button.IsEnabled = false;
					button.Opacity = 0.5; // Grey-out and disable the other buttons
				}
			}
		}

		private void RadioButton_Checked(object sender, RoutedEventArgs e)
		{
			if (sender is RadioButton selectedRadioButton)
			{
				lblSelectedPeople.Text = $"For: {selectedRadioButton.Content}";
			}
		}

		private void ListWeekly_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (listWeekly.SelectedItem is ComboBoxItem selectedItem)
			{
				lblWeeklyFrequency.Text = $"Weekly: {selectedItem.Content}";
			}
		}
		private void btnVeggie_Click(object sender, RoutedEventArgs e)
		{
			MealButtonState(btnVeggie);
		}
		private void btnMeat_Click(object sender, RoutedEventArgs e)
		{
			MealButtonState(btnMeat);
		}
		private void btnVegan_Click(object sender, RoutedEventArgs e)
		{
			MealButtonState(btnVegan);
		}

		private void btnReset_Click(object sender, RoutedEventArgs e)
		{
			//uncheck cbo1person,cbo2person,cbo4person
			//all visible btnVeggie,btnMeat,btnVegan
			var allButtons = new List<Button> { btnVeggie, btnMeat, btnVegan };

			foreach (var button in allButtons)
			{
				// Deselect meal type buttons
				button.IsEnabled = true;
				button.Opacity = 1.0;

				// Reset label text
				lblSelectedMeal.Text = "Pick a Meal type";
			}

			// Uncheck all radio buttons
			rb1Person.IsChecked = false;
			rb2Person.IsChecked = false;
			rb4Person.IsChecked = false;

			// Reset label text
			lblSelectedPeople.Text = "For: None";

			// Reset ComboBox selection
			listWeekly.SelectedIndex = -1;

			// Reset label text
			lblWeeklyFrequency.Text = "Weekly: None";

		}

		private async void btnSelectPlan_Click(object sender, RoutedEventArgs e)
		{
			if (lblSelectedMeal.Text == "Pick a Meal type"
				|| lblSelectedPeople.Text == "For: None"
				|| lblWeeklyFrequency.Text == "Weekly: None")
			{
				btnSelectPlan.IsEnabled = false;
			}
			else
			{
				var msg = new Windows.UI.Popups.MessageDialog("Proceed to submit by entering your email address");
				await msg.ShowAsync();
			}
		}

		private async void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var msg = new Windows.UI.Popups.MessageDialog("Thank you");
            await msg.ShowAsync();
        }

		
	}
}
