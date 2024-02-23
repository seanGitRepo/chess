
using ChessGames;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;


BoardClass board = new BoardClass();


board.initialiseSquare();
board.initialisePieces();

board.boardVisual();


var pieceToMove = board.FindWPieceByCode("p1");
var newSquare = board.FindSquareByCode("C5");


string[] userInSpit;
string userIn = "a";
string piece;
string location;

while (userIn != "restart")
{
    int turn = board.turn % 2;
    if (turn == 0) // test for even and odd: https://csharp-station.com/how-to-test-for-even-or-odd-numbers-in-c/
    {
        Console.WriteLine("White to move");
        Console.WriteLine("Please select a piece and location");
        Console.WriteLine("Example: p1.a5");

        userIn = Console.ReadLine();

        if(userIn == "restart")
        {
            break;
        }

        userInSpit = userIn.Split('.');

        piece = userInSpit[0];
        location = userInSpit[1];
        pieceToMove = board.FindWPieceByCode(piece);
        var oldSpot = pieceToMove.CurrentSquare;
        newSquare = board.FindSquareByCode(location);
        
        pieceToMove.CurrentSquare = newSquare;
        newSquare.piece = pieceToMove;
        oldSpot.piece = null;




    }
    else
    {
        Console.WriteLine("Black to move");
        Console.WriteLine("Please select a piece and location");
        Console.WriteLine("Example: p1.a5");

        userIn = Console.ReadLine();

        if (userIn == "restart")
        {
            break;
        }

        userInSpit = userIn.Split('.');
        piece = userInSpit[0];
        location = userInSpit[1];
        pieceToMove = board.FindBPieceByCode(piece);
        var oldSpot = pieceToMove.CurrentSquare;
        newSquare = board.FindSquareByCode(location);

        pieceToMove.CurrentSquare = newSquare;
        newSquare.piece = pieceToMove;
        oldSpot.piece = null;


    }

    Console.Clear();
    board.boardVisual();

}




