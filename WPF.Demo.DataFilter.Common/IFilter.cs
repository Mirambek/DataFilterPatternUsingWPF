using System;
using System.Collections.Generic;

namespace WPF.Demo.DataFilter.Common
{
    public interface IFilter<T>
    {
        IEnumerable<T> Apply(IEnumerable<T> values);
    }
}
