using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.DataAccess.Sql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace AspNetCoreDashboardState {
    public class Startup {
        public Startup(IConfiguration configuration, IWebHostEnvironment hostingEnvironment) {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services) {
            services
                .AddDevExpressControls()
                .AddMvc();

            services.AddScoped<DashboardConfigurator>((IServiceProvider serviceProvider) => {
                DashboardConfigurator configurator = new DashboardConfigurator();

                configurator.SetDashboardStorage(new DashboardFileStorage("Dashboards"));
                configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));
                configurator.SetDataSourceStorage(CreateDataSourceStorage());
                configurator.ConfigureDataConnection += Configurator_ConfigureDataConnection;

                return configurator;
            });
        }

        private void Configurator_ConfigureDataConnection(object sender, ConfigureDataConnectionWebEventArgs e) {
            if (e.ConnectionName == "sqliteConnection") {
                SQLiteConnectionParameters sqliteParams = new SQLiteConnectionParameters();
                sqliteParams.FileName = "file:Data/nwind.db";
                e.ConnectionParameters = sqliteParams;
            }
        }

        public DataSourceInMemoryStorage CreateDataSourceStorage() {
            DataSourceInMemoryStorage dataSourceStorage = new DataSourceInMemoryStorage();

            DashboardSqlDataSource sqlDataSource = new DashboardSqlDataSource("SQL Data Source", "sqliteConnection");
            sqlDataSource.DataProcessingMode = DataProcessingMode.Client;
            DevExpress.DataAccess.Sql.SelectQuery query = SelectQueryFluentBuilder
                .AddTable("SalesPerson")
                .SelectAllColumns()
                .Build("Sales Person");
            sqlDataSource.Queries.Add(query);
            dataSourceStorage.RegisterDataSource("sqlDataSource", sqlDataSource.SaveToXml());

            return dataSourceStorage;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            // Register the DevExpress middleware.
            app.UseDevExpressControls();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                // Map dashboard routes.
                endpoints.MapDashboardRoute("api/dashboard", "DefaultDashboard");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
