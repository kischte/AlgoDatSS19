using System;

namespace AlgoDatSS19
{
    class Treap : BinSearchTree
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
            Node temp; // temporäre Node welche zum Rotieren benötigt wird

            if (n != null)
            {
                // Prüfen ob Elternelement Root ist, wenn ja:
                if (n.Parent == root)
                {
                    temp = n.Left; // speichere "wanderndes" Element in temp
                    root = n; // mache n zur neuen Wurzel
                    root.Left = n.Parent; // schiebe ursprüngliche Wurzel nach linksunten
                    n.Parent = null; // sage neuer Wurzel, dass sie kein Elternelement mehr hat
                    root.Left.Parent = root; // weise alter Wurzel die neue Wurzel als Elternelment zu
                    root.Left.Right = temp; // speichere "wandernde" Node an neuer Stelle

                    if (temp != null)
                    {
                        root.Left.Right.Parent = root.Left; // setze neuen Elternknoten des "gewanderten" Elements
                    }
                }

                // Wenn Elternelement nicht Root ist:
                else
                {
                    temp = n.Left; // speichere "wanderndes" Element in temp
                    n.Left = n.Parent; // verschiebe linkes Element eins nach oben
                    n.Parent = n.Parent.Parent; // setze Parent-Element von n eine Ebene höher (für nächste If-Abfrage)

                    // Prüfen ob n zukünfig links oder rechts des "Eltern-Eltern"-Elements ist
                    if (n.Element < n.Parent.Element)
                    {
                        n.Parent.Left = n;
                    }

                    else
                    {
                        n.Parent.Right = n;
                    }

                    n.Left.Parent = n; // weise nach unten verschobenem Element n als Elternelment zu
                    n.Left.Right = temp; // speichere "wandernde" Node an neuer Stelle
                    if (temp != null)
                    {
                        n.Left.Right.Parent = n.Left; // setze neuen Elternknoten des "gewanderten" Elements
                    }
                }
            }
        }

        // Rechts Rotation
        protected void RightRotation(Node n)
        {
            Node temp; // temporäre Node welche zum Rotieren benötigt wird

            if (n != null)
            {
                // Prüfen ob Elternelement Root ist, wenn ja:
                if (n.Parent == root)
                {
                    temp = n.Right; // speichere "wanderndes" Element in temp
                    root = n; // mache n zur neuen Wurzel
                    root.Right = n.Parent; // schiebe ursprüngliche Wurzel nach rechtsunten
                    n.Parent = null; // sage neuer Wurzel, dass sie kein Elternelement mehr hat
                    root.Right.Parent = root; // weise alter Wurzel die neue Wurzel als Elternelment zu
                    root.Right.Left = temp; // speiche "wandernde" Node an neuer Stelle

                    if (temp != null)
                    {
                        root.Right.Left.Parent = root.Right; // setze neuen Elternknoten des "gewanderten" Elements
                    }
                }

                // Wenn Elternelement nicht Root ist:
                else
                {
                    temp = n.Right; // speichere "wanderndes" Element in temp
                    n.Right = n.Parent; // verschiebe rechtes Element eins nach oben
                    n.Parent = n.Parent.Parent; // setze Parent-Element von n eine Ebene höher (für nächste If-Abfrage)

                    // Prüfen ob n zukünfig links oder rechts des "Eltern-Eltern"-Elements ist
                    if (n.Element < n.Parent.Element)
                    {
                        n.Parent.Left = n;
                    }

                    else
                    {
                        n.Parent.Right = n;
                    }

                    n.Right.Parent = n; // weise nach unten verschobenem Element n als Elternelment zu
                    n.Right.Left = temp; // speichere "wandernde" Node an neuer Stelle
                    if (temp != null)
                    {
                        n.Right.Left.Parent = n.Right; // setze neuen Elternknoten des "gewanderten" Elements
                    }
                }
            }
        }
    }
}
