using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChessGames
{
    public class Square
    {

            
            public int Number { get; set; }
            public char Letter { get; set; }

            public Piece piece{  get; set; }


        public override string ToString()
        {
            return $"{Letter}{Number}";
        }

    }
}
