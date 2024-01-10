using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class ManufacturerViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private string[] _manufacturers;

		public ManufacturerViewModel()
		{
			_manufacturers = new string[] { "Audi", "BMW", "Porsche" };
		}

		public string[] Manufacturers
		{
			get => _manufacturers;
			set => SetProperty(ref _manufacturers, value);
		}
	}
}
