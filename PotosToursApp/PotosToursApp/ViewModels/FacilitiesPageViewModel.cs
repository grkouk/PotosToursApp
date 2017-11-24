using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Prism.Navigation;

namespace PotosToursApp.ViewModels
{
	public class FacilitiesPageViewModel : ViewModelBase
    {
        public FacilitiesPageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        private string _name;
	    public string Name
	    {
	        get { return _name; }
	        set { SetProperty(ref _name, value); }
	    }

	    private string _shortDescription;
	    public string ShortDescription
	    {
	        get { return _shortDescription; }
	        set { SetProperty(ref _shortDescription, value); }
	    }

	    private string _description;
	    public string Description
	    {
	        get { return _description; }
	        set { SetProperty(ref _description, value); }
	    }

	    private DelegateCommand _saveCommand;
	    public DelegateCommand SaveCommand =>
	        _saveCommand ?? (_saveCommand = new DelegateCommand(ExecuteSaveCommand));

	    void ExecuteSaveCommand()
	    {
	        Debug.WriteLine("SaveCommand clicked");
	    }

        
    }
}
