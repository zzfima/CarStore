﻿using Client.Messages;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using Server;
using Server.Models;
using System.Collections.ObjectModel;

namespace Client.ViewModel
{
    public sealed class OrderViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private MvxSubscriptionToken? _tokenOrderAdded;
		private ObservableCollection<Sample> _orders;

		public OrderViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			ICarsDBReader carsDbReader = new CarsDBReaderEF();

			_tokenOrderAdded = messenger?.Subscribe<OrderCreated>((res) =>
			{
				var sample = carsDbReader.ReadSample(res.SelectedSample.Id);
                Orders.Add(sample);
				carsDbReader.WriteOrder(res.SelectedSample);
			});
			_orders = new ObservableCollection<Sample>();
		}

		public ObservableCollection<Sample> Orders
		{
			get => _orders;
			set => SetProperty(ref _orders, value);
		}
	}
}
