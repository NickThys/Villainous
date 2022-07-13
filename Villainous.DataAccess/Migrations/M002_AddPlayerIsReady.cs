using FluentMigrator;

namespace Villainous.DataAccess.Migrations
{
    [Migration(2)]
    public class M002_AddPlayerIsready : Migration
    {
        private readonly bool _seed;

        public M002_AddPlayerIsready(Options options)
        {
            _seed = options.Seed;
        }

        public override void Up()
        {

            Alter.Table("Players")
                .AddColumn("IsReady").AsBoolean().NotNullable().WithDefaultValue(false);
        }

        public override void Down()
        {
            if (Schema.Table("Players").Column("IsReady").Exists())
            {
                Delete.Column("IsReady").FromTable("Players");
            }
        }
    }

}
