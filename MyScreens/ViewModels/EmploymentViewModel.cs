using MyScreens.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace MyScreens.ViewModels
{
    class EmploymentViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        DMSAppEntities db = new DMSAppEntities();

        OutgoingContractTable table = new OutgoingContractTable();
        public DelegateCommand<string> HomeButton { get; private set; }
        public DelegateCommand SaveBtn { get; private set; }
        public DelegateCommand DeleteButton { get; private set; }
        private string _contractOfficer;
        private string _department;
        private DateTime? _dates;
        private string _contractTitles;
        private string _notes;
        private string _contractDatepicker;
        private string _mandatoryLabel;

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
        public DateTime? Dates
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
        public string contractDatepicker
        {
            get { return _contractDatepicker; }
            set
            {
                SetProperty(ref _contractDatepicker, value);
                RaisePropertyChanged("contractDatepicker");
            }
        }
        public string MandatoryLabel
        {
            get { return _mandatoryLabel; }
            set 
            {
                _mandatoryLabel = value;
                RaisePropertyChanged("MandatoryLabel");
            }
        }

        public EmploymentViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            HomeButton = new DelegateCommand<string>(HomeButtonClicked);
            SaveBtn = new DelegateCommand(SaveBtnClicked);
            DeleteButton = new DelegateCommand(DeleteBtnClicked);
        }

        private void SaveBtnClicked()
        {
            if (!string.IsNullOrWhiteSpace(ContractOfficer) && ContractOfficer.Length != 0
                && !string.IsNullOrWhiteSpace(Department) && Department.Length != 0)
            {
                table.ContractOfficer = ContractOfficer;
                table.Department = Department;
                table.ContractTitles = ContractTitles;
                table.Notes = Notes;
                table.ContractDate = Dates;
                db.OutgoingContractTables.Add(table);
                db.SaveChanges();

                MessageBox.Show("Added Successfully", "Success", MessageBoxButton.OK);
                ClearEntries();

                MandatoryLabel = string.Empty;
            }
            //else if (string.IsNullOrWhiteSpace(ContractOfficer) && ContractOfficer.Length == 0
            //    || string.IsNullOrWhiteSpace(Department) && Department.Length == 0)
            else
            {
                MandatoryLabel = "*This field is mandatory";
            }
        }

        private void DeleteBtnClicked()
        {            
            if(!string.IsNullOrWhiteSpace(ContractOfficer) && ContractOfficer.Length>0
                || !string.IsNullOrWhiteSpace(Department) && Department.Length > 0 
               // || !string.IsNullOrWhiteSpace(contractDatepicker) && contractDatepicker.Length > 0
                || !string.IsNullOrWhiteSpace(Convert.ToString(Dates)) && Convert.ToString(Dates).Length>0
                || !string.IsNullOrWhiteSpace(ContractTitles) && ContractTitles.Length > 0
                || !string.IsNullOrWhiteSpace(Notes) && Notes.Length > 0)
            {
                MessageBoxResult result = MessageBox.Show("Are you sure? You want to delete entries", "Delete !", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    ClearEntries();
                }
            }
        }
        
        private void ClearEntries()
        {
            ContractOfficer = string.Empty;
            Department = string.Empty;
            contractDatepicker = string.Empty;
            ContractTitles = string.Empty;
            Notes = string.Empty;
        }
        private void HomeButtonClicked(string obj)
        {
            if (!string.IsNullOrWhiteSpace(ContractOfficer) && ContractOfficer.Length > 0
                || !string.IsNullOrWhiteSpace(Department) && Department.Length > 0
                //|| !string.IsNullOrWhiteSpace(contractDatepicker) && contractDatepicker.Length > 0
                || !string.IsNullOrWhiteSpace(Convert.ToString(Dates)) && Convert.ToString(Dates).Length>0
                || !string.IsNullOrWhiteSpace(ContractTitles) && ContractTitles.Length > 0
                || !string.IsNullOrWhiteSpace(Notes) && Notes.Length > 0)
            {
                MessageBoxResult result = MessageBox.Show("You will loose all entries. Press cancel to stay on this page",
                    "Warning !", MessageBoxButton.OKCancel);

                if (result == MessageBoxResult.OK)
                {
                    if (obj != null)
                        _regionManager.RequestNavigate("MainRegion", obj);
                    ClearEntries();
                }
            }
            else
            {
                _regionManager.RequestNavigate("MainRegion", obj);
            }
        }
    }
}
