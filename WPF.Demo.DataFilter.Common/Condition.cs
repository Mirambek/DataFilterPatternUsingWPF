using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.Demo.DataFilter.Common
{    
    public sealed class Condition<T> : ICondition<T>
    {
        private readonly Func<T, bool> condition;
        public Condition(Func<T, bool> condition)
        {
            this.condition = condition;
        }
        public bool Check(T value)
        {
            return condition.Invoke(value);
        }
    }
}
