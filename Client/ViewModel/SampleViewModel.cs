using Client.Model;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class SampleViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private Sample[] _samples;

		public SampleViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			_samples = new Sample[] {
				new Sample(new BodyType("Sedan"), new Manufacturer("Audi"), "A1"),
				new Sample(new BodyType("Sedan"), new Manufacturer("Audi"), "A2"),
				new Sample(new BodyType("Sedan"), new Manufacturer("BMW"), "120"),
				new Sample(new BodyType("Sedan"), new Manufacturer("BMW"), "220"),
				new Sample(new BodyType("Sedan"), new Manufacturer("Porsche"), "Panamera"),
				new Sample(new BodyType("Sedan"), new Manufacturer("Porsche"), "Taycan"),
				new Sample(new BodyType("SUV"), new Manufacturer("Audi"), "Q4"),
				new Sample(new BodyType("SUV"), new Manufacturer("Audi"), "Q6"),
				new Sample(new BodyType("SUV"), new Manufacturer("BMW"), "X5"),
				new Sample(new BodyType("SUV"), new Manufacturer("BMW"), "X6"),
				new Sample(new BodyType("SUV"), new Manufacturer("Porsche"), "Cayenne"),
				new Sample(new BodyType("SUV"), new Manufacturer("Porsche"), "Macan")};
		}

		public Sample[] Samples
		{
			get => _samples;
			set => SetProperty(ref _samples, value);
		}
	}
}
