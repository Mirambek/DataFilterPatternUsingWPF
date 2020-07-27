using System;
using System.Collections.Generic;

namespace WPF.Demo.DataFilter.Common
{
    public abstract class Filter<T>
    {
        protected readonly ICondition<T> filters;
        
        protected Filter(ICondition<T> filters)
        {
            this.filters = filters;
        }

        public abstract IEnumerable<T> Apply(IEnumerable<T> values);
    }
}
