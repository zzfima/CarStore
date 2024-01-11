using Client.ViewModel;
using MvvmCross;
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
			manufacturersView.DataContext = new ManufacturerViewModel(null);
			bodyTypes.DataContext = Mvx.IoCProvider?.Resolve<BodyTypeViewModel>();
			samples.DataContext = Mvx.IoCProvider?.Resolve<SampleViewModel>();
			orders.DataContext = Mvx.IoCProvider?.Resolve<OrderViewModel>();
		}
	}
}