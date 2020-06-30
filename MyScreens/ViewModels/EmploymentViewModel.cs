using MyScreens.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyScreens.ViewModels
{
    class EmploymentViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
        public DelegateCommand<string> HomeButton { get; private set; }
        public DelegateCommand SaveBtn { get; private set; }
        public DelegateCommand DeleteButton { get; private set; }
        private string _contractOfficer;
        private string _department;
        private string _dates;
        private string _contractTitles;
        private string _notes;
        public string ContractOfficer
        {
            get { return _contractOfficer; }
            set { SetProperty(ref _contractOfficer, value); } 
        }
        public string Department
        {
            get { return _department; }
            set {SetProperty(ref _department, value); }
        }
        public string Dates
        {
            get { return _dates; }
            set { SetProperty(ref _dates, value); }
        }
        public string ContractTitles
        {
            get { return _contractTitles; }
            set { SetProperty(ref _contractTitles, value); }
        }
        public string Notes
        {
            get { return _notes; }
            set { SetProperty(ref _notes, value); }
        }

        DMSAppEntities db = new DMSAppEntities();
        public EmploymentViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            HomeButton = new DelegateCommand<string>(HomeButtonClicked);
            SaveBtn = new DelegateCommand(SaveBtnClicked);
            DeleteButton = new DelegateCommand(DeleteBtnClicked);
        }

        private void SaveBtnClicked()
        {
            MessageBox.Show("Added Successfully", "Success", MessageBoxButton.OK);
        }

        private void DeleteBtnClicked()
        {
            ContractOfficer = string.Empty;
            Department = string.Empty;
            Dates = string.Empty;
            ContractTitles = string.Empty;
            Notes = string.Empty;
            //MessageBox.Show("Press OK to delete all entries", "Delete !", MessageBoxButton.OKCancel);

        }
        private void HomeButtonClicked(string obj)
        {
            if (obj != null)
                _regionManager.RequestNavigate("MainRegion", obj);
        }
    }
}
