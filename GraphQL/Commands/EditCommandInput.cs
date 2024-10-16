namespace CommanderGQL.GraphQL.Commands
{
    public record EditCommandInput(int Id, string? HowTo, string? CommandLine, int? PlatformId);
}