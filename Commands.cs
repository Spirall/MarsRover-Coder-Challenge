
using System.Data;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre
{
    public interface Commands
    {
        CommandType GetCommandType();
        void Execute();
    }
}