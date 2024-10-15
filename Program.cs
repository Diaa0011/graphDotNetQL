using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using CommanderGQL.GraphQL.Platforms;
using CommanderGQL.GraphQL.Commands;

using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//AddPooledDbContextFactory is used to create a pool of DbContext instances - we can use the same DbContext more than one time 
//enable the use of the DbContext in the GraphQL schema(paralled usage)
builder.Services.AddPooledDbContextFactory<AppDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddType<PlatformType>()
    .AddType<CommandType>()
    .AddFiltering()
    .AddSorting();
    //.AddProjections();
    
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });


app.UseGraphQLVoyager("/voyager",new VoyagerOptions(){
    GraphQLEndPoint = "/graphql",
});

app.Run();
