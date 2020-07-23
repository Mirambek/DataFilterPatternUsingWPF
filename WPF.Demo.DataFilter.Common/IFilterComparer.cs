using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.Demo.DataFilter.Common
{
    public interface IFilterComparer<T>
    {
        bool Compare(T value);
    }
}
