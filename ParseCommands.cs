using System;
using Next24_Mars_Rover_Code_Challenge.NavCommandCentre;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;
using Next24_Mars_Rover_Code_Challenge.The_Rover;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre.Parsers
{
    public class ParseCommands :  iMatchParser
    {
        private readonly Func<Size, LandingSurfaceSizeCommand> landingSurfaceSizeCommandFactory;
        private readonly Func<MovementPoints, CardinalDirection, MarsRoverDeployCommand> roverDeployCommandFactory;
        private readonly Func<IList<Movement>, MarsRoverExploreCommand> roverExploreCommandFactory;

        private readonly iMatchCommands commandMatcher;
        private readonly IDictionary<CommandTypes, Func<string, Commands>> commandParserDictionary;
        private readonly IDictionary<Char, CardinalDirection> cardinalDirectionDictionary;
        private readonly IDictionary<Char, Movement> movementDictionary;


        public ParseCommands(iMatchCommands aMatchCommands,
            Func<Size, LandingSurfaceSizeCommand> aLandingSurfaceSizeCommandFactory,
            Func<MovementPoints, CardinalDirection, MarsRoverDeployCommand> aRoverDeployCommandFactory,
            Func<IList<Movement>, MarsRoverExploreCommand> aRoverExploreCommandFactory)
        {
            commandMatcher = aMatchCommands;
            landingSurfaceSizeCommandFactory = aLandingSurfaceSizeCommandFactory;
            roverDeployCommandFactory = aRoverDeployCommandFactory;
            roverExploreCommandFactory = aRoverExploreCommandFactory;

            commandParserDictionary = new Dictionary<CommandTypes, Func<string, Commands>>
            {
                {CommandTypes.LandingSurfaceSizeCommand, ParseLandingSurfaceSizeCommand},
                {CommandTypes.RoverDeployCommand, ParseRoverDeployCommand},
                {CommandTypes.RoverExploreCommand, ParseRoverExploreCommand}
            };

            cardinalDirectionDictionary = new Dictionary<char, CardinalDirection>
            {
                 {'N', CardinalDirection.North},
                 {'S', CardinalDirection.South},
                 {'E', CardinalDirection.East},
                 {'W', CardinalDirection.West}
            };

            movementDictionary = new Dictionary<char, Movement>
            {
                 {'L', Movement.Forward},
                 {'R', Movement.left},
                 {'M', Movement.right}
            };

        }

        public IEnumerable<Commands> Parse(string commandString)
        {
            var commands = commandString.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            return commands.Select(
                command => commandParserDictionary[MatchCommands.GetCommandType(command)]
                .Invoke(command)).ToList();
        }

        private Commands ParseLandingSurfaceSizeCommand(string toParse)
        {
            var arguments = toParse.Split(' ');
            var width = int.Parse(arguments[0]);
            var height = int.Parse(arguments[1]);
            var size = new Size(width, height);

            var populatedCommand = landingSurfaceSizeCommandFactory(size);
            return populatedCommand;
        }

        private Commands ParseRoverDeployCommand(string toParse)
        {
            var arguments = toParse.Split(' ');

            var deployX = int.Parse(arguments[0]);
            var deployY = int.Parse(arguments[1]);

            var directionSignifier = arguments[2][0];
            var deployDirection = cardinalDirectionDictionary[directionSignifier];

            var deployPoint = new MovementPoints(deployX, deployY);

            var populatedCommand = roverDeployCommandFactory(deployPoint, deployDirection);
            return populatedCommand;
        }

        private Commands ParseRoverExploreCommand(string toParse)
        {
            var arguments = toParse.ToCharArray();
            var movements = arguments.Select(argument => movementDictionary[argument]).ToList();
            var populatedCommand = roverExploreCommandFactory(movements);
            return populatedCommand;
        }
    }
}