using Client.Model;

namespace Client.Messages
{
	public class OrderCreated : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public Sample? SelectedSample { get; }
		public OrderCreated(object sender, Sample? selectedSample) : base(sender)
		{
			SelectedSample = selectedSample;
		}
	}
}
