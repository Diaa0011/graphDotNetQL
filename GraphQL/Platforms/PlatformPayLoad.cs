using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Platforms
{
    [GraphQLDescription("Represents the payload(result for each mutation) to return for a platform.")]
    public record PlatformPayLoad(Platform platform);
}