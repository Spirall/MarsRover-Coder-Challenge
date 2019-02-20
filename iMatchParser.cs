using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Next24_Mars_Rover_Code_Challenge.NavCommandCentre.Parsers
{
    public interface iMatchParser
    {
        IEnumerable<Commands> Parse(string commandString);
    }
}