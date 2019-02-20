using System.Collections.Generic;
using Next24_Mars_Rover_Code_Challenge.NavCommandCentre;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;
using Next24_Mars_Rover_Code_Challenge.NavCommandCentre.Parsers;
using Next24_Mars_Rover_Code_Challenge.The_Rover;

namespace Nasa.MarsRover
{
    public class CommandCenter : ICommandCenter
    {
        private readonly LandingSurface landingSurface;
        private readonly  ParseCommands commandParser;
        private readonly CommandsInvoke commandInvoker;
        private readonly IReportComposer reportComposer;

        private readonly IList<MarsRoverDeployCommand> rovers;

        public CommandCenter(LandingSurface aLandingSurface, ParseCommands aCommandParser, CommandsInvoke aCommandInvoker, IReportComposer aReportComposer)
        {
            rovers = new List<MarsRover>();
            landingSurface = aLandingSurface;
            commandParser = aCommandParser;
            commandInvoker = aCommandInvoker;
            reportComposer = aReportComposer;
            commandInvoker.SetLandingSurface(landingSurface);
            commandInvoker.SetRovers(rovers);
        }

        public void Execute(string commandString)
        {
            var commandList = commandParser.Parse(commandString);
            CommandsInvoke.Assign(commandList);
            CommandsInvoke.InvokeAll();
        }

        public LandingSurface GetLandingSurface()
        {
            return landingSurface;
        }

        public string GetCombinedRoverReport()
        {
            return reportComposer.CompileReports(rovers);
        }

        LandingSurface ICommandCenter.GetLandingSurface()
        {
            throw new System.NotImplementedException();
        }
    }
}