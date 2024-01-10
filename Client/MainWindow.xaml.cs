using Client.ViewModel;
using System.Windows;

namespace Client
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			manufacturersView.DataContext = new ManufacturerViewModel();
			bodyTypes.DataContext = new BodyTypeViewModel();
		}
	}
}