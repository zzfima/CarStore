using Client.Messages;
using MvvmCross.Plugin.Messenger;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using Server.Model;
using Server;

namespace Client.ViewModel
{
    public sealed class OrderViewModel : MvxViewModel
	{
		private IMvxMessenger? _messenger;
		private MvxSubscriptionToken? _tokenOrderAdded;
		private ObservableCollection<SampleRecord> _orders;

		public OrderViewModel(IMvxMessenger? messenger)
		{
			_messenger = messenger;
			ICarsDBReader carsDbReader = new CarsDBReader();

			_tokenOrderAdded = messenger?.Subscribe<OrderCreated>((res) =>
			{
				Orders.Add(res.SelectedSample);
				carsDbReader.WriteOrder(res.SelectedSample);
			});
			_orders = new ObservableCollection<SampleRecord>();
		}

		public ObservableCollection<SampleRecord> Orders
		{
			get => _orders;
			set => SetProperty(ref _orders, value);
		}
	}
}
