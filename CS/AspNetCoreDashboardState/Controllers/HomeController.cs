using AspNetCoreDashboardState.Models;
using DevExpress.DashboardCommon;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace AspNetCoreDashboardState.Controllers {
    public class HomeController : Controller
    {
        public IActionResult Index() {
            DashboardState dashboardState = new DashboardState();

            DashboardParameterState parameterState =
                new DashboardParameterState("countryParameter", "USA", typeof(string));

            DashboardItemState gridFilterState = new DashboardItemState("gridDashboardItem1");
            gridFilterState.MasterFilterValues.AddRange(new List<object[]>() {
                new string[1] { "Andrew Fuller" },
                new string[1] { "Laura Callahan" }
            }
            );

            DashboardItemState treemapDrilldownState = new DashboardItemState("treemapDashboardItem1");
            treemapDrilldownState.DrillDownValues.Add("Beverages");

            DashboardItemState rangeFilterState = new DashboardItemState("rangeFilterDashboardItem1");
            rangeFilterState.RangeFilterState.Selection =
                new RangeFilterSelection(new DateTime(2015, 1, 1), new DateTime(2016, 1, 1));

            dashboardState.Parameters.Add(parameterState);
            dashboardState.Items.AddRange(new List<DashboardItemState>() {
                gridFilterState,
                treemapDrilldownState,
                rangeFilterState }
            );

            return View(dashboardState);
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
