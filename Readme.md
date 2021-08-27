<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128576981/20.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T607138)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/AspNetCoreDashboardState/Controllers/HomeController.cs)
* [_ViewImports.cshtml](./CS/AspNetCoreDashboardState/Views/_ViewImports.cshtml)
* [Index.cshtml](./CS/AspNetCoreDashboardState/Views/Home/Index.cshtml)
* [_Layout.cshtml](./CS/AspNetCoreDashboardState/Views/Shared/_Layout.cshtml)
<!-- default file list end -->
# Dashboard for ASP.NET Core - How to specify a default dashboard state in code


The sample illustrates how to specify a <strong>dashboard state</strong> (such as <a href="">master filter</a> or parameter values) in code and how to apply this state when loading a dashboard for the first time. In this example, the <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardCommon.DashboardState">DashboardState</a> object defined in the controller holds the required dashboard state. The MVC approach is used to pass the specified dashboard state to the View's <a href="https://docs.devexpress.com/Dashboard/DevExpress.DashboardAspNetCore.DashboardBuilder.InitialDashboardState(System.String)">DashboardBuilder.InitialDashboardState</a> property and use this state on loading a dashboard.

## Documentation

* [Manage Dashboard State](https://docs.devexpress.com/Dashboard/119997/web-dashboard/aspnet-core-dashboard-control/manage-dashboard-state)
* [Master Filtering](https://docs.devexpress.com/Dashboard/117060/web-dashboard/create-dashboards-on-the-web/interactivity/master-filtering)

## More Examples

* [Dashboard for Web Forms - How to specify a default dashboard state in code](https://github.com/DevExpress-Examples/aspxdashboard-how-to-specify-a-default-dashboard-state-in-code-t513681)
* [Dashboard for MVC - How to specify a default dashboard state in code](https://github.com/DevExpress-Examples/aspnet-mvc-dashboard-how-to-specify-a-default-dashboard-state-in-code-t586607)
* [Dashboard for WPF - How to Set the Initial Dashboard State](https://github.com/DevExpress-Examples/wpf-dashboard-how-to-set-initial-dashboard-state)
* [Dashboard for WinForms - How to Save and Restore the Dashboard State](https://github.com/DevExpress-Examples/winforms-dashboard-save-restore-dashboard-state)


