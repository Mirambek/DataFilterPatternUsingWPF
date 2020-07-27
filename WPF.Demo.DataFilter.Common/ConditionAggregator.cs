using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WPF.Demo.DataFilter.Common
{
    public class ConditionAggregator<T> : ICondition<T>
    {
        public delegate void EventHandler();
        public event EventHandler OnFilterChanged;
        private readonly IEnumerable<ICondition<T>> aggregate;
        public ConditionAggregator(IEnumerable<ICondition<T>> aggregate)
        {
            this.aggregate = aggregate;
        }
        public bool Check(T value)
        {
            return aggregate.All(a=>a.Check(value));
        }

        public void RaiseFilterChanged()
        {
            OnFilterChanged.Invoke();
        }
    }
}