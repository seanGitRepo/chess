using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChessGames
{
    public class BoardClass
    {

        public BoardClass() { 
        //visual

            //validator

        }

        public int turn = 0;
        public int pawnCountBlack = 0;
        public int pawnCountWhite = 0;
       

        public void topline()
        {

            for (int a = 0; a < 58; a++)
            {
                Console.Write("-");

            }
            Console.Write("\n");
           // Console.WriteLine();
        }

        public void numberrow(int y)
        {


            // 0 and i want 8
            // 1 and i want 7
            y = y+(-8);
            y = -y;
            Console.Write(y);


        }

        public void letterRow()
        {

            for (int i = 0; i < 8; i++)
            {

                i = i + 65;
                char letter = (char)i;
                i = i - 65;
                Console.Write($"     {letter} ");
            }
            Console.Write("\n");
        }

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

                    checkSqaureStart(square);
                    square++ ;

                    

                }
            
                Console.Write("\n");
            }
            topline();

        }

        public void checkSqaureStart(int currentSquare)
        {
            if (currentSquare >= 0 && currentSquare <= 7)
            {
                // this adds all the black pieces to the board
               
                    if (currentSquare == 0)//r1
                    {
                        Console.Write($" | {this.piecesBlack[8].Name} |");
                      
                    }
                    else if (currentSquare == 7)
                    {
                        Console.Write($" | {this.piecesBlack[11].Name} |");
                       
                    }else if (currentSquare == 1)//k1
                    {

                        Console.Write($" | {this.piecesBlack[9].Name} |");
                      

                    }
                    else if (currentSquare == 6)
                    {

                        Console.Write($" | {this.piecesBlack[12].Name} |");
                      

                    }
                    else if (currentSquare == 2)//b1
                    {

                        Console.Write($" | {this.piecesBlack[10].Name} |");
                       

                    }
                    else if (currentSquare == 5)
                    {

                        Console.Write($" | {this.piecesBlack[13].Name} |");
                       

                    }
                else if (currentSquare == 3)//q
                {

                    Console.Write($" |  {this.piecesBlack[14].Name} |");
                   

                }
                else if (currentSquare == 4)//k
                {

                    Console.Write($" |  {this.piecesBlack[15].Name} |");
           

                }


            }
            else if (currentSquare >= 8 && currentSquare <= 15 && this.piecesBlack != null)// this adds the black pawns  to the board
            {
               Console.Write($" | {this.piecesBlack[pawnCountBlack].Name} |");
                pawnCountBlack++; 
            }
            else if (currentSquare >= 48 && currentSquare <= 55) //this adds the white pawns to the board
            {
                Console.Write($" | {this.piecesWhite[pawnCountWhite].Name} |");
                pawnCountWhite++;
            }else if(currentSquare >= 56 && currentSquare <= 63){


                if (currentSquare == 56)//r1
                {
                    Console.Write($" | {this.piecesWhite[8].Name} |");
                }
                else if (currentSquare == 63)
                {
                    Console.Write($" | {this.piecesWhite[11].Name} |");
                }
                else if (currentSquare == 57)//k1
                {

                    Console.Write($" | {this.piecesWhite[9].Name} |");

                }
                else if (currentSquare == 62)
                {

                    Console.Write($" | {this.piecesWhite[12].Name} |");

                }
                else if (currentSquare == 58)//b1
                {

                    Console.Write($" | {this.piecesWhite[10].Name} |");

                }
                else if (currentSquare == 61)
                {

                    Console.Write($" | {this.piecesWhite[13].Name} |");

                }
                else if (currentSquare == 59)//q
                {

                    Console.Write($" |  {this.piecesWhite[14].Name} |");

                }
                else if (currentSquare == 60)//k
                {

                    Console.Write($" |  {this.piecesWhite[15].Name} |");

                }



            }else if (this.SquareList[currentSquare].piece == null)
                {

                Console.Write($" |    |"); // this is for empty strings
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

            }else if(colour == "white"){

                piecesWhite.Add(piece);
            }

            return piece;


        }

        public void initialiseSquare()
        {
            for (int i = 0; i < 64; i++)
            {
                //here i would like to generate/initalise the system that i use to track the game.
               
                    int modLetter = (i % 8) + 65;

                    this.squareCreation(i, (char)modLetter);
                   

                
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

        public Piece FindBPieceByCode(string code) => piecesBlack.FirstOrDefault(s => s.ToString() == code);
        public Piece FindWPieceByCode(string code) => piecesWhite.FirstOrDefault(s => s.ToString() == code);
    
        public Square FindSquareByCode(string code) => SquareList.FirstOrDefault(s => s.ToString() == code);
        //stolen straight from Peter, no idea how to do this one.
    }
}


//so there are 64 squares 