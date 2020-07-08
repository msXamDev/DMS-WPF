using MyScreens.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyScreens.ViewModels
{
    class IncomingWorkContractViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        DMSAppEntities entities = new DMSAppEntities();

        IncomingContractTable IncTable = new IncomingContractTable();

        public DelegateCommand<string> HomeButton { get; private set; }
        public DelegateCommand IncDeleteBtn { get; private set; }
        public DelegateCommand IncSaveBtn { get; private set; }

        private string _incDepartment;

        public string IncDepartment
        {
            get { return _incDepartment; }
            set 
            {
                SetProperty(ref _incDepartment, value);
            }
        }

        private string _incCustomer;

        public string IncCustomer
        {
            get { return _incCustomer; }
            set 
            {
                SetProperty(ref _incCustomer, value);
            }
        }

        private string _incDatePicker;
        public string IncDatePicker
        {
            get { return _incDatePicker; }
            set 
            { 
                SetProperty(ref _incDatePicker, value);
                RaisePropertyChanged("IncDatePicker");
            }
        }

        public DateTime? IncCalender { get; set; }

        private string _incTitles;
        public string IncTitles
        {
            get { return _incTitles; }
            set 
            {
                SetProperty(ref _incTitles, value); 
            }
        }

        private string _incNotes;

        public string IncNotes
        {
            get { return _incNotes; }
            set 
            {
                SetProperty(ref _incNotes, value); 
            }
        }

        private string _incRecommend;

        public string IncRecommend
        {
            get { return _incRecommend; }
            set 
            {
                SetProperty(ref _incRecommend, value); 
            }
        }
        private string _mandatoryLabel;

        public string MandatoryLabel
        {
            get { return _mandatoryLabel; }
            set 
            { 
                _mandatoryLabel = value;
                RaisePropertyChanged("MandatoryLabel");
            }
        }

        public IncomingWorkContractViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            HomeButton = new DelegateCommand<string>(HomeButtonClicked);
            IncDeleteBtn = new DelegateCommand(DeleteButtonClicked);
            IncSaveBtn = new DelegateCommand(SaveButtonClicked);
        }

        private void SaveButtonClicked()
        {
            if(!string.IsNullOrWhiteSpace(IncDepartment) && IncDepartment.Length!=0
                || !string.IsNullOrWhiteSpace(IncCustomer) && IncCustomer.Length!=0)
            {
                IncTable.Department = IncDepartment;
                IncTable.Customer = IncCustomer;
                IncTable.ContractDate = IncCalender;
                IncTable.ContractTitles = IncTitles;
                IncTable.Notes = IncNotes;
                IncTable.Recommendations = IncRecommend;
                entities.IncomingContractTables.Add(IncTable);
                entities.SaveChanges();

                MessageBox.Show("Added Successfully", "Success", MessageBoxButton.OK);
                ClearEntries();

                MandatoryLabel = string.Empty;
            }

            else
            {
                MandatoryLabel = "*This field is mandatory";
            }
            
        }

        private void DeleteButtonClicked()
        {
            if(!string.IsNullOrWhiteSpace(IncDepartment) && IncDepartment.Length>0
            || !string.IsNullOrWhiteSpace(IncCustomer) && IncCustomer.Length > 0
            || !string.IsNullOrWhiteSpace(Convert.ToString(IncCalender)) && Convert.ToString(IncCalender).Length > 0
            || !string.IsNullOrWhiteSpace(IncTitles) && IncTitles.Length > 0
            || !string.IsNullOrWhiteSpace(IncRecommend) && IncRecommend.Length > 0)
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
            IncDepartment = string.Empty;
            IncCustomer = string.Empty;
            IncDatePicker = string.Empty;
            IncTitles = string.Empty;
            IncNotes = string.Empty;
            IncRecommend = string.Empty;
        }

        private void HomeButtonClicked(string obj)
        {
            if(!string.IsNullOrWhiteSpace(IncDepartment) && IncDepartment.Length > 0
            || !string.IsNullOrWhiteSpace(IncCustomer) && IncCustomer.Length > 0
            || !string.IsNullOrWhiteSpace(Convert.ToString(IncCalender)) && Convert.ToString(IncCalender).Length > 0
            || !string.IsNullOrWhiteSpace(IncTitles) && IncTitles.Length > 0
            || !string.IsNullOrWhiteSpace(IncRecommend) && IncRecommend.Length > 0)
            {
                MessageBoxResult result = MessageBox.Show("You will loose all entries. Press cancel to stay on this page", "Warning !", MessageBoxButton.OKCancel);
                if(result == MessageBoxResult.OK)
                {
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
