using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;
using Next24_Mars_Rover_Code_Challenge.The_Rover;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre
{
    public class ICommandInvoker : CommandsInvoke
    {
        private readonly Func<MarsRover> roverFactory;
        private readonly IDictionary<CommandTypes, Action<Commands>> setReceiversMethodDictionary;

        private LandingSurface LandingSurface;
        private IList<MarsRover> rovers;
        private IEnumerable<Commands> CommandList;

        public ICommandInvoker(Func<MarsRover> aRoverFactory)
        {
            roverFactory = aRoverFactory;

            setReceiversMethodDictionary = new Dictionary<CommandTypes, Action<Commands>>
            {
                { CommandTypes.LandingSurfaceSizeCommand, SetReceiversLandingSurfaceSizeCommand},
                { CommandTypes.RoverDeployCommand, SetReceiversOnRoverDeployCommand},
                { CommandTypes.RoverExploreCommand, SetReceiversOnRoverExploreCommand}
            };          
        }

        public void SetLandingSurface(LandingSurface aLandingSurface)
        {
            LandingSurface = aLandingSurface;
        }

        public void setRovers(IList<MarsRover> someRovers)
        {
            rovers = someRovers;
        }

        public void Assign(IEnumerable<Commands> aCommandList)
        {
            CommandList = aCommandList;
        }

        public void InvokeAll()
        {
            foreach (var command in CommandList)
            {
                setReceivers(command);
                command.Execute();
            }
        }

        public void setReceivers(Commands command)
        {
            setReceiversMethodDictionary[command.GetCommandType()]
                .Invoke(command);
        }

        private void SetReceiversLandingSurfaceSizeCommand(Commands command)
        {
            var landingSurfaceSizeCommand = (landingSurfaceSizeCommand)command;
            landingSurfaceSizeCommand.setReceiver(LandingSurface);
        }

        private void SetReceiversOnRoverDeployCommand(Commands command)
        {
            var roverDeployCommand = (MarsRoverDeployCommand)command;
            var newRover = roverFactory();
            rovers.Add(newRover);
            roverDeployCommand.setReceivers(newRover, LandingSurface);

        }

        private void SetReceiversOnRoverExploreCommand(Commands command)
        {
            var roverExploreCommand = (marsExploreCommand)command;
            var latestRover = rovers[rovers.Count - 1];
            roverExploreCommand.SetReceiver(latestRover);
        }

        public void SetRovers(IList<MarsRover> aRovers)
        {
            throw new NotImplementedException();
        }

        public void assign(IEnumerable<Commands> aCommandList)
        {
            throw new NotImplementedException();
        }
    }
}
