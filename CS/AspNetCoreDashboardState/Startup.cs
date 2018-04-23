using DevExpress.AspNetCore;
using DevExpress.DashboardAspNetCore;
using DevExpress.DashboardCommon;
using DevExpress.DashboardWeb;
using DevExpress.DataAccess.ConnectionParameters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspNetCoreDashboardState {
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment hostingEnvironment) {
            Configuration = configuration;
            HostingEnvironment = hostingEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment HostingEnvironment { get; }

        public void ConfigureServices(IServiceCollection services) {
            services
                .AddMvc()
                .AddDefaultDashboardController(configurator => {
                    configurator.SetDashboardStorage(new DashboardFileStorage("Dashboards"));
                    configurator.SetConnectionStringsProvider(new DashboardConnectionStringsProvider(Configuration));
                    configurator.SetDataSourceStorage(CreateDataSourceStorage());
                    configurator.ConfigureDataConnection += Configurator_ConfigureDataConnection;
                });
            services.AddDevExpressControls(settings => settings.Resources = ResourcesType.ThirdParty | ResourcesType.DevExtreme);
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
            DevExpress.DataAccess.Sql.SelectQuery query = DevExpress.DataAccess.Sql.SelectQueryFluentBuilder
                .AddTable("SalesPerson")
                .SelectAllColumns()
                .Build("Sales Person");
            sqlDataSource.Queries.Add(query);
            dataSourceStorage.RegisterDataSource("sqlDataSource", sqlDataSource.SaveToXml());

            return dataSourceStorage;
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            } else {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseDevExpressControls();
            app.UseMvc(routes => {
                routes.MapDashboardRoute();
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
