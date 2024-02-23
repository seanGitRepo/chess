
using ChessGames;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;


BoardClass board = new BoardClass();


board.initialiseSquare();
board.initialisePieces();

board.boardVisual();

int turn = board.turn % 2;
var pieceToMove = board.FindWPieceByCode("p1");
var newSquare = board.FindSquareByCode("a1");
int oldSpot = 0;

string[] userInSpit;
string userIn;
string piece;
string location;

if (turn== 0) // test for even and odd: https://csharp-station.com/how-to-test-for-even-or-odd-numbers-in-c/
{
    Console.WriteLine("White to move");
    Console.WriteLine("Please select a piece and location");
    Console.WriteLine("Example: p1.a5");

     userIn = Console.ReadLine();


    userInSpit = userIn.Split('.');

    piece = userInSpit[0];
    location = userInSpit[1];
    pieceToMove = board.FindWPieceByCode(piece);
   // oldSpot = pieceToMove.CurrentSquare;
    newSquare = board.FindSquareByCode(location);
}
else
{
    Console.WriteLine("Black to move");
    Console.WriteLine("Please select a piece and location");
    Console.WriteLine("Example: p1.a5");

     userIn = Console.ReadLine();


     userInSpit = userIn.Split('.');

    piece = userInSpit[0];
    location = userInSpit[1];
    pieceToMove = board.FindBPieceByCode(piece);
   // oldSpot = pieceToMove.CurrentSquare;
    newSquare = board.FindSquareByCode(location);
   

}
int pieceCode = 0 ;//dont think i need this 
for (int i = 0; i < board.piecesWhite.Count; i++)
{

    if (pieceToMove.Name == board.piecesWhite[i].Name)
    {
        pieceCode = i; break;

    }

}


Console.WriteLine(board.FindSquareByCode(location));



//now i have the -- name|colour|location|code --

//if (turn  == 0)//white
//{

//    for (int i = 0; i < length; i++)
//    {

//    }


//    pieceToMove.CurrentSquare = board.SquareList[]; 
//    newSquare.piece = pieceToMove;
//    board.SquareList[oldSpot].piece = null;
   
//    //then here is when we move it to the new one, cause we are not changing 
    



//}
//else
//{

//    newSquare.piece = pieceToMove;
//    board.SquareList[oldSpot].piece = null;
//}



