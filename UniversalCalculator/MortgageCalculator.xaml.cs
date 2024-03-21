using System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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

		// calculate button on click event handler
		private async void calculateButton_Click(object sender, RoutedEventArgs e)
		{
			double borrowAmount;
			int years;
			int months;
			double yearlyInterest;
			double monthlyInterest;
			double monthlyRepayment;
			int repaymentTerm;

			/* check principal amount for a double value, if fail then produce error, point focus back to borrowTextBox and select all */
			try
			{
				borrowAmount = double.Parse(borrowTextBox.Text);
			}
			catch
			{
				var dialogMessage = new MessageDialog("Error! Principal amount must be a number, please try again.");
				await dialogMessage.ShowAsync();
				borrowTextBox.Focus(FocusState.Programmatic);
				borrowTextBox.SelectAll();
				return;
			}

			/* check years for an int value, if fail then produce error, point focus back to yearsTextBox and select all */
			try
			{
				years = int.Parse(yearsTextBox.Text);
			}
			catch
			{
				var dialogMessage = new MessageDialog("Error! Years must be a number, please try again.");
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}

			/* check months for an int value, if fail then produce error, point focus back to monthsTextBox and select all */
			try
			{
				months = int.Parse(monthsTextBox.Text);
			}
			catch
			{
				var dialogMessage = new MessageDialog("Error! Months must be a number, please try again.");
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}

			/* check yearly interest rate for a double value, if fail then produce error, point focus back to yearlyInterestTextBox and select all */
			try
			{
				yearlyInterest = double.Parse(yearlyInterestTextBox.Text);
			}
			catch
			{
				var dialogMessage = new MessageDialog("Error! Yearly interest rate must be a number, please try again.");
				await dialogMessage.ShowAsync();
				yearlyInterestTextBox.Focus(FocusState.Programmatic);
				yearlyInterestTextBox.SelectAll();
				return;
			}

			/* if principal amount is less than zero, show error, point focus back to borrowTextBox */
			if (borrowAmount < 0)
			{
				var dialogMessage = new MessageDialog("Error! Principal amount must be greater than zero, please try again.");
				await dialogMessage.ShowAsync();
				borrowTextBox.Focus(FocusState.Programmatic);
				borrowTextBox.SelectAll();
				return;
			}

			/* if years is less than zero, show error, point focus back to yearsTextBox */
			if (years < 0)
			{
				var dialogMessage = new MessageDialog("Error! Years must be greater than zero, please try again.");
				await dialogMessage.ShowAsync();
				yearsTextBox.Focus(FocusState.Programmatic);
				yearsTextBox.SelectAll();
				return;
			}

			/* if months is less than zero, show error, point focus back to monthsTextBox */
			if (months < 0)
			{
				var dialogMessage = new MessageDialog("Error! Months must be greater than zero, please try again.");
				await dialogMessage.ShowAsync();
				monthsTextBox.Focus(FocusState.Programmatic);
				monthsTextBox.SelectAll();
				return;
			}

			/* if yearly interest is less than zero, show error, point focus back to yearlyInterestTextBox */
			if (yearlyInterest < 0)
			{
				var dialogMessage = new MessageDialog("Error! Yearly interest rate must be greater than zero, please try again.");
				await dialogMessage.ShowAsync();
				yearlyInterestTextBox.Focus(FocusState.Programmatic);
				yearlyInterestTextBox.SelectAll();
				return;
			}

			monthlyInterest = (yearlyInterest / 100) / 12;

			repaymentTerm = (years * 12) + months;

			monthlyRepayment = borrowAmount * (monthlyInterest * Math.Pow((1 + monthlyInterest), repaymentTerm)) / (Math.Pow((1 + monthlyInterest), repaymentTerm) - 1);

			monthlyInterestTextBox.Text = monthlyInterest.ToString("p");

			repaymentTextBox.Text = monthlyRepayment.ToString("C");
		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainMenu));
		}

	}
}
