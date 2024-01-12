using Server.Model;

namespace Client.Messages
{
    public class OrderCreated : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public SampleRecord? SelectedSample { get; }
		public OrderCreated(object sender, SampleRecord? selectedSample) : base(sender)
		{
			SelectedSample = selectedSample;
		}
	}
}
