# ASP.NET Core Dashboard Control - How to specify a default dashboard state in code


<p>The sample illustrates how to specify a <strong>dashboard state</strong> (such as master filter or parameter values) in code and how to apply this state when loading a dashboard for the first time. In this example, the <a href="https://documentation.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardState.class">DashboardState</a> object defined in the Controller holds the required dashboard state. The MVC approach is used to pass the specified dashboard state to the View's <strong>DashboardBuilder.InitialDashboardState</strong> property and use this state on loading a dashboard.</p>

<br/>


