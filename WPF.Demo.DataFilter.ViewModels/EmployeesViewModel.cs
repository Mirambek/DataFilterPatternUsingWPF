using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WPF.Demo.DataFilter.Common;
using WPF.Demo.DataFilter.Model;
using WPF.Demo.DataFilter.Repository;

namespace WPF.Demo.DataFilter.ViewModels
{
    public class EmployeesViewModel: ViewModelBase
    {        
        private readonly IEmployeesRepository repository;

        private string employeeTypeSelected;
        public string EmployeeTypeSelected
        {
            get => employeeTypeSelected;
            set
            {
                Set(ref employeeTypeSelected, value);
                this.comparerAggregator?.RaiseFilterChanged();
                
            }
        }

        private EmployeeList employeeList;
        private readonly ComparerAggregator<Employee> comparerAggregator;

        public EmployeeList EmployeeList
        {
            get => employeeList;
            set
            {
                Set(ref employeeList, value);
            }
        }
        public EmployeesViewModel(IEmployeesRepository repository)
        {
            this.repository = repository;
            FilterComparer<Employee> filterEmployee = new FilterComparer<Employee>((e) => e.employeeCode == this.EmployeeTypeSelected);
            this.comparerAggregator = new ComparerAggregator<Employee>(new List<FilterComparer<Employee>> { filterEmployee });
            this.EmployeeList = new EmployeeList(repository, this.comparerAggregator);            
        }
        
    }
}
