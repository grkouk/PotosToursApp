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

        public FacilitiesPageViewModel(INavigationService navigationService, IDataStore<Facility> facilityDs) : base(navigationService)
        {
            _facilityDS = facilityDs;
        }

        private ObservableCollection<Facility> _facilitiesCollection;
        public ObservableCollection<Facility> FacilitiesCollection  
        {
            get { return _facilitiesCollection; }
            set { SetProperty(ref _facilitiesCollection, value); }
        }

        //   private string _name;
        //public string Name
        //{
        //    get { return _name; }
        //    set { SetProperty(ref _name, value); }
        //}

        //private string _shortDescription;
        //public string ShortDescription
        //{
        //    get { return _shortDescription; }
        //    set { SetProperty(ref _shortDescription, value); }
        //}

        //private string _description;
        //public string Description
        //{
        //    get { return _description; }
        //    set { SetProperty(ref _description, value); }
        //}

        private DelegateCommand _saveCommand;
	    public DelegateCommand SaveCommand =>
	        _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

	    void ExecuteSaveCommand()
	    {
	        Debug.WriteLine("SaveCommand clicked");
	    }

	    public override async void OnNavigatedTo(NavigationParameters parameters)
	    {
	        if (FacilitiesCollection == null)
	        {
	            FacilitiesCollection=new ObservableCollection<Facility>(await _facilityDS.GetItemsAsync());
	        }
	    }
	}
}
