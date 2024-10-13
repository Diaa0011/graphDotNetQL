using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL
{
    public class Query{
        //ScopedService & UseDbContext is used to create a new instance of the DbContext for each client request
        //enabling the use of the DbContext in the GraphQL schema mutiple times
        [UseDbContext(typeof(AppDbContext))]
        //UseProjection is used to enable the projection of the data from the database
        //meaning to conclude each child in the parent object such as the commands in the platform -must be added in program.cs in graphql adding part too- 
        [UseProjection]
        
        public IQueryable<Platform> GetPlatform([ScopedService] AppDbContext context)
        {
            return context.Platforms;
        }

        [UseDbContext(typeof(AppDbContext))]
        [UseProjection]
        public IQueryable<Command> GetCommand([ScopedService] AppDbContext context)
        {
            return context.Commands;
        }
    }
}