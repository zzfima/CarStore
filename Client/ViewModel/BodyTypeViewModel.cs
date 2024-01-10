using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class BodyTypeViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private string[] _bodyTypes;

		public BodyTypeViewModel()
		{
			_bodyTypes = new string[] { "Sedan", "SUV" };
		}

		public string[] BodyTypes
		{
			get => _bodyTypes;
			set => SetProperty(ref _bodyTypes, value);
		}
	}
}
