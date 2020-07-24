using Microsoft.Extensions.DependencyInjection;
using WPF.Demo.DataFilter.ViewModels;

namespace WPF.Demo.DataFilter.vm
{
    public sealed class ViewModelLocator
    {
        public EmployeesViewModel EmployeeModel => App.ServiceProvider.GetRequiredService<EmployeesViewModel>();
    }
}
