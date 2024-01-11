﻿using Client.Messages;
using Client.Model;
using MvvmCross.Commands;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class SampleViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private List<Sample> _allSamples;
		private List<Sample> _filteredSamples;

		private MvxSubscriptionToken? _tokenBodyTypeChanged;
		private MvxSubscriptionToken? _tokenManufacturerChanged;

		private BodyType? _selectedBodyType;
		private Manufacturer? _selectedManufacturer;
		private Sample? _selectedSample;

		public SampleViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;

			_tokenBodyTypeChanged = messenger?.Subscribe<BodyTypeChanged>((res) =>
			{
				_selectedBodyType = res.SelectedBodyType;
				ShomModels();
			});

			_tokenManufacturerChanged = messenger?.Subscribe<ManufacturerChanged>((res) =>
			{
				_selectedManufacturer = res.SelectedManufacturer;
				ShomModels();
			});

			OrderCommand = new MvxCommand(() => _messenger?.Publish(new OrderCreated(this, _selectedSample)));

			_allSamples = [
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
				new Sample(new BodyType("SUV"), new Manufacturer("Porsche"), "Macan")
				];

			_filteredSamples = new List<Sample>();
		}

		private void ShomModels()
		{
			if (_selectedBodyType != null && _selectedManufacturer != null)
			{
				FilteredSamples = (from s in _allSamples
								   where s.Manufacturer == _selectedManufacturer
								   where s.BodyType == _selectedBodyType
								   select s).ToList();
			}
		}

		public List<Sample> FilteredSamples
		{
			get => _filteredSamples;
			set => SetProperty(ref _filteredSamples, value);
		}

		public Sample? SelectedSample
		{
			get => _selectedSample;
			set => SetProperty(ref _selectedSample, value);
		}

		public IMvxCommand OrderCommand { get; }
	}
}
