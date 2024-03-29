﻿using Client.Messages;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using Server;
using Server.Models;
using System.Collections.ObjectModel;

namespace Client.ViewModel
{
    public sealed class ManufacturerViewModel : MvxViewModel
    {
        private IMvxMessenger? _messenger;
        private ObservableCollection<Manufacturer>? _manufacturers;
        private Manufacturer? _selectedItem;

        public ManufacturerViewModel(IMvxMessenger? messenger)
        {
            _messenger = messenger;
            ICarsDBReader carsDbReader = new CarsDBReader();
            _manufacturers = new ObservableCollection<Manufacturer>(carsDbReader.ReadManufacturers());
            //_manufacturers = [new Manufacturer("Audi"), new Manufacturer("BMW"), new Manufacturer("Porsche")];
        }

        public ObservableCollection<Manufacturer>? Manufacturers
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
