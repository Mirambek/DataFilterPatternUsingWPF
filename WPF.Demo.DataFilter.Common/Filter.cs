using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.Demo.DataFilter.Common
{
    public sealed class Filter<T> : IFilter<T>
    {
        private readonly IFilterComparer<T> filters;
        public Filter(IFilterComparer<T> filters)
        {
            this.filters = filters;
        }
        public IEnumerable<T> Apply(IEnumerable<T> values)
        {
            return values.Where(w => this.filters.Compare(w));
        }
    }
}
