using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
    public class Node
    {
        public int Element { get; set; } // Inhalt des Knotens
        public Node Left { get; set; } // Linkes Kind des Knotens
        public Node Right { get; set; } // Rechtes Kind des Knotens
        public Node Parent { get; set; } // Elternknoten des Knotens
        public int BalanceFaktor { get; set; } //Gibt den Balancefaktor des Knotens an
        public int Height { get; set; } // Höhe des Knotens / Baumes
        public int Prio { get; set; } // Priorität des Knotens

        public Node(int x)
        {
            this.Element = x;
            Left = null;
            Right = null;
            BalanceFaktor = -10; // zur Unterscheidung bei der Ausgabe von AVL und Co  
        }
    }
}
