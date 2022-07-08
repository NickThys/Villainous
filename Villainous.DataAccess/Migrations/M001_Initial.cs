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

            Create.Table("Games")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Code").AsString().NotNullable()
                .WithColumn("PlayerPlaying").AsInt32().Nullable();
            Create.Table("Players")
                .WithColumn("Id").AsInt32().Identity().PrimaryKey().NotNullable()
                .WithColumn("Name").AsString().NotNullable()
                .WithColumn("GameId").AsInt32().NotNullable().ForeignKey("FK_players_game", "Games", "Id");
        }

        public override void Down()
        {
            if (Schema.Table("Players").Constraint("FK_players_game").Exists())
            {
                Delete.ForeignKey("FK_players_game").OnTable("Players");
            }
            Delete.Table("Games");
            Delete.Table("Players");
        }
    }

}
