# ASP.NET Core Dashboard Control - How to specify a default dashboard state in code


<p>The sample illustrates how to specify a <strong>dashboard state</strong> (such as <a href="">master filter</a> or parameter values) in code and how to apply this state when loading a dashboard for the first time. In this example, the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardState">DashboardState</a> object defined in the controller holds the required dashboard state. The MVC approach is used to pass the specified dashboard state to the View's <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardAspNetCore.DashboardBuilder.InitialDashboardState(System.String)">DashboardBuilder.InitialDashboardState</a> property and use this state on loading a dashboard.</p>

<br/>


