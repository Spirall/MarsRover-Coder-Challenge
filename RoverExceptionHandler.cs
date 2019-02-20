using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Next24_Mars_Rover_Code_Challenge.The_Rover
{
    public class RoverExceptionHandler : Exception
    {
        public RoverExceptionHandler(string msg) : base(msg) { }
    }
}