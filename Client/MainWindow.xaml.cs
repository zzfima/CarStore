using Client.ViewModel;
using MvvmCross;
using System.Windows;
using System.Windows.Controls;

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
			manufacturersView.DataContext = Mvx.IoCProvider?.Resolve<ManufacturerViewModel>();
			bodyTypes.DataContext = Mvx.IoCProvider?.Resolve<BodyTypeViewModel>();
			samples.DataContext = Mvx.IoCProvider?.Resolve<SampleViewModel>();
			orders.DataContext = Mvx.IoCProvider?.Resolve<OrderViewModel>();
		}
	}
}