using CommanderGQL.Data;
using CommanderGQL.GraphQL;
using GraphQL.Server.Ui.Voyager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
));
builder.Services.AddGraphQLServer().AddQueryType<Query>();
var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });


app.UseGraphQLVoyager("/voyager",new VoyagerOptions(){
    GraphQLEndPoint = "/graphql",
});

app.Run();
