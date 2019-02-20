using System;


namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre.Parsers
{
    public interface iMatchCommands
    {
        CommandTypes GetCommandTypes(string command);
    }
}