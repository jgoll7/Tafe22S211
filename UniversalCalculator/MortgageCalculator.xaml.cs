using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
	///
/* Use the following equation for calculating the repayment:
M = P [ i(1 + i)^n ] / [ (1 + i)^n – 1]
P = principal loan amount
i = monthly interest rate
n = number of months required to repay the loan
For example, if the annual interest rate is 4%, the monthly interest rate would be 0.33% (0.04/12 = 0.0033).

A 30-year mortgage would require 360 monthly payments, while a 15-year mortgage would require exactly half that number of monthly payments, or 180. 
Hints: use C# Math.Pow() function for calculating exponential.
*/
public sealed partial class MortgageCalculator : Page
{
	public MortgageCalculator()
	{
		this.InitializeComponent();
	}
		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double principal;
			int years;
			int months;
			int repaymentMonths;
			double annualRate;
			double monthlyRate;
			double monthlyRepayment;

			// Validation
			// Ensure that values entered are numerical, return focus to textbox if non-numeric

			// Principal validation
			try
			{
				principal = double.Parse(principalTextBox.Text.ToString());
			}

			catch
			{
				var dialogMessage = new MessageDialog("Cannot convert non numeric value");
				await dialogMessage.ShowAsync();
				principalTextBox.Focus(FocusState.Programmatic);
				return;

			}

			// Years validation
			try
			{
				years = int.Parse(yearsTextBox.Text.ToString());

			}

			catch
			{
				var dialogMessage = new MessageDialog("Cannot convert non numeric value");
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				return;

			}

			// Months validation
			try
			{
				months = int.Parse(monthsTextBox.Text.ToString());
			}

			catch
			{
				var dialogMessage = new MessageDialog("Cannot convert non numeric value");
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				return;

			}
			// Annual rate validation
			try
			{
				annualRate = double.Parse(annualRateTextBox.Text.ToString());
			}

			catch
			{
				var dialogMessage = new MessageDialog("Cannot convert non numeric value");
				await dialogMessage.ShowAsync();
				annualRateTextBox.Focus(FocusState.Programmatic);
				return;

			}

			// Monthly rate validation
			/*
			try
			{
				monthlyRate = double.Parse(monthlyRateTextBox.Text.ToString());
			}

			catch
			{
				var dialogMessage = new MessageDialog("Cannot convert non numeric value");
				await dialogMessage.ShowAsync();
				monthlyRateTextBox.Focus(FocusState.Programmatic);
				return;

			}
			*/
			// 
			
			repaymentMonths = (years * 12) + months;
			monthlyRate = annualRate / 100 / 12;
			monthlyRateTextBox.Text = monthlyRate.ToString("0.0000")+"%";
			monthlyRepayment = principal * ((monthlyRate * Math.Pow((1 + monthlyRate), repaymentMonths)) / (Math.Pow(1 + monthlyRate, repaymentMonths) - 1));
			monthlyRepaymentTextBox.Text = monthlyRepayment.ToString("C");
		}  

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainMenu));
		}

		
	}
}
