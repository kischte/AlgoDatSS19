using System;

namespace AlgoDatSS19
{
    class Treap : BinSearchTree, ISetSorted
    {
        // Einfügefunktion
        public override bool Insert(int x)
        {
            bool eingefuegt = false;
            Node pointer = current; // Hilfsnode welche auf aktuelle Node verweist

            // Prüfen
            if (base.Search(x))
            {
                Console.WriteLine("Das einzufügende Element ist bereits vorhanden und wird nicht erneut eingefügt.");
                return eingefuegt; 
            }

            else
            {

                // Prüfen ob Struktur schon vorhanden, wenn nein dann Wurzel anlegen/einfügen:
                if (root == null)
                {
                    base.Insert(x);

                    root.Prio = RndPrio(); // zufällige Priorität vergeben

                    // Testausgabe:
                    //Console.WriteLine("Priorität: {0}", current.Prio);

                    return true;
                }

                // Wenn Baumstruktur schon vorhanden, dann einfügen
                else
                {
                    base.Insert(x);

                    current.Prio = RndPrio(); // Random Priorität vergeben

                    // Testausgabe
                    Console.WriteLine("Priorität: {0}", current.Prio);

                    eingefuegt = true;
                }

                //Treapbedinung herstellen
                TreapbedingungHerstellen(current);

                return eingefuegt;


            }
        }

        // Hilfsfunktion zum Herstellen der Treapbedingung
        public void TreapbedingungHerstellen(Node n)
        {
            // Prüfen ob Baum nicht leer, wenn nicht leer dann:
            if (n != null)
            {
                // Solange Eltern Priorität(en) größer als Kind Priorität(en)
                while (n.Parent != null && n != null && n.Parent.Prio > n.Prio)
                {
                    // Prüfen ob Kind links oder rechts
                    if (n.Element < n.Parent.Element)
                    {
                        // Rechts Rotation durchführen
                        RightRotation(n);
                    }
                    else
                        //Links Rotation durchführen
                        LeftRotation(n);
                }
            }
        }

        // Löschfunktion
        public override bool Delete(int x)
        {
            bool geloescht = false;
            Node pointer = null;

            // Element mit Suchfunktion finden und Merker/Pointer auf dieses setzen
            if (base.Search(x))
            {
                pointer = current;
            }

            // Falls Element noch kein Blatt, solange rotieren bis Element ein Blatt ist
            while (pointer.Left != null || pointer.Right != null)
            {
                if (pointer.Right == null || (pointer.Left != null && pointer.Left.Prio < pointer.Right.Prio))
                    RightRotation(pointer.Left);
                else
                    LeftRotation(pointer.Right);
            }

            // Gesuchtes bzw. zu löschendes Element als Blatt löschen
            if (base.Delete(pointer.Element))
            {
                geloescht = true;
            }
            return geloescht;
        }

        // Funktion zur Bestimmung der Priorität einer Node
        public int RndPrio()
        {
            Random rnd = new Random();
            return rnd.Next(500);
        }

        // Links Rotation
        protected void LeftRotation(Node n)
        {
            Node temp;

            if (n != null)
            {
                // Prüfen ob Elternelement Root ist, wenn ja:
                if (n.Parent == root)
                {
                    temp = n.Left;
                    root = n;
                    root.Left = n.Parent;
                    n.Parent = null;
                    root.Left.Parent = root;
                    root.Left.Right = temp;

                    if (temp != null)
                    {
                        root.Left.Right.Parent = root.Left;
                    }
                }

                // Wenn Elternelement nicht Root ist:
                else
                {
                    temp = n.Left;
                    n.Left = n.Parent;
                    n.Parent = n.Parent.Parent;

                    if (n.Element < n.Parent.Element)
                    {
                        n.Parent.Left = n;
                    }

                    else
                    {
                        n.Parent.Right = n;
                    }

                    n.Left.Parent = n;
                    n.Left.Right = temp;
                    if (temp != null)
                    {
                        n.Left.Right.Parent = n.Left;
                    }
                }
            }
        }

        // Rechts Rotation
        protected void RightRotation(Node n)
        {
            Node temp;
            if (n != null)
            {
                // Prüfen ob Elternelement Root ist, wenn ja:
                if (n.Parent == root)
                {
                    temp = n.Right;
                    root = n;
                    root.Right = n.Parent;
                    n.Parent = null;
                    root.Right.Parent = root;
                    root.Right.Left = temp;

                    if (temp != null)
                    {
                        root.Right.Left.Parent = root.Right;
                    }
                }

                // Wenn Elternelement nicht Root ist:
                else
                {
                    temp = n.Right;
                    n.Right = n.Parent;
                    n.Parent = n.Parent.Parent;

                    if (n.Element < n.Parent.Element)
                    {
                        n.Parent.Left = n;
                    }

                    else
                    {
                        n.Parent.Right = n;
                    }

                    n.Right.Parent = n;
                    n.Right.Left = temp;
                    if (temp != null)
                    {
                        n.Right.Left.Parent = n.Right;
                    }
                }
            }
        }
    }
}
