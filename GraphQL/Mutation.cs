using CommanderGQL.Data;
using CommanderGQL.GraphQL.Commands;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.Models;
using HotChocolate.Subscriptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace CommanderGQL.GraphQL
{
    public class Mutation
    {
        //Platform Section
        [UseDbContext(typeof(AppDbContext))]
        public async Task<PlatformPayLoad> AddPlatformAsync(AddPlatformInput input,
        [ScopedService]AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var platform = new Platform{
                Name = input.Name
            };

            context.Platforms.Add(platform);

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformAdd), platform, cancellationToken);
            
            return new PlatformPayLoad(platform);
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<PlatformPayLoad> EditPlatformAsync(EditPlatformInput input,
        [ScopedService]AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var platform = await context.Platforms.FindAsync(input.Id);

            if(platform == null)
            {
                throw new InvalidOperationException("Platform not found");
            }

            platform.Name = input.Name;

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformEdit), platform, cancellationToken);

            return new PlatformPayLoad(platform);
        }
        [UseDbContext(typeof(AppDbContext))]
        public async Task<PlatformPayLoad> DeletePlatformAsync(DeletePlatformInput input,
        [ScopedService]AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var platform = await context.Platforms.FindAsync(input.Id);
            if(platform == null){
                throw new InvalidOperationException("Platform not found");
            }

            var commands = await context.Commands.Where(c => c.PlatformId == platform.Id).ToListAsync();
            //Remove all commands associated with the platform
            context.Commands.RemoveRange(commands);
            //Remove the platform
            context.Platforms.Remove(platform);

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnPlatformDelete), platform, cancellationToken);

            return new PlatformPayLoad(platform);
        }
        
        //Command Section
        [UseDbContext(typeof(AppDbContext))]
        public async Task<CommandPayload> AddCommandAsync(AddCommandInput input,
        [ScopedService]AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var command = new Command{
                HowTo = input.HowTo,
                CommandLine = input.CommandLine,
                PlatformId = input.PlatformId
            };
            context.Commands.Add(command);

            await context.SaveChangesAsync();
            
            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnCommandAdd), command, cancellationToken);
            return new CommandPayload(command);
        }

        [UseDbContext(typeof(AppDbContext))]
        public async Task<CommandPayload> EditCommandAsync(EditCommandInput input,
        [ScopedService]AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var command = await context.Commands.FindAsync(input.Id);

            if(command == null){
                throw new InvalidOperationException("Command not found");
            }
            if(input.HowTo != null){
                command.HowTo = input.HowTo;
            }
            if(input.CommandLine != null){
                command.CommandLine = input.CommandLine;
            }
            if(input.PlatformId != null){
                command.PlatformId = (int)input.PlatformId;
            }

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnCommandEdit), command, cancellationToken);

            return new CommandPayload(command);
    }
    [UseDbContext(typeof(AppDbContext))]
        public async Task<CommandPayload> DeleteCommandAsync(DeleteCommandInput input,
        [ScopedService]AppDbContext context,
        [Service] ITopicEventSender eventSender,
        CancellationToken cancellationToken)
        {
            var command = await context.Commands.FindAsync(input.Id);

            if(command == null){
                throw new InvalidOperationException("Command not found");
            }

            context.Commands.Remove(command);

            await context.SaveChangesAsync(cancellationToken);

            await eventSender.SendAsync(nameof(Subscription.OnCommandDelete), command, cancellationToken);

            return new CommandPayload(command);
        }
}
}