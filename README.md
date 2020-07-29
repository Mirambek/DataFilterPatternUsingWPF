

<p>This article demonstrates filter pattern with generic lambda expression on WPF. Filter pattern along with pipeline is heavily used in data driven application. With c# lambda expression, the code can be shorted and generalized.</p>

<h2>Pipeline and filter pattern</h2>

<p>Traditionally filter pattern interface is implemented for every new filter. Instead of implementing interface for every filter condition, the generic lambda expression can be used as input to filters pipeline. As result, there will be less code. The following is class diagram:</p>

<p><img alt="" src="FilterPattern.png" /></p>

<p>ConditionAggregator is pipeline class where it stores collection of Condition&lt;T&gt;. Filter&lt;T&gt; owns ConditionAggregator or Condition&lt;T&gt; to apply filter conditions on data collection. When Filter&lt;T&gt; apply function is called, ICondition&lt;T&gt; check method is executed.&nbsp; ConditionAggregator&lt;T&gt; has event OnFilterChanged. It is triggered when the collection or condition value is changed at view model classes.&nbsp; The next section will describes view model usage filter pattern.</p>

<h2>Using the code</h2>

<p><strong>Usage in View Model</strong></p>

<p>MVVM framework explanation can be read in this <a href="https://www.tutorialspoint.com/mvvm/mvvm_responsibilities.htm">link</a>. In MVVM&nbsp; the one of responsibilities of the view model is to handle user interaction and data changes. In our case the filter condition value changes should be passed to business layer to apply filters on given data collection. The condition value changes in view model will trigger ConditionAggregator&lt;T&gt; OnFilterChanged event where filter apply method is subscribed. The following is class diagram of view model:</p>

<p><img src="ViewModel.png" /></p>

<p>Employee entity class is created to contain employee information. The generic T type of filter design pattern will be replaced with Employee class. EmployeeList holds list of employee data and Filters to apply. The class constructor receives condition list and passes to filter list.</p>

<pre lang="C#">
public EmployeeList(IEmployeesRepository repository, ConditionAggregator&lt;employee&gt; conditionAggregator)
        {
            this.repository = repository;
            this.filters = new ConcreteFilter&lt;employee&gt;(conditionAggregator);
            conditionAggregator.OnFilterChanged += this.FilterList;
            _ = initAsync();
        }

</pre>

<p>FilterList method is subscribed to OnFilterChanged event to apply filters on data when condition or value changed event occurs.</p>

<pre>
        private void FilterList()
        {
            this.Employees = this.filters.Apply(this.employeesFullList);
        }</pre>

<p>EmployeesViewModel is connected to UI. In this sample application, the only one EmployeeTypeselected property filter is demonstrated but the many filters can be passed to ConditionAggregator. The following code snippet is constructor method where Filter condition is registered.</p>

<pre>
     public EmployeesViewModel(IEmployeesRepository repository)
        {
            this.repository = repository;
            Condition&lt;employee&gt; filterEmployee = new Condition&lt;employee&gt;((e) =&gt; e.employeeCode == this.EmployeeTypeSelected);
            this.conditionAggregator = new ConditionAggregator&lt;employee&gt;(new List&lt;condition&lt;employee&gt;&gt; { filterEmployee });
            this.EmployeeList = new EmployeeList(repository, this.conditionAggregator);            
        }  
&lt;/condition&lt;employee&gt;&lt;/employee&gt;&lt;/employee&gt;&lt;/employee&gt;</pre>

<p>The condition is given as lambda expression. It can be as many as necessary since ConditionAggregator constructor accepts the List of filter conditions. The primary goal of code reduction of creating specific filter condition class is achieved.</p>

<h2>Architecture of sample application</h2>

<p><img src="architecture.png" /></p>

<p>WPF.Demo.DataFilter project is WPF UI view. It has one grid and one combobox to filter. WPF.Demo.DataFilter.ViewModels project handles data and filter changes and reloads data for UI update. WPF.Demo.DataFilter.Common project is full implementation of Filter and pipeline patterns. WPF.Demo.DataFilter.DAL loads simple json file as data store.</p>

<p>This is main UI::</p>

<p><img src="mainui.png" /></p>
