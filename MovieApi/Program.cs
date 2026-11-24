
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Welcom to Movie API!");

app.MapGet("/api/healt/db", async (IConfiguration configuration, ILogger<Program> logger) =>
{
    string connectionString =
         configuration.GetConnectionString("MovieDatabase")
         ?? throw new InvalidOperationException(
             "Missing database connection string.");

    try
    {
        await using var connection =
            new MySqlConnection(connectionString);

        await connection.OpenAsync();

        await using var command =
            new MySqlCommand("SELECT 1;", connection);

        object? result = await command.ExecuteScalarAsync();

        return Results.Ok(new
        {
            message = "Database connection successful",
            result
        });
    }
    catch (MySqlException ex)
    {
        logger.LogError(ex, "Database connection failed");

        return Results.Problem(
            title: "Database unavailable",
            statusCode: 503
        );
    }
});




app.Run();
