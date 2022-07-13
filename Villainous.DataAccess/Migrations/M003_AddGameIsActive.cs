using FluentMigrator;

namespace Villainous.DataAccess.Migrations
{
    [Migration(3)]
    public class M003_AddGameIsActive : Migration
    {
        private readonly bool _seed;

        public M003_AddGameIsActive(Options options)
        {
            _seed = options.Seed;
        }

        public override void Up()
        {

            Alter.Table("Games")
                .AddColumn("IsActive").AsBoolean().NotNullable().WithDefaultValue(false);
        }

        public override void Down()
        {
            if (Schema.Table("Games").Column("IsActive").Exists())
            {
                Delete.Column("IsActive").FromTable("Games");
            }
        }
    }

}
