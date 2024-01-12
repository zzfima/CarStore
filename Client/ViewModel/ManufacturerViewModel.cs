using Client.Messages;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using Server.Model;
using Server;

namespace Client.ViewModel
{
	public sealed class ManufacturerViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private ObservableCollection<ManufacturerRecord>? _manufacturers;
		private ManufacturerRecord? _selectedItem;

		public ManufacturerViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			ICarsDBReader carsDbReader = new CarsDBReader();
			_manufacturers = new ObservableCollection<ManufacturerRecord>(carsDbReader.ReadManufacturers());
			//_manufacturers = [new Manufacturer("Audi"), new Manufacturer("BMW"), new Manufacturer("Porsche")];
		}

		public ObservableCollection<ManufacturerRecord>? Manufacturers
		{
			get => _manufacturers;
			set => SetProperty(ref _manufacturers, value);
		}

		public ManufacturerRecord? SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				_messenger?.Publish(new ManufacturerChanged(this, _selectedItem));
			}
		}
	}
}
