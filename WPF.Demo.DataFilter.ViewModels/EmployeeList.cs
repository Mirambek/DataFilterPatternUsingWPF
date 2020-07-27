using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WPF.Demo.DataFilter.Common;
using WPF.Demo.DataFilter.Model;
using WPF.Demo.DataFilter.Repository;

namespace WPF.Demo.DataFilter.ViewModels
{
    public sealed class EmployeeList: ViewModelBase
    {
        private IEnumerable<Employee> employeesFullList;
        private readonly Filter<Employee> filters;
        private IEmployeesRepository repository;

        private IEnumerable<Employee> employees;
        public IEnumerable<Employee> Employees
        {
            get => employees;
            set => Set(ref employees, value);
        }
        public EmployeeList(IEmployeesRepository repository, ConditionAggregator<Employee> conditionAggregator)
        {
            this.repository = repository;
            this.filters = new ConcreteFilter<Employee>(conditionAggregator);
            conditionAggregator.OnFilterChanged += this.FilterList;
            _ = initAsync();
        }

        private void FilterList()
        {
            this.Employees = this.filters.Apply(this.employeesFullList);
        }
        private async Task initAsync()
        {
            this.Employees = await repository.GetEmployeesAsync();
            this.employeesFullList = this.Employees;
        }
    }
}
