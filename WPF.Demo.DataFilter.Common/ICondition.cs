using System;
using System.Collections.Generic;
using System.Text;

namespace WPF.Demo.DataFilter.Common
{
    public interface ICondition<T>
    {
        bool Check(T value);
    }
}
