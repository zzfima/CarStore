﻿using Client.Messages;
using Client.Model;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;

namespace Client.ViewModel
{
	public sealed class ManufacturerViewModel : MvxViewModel
	{
		private IMvxMessenger _messenger;
		private Manufacturer[] _manufacturers;
		private Manufacturer? _selectedItem;

		public ManufacturerViewModel(IMvxMessenger messenger)
		{
			_messenger = messenger;
			_manufacturers = [new Manufacturer("Audi"), new Manufacturer("BMW"), new Manufacturer("Porsche")];
		}

		public Manufacturer[] Manufacturers
		{
			get => _manufacturers;
			set => SetProperty(ref _manufacturers, value);
		}

		public Manufacturer? SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);
				_messenger?.Publish(new ManufacturerChanged(this, _selectedItem));
			}
		}
	}
}
