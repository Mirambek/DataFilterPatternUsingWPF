using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WPF.Demo.DataFilter.Common
{
    public sealed class ConcreteFilter<T> : Filter<T>
    {

        public ConcreteFilter(ICondition<T> filters) : base(filters) { }
       
        public override IEnumerable<T> Apply(IEnumerable<T> values)
        {
            return values?.Where(w => this.filters.Check(w));
        }
    }
}
