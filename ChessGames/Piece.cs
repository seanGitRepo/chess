using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChessGames
{
    public class Piece
    {
       public string Name { get; set; }
       public string Colour { get; set; }
       public Square CurrentSquare { get; set; }
        

        // movement // this should be a class based on the piece time
        //   location }// this is just a square association 


        public override string ToString()
        {
            return $"{Name}";
        }



    } 






}
