using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    [GraphQLDescription("Represents any software or service that has a command line interface.")]
    public class Platform
    {
        [Key]
        public int Id { get; set; }
        [GraphQLDescription("Name of the software or service")]
        public string Name { get; set; }
        [GraphQLDescription("Represents a purchased, valid license for the platform")]
        public string? LicenseKey { get; set; }
        [GraphQLDescription("List of commands available for this platform")]
        public ICollection<Command> Commands{get;set;} = new List<Command>();
    }
}