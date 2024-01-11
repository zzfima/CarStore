using Client.Messages;
using Client.Model;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class BodyTypeViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private BodyType[]? _bodyTypes;
		private BodyType? _selectedItem;

		public BodyTypeViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			_bodyTypes = [new BodyType("Sedan"), new BodyType("SUV")];
		}

		public BodyType[]? BodyTypes
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
