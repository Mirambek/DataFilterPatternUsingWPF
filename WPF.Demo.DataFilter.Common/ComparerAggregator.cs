using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WPF.Demo.DataFilter.Common
{
    public class ComparerAggregator<T> : IFilterComparer<T>
    {
        public delegate void EventHandler();
        public event EventHandler OnFilterChanged;
        private readonly IEnumerable<IFilterComparer<T>> aggregate;
        public ComparerAggregator(IEnumerable<IFilterComparer<T>> aggregate)
        {
            this.aggregate = aggregate;
        }
        public bool Compare(T value)
        {
            return aggregate.All(a=>a.Compare(value));
        }
    }
}
