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
		private ObservableCollection<BodyTypeRecord>? _bodyTypes;
		private BodyTypeRecord? _selectedItem;

		public BodyTypeViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			ICarsDBReader carsDbReader = new CarsDBReader();
			_bodyTypes = new ObservableCollection<BodyTypeRecord>(carsDbReader.ReadBodyTypes());
			//_bodyTypes = [new BodyType("Sedan"), new BodyType("SUV")];
		}

		public ObservableCollection<BodyTypeRecord>? BodyTypes
		{
			get => _bodyTypes;
			set => SetProperty(ref _bodyTypes, value);
		}

		public BodyTypeRecord? SelectedItem
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
