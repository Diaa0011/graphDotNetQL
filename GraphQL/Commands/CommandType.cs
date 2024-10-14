using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL.Commands
{
    public class CommandType:ObjectType<Command>
    {
        protected override void Configure(IObjectTypeDescriptor<Command> descriptor)
        {
            descriptor.Description("Represents any executable command.");

            /*descriptor
                .Field(c => c.Id)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!,default!))
                .UseDbContext<AppDbContext>()
                .Description("This is Paltform the command belongs");
            
             descriptor
                .Field(c => c.Id)
                .Description("This is the unique ID of the command.");*/

            // Resolver for platform
            descriptor
                .Field(c => c.Platform)
                .ResolveWith<Resolvers>(c => c.GetPlatform(default!, default!))
                .UseDbContext<AppDbContext>()
                .Description("This is the platform the command belongs to.");
             
        }

        private class Resolvers
        {
            public Platform GetPlatform([Parent] Command command,[ScopedService] AppDbContext context)
            {
                return context.Platforms.FirstOrDefault(p=>p.Id==command.PlatformId);
            }
        }
    }
}