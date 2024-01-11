using Client.Messages;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using Server.Model;
using Server;

namespace Client.ViewModel
{
    public sealed class BodyTypeViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private ObservableCollection<BodyType>? _bodyTypes;
		private BodyType? _selectedItem;

		public BodyTypeViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			CarsDbReader carsDbReader = new CarsDbReader();
			_bodyTypes = new ObservableCollection<BodyType>(carsDbReader.ReadBodyTypes());
			//_bodyTypes = [new BodyType("Sedan"), new BodyType("SUV")];
		}

		public ObservableCollection<BodyType>? BodyTypes
		{
			get => _bodyTypes;
			set => SetProperty(ref _bodyTypes, value);
		}

		public BodyType? SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				_messenger?.Publish(new BodyTypeChanged(this, _selectedItem));
			}
		}
	}
}
