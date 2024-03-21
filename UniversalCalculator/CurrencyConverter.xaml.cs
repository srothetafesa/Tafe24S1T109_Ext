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

namespace Calculator
{
	public sealed partial class CurrencyConverter : Page
	{
		// Conversion rates
		private const double USD_to_Euro = 0.85189982;
		private const double USD_to_Pound = 0.72872436;
		private const double USD_to_INR = 74.257327;
		private const double Euro_to_USD = 1.1739732;
		private const double Euro_to_Pound = 0.8556672;
		private const double Euro_to_INR = 87.00755;
		private const double Pound_to_USD = 1.371907;
		private const double Pound_to_Euro = 1.1686692;
		private const double Pound_to_INR = 101.68635;
		private const double INR_to_USD = 0.011492628;
		private const double INR_to_Euro = 0.013492774;
		private const double INR_to_Pound = 0.0098339397;

		public CurrencyConverter()
		{
			this.InitializeComponent();
		}

		private void Convert_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				double amount = Convert.ToDouble(txtAmount.Text);

				// Get the selected currencies from the ComboBoxes
				string fromCurrency = (cmbFrom.SelectedItem as ComboBoxItem).Content.ToString();
				string toCurrency = (cmbTo.SelectedItem as ComboBoxItem).Content.ToString();

				// Get the conversion rate based on the selected currencies
				double conversionRate = GetConversionRate(fromCurrency, toCurrency);

				// Perform currency conversion using the ConvertCurrency method
				double convertedAmount = ConvertCurrency(amount, conversionRate);

				txtResult.Text = $"Converted Amount: {convertedAmount:F2} {toCurrency}";
			}
			catch (FormatException)
			{
				txtResult.Text = "Please enter valid numeric values.";
			}
		}

		private void Exit_Click(object sender, RoutedEventArgs e)
		{
			// Navigate back to the main menu page
			this.Frame.Navigate(typeof(MainMenu));
		}

		private double ConvertCurrency(double amount, double conversionRate)
		{
			// Perform currency conversion using the provided formula
			return amount * conversionRate;
		}

		private double GetConversionRate(string fromCurrency, string toCurrency)
		{
			// Determine the conversion rate based on the 'From' and 'To' currencies
			switch (fromCurrency)
			{
				case "US Dollar":
					switch (toCurrency)
					{
						case "Euro": return USD_to_Euro;
						case "British Pound": return USD_to_Pound;
						case "Indian Rupee": return USD_to_INR;
					}
					break;
				case "Euro":
					switch (toCurrency)
					{
						case "US Dollar": return Euro_to_USD;
						case "British Pound": return Euro_to_Pound;
						case "Indian Rupee": return Euro_to_INR;
					}
					break;
				case "British Pound":
					switch (toCurrency)
					{
						case "US Dollar": return Pound_to_USD;
						case "Euro": return Pound_to_Euro;
						case "Indian Rupee": return Pound_to_INR;
					}
					break;
				case "Indian Rupee":
					switch (toCurrency)
					{
						case "US Dollar": return INR_to_USD;
						case "Euro": return INR_to_Euro;
						case "British Pound": return INR_to_Pound;
					}
					break;
			}
			// Default conversion rate (if currencies are not found)
			return 1.0;
		}
	}
}