using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChessGames
{
    public class BoardClass
    {
        public int turn = -1;
      
        public void boardVisual()
        {
            int square = 0;
            letterRow();
            
            for (int i = 0; i < 8; i++)
            {
             topline();
                numberrow(i);   
                
                for (int j = 0; j < 8; j++)
                {

                    displaySquare(square);
                    square++ ;

                }
            
                Console.Write("\n");
            }
            topline();
            turn++;
        }

        public void displaySquare(int currentSquare)
        {
            if (this.SquareList[currentSquare].piece == null)
            {

                Console.Write($"     |"); // this is for empty strings
            } else
            {

                if (this.SquareList[currentSquare].piece.Name == "Q"|| this.SquareList[currentSquare].piece.Name == "K")
                {

                    string c = this.SquareList[currentSquare].piece.Colour;


                    Console.Write($" {c[0]}{this.SquareList[currentSquare].piece.Name}  |");
                }
                else
                {
                    string c = this.SquareList[currentSquare].piece.Colour;
                    Console.Write($" {c[0]}{this.SquareList[currentSquare].piece.Name} |");
                }
           

            }


        }

       public List<Square> SquareList { get; } = new();

        public Square squareCreation(int number, char letter)
        {
            var square = new Square { Number = number, Letter = letter };

            SquareList.Add(square);

            return square;

        }

        public List<Piece> piecesWhite { get; } = new();
        public List<Piece> piecesBlack { get; } = new();



        public Piece PieceGenerator(string name, string colour,Square currentSquare)
        {

            var piece = new Piece { Name = name, Colour = colour, CurrentSquare = currentSquare };

            if(colour == "black")
            {
                piecesBlack.Add(piece);
                currentSquare.piece = piece;

            }else if(colour == "white"){

                piecesWhite.Add(piece);
                currentSquare.piece = piece;
            }

            return piece;


        }

        public void initialiseSquare()
        {

            for (int j = 8; j > 0; j--)
            {
                for (int i = 0; i < 8; i++)
                {
                    //here i would like to generate/initalise the system that i use to track the game.

                    int modLetter = (i % 8) + 65;

                    //needs to start at 7 

                    this.squareCreation(j, (char)modLetter);
                   


                }
            }
            


        }

        public void initialisePieces()
        {

            for (int i = 0; i < 8; i++)
            {
                PieceGenerator($"p{i + 1}", "black", SquareList[i + 8]);
                PieceGenerator($"p{i + 1}", "white", SquareList[i + 48]);
            }

           
            PieceGenerator($"r1", "black", SquareList[0]);
            PieceGenerator($"r2", "black", SquareList[7]);

            PieceGenerator($"r1", "white", SquareList[56]);
            PieceGenerator($"r2", "white", SquareList[63]);

            PieceGenerator($"k1", "black", SquareList[1]);
            PieceGenerator($"k2", "black", SquareList[6]);

            PieceGenerator($"k1", "white", SquareList[57]);
            PieceGenerator($"k2", "white", SquareList[62]);

            PieceGenerator($"b1", "black", SquareList[2]);
            PieceGenerator($"b2", "black", SquareList[5]);

            PieceGenerator($"b1", "white", SquareList[58]);
            PieceGenerator($"b2", "white", SquareList[61]);

           

            PieceGenerator($"Q", "black",SquareList[3]);
            PieceGenerator($"Q", "white", SquareList[59]);

            PieceGenerator($"K", "black",SquareList[4]);
            PieceGenerator($"K", "white", SquareList[60]);
            


        }
        //stolen straight from Peter, no idea how to do this one.
        public Piece FindBPieceByCode(string code) => piecesBlack.FirstOrDefault(s => s.ToString() == code);
        public Piece FindWPieceByCode(string code) => piecesWhite.FirstOrDefault(s => s.ToString() == code);
    
        public Square FindSquareByCode(string code)
        {

            for (int i = 0; i < SquareList.Count; i++)
            {
                string squareCode = $"{SquareList[i].Letter}{SquareList[i].Number}";


                if (squareCode == code)
                {
                    return SquareList[i];
                }


            }

            Square hero = null;

            return hero;
        }

        public void move()
        {

            string[] userInSpit;
            string userIn = "a";
            string piece;
            string location;

            var x = true;
            while (x)
            {
                if (turn % 2 == 0)
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
                userInSpit = userIn.Split('.');
                if (turn%2 == 0)
                {
                    if (this.FindWPieceByCode(userInSpit[0]) == null || this.FindSquareByCode(userInSpit[1]) == null)
                    {

                        x = true;
                        Console.WriteLine("Not a valid piece or location");
                    }
                    else
                    {
                        x = false;
                    }
                }
                else
                {
                    if (this.FindBPieceByCode(userInSpit[0]) == null || this.FindSquareByCode(userInSpit[1]) == null)
                    {

                        x = true;
                        Console.WriteLine("Not a valid piece or location");
                    }
                    else
                    {
                        x = false;
                    }
                }
                
            }

           



            userInSpit = userIn.Split('.');
            piece = userInSpit[0];
            location = userInSpit[1];

            if (turn % 2 == 0)
            {
                var pieceToMove = this.FindWPieceByCode(piece);
                var oldSpot = pieceToMove.CurrentSquare;
                var newSquare = this.FindSquareByCode(location);

                this.pieceTake(pieceToMove, oldSpot, newSquare);
            }
            else
            {
                var pieceToMove = this.FindBPieceByCode(piece);
                var oldSpot = pieceToMove.CurrentSquare;
                var newSquare = this.FindSquareByCode(location);

                this.pieceTake(pieceToMove, oldSpot, newSquare);
            }

 
        }


        public void topline()
        {

            for (int a = 0; a < 50; a++)
            {

                if (a < 3)
                {
                    Console.Write(" ");

                }
                else
                {

                    Console.Write("-");
                }

            }
            Console.Write("\n");
            // Console.WriteLine();
        }

        public void numberrow(int y)
        {


            // 0 and i want 8
            // 1 and i want 7
            y = y + (-8);
            y = -y;
            Console.Write($"{y} |");



        }

        public void letterRow()
        {

            for (int i = 0; i < 8; i++)
            {

                i = i + 65;
                char letter = (char)i;
                i = i - 65;
                Console.Write($"     {letter}");
            }
            Console.Write("\n");
        }



        public void pieceTake(Piece pieceToMove, Square oldSpot, Square NewSquare)
        {
            //I need to do two things here, is this an acceptable move for this piece ?

            //Is there a 

            var enemyPiece = NewSquare.piece;


            if (enemyPiece == null)
            {
                
            }
            else { 

                if (enemyPiece.Colour == "black") //validate turn 
                {
                    Console.WriteLine($"{pieceToMove.Name}-{pieceToMove.Colour} takes {enemyPiece.Name}-{enemyPiece.Colour}");

                    piecesBlack.Remove(enemyPiece);

                }
                else if (enemyPiece.Colour == "white")
                {
                    Console.WriteLine($"{pieceToMove.Name}-{pieceToMove.Colour} takes {enemyPiece.Name}-{enemyPiece.Colour}");

                    piecesWhite.Remove(enemyPiece);


                }

            }



            pieceToMove.CurrentSquare = NewSquare;
            NewSquare.piece = pieceToMove;
            oldSpot.piece = null;

        }
    }


}


//so there are 64 squares 