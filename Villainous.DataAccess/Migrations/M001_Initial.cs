using FluentMigrator;

namespace Villainous.DataAccess.Migrations
{
    [Migration(1)]
    public class M001_Initial : Migration
    {
        private readonly bool _seed;

        public M001_Initial(Options options)
        {
            _seed = options.Seed;
        }

        public override void Up()
        {
            Create.Table("Players")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("Position").AsInt32().NotNullable()
                .WithColumn("IsReady").AsBoolean().NotNullable();

        }

        public override void Down()
        {
            Delete.Table("Players");
        }
    }

}
