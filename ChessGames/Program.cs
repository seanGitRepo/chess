
using ChessGames;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;


BoardClass board = new BoardClass();


board.initialiseSquare();
board.initialisePieces();

board.boardVisual();


while (true)
{
    board.move();

    Console.Clear();

    board.boardVisual();

}






//TODO: Validator - yes, can only move to real squares.
//TODO: what happens when a pawn gets to the end of the board
//TODO: instructions on commands
//TODO: connect database of previous games.

