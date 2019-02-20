using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Web;
using Next24_Mars_Rover_Code_Challenge.NavCommandCentre.Parsers;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre.Parsers
{
    public class MatchCommands : iMatchCommands
    {
        private IDictionary<string, CommandTypes> commandTypeDictionary;

        public MatchCommands()
        {
            InitializeCommandTypeDictionary();
        }

        public CommandTypes GetCommandTypes(string command)
        {
            try
            {
                var commandType = commandTypeDictionary.First(
                    regexToCommandType => new Regex(regexToCommandType.Key).IsMatch(command));

                return commandType.Value;
            }
            catch (InvalidOperationException e)
            {

                var exceptionMessage = String.Format("String '{0}' is not a valid command", command);
                throw new CommandExceptions(exceptionMessage, e);
            }
        }

        private void InitializeCommandTypeDictionary()
        {
            commandTypeDictionary = new Dictionary<string, CommandTypes>
            {
                { @"^\d+ \d+$", CommandTypes.LandingSurfaceSizeCommand },
                { @"^\d+ \d+ [NSEW]$", CommandTypes.RoverDeployCommand },
                { @"^[LRM]+$", CommandTypes.RoverExploreCommand }
            };
        }

        internal static CommandTypes GetCommandType(string command)
        {
            throw new NotImplementedException();
        }
    }
}