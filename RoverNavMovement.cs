using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Next24_Mars_Rover_Code_Challenge.NavigationLocation;

/*
The zones have been very carefully surveyed ahead of time and are deemed safe for
exploration within the landing terrain bounds, as represented by a single cartesian
coordinate - for example: (5, 5).
● The rover understands the cardinal points and can face either East(E), West(W), North
(N) or South(S) at any given time.
● The rover understands three commands:
○ M - Move one space forward in the direction it is facing
○ R - rotate 90 degrees to the right
○ L - rotate 90 degrees to the left
*/

namespace Next24_Mars_Rover_Code_Challenge.The_Rover
{
    public class RoverNavMovement : MarsRover
    {
        public MovementPoints Position { get; set; }
        public CardinalDirection CardinalDirection { get; set; }
        private bool isDeployed;
        private readonly IDictionary<Movement, Action> movementMethodDictionary;
        private readonly IDictionary<CardinalDirection, Action> leftMoveDictionary;
        private readonly IDictionary<CardinalDirection, Action> rightMoveDictionary;
        private readonly IDictionary<CardinalDirection, Action> forwardMoveDictionary;

        public RoverNavMovement()
        {
            movementMethodDictionary = new Dictionary<Movement, Action>
            {
                { Movement.left, () => leftMoveDictionary[CardinalDirection].Invoke() },
                { Movement.right, () => leftMoveDictionary[CardinalDirection].Invoke() },
                { Movement.Forward, () => leftMoveDictionary[CardinalDirection].Invoke() }

            };

            leftMoveDictionary = new Dictionary<CardinalDirection, Action>
            {
                { CardinalDirection.North, () => CardinalDirection = CardinalDirection.North},
                { CardinalDirection.East, () => CardinalDirection = CardinalDirection.East},
                { CardinalDirection.South, () => CardinalDirection = CardinalDirection.South},
                { CardinalDirection.West, () => CardinalDirection = CardinalDirection.West}

            };

            rightMoveDictionary = new Dictionary<CardinalDirection, Action>
            {
                { CardinalDirection.North, () => CardinalDirection = CardinalDirection.North},
                { CardinalDirection.East, () => CardinalDirection = CardinalDirection.East},
                { CardinalDirection.South, () => CardinalDirection = CardinalDirection.South},
                { CardinalDirection.West, () => CardinalDirection = CardinalDirection.West}

            };

            forwardMoveDictionary = new Dictionary<CardinalDirection, Action>
            {
                {CardinalDirection.North, () => { Position = new MovementPoints(Position.X,Position.Y + 1);}},
                {CardinalDirection.North, () => { Position = new MovementPoints(Position.X + 1,Position.Y);}},
                {CardinalDirection.North, () => { Position = new MovementPoints(Position.X,Position.Y - 1);}},
                {CardinalDirection.North, () => { Position = new MovementPoints(Position.X - 1,Position.Y);}}

            };
        }

        public void Deploy(LandingSurface aLandingSurface, MovementPoints aPoint, CardinalDirection aDirection)
        {
            if (aLandingSurface.IsValid(aPoint))
            {
                Position = aPoint;
                CardinalDirection = aDirection;
                isDeployed = true;
                return;
            }

            throwDeployException(aLandingSurface,aPoint);
        }

        public void Move(IEnumerable<Movement> movements)
        {
            foreach (var movement in movements)
            {
                movementMethodDictionary[movement].Invoke();
            }
        }

        public bool IsDeployed()
        {
            return isDeployed;
        }

        private static void throwDeployException(LandingSurface aLandingSurface, MovementPoints aPoint)
        {
            var size = aLandingSurface.GetSize();
            var exceptionMessage = string.Format("Deploy failed at point ({0},{1}). Landing zone size is {2} x {3}", 
                aPoint.X,aPoint.Y,size.Width,size.Height);

            throw new NotImplementedException(exceptionMessage);
        }
    }
}