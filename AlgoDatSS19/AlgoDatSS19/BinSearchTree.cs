using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
    class BinSearchTree : ISetSorted {

        public Node root; //Wurzelelement 
        public Node searched; //gesuchtes Element
        public Node current; //aktuelles Element
        public int numberOfNodes; //Knotenzähler


        //Suchfunktion
        public bool Search(int x) 
        {
            // Wurzelelement festlegen
            Node w = root; 

            // Prüfen ob Baum existiert, falls nein return false
            if (root == null)
            {
                Console.WriteLine("Der Baum existiert noch nicht.")
                return false; 
            }

            // Prüfen ob Wurzelelement das gesuchte Element ist
            if (w.Element == x) 
            {
                searched = w;
                current = w; 
                return true; 
            }

            // Suchen und aktuelle Stelle merken
            while (w != null && w.Element != x) 
            {
                // Falls gesuchtes Element kleiner aktuelles Element, gehe links
                if (x < w.Element) 
                {
                    searched = w; 
                    w = w.Left; 
                    // Wenn Kindelement vorhanden (nicht Null), setze Merker auf aktuelles Element
                    if (w != null) 
                    {
                        current = w; 
                    }
                }

                // Ansonsten gehe rechts
                else 
                {
                    searched = w; 
                    w = w.Right; 
                    // Wenn Kindelement vorhanden (nicht Null), setze Merker
                    if (w != null) 
                    {
                        current = w; 
                    }
                }

                if (w != null && x == w.Element)
                {
                    return true; 
                }
            }

            // Falls Suche nicht erfolgreich
            return false;
        }

        // Einfügefunktion
        public virtual bool Insert(int x)
        {
            bool hinzugefuegt = false; 

            // Prüfen ob Baum schon existiert, falls Nein diesen anlegen
            if (root == null) 
            {
                root = new Node(x); 
                numberOfNodes++; 
                return true; 
            }

            // Falls Baum existiert, prüfen ob einzufügendes Element schon vorhanden
            // Wenn Element nicht vorhanden --> einfügen
            if (!Search(x))
            {
                // Element links einfügen
                if (x < searched.Element)
                {
                    searched.Left = new Node(x); 
                    current = searched.Left; 
                    current.Parent = searched; 
                    numberOfNodes++; 
                    hinzugefuegt = true; 
                }
                
                // Element rechts einfügen 
                else 
                {
                    searched.Right = new Node(x) ; 
                    current = searched.Right; 
                    current.Parent = searched; 
                    numberOfNodes++;
                    hinzugefuegt = true; 
                }
            }

            // Element schon vorhanden --> nicht einfügen
            else 
            {
                Console.WriteLine("Das einzufügende Element ist bereits vorhanden.");
                return hinzugefuegt; 
            }

            Console.WriteLine("Das Element ({0}) wurde erfolgreich eingefügt", x);
            return hinzugefuegt;
        }

        // Löschfunktion
        public virtual bool Delete(int x)
        {
            // Prüfen ob zu löschendes Element im Baum existiert

            // Wenn Element nicht gefunden --> nichts löschen
            if (!Search(x))
            {
                Console.WriteLine("Das aus dem Baum zulöschende Element ({0}) existiert nicht.", x);
                return false; 
            }

            // Verschiedene Fälle des zu löschenden Elements 

            // 1. Fall: zu löschender Knoten ist eine Wurzel
            else if (current == root && root.Left == null && root.Right == null)
            {
                root = null; 
                Console.WriteLine("Das zu löschende Element ({0}) war eine alleinstehende Wurzel, der Baum wurde gelöscht", x);
                return true; 
            }

            // 2. Fall: zu löschender Knoten ist ein Blatt
            else if (current.Left == null && current.Right == null) 
            {
                if (current.Element < current.Parent.Element)
                {
                    current.Parent.Left = null; 
                }

                else 
                {
                    current.Parent.Right = null; 
                }
                
                Console.WriteLine("Das zu löschende Element ({0}) war ein Blatt und wurde gelöscht", x);
                return true; 
            }

            // 3. Fall: zu löschender Knoten hat EINEN Nachfolger
            else if (current.Left != null ^ current.Right != null) // ^ ist ein XOR, current ist zu löschendes Element
            {
                // Falls zu löschendes Element eine Wurzel ist
                if (x == root.Element) 
                {
                    // Wenn Nachfolger rechts...
                    if (root.Right != null) 
                    {
                        root = root.Right; 
                        root.Parent = null;
                    }

                    // Wenn Nachfolger links...
                    else 
                    {
                        root = root.Left;
                        root.Parent = null; 
                    }

                    Console.WriteLine("Das zu löschende Element ({0}) war eine Wurzel mit EINEM Nachfolger und wurde gelöscht", x);

                    return true; 
                }

                // zu löschender Knoten hat rechts einen Nachfolger
                if(current.Right != null)
                {
                    current.Right.Parent = current.Parent; // Verbinde Kind mit Elternelement von Current
                    current = null; 
                }

                // zu löschender knoten hat links einen Nachfolger
                else 
                {
                    current.Left.Parent = current.Parent; // Verbinde Kind mit Elternelement von Current
                    current = null; 
                }

                Console.WriteLine("Das zu löschende ELement ({0}) war ein Knoten mit EINEM Nachfolger und wurde gelöscht",x);
                return true; 

            }

            // 4. Fall: zu löschender Knoten hat ZWEI Nachfolger
            if (current.Left != null && current.Right != null)
            {
                DelSymPred(current);
            }
            
            Console.WriteLine("Das zu löschende Element ({0}) hatte ZWEI Nachfolger und wurde gelöscht",x);
            return true; 

            // Hilfsfunktion für das Löschen mit ZWEI Nachfolgern aus dem Skript
            public void DelSymPred(Node a)
            {
            Node b, c;
            b = a;      // a überschreibt b, wobei b als Zeiger auf a fungiert
            if (b.Left.Right != null)
            {
                b = b.Left;
                while (b.Right.Right != null)
                    b = b.Right;
            }
            if (b == a)
            {
                c = b.Left;
                b.Left = c.Left;
            }
            else
            {
                c = b.Right;
                b.Right = c.Left;
            }
            a.Element = c.Element;
            }
        }

        // Ausgabefunktion für Binäre- und AVL-Bäume
        public virtual void Print()
        {
            // Prüfen ob Baum überhaupt vorhanden
            if(root == null)
            {
                Console.WriteLine("Es existiert kein Baum der ausgegeben werden könnte!");
                return;
            }

            // Wenn Vorhanden, dann gib Baum aus
            Node a = root;
            Console.WriteLine("Die Baumstruktur wird ausgegeben:");
            InOrder(a);
        }

        // Hilfsfunktionen zur Reihenfolge bei der Ausgabe bzw. Print des Baumes (Inorder)

        public void InOrder(Node n)
        {
            // 
            if (n.Left != null)
            {
                InOrder(n.Left);
            }
            TrennzeichenEinfuegen(n);
            if (n.Prio == 0)
                Console.Write(n.Element);
            else
                Console.Write("{0},{1}", n.Element, n.Prio);
            Console.WriteLine();
            if (n.Right != null)
            {
                InOrder(n.Right);
            }
        }

        //Hilfsfunktion für Printfunktion um Trennzeichen einzufügen
        public void TrennzeichenEinfuegen(Node n) 
        {
            n.Height = GetHeight(n);

            // für jede Ebene einen Strich einfügen
            for (int i = 0; i < n.Height; i++)
            {
                Console.Write("-");
            }
        }

        //Hilfsfunktion für TrennzeichenEinfuegen um korrekte Anzahl der Trennstriche zu ermitteln
        public int GetHeight(Node n) // n = current
        {
            int Height = 0;

            // Prüfen auf welcher Ebene ein Element liegt
            if (n.Parent == null)
            {
                return 0;
            }
            while (n.Parent != null)
            {
                Height++;
                n = n.Parent;
            }
            
            // Ebene/Höhe zurück geben
            return Height;
        }

    }
    
}