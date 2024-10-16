using CommanderGQL.Models;
namespace CommanderGQL.GraphQL.Commands
{
    [GraphQLDescription("Represents the payload(result for each mutation) to return for a command.")]
    public record CommandPayload(Command command);
}