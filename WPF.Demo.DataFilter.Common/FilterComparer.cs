using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.Demo.DataFilter.Common
{    
    public sealed class FilterComparer<T> : IFilterComparer<T>
    {
        private readonly Func<T, bool> comparer;
        public FilterComparer(Func<T, bool> comparer)
        {
            this.comparer = comparer;
        }
        public bool Compare(T value)
        {
            return comparer.Invoke(value);
        }
    }
}
