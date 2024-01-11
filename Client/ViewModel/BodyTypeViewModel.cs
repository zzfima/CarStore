using Client.Model;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class BodyTypeViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private BodyType[] _bodyTypes;

		public BodyTypeViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			_bodyTypes = new BodyType[] { new BodyType("Sedan"), new BodyType("SUV") };
		}

		public BodyType[] BodyTypes
		{
			get => _bodyTypes;
			set => SetProperty(ref _bodyTypes, value);
		}
	}
}
