using Server;

namespace Client.Messages
{
	public class BodyTypeChanged : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public BodyType? SelectedBodyType { get; }
		public BodyTypeChanged(object sender, BodyType? selectedBodyType) : base(sender)
		{
			SelectedBodyType = selectedBodyType;
		}
	}
}
