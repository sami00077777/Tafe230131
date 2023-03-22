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
	public sealed partial class MortgageCalculator : Page
	{
		public MortgageCalculator()
		{
			this.InitializeComponent();
		}
		private void onCalculateButton(object sender, RoutedEventArgs e)
		{
			// Retrieve input data
			double principalBorrow = double.Parse(PrincipalBorrow.Text);
			int year = int.Parse(Year.Text);
			int month = int.Parse(Month.Text);
			double yearlyInterestRate = double.Parse(YearlyInterestRate.Text) / 100;

			// Calculate number of monthly payments
			int n = year * 12 + month;

			// Calculate monthly interest rate
			double monthlyInterestRate = yearlyInterestRate / 12;

			// Calculate mortgage payment
			double M = principalBorrow * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, n)) / (Math.Pow(1 + monthlyInterestRate, n) - 1);

			// Set monthly interest rate
			MonthlyInterestRate.Text = string.Format("{0:P2}", monthlyInterestRate);

			// Display result
			MonthlyRepayment.Text = string.Format("{0:C2}", M);
		}
		private void onExitClick(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}
	}
}
