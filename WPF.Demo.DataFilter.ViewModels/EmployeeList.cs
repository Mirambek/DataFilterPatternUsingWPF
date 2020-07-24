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

        private readonly IFilter<Employee> filters;
        private IEmployeesRepository repository;

        private IEnumerable<Employee> employees;
        public IEnumerable<Employee> Employees
        {
            get => employees;
            set => Set(ref employees, value);
        }
        public EmployeeList(IEmployeesRepository repository, ComparerAggregator<Employee> filterAggregate)
        {
            this.repository = repository;
            this.filters = new Filter<Employee>(filterAggregate);
            filterAggregate.OnFilterChanged += this.FilterList;
            _ = initAsync();
        }

        private void FilterList()
        {
            this.Employees = this.filters.Apply(Employees);
        }
        private async Task initAsync()
        {
            this.Employees = await repository.GetEmployeesAsync();
        }
    }
}
