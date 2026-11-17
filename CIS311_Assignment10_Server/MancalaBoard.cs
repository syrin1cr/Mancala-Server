using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mancala_Console
{

    internal class MancalaBoard
    {
        /// <summary>
        /// This var holds how many marbles are in the game board.
        /// </summary>
        private int[] gameBoard;
        /// <summary>
        /// This var holds all buckets the player can interact with
        /// </summary>
        public int[] playerHalf { get; set; }
        /// <summary>
        /// This var holds all the buckets the player can not interact with
        /// </summary>
        public int[] notMyBoard { get; set; }
        /// <summary>
        /// This var holds the location of our point counter.
        /// </summary>
        public int myPointFlag { get; set; }
        /// <summary>
        /// This var holds the location of other players point counter.
        /// </summary>
        public int notMyPointFlag { get; set; }

        /// <summary>
        /// Constructor will set all the base values with some logic
        /// according to what player they are.(1/2)
        /// </summary>
        /// <param name="pnum"></param>
        public MancalaBoard(int pnum)
        {
            if (pnum == 1)
            {
                playerHalf = new int[] { 0, 1, 2, 3, 4 };
                notMyBoard = new int[] { 6, 7, 8, 9, 10 };
                myPointFlag = 5;
                notMyPointFlag = 11;
            }
            else
            {
                playerHalf = new int[] { 6, 7, 8, 9, 10 };
                notMyBoard = new int[] { 0, 1, 2, 3, 4 };
                myPointFlag = 11;
                notMyPointFlag = 5;
            }

            gameBoard = new int[] { 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 0 };
        }
        /// <summary>
        /// This will return a string to see what player won.
        /// </summary>
        /// <returns></returns>
        public string didWin()
        {
            if (gameBoard[myPointFlag] > gameBoard[notMyPointFlag])
            {
                return "You are the winner!!!";
            }
            else if (gameBoard[myPointFlag] < gameBoard[notMyPointFlag])
            {
                return "You are the loser...";
            }
            else if (gameBoard[myPointFlag] == gameBoard[notMyPointFlag])
            {
                return "You Tied!!!";
            }
            return "THIS SHOULDN'T SHOW UP EVER...please...";
        }
        /// <summary>
        /// This method calcs the amount of marbles on the players
        /// half of the board.
        /// </summary>
        /// <returns></returns>
        public int calcMarblesMySide()
        {
            int cnt = 0;
            foreach (var i in playerHalf)
            {
                cnt += gameBoard[i];
            }
            return cnt;
        }
        /// <summary>
        /// This method calcs the amount of marbles on the servers
        /// half of the board.
        /// </summary>
        /// <returns></returns>
        public int calcMarblesNotMySide()
        {
            int cnt = 0;
            foreach (var i in notMyBoard)
            {
                cnt += gameBoard[i];
            }
            return cnt;
        }
        /// <summary>
        /// This method will simulate the other players turn
        /// so our local board will update.
        /// </summary>
        /// <param name="location"></param>
        /// <returns> the location of last marble</returns>
        public int theirTurn(int location)
        {
            int numPebbles;

            numPebbles = gameBoard[location];
            return movePebblesTheirTurn(numPebbles, location);
        }
        /// <summary>
        /// This method will simulate the movement of 
        /// the marbles during the other players turn.
        /// </summary>
        /// <param name="numPebbles"></param>
        /// <param name="location"></param>
        /// <returns> the location of last marble</returns>
        private int movePebblesTheirTurn(int numPebbles, int location)
        {
            gameBoard[location] = 0;
            location++;

            do
            {
                if (location == this.myPointFlag)
                {
                    location++;
                }
                if (location >= 12)
                {
                    location = 0;
                }
                gameBoard[location]++;
                numPebbles--;
                location++;
            } while (numPebbles > 0);

            return location;
        }
        /// <summary>
        /// This method will fire when you take your turn.
        /// </summary>
        /// <param name="location"></param>
        /// <returns> the location of last marble</returns>
        public int takeTurn(int location)
        {
            int numPebbles;

            numPebbles = gameBoard[location];
            return movePebbles(numPebbles, location);
        }
        /// <summary>
        /// This method will handle the movement of the marbles.
        /// </summary>
        /// <param name="numPebbles"></param>
        /// <param name="location"></param>
        /// <returns> the location of last marble</returns>
        private int movePebbles(int numPebbles, int location)
        {
            gameBoard[location] = 0;
            location++;

            do
            {
                if (location == this.notMyPointFlag)
                {
                    location++;
                }
                if (location >= 12)
                {
                    location = 0;
                }

                gameBoard[location]++;
                numPebbles--;
                location++;
            } while (numPebbles > 0);

            return location;
        }
        /// <summary>
        /// This method will build a string of the entire game board
        /// </summary>
        /// <returns></returns>
        public string createString()
        {
            string stringBuilder = "";
            int endLoc = gameBoard.Length;
            int cnt = 0;
            foreach (int i in gameBoard)
            {
                stringBuilder += i;
                cnt++;
                if (cnt <= endLoc - 1)
                {
                    stringBuilder += ",";
                }

            }
            return stringBuilder;
        }
        /// <summary>
        /// This method returns the int array 
        /// that is our gameboard.
        /// </summary>
        /// <returns></returns>
        public int[] getBoard()
        {
            return gameBoard;
        }
    }
}
