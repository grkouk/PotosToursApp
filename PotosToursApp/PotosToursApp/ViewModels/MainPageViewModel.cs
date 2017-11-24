using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotosToursApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
       

        public MainPageViewModel(INavigationService navigationService) 
            : base (navigationService)
        {
            Title = "Main Page Title";
        }
        private DelegateCommand _faciliesButtonCommand;
        public DelegateCommand FacilitiesButtonCommand =>
            _faciliesButtonCommand ?? (_faciliesButtonCommand = new DelegateCommand(ExecuteFacilitiesButtonCommand));

        void ExecuteFacilitiesButtonCommand()
        {
            NavigationService.NavigateAsync("FacilitiesPage");
        }
       
    }
}
