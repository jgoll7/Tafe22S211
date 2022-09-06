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

	public sealed partial class CurrencyCalculator : Page
	{
		double usDollar_Euro = 0.85189982;
		double usDollar_BritishPound = 0.72872436;
		double usDollar_IndianRupee = 74.257327;

		double euro_USDollar = 1.1739732;
		double euro_BritishPound = 0.8556672;
		double euro_IndianRupee = 87.00755;

		double britishPound_USDollar = 1.371907;
		double britishPound_Euro = 1.1686692;
		double britishPound_IndianRupee = 101.68635;

		double indianRupee_USDollar = 0.011492628;
		double indianRupee_Euro = 0.013492774;
		double indianRupee_BritishPound = 0.0098339397;

		public CurrencyCalculator()
		{
			this.InitializeComponent();
		}

		private async void ConvertButton_Click(object sender, RoutedEventArgs e)
		{
			int fromSelection;
			int toSelection;
			double toConversionRate;
			double toAmount;
			double inputValue;

			fromSelection = comboBoxFromSelection.SelectedIndex;
			toSelection = comboBoxToSelection.SelectedIndex;

			// If anything other then numerical values are entered into the text box, returns an error.
			try
			{
				inputValue = double.Parse(valueInputTextBox.Text.ToString());
			}

			catch
			{
				var dialogMessage = new MessageDialog("You cannot convert non numeric values.");
				await dialogMessage.ShowAsync();
				valueInputTextBox.Focus(FocusState.Programmatic);
				return;
			}

			// If the same option is selected for both options, returns an error.
			if (fromSelection == toSelection)
			{
				var dialogMessage = new MessageDialog("You cannot convert to the same currency. Please select another currency to convert.");
				await dialogMessage.ShowAsync();
				comboBoxToSelection.Focus(FocusState.Programmatic);
				return;
			}

			else
			{
				// US Dollar
				if (fromSelection == 0)
				{
					// Converts US to Euro
					if (toSelection == 1)
					{
						toConversionRate = usDollar_Euro;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " US Dollars = ";
						comboBoxFromInputTextBlock.Text = "US Dollar to Euro = 0.85189982";
						comboBoxToInputTextBlock.Text = "Euro to US Dollar = 1.1739732";
						calculationTextBlock.Text = toAmount.ToString();
					}
					// Converts US to British Pound
					else if (toSelection == 2)
					{
						toConversionRate = usDollar_BritishPound;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " US Dollars = ";
						comboBoxFromInputTextBlock.Text = "US Dollar to British Pound = 0.72872436";
						comboBoxToInputTextBlock.Text = "British Pound to US Dollar = 1.371907";
						calculationTextBlock.Text = toAmount.ToString();
					}
					// Converts US to Indian Rupee
					else if (toSelection == 3)
					{
						toConversionRate = usDollar_IndianRupee;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " US Dollars = ";
						comboBoxFromInputTextBlock.Text = "US Dollar to Indian Rupee = 74.257327";
						comboBoxToInputTextBlock.Text = "Indian Rupee to US Dollar = 0.011492628";
						calculationTextBlock.Text = toAmount.ToString();
					}
				}
				// Euro selected
				else if (fromSelection == 1)
				{
					// Converts Euro to US Dollar
					if (toSelection == 0)
					{
						toConversionRate = euro_USDollar;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " Euro = ";
						comboBoxFromInputTextBlock.Text = "Euro to US Dollar = 1.1739732";
						comboBoxToInputTextBlock.Text = "US Dollar to Euro = 0.85189982";
						calculationTextBlock.Text = toAmount.ToString();
					}
					// Converts Euro to British Pound
					else if (toSelection == 2)
					{
						toConversionRate = euro_BritishPound;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " Euro = ";
						comboBoxFromInputTextBlock.Text = "Euro to British Pound = 0.8556672";
						comboBoxToInputTextBlock.Text = "British Pound to Euro = 1.1686692";
						calculationTextBlock.Text = toAmount.ToString();
					}
					// Converts Euro to Indian Rupee
					else if (toSelection == 3)
					{
						toConversionRate = euro_IndianRupee;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " Euro = ";
						comboBoxFromInputTextBlock.Text = "Euro to Indian Rupee = 87.00755";
						comboBoxToInputTextBlock.Text = "Indian Rupee to Euro =  0.013492774";
						calculationTextBlock.Text = toAmount.ToString();
					}
				}

				// British Pound
				else if (fromSelection == 2)
				{
					// Converts British Pound to US Dollar
					if (toSelection == 0)
					{
						toConversionRate = britishPound_USDollar;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " British Pound = ";
						comboBoxFromInputTextBlock.Text = "British Pound to US Dollar = 1.371907";
						comboBoxToInputTextBlock.Text = "US Dollar to British Pound = 0.72872436";
						calculationTextBlock.Text = toAmount.ToString();
					}
					// Converts British Pound to Euro
					else if (toSelection == 1)
                    {
						toConversionRate = britishPound_Euro;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " British Pound = ";
						comboBoxFromInputTextBlock.Text = "British Pound to Euro = 1.1686692";
						comboBoxToInputTextBlock.Text = "Euro to British Pound = 0.8556672";
						calculationTextBlock.Text = toAmount.ToString();
                    }
					// Converts British Pound to Indian Rupee
					else if (toSelection == 3)
                    {
						toConversionRate = britishPound_IndianRupee;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " British Pound = ";
						comboBoxFromInputTextBlock.Text = "British Pound to Indian Rupee = 101.68635";
						comboBoxToInputTextBlock.Text = "Indian Rupee to British Pound = 0.0098339397";
						calculationTextBlock.Text = toAmount.ToString();
                    }
				}
				// Indian Rupee
				else if (fromSelection == 3)
                {
					// Converts Indian Rupee to US Dollar
					if (toSelection == 0)
                    {
						toConversionRate = indianRupee_USDollar;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " Indian Rupee =";
						comboBoxFromInputTextBlock.Text = "Indian Rupee to US Dollar =  0.011492628";
						comboBoxToInputTextBlock.Text = "US Dollar to Indian Rupee = 74.257327";
						calculationTextBlock.Text = toAmount.ToString();
                    }
					// Converts Indian Rupee to Euro
					else if (toSelection == 1)
                    {
						toConversionRate = indianRupee_Euro;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " Indian Rupee =";
						comboBoxFromInputTextBlock.Text = "Indian Rupee to Euro = 0.013492774";
						comboBoxToInputTextBlock.Text = "Euro to Indian Rupee = 101.68635";
						calculationTextBlock.Text = toAmount.ToString();
                    }
					// Converts Indian Rupee to British Pound
					else if (toSelection == 2)
                    {
						toConversionRate = indianRupee_BritishPound;
						toAmount = toConversionRate * double.Parse(valueInputTextBox.Text);

						inputTextBlock.Text = valueInputTextBox.Text.ToString() + " Indian Rupee = ";
						comboBoxFromInputTextBlock.Text = "Indian Rupee to British Pound = 0.0098339397";
						comboBoxToInputTextBlock.Text = "British Pound to Indian Rupee = 101.68635";
						calculationTextBlock.Text = toAmount.ToString();
                    }
                }
			}
		}
		
	}
}
