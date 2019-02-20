using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre.Parsers
{

    [Serializable]
    public class CommandExceptions : Exception
    {
        public CommandExceptions(string msg, Exception innerException) : base(msg,innerException) { }
    }
}