using DbUp;

namespace UsersListWeb.PostgresMigrate
{
    public class PostgresMigrator
    {
        public static void Migrate(string connectionString)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            var upgrader = DeployChanges.To
            .PostgresqlDatabase(connectionString)
            .JournalToPostgresqlTable("protection", "__SchemaVersion")
            .WithScriptsFromFileSystem(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Scripts"))
            .WithVariable("BODY", "$BODY$")
            .WithExecutionTimeout(TimeSpan.FromSeconds(5))
            .Build();

            upgrader.GetScriptsToExecute();

            var result = upgrader.PerformUpgrade();

            if(!result.Successful)
            {
                throw new Exception("Migrate error: ", result.Error);
            }
        }

    }
}