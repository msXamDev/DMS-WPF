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
using System.Windows.Navigation;

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
        //public DateTime Dates { get; set; }

        DMSAppEntities db = new DMSAppEntities();
        OutgoingContractTable table = new OutgoingContractTable();

        //public OutgoingContractTable OutgoingContractTable { get; set; }

        public EmploymentViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            HomeButton = new DelegateCommand<string>(HomeButtonClicked);
            SaveBtn = new DelegateCommand(SaveBtnClicked);
            DeleteButton = new DelegateCommand(DeleteBtnClicked);
        }

        private void SaveBtnClicked()
        {
            table.ContractOfficer = ContractOfficer;
            table.Department = Department;
            table.ContractTitles = ContractTitles;
            table.Notes = Notes;
            table.ContractDate = Convert.ToDateTime(Dates);
            db.OutgoingContractTables.Add(table);
            db.SaveChanges();
            //var contractOfficer = CreateNewContract();
            //await _contractOfficerRepos.SaveAsync();
            MessageBox.Show("Added Successfully", "Success", MessageBoxButton.OK);
            ClearEntries();
        }

        //private object CreateNewContract()
        //{
        //    var contractOfficer = new OutgoingContractTable();
        //    ContractOfficer.Add(contractOfficer);
        //    //.Add(contractOfficer);
        //    return contractOfficer;
        //}
        //public void Add(OutgoingContractTable outgoingContractTable)
        //{
        //    db.OutgoingContractTables.Add(outgoingContractTable);
        //}

        private void DeleteBtnClicked()
        {
            MessageBoxResult result= MessageBox.Show("Press OK to delete all entries", "Delete !", MessageBoxButton.OKCancel);
            if(result== MessageBoxResult.OK)
            {
                ClearEntries(); 
            }
        }
        private void ClearEntries()
        {
            ContractOfficer = string.Empty;
            Department = string.Empty;
            //Dates = new DateTime();
            //Dates = Convert.ToDateTime("");
            ContractTitles = string.Empty;
            Notes = string.Empty;
        }
        private void HomeButtonClicked(string obj)
        {
            if (obj != null)
                _regionManager.RequestNavigate("MainRegion", obj);
        }
    }
}
