using Client.Model;

namespace Client.Messages
{
	public class ManufacturerChanged : MvvmCross.Plugin.Messenger.MvxMessage
	{
		public Manufacturer? SelectedManufacturer { get; }
		public ManufacturerChanged(object sender, Manufacturer? selectedManufacturer) : base(sender)
		{
			SelectedManufacturer = selectedManufacturer;
		}
	}
}
