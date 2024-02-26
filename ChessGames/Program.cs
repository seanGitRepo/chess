
using ChessGames;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;


var board = new Board();

//infer with var

board.Initialise(seed: false) ; //concept responsiblity (single responsibility)
                                // information expert
                                //optional named parameteres
board.Draw();


while (true)
{

    string userIn = "a";

    if (board.lastmove != null || board.lastmove == "")
    {
        Console.WriteLine($"{board.lastmove}");

    }



    if (board.turn % 2 == 0)
    {
        Console.WriteLine("White to move");
    }
    else
    {
        Console.WriteLine("Black to move");
    }



    Console.WriteLine("Please select a piece and location");
    Console.WriteLine("Example: p1.a5");

    userIn = Console.ReadLine();

    if (userIn == "exit")
    {
        Environment.Exit(0);
    }
    else if (userIn == "Game Selection" || userIn == "game selection")
    {
        Console.WriteLine("Please Select from the following: ");
        // log of previous games
        // log of a famous game

        //adding rn the ability to run famous games. -> into the  
         //useing the id from the game, we can print the various games options/;
        //then I can fefed the auto GAmeRunner with correct Game. whihc is why i should be in board.

         

    }


    board.move(userIn);

    Console.Clear();

    board.Draw();

}

//Board:
//TODO: Validator - yes, can only move to real squares.
//TODO: instructions on commands
//TODO: add winning scree

//Data:
//TODO: connect database of previous games. The games now load into the program, have to shift them to the database then into the game. 
//TODO: Turn the data into a readable langauge for program to run

//For Moves:
//TODO: King Swap
//TODO: what happens when a pawn gets to the end of the board


//Bugs:
//userinput = null or enter forever loop ? - resolved 
