using Windows.ApplicationModel.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainMenu : Page
	{
		public MainMenu()
		{
			this.InitializeComponent();
		}

		private void mathsCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(MainPage));
		}

		private void mortgageCalculatorButton_Click(object sender, RoutedEventArgs e)
		{

			Frame.Navigate(typeof(MortgageCalculator));
		}

		private void currencyConverterButton_Click(object sender, RoutedEventArgs e)
		{
			Frame.Navigate(typeof(CurrencyConverter)); // Navigate to Currency Converter page
		}

		private void tripCalculatorButton_Click(object sender, RoutedEventArgs e)
		{
			// Display message
			var dialog = new Windows.UI.Popups.MessageDialog("Trip calculator C# code will be developed later");
			dialog.ShowAsync();
		}
		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			CoreApplication.Exit();
		}
	}
}
