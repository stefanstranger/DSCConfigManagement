namespace DSCConfigurationManagement.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DSCConfigurationManagement.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DSCConfigurationManagement.Models.DSCConfigurationManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DSCConfigurationManagement.Models.DSCConfigurationManagementContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.MyGuids.AddOrUpdate(x => x.ID,
                new MyGuid() {ID = 1, FQDN = "server1.contoso.local", DSCGuid = "d78e1ac4-ea67-4735-b969-6d8751c05bde"});
        }
    }
}
