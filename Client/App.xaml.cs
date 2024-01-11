using Client.ViewModel;
using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Plugin.Messenger;
using System.Windows;

namespace Client
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static IMvxIoCProvider? IoCProvider => MvxSingleton<IMvxIoCProvider>.Instance;

		public App()
		{
			ConfigureServices();
		}

		private void ConfigureServices()
		{
			var instance = MvxIoCProvider.Initialize();

			//Core
			instance.ConstructAndRegisterSingleton<IMvxMessenger, MvxMessengerHub>();

			//ViewModels
			instance.ConstructAndRegisterSingleton(typeof(BodyTypeViewModel));
			instance.ConstructAndRegisterSingleton(typeof(ManufacturerViewModel));
			instance.ConstructAndRegisterSingleton(typeof(SampleViewModel));
			instance.ConstructAndRegisterSingleton(typeof(OrderViewModel));
		}
	}

}
