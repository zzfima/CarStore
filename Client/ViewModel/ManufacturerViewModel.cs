using Client.Model;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class ManufacturerViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private Manufacturer[] _manufacturers;

		public ManufacturerViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			_manufacturers = new Manufacturer[] { new Manufacturer("Audi"), new Manufacturer("BMW"), new Manufacturer("Porsche") };
		}

		public Manufacturer[] Manufacturers
		{
			get => _manufacturers;
			set => SetProperty(ref _manufacturers, value);
		}
	}
}
