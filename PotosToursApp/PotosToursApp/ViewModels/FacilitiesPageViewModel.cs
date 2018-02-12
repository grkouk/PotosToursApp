using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using PotosToursApp.Models;
using PotosToursApp.Services;
using Prism.Navigation;

namespace PotosToursApp.ViewModels
{
	public class FacilitiesPageViewModel : ViewModelBase
	{
	    private IDataStore<Facility> _facilityDS;

        private bool _dsInitialized = false;

        private bool isBusy = false;
	    public bool IsBusy
	    {
	        get { return isBusy; }
	        set { SetProperty(ref isBusy, value); }
	    }
        public FacilitiesPageViewModel(INavigationService navigationService, IDataStore<Facility> facilityDs) : base(navigationService)
        {
            _facilityDS = facilityDs;
        }

	    //private ObservableCollection<Facility> _facilitiesCollection =new ObservableCollection<Facility>();
	    private ObservableCollection<Facility> _facilitiesCollection ;

        public ObservableCollection<Facility> FacilitiesCollection  
        {
            get { return _facilitiesCollection; }
            set { SetProperty(ref _facilitiesCollection, value); }
        }

       
        private DelegateCommand _addCommand;
	    public DelegateCommand AddCommand =>
	        _addCommand ?? (_addCommand = new DelegateCommand(AddFacilityCommand));

	    void AddFacilityCommand()
	    {
	        NavigationService.NavigateAsync("FacilityPage");
	    }

        
        
	    public override async void OnNavigatedTo(NavigationParameters parameters)
	    {
	        if (FacilitiesCollection==null)
	        {
	            FacilitiesCollection = new ObservableCollection<Facility>(await _facilityDS.GetItemsAsync());
            }

            //if (!_dsInitialized)
            //{
            //    var items = await _facilityDS.GetItemsAsync();

                
            //    foreach (Facility facility in items)
            //    {
            //        _facilitiesCollection.Add(facility);
            //    }
            //    _dsInitialized = true;
            //}

        }
	}
}
