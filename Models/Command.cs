using System.ComponentModel.DataAnnotations;

namespace CommanderGQL.Models
{
    public class Command{
        [Key]
        public int Id{get;set;}
        [GraphQLDescription("what command should do?")]
        [Required]
        public string HowTo{get;set;}
        [GraphQLDescription("syntax of the command in the command line")]
        [Required]
        public string CommandLine{get;set;}
        [GraphQLDescription("Platform Id which this command belongs to")]
        [Required]
        public int PlatformId{get;set;}
        [GraphQLDescription("Platform")]
        public Platform Platform{get;set;}

    }
}