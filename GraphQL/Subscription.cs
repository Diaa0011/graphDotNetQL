using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    [GraphQLDescription("Subscriptions available in the API for real-time updates.")]
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Platform OnPlatformAdd([EventMessage] Platform platform) => platform;
        [Subscribe]
        [Topic]
        public Platform OnPlatformEdit([EventMessage] Platform platform) => platform;
        [Subscribe]
        [Topic]
        public Platform OnPlatformDelete([EventMessage] Platform platform) => platform;
        [Subscribe]
        [Topic]
        public Command OnCommandAdd([EventMessage] Command command) => command;
        [Subscribe]
        [Topic]
        public Command OnCommandEdit([EventMessage] Command command) => command;
        [Subscribe]
        [Topic]
        public Command OnCommandDelete([EventMessage] Command command) => command;
        //Same as 
        /*
        public Platform OnPlatformAdded([EventMessage] Platform platform)
        {
            return platform;
        }
        */
    }
}