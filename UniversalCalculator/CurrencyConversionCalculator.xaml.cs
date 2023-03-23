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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConversionCalculator : Page
	{
		public CurrencyConversionCalculator()
		{
			this.InitializeComponent();
		}

		private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
		{

        }

		private void Button_Exit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		private void Button_Convert_Currency_Click(object sender, RoutedEventArgs e)
		{
			double amount = double.Parse(TextBox_EnterAmount.Text);
			string from = ComboBox_From.SelectedValue.ToString();
			string to = ComboBox_To.SelectedValue.ToString();


			double conversionFromTo = GetConversionRate(from, to);
			double conversionToFrom = GetConversionRate(to, from);

			double conversionAmount = amount * conversionFromTo;


			// Populate the results on the GUI
			TextBlock_ToConvert.Text = amount.ToString() + " " + from + " = ";
			TextBlock_Conversion.Text = "$" + conversionAmount + " " + to + "s";
			TextBlock_ConversionFrom.Text = "1 " + from + " = " + conversionFromTo + " " + to + "s";
			TextBlock_ConversionTo.Text = "1 " + to + " = " + conversionToFrom + " " + from + "s";
		}

		private double GetConversionRate(string from, string to)
		{
			double conversion = 0.0;

			// From is US Dollar
			if (from == "US Dollar")
			{
				switch (to)
				{
					case "Euro":
						conversion = 0.85189982;
						break;
					case "Brittish Pound":
						conversion = 0.72872436;
						break;
					case "Indian Rupee":
						conversion = 74.257327;
						break;
				}
			}
			// From is Euro
			if (from == "Euro")
			{
				switch (to)
				{
					case "US Dollar":
						conversion = 1.1739732;
						break;
					case "Brittish Pound":
						conversion = 0.8556672;
						break;
					case "Indian Rupee":
						conversion = 87.00755;
						break;
				}
			}
			// From is Brittish Pound
			if (from == "Brittish Pound")
			{
				switch (to)
				{
					case "Euro":
						conversion = 1.1686692;
						break;
					case "US Dollar":
						conversion = 1.371907;
						break;
					case "Indian Rupee":
						conversion = 101.68635;
						break;
				}
			}
			// From is Indian Rupee
			if (from == "Indian Rupee")
			{
				switch (to)
				{
					case "Euro":
						conversion = 0.013492774;
						break;
					case "Brittish Pound":
						conversion = 0.0098339397;
						break;
					case "US Dollar":
						conversion = 0.011492628;
						break;
				}
			}
			return conversion;
		}

		private void ComboBox_To_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{

		}

		private void ComboBox_From_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			string from = ComboBox_From.SelectedValue.ToString();

			ComboBox_To.Items.Clear();
			if (from == "US Dollar")
			{
				ComboBox_To.Items.Add("Euro");
				ComboBox_To.Items.Add("Brittish Pound");
				ComboBox_To.Items.Add("Indian Rupee");
			}
			if (from == "Euro")
			{
				ComboBox_To.Items.Add("US Dollar");
				ComboBox_To.Items.Add("Brittish Pound");
				ComboBox_To.Items.Add("Indian Rupee");
			}
			if (from == "Brittish Pound")
			{
				ComboBox_To.Items.Add("US Dollar");
				ComboBox_To.Items.Add("Euro");
				ComboBox_To.Items.Add("Indian Rupee");
			}
			if (from == "Indian Rupee")
			{
				ComboBox_To.Items.Add("US Dollar");
				ComboBox_To.Items.Add("Euro");
				ComboBox_To.Items.Add("Brittish Pound");
			}
		}

		private void TextBox_EnterAmount_TextChanged(object sender, TextChangedEventArgs e)
		{
			
		}
	}
}
