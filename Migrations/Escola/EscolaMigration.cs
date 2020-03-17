using FluentMigrator;

namespace Migrations.Escola
{
    [Tags(TagBehavior.RequireAny, nameof(Escola))]
    public abstract class EscolaMigration : Migration
    {
    }
}
