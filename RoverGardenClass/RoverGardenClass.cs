using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverGardenClass
{
    public class MowerInformation
    {
        public MowerInformation(GardenRover.RoverDirection moving, int x, int y)
        {
            Moving = moving;
            X = x;
            Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public GardenRover.RoverDirection Moving { get; set; }
    }

    public class GardenRover
    {
        public enum RoverDirection
        {
            N, S, E, W
        }
        private const string comL = "L";
        private const string comR = "R";
        private const string comM = "M";

        private MowerInformation CurrentMowerPosition;
        private int GardenWidth;
        private int GardenHeight;
        /// <summary>
        /// This is constructor for the Rover and assign all the required values 
        /// </summary>
        public GardenRover(int x, int y, RoverDirection strMowerDircetion, int xGarden, int yGarden)
        {
            //Validation checking for the input data can be implemented 
            CurrentMowerPosition = new MowerInformation(strMowerDircetion, x, y);
            GardenWidth = xGarden;
            GardenHeight = yGarden;
        }

        public bool MoveMowerByCommand(string strCommandVal)
        {
            for (int i = 0; i < strCommandVal.Length; i++)
            {
                string strCommanditem = strCommandVal[i].ToString();
                if (strCommanditem == comL || strCommanditem == comR)
                    ChangeDirection(strCommanditem);
                else if (strCommanditem == comM)
                    MoveNext(strCommanditem);
                else
                    throw new Exception("The command is not valid!!!");
            }

            return true;
        }

        /// <summary>
        /// This function is to move forward the rover without changing the direction 
        /// also ensuring the mower is inside the garden 
        /// </summary>
        public void MoveNext(string strMove)
        {
            switch (CurrentMowerPosition.Moving)
            {
                case RoverDirection.S:
                    if (CurrentMowerPosition.Y > 0)
                        CurrentMowerPosition.Y -= 1;
                    break;
                case RoverDirection.N:
                    if (CurrentMowerPosition.Y + 1 <= GardenHeight)
                        CurrentMowerPosition.Y += 1;
                    break;
                case RoverDirection.W:
                    if (CurrentMowerPosition.X > 0)
                        CurrentMowerPosition.X -= 1;
                    break;
                case RoverDirection.E:
                    if (CurrentMowerPosition.X + 1 <= GardenWidth)
                        CurrentMowerPosition.X += 1;
                    break;
            }
        }
        public MowerInformation GetPosition()
        {
            return CurrentMowerPosition;
        }
        /// <summary>
        /// This fuction to set the mower direction without changing current coordinate 
        /// </summary>
        /// <param name="command"></param>
        public void ChangeDirection(string strcommand)
        {

            if (strcommand == comL)
            {
                if (CurrentMowerPosition.Moving == RoverDirection.N)
                    CurrentMowerPosition.Moving = RoverDirection.W;
                else if (CurrentMowerPosition.Moving == RoverDirection.W)
                    CurrentMowerPosition.Moving = RoverDirection.S;
                else if (CurrentMowerPosition.Moving == RoverDirection.S)
                    CurrentMowerPosition.Moving = RoverDirection.E;
                else if (CurrentMowerPosition.Moving == RoverDirection.E)
                    CurrentMowerPosition.Moving = RoverDirection.N;
            }
            else if (strcommand == comR)
            {
                if (CurrentMowerPosition.Moving == RoverDirection.N)
                    CurrentMowerPosition.Moving = RoverDirection.E;
                else if (CurrentMowerPosition.Moving == RoverDirection.E)
                    CurrentMowerPosition.Moving = RoverDirection.S;
                else if (CurrentMowerPosition.Moving == RoverDirection.S)
                    CurrentMowerPosition.Moving = RoverDirection.W;
                else if (CurrentMowerPosition.Moving == RoverDirection.W)
                    CurrentMowerPosition.Moving = RoverDirection.N;
            }
            else
            {
                throw new Exception("The command is not valid!!!");
            }
        }

    }
}
