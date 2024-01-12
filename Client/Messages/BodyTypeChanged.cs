using Server.Model;

namespace Client.Messages
{
    public class BodyTypeChanged : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public BodyTypeRecord? SelectedBodyType { get; }
		public BodyTypeChanged(object sender, BodyTypeRecord? selectedBodyType) : base(sender)
		{
			SelectedBodyType = selectedBodyType;
		}
	}
}
