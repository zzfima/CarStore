using Server.Model;

namespace Client.Messages
{
    public class ManufacturerChanged : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public ManufacturerRecord? SelectedManufacturer { get; }
		public ManufacturerChanged(object sender, ManufacturerRecord? selectedManufacturer) : base(sender)
		{
			SelectedManufacturer = selectedManufacturer;
		}
	}
}
