using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoDatSS19
{
    class AVLTree : BinSearchTree, ISetSorted
    {   
        // Einfügefunktion
        public override bool Insert(int x)
        {
            bool hinzugefuegt = false; 
            if (base.Insert(x))
            {
                hinzugefuegt = true; 
                Node pointer = current; 
                Reorganisieren(pointer);

                return hinzugefuegt;
            }
            return hinzugefuegt;
        } 

        // Balancefaktor errechnen
        public int GetBalanceFaktor(Node right, Node left) 
        {
            return GetHeight(right) - GetHeight(left);
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

        // Rechts-Links Rotation
        protected void RightLeftRotation(Node n)
        {
            if(n != null)
            {
                //Erst Rechts Rotation
                n.Parent.Right = n.Left;
                n.Left.Parent = n.Parent;
                n.Parent.Right.Right = n;
                n.Parent = n.Parent.Right;
                n.Left = null;
                
                // Dann Links Rotation
                LeftRotation(n.Parent);
            }
        }

        // Links-Rechts Rotation
        protected void LeftRightRotation(Node n)
        {
            if (n != null)
            {
                // Erst Links Rotation
                n.Parent.Left = n.Right;
                n.Right.Parent = n.Parent;
                n.Parent.Left.Left = n;
                n.Parent = n.Parent.Left;
                n.Right = null;

                // Dann Rechts Rotation
                RightRotation(n.Parent);
            }
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
                Reorganisieren(pointer);
            }

            Console.WriteLine("Das Element ({0}) wurde erfolgreich gelöscht", x);
            return geloescht; 
        }

        public override int GetHeight(Node n)
        {
            if (n != null)
            {
                return -1; 
            }
            return Math.Max(GetHeight(n.Left), GetHeight(n.Right)) + 1;
        }

        public void Reorganisieren(Node pointer)
        {
            while (pointer != null)
            {
                // Prüfen des Balancefaktors und Reorganisation des Baumes FALLS Ausgleichsbedingung verletzt
                pointer.BalanceFaktor = GetBalanceFaktor(pointer.Right, pointer.Left);

                // Ausgleichsbedingung verletzt, Baum ist Linkslastig 
                if (pointer.BalanceFaktor < -1)
                {
                    // 1. Fall: Links-Rechts Rotation erforderlich (a-- und b+ (a vater, b kind)) 
                    if (pointer.BalanceFaktor == -2 && GetBalanceFaktor(pointer.Left.Right, pointer.Left.Left) >0)
                    {
                        Console.WriteLine("Der Baum ist unausgeglichen (linkslastig), es erfolgt eine Links-Rechts Rotation um ({0})", pointer.Left.Element);
                        LeftRightRotation(pointer.Left);
                        return; 
                    }

                    // 2. Fall: Rechts Rotation erforderlich (a-- und b- (a vater, b kind))
                    else
                    {
                        Console.WriteLine("Der Baum ist unausgeglichen (linkslastig), es erfolgt eine Rechts Rotation um ({0})", pointer.Left.Element);
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
                        Console.WriteLine("Der Baum ist unausgeglichen (rechtslastig), es erfolgt eine Rechts-Links Rotation um ({0})", pointer.Right.Element);
                        RightLeftRotation(pointer.Right);
                        return; 
                    }

                    // 4. Fall: Links Rotation erforderlich (a++ und b+ (a vater, b kind))
                    else
                    {
                        Console.WriteLine("Der Baum ist unausgeglichen (rechtslastig), es erfolgt eine Links Rotation um ({0})", pointer.Right.Element);
                        LeftRotation(pointer.Right);
                    }
                    return; 
                }

                // Pointer durch AVL Baum nach oben navigieren
                pointer = pointer.Parent; 
            }
        }

    }



}