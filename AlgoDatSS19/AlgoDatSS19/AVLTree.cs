using System;

namespace AlgoDatSS19
{
    class AVLTree : BinSearchTree
    {
        // Einfügefunktion
        public override bool Insert(int x)
        {
            bool hinzugefuegt = false;

            // Einfügen des Elements
            if (base.Insert(x)) // Wenn Einfügen erfolgreich
            {
                hinzugefuegt = true;
                Node pointer = current;
                Reorganisieren(pointer); // Nach Einfügen Reorganisieren
            }
            return hinzugefuegt;
        }

        // Löschfunktion
        public override bool Delete(int x)
        {
            bool geloescht = false;

            // Löschen des Elements
            if (base.Delete(x))
            {
                geloescht = true;
                Node pointer = current;
                Reorganisieren(pointer); // Nach Löschen Reorganisieren
            }
            return geloescht;
        }

        // Balancefaktor errechnen
        public int GetBalanceFaktor(Node right, Node left)
        {
            int BalanceFaktor = 0; 

            // BalanceFaktor aus Höhe errechnen
            BalanceFaktor =  GetHeight(right) - GetHeight(left);

            return BalanceFaktor; 
        }

        // Höhe bis zu aktueller Node errechnen
        public override int GetHeight(Node n)
        {
            if (n != null)
            {
                return Math.Max(GetHeight(n.Left), GetHeight(n.Right)) + 1;
            }
            return 0;
        }

        public void Reorganisieren(Node pointer)
        {
            while (pointer != null)
            {
                // Im Folgenden: Prüfen des Balancefaktors und Reorganisation des Baumes FALLS Ausgleichsbedingung verletzt
                pointer.BalanceFaktor = GetBalanceFaktor(pointer.Right, pointer.Left);

                // Ausgleichsbedingung verletzt, Baum ist Linkslastig
                if (pointer.BalanceFaktor < -1)
                {
                    // 1. Fall: Links-Rechts Rotation erforderlich (a-- und b+ (a vater, b kind))
                    if (pointer.BalanceFaktor == -2 && GetBalanceFaktor(pointer.Left.Right, pointer.Left.Left) > 0)
                    {
                        Console.WriteLine("Der (Teil-)Baum ist unausgeglichen (linkslastig), es erfolgt eine Links-Rechts Rotation um ({0})", pointer.Left.Right.Element);
                        LeftRightRotation(pointer.Left);
                        return;
                    }

                    // 2. Fall: Rechts Rotation erforderlich (a-- und b- (a vater, b kind))
                    else
                    {
                        Console.WriteLine("Der (Teil-)Baum ist unausgeglichen (linkslastig), es erfolgt eine Rechts Rotation um ({0})", pointer.Left.Element);
                        RightRotation(pointer.Left);
                    }
                    return;
                }

                // Ausgleichsbedingung verletzt, Baum ist Rechtslastig
                if (pointer.BalanceFaktor > 1)
                {
                    // 3. Fall: Rechts-Links-Rotation erforderlich (a++ und b- (a vater, b kind))
                    if (pointer.BalanceFaktor == 2 && GetBalanceFaktor(pointer.Right.Left, pointer.Right.Right) ==1)
                    {
                        Console.WriteLine("Der (Teil-)Baum ist unausgeglichen (rechtslastig), es erfolgt eine Rechts-Links Rotation um ({0})", pointer.Right.Left.Element);
                        RightLeftRotation(pointer.Right);
                        return;
                    }

                    // 4. Fall: Links Rotation erforderlich (a++ und b+ (a vater, b kind))
                    else
                    {
                        Console.WriteLine("Der (Teil-)Baum ist unausgeglichen (rechtslastig), es erfolgt eine Links Rotation um ({0})", pointer.Right.Element);
                        LeftRotation(pointer.Right);
                    }
                    return;
                }
                // Pointer durch AVL Baum nach oben navigieren
                pointer = pointer.Parent;
            }
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
                        n.Right.Left.Parent = n.Right;  // setze neuen Elternknoten des "gewanderten" Elements
                    }
                }
            }
        }

        // Rechts-Links Rotation
        protected void RightLeftRotation(Node n)
        {
            // n != Node um welche rotiert wird!! n = Parent von Node um welche rotiert wird (da pointer da stehen bleibt)
            if (n != null)
            {
                //Erst Rechts Rotation
                n.Parent.Right = n.Left; // setze zu rotierendes Element eine Ebene hoch
                n.Left.Parent = n.Parent; // weise zu rotierendem Element neues Elternelement zu 
                n.Parent.Right.Right = n; // schiebe Parent des zu rotierenden Elements nach unten
                n.Parent = n.Parent.Right; // weise nach unten geschobenem Element neues Elternelement zu (früheres Kind)
                n.Left = null; // lösche rotierte Node aus der Struktur
                

                // Dann Links Rotation
                LeftRotation(n.Parent);
            }
        }

        // Links-Rechts Rotation
        protected void LeftRightRotation(Node n)
        {
            // n != Node um welche rotiert wird!! n = Parent von Node um welche rotiert wird (da pointer da stehen bleibt)
            if (n != null)
            {
                // Erst Links Rotation
                n.Parent.Left = n.Right; // setze zu rotierendes Element eine Ebene hoch
                n.Right.Parent = n.Parent; // weise zu rotierendem Element neues Elternelement zu 
                n.Parent.Left.Left = n; // schiebe Parent des zu rotierenden Elements nach unten
                n.Parent = n.Parent.Left; // weise nach unten geschobenem Element neues Elternelement zu (früheres Kind)
                n.Right = null; // lösche rotierte Node aus der Struktur


                // Dann Rechts Rotation
                RightRotation(n.Parent);
            }
        }

    }



}
