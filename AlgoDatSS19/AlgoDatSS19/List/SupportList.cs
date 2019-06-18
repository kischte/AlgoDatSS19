using System;

namespace AlgoDatSS19
{
    abstract public class SupportList   //abstract wegen abstrakter Insert Methode
    {
        class LElement
        {
            public int x;
            public LElement next;
            public LElement(int x)
            {
                this.x = x;
                next = null;
            }
        }
        LElement root;            //erstes Element der Liste
        public SupportList()
        {
            root = null;
        }

        // nach Element x suchen
        public bool Search(int x)
        {
            LElement current = root;
            while (current != null)     //Wenn Liste nicht leer ist
            {
                if (current.x == x)
                {
                    return true;
                }
                current = current.next;
            }
            return false;
        }

        //Einfügen als letztes Element
        public void Enque(int x)
        {
            if (root == null)       //Wenn Liste leer ist
            {
                root = new LElement(x);   //als erstes Element einfügen
            }
            else
            {
                LElement current = root;
                while (current.next != null)  //Liste so lange durchgehen, bis man beim letzten Element ist
                {
                    current = current.next;
                }
                current.next = new LElement(x);  //hinter letztes Element einfügen
            }
        }

        //Element x sortiert hinzufügen
        public void AddSorted(int x)
        {

            LElement newElement = new LElement(x);

            if (root == null)       //Wenn Liste leer ist
            {
                root = newElement;
                return;
            }

            //Vor dem ersten x einfügen, wenn neues x kleiner als erstes x der Liste
            if (newElement.x <= root.x)
            {
                newElement.next = root;
                root = newElement;
                return;
            }


            //Stelle zum Einfügen suchen
            LElement current = root;

            while (current.next != null && newElement.x >= current.x) // nur wenn Liste bereits existiert & neues Element größer als Anfangselement ist
            {
                current = current.next;
            }
            newElement.next = current.next; //um einen Platz in der Liste frei zu machen
            current.next = newElement;  //Element an diesem Platz einfügen

        }
        abstract public bool Insert(int x);   //damit alle Unterklassen eine eigene Methode Insert definieren müssen

        //löschen eines Elementes
        public bool Delete(int x)
        {
            if (Search(x) == true)           //wenn x gefunden wurde
            {
                LElement current = root;
                LElement previous = null;

                while (current.next != null && x != current.x)
                {
                    previous = current;
                    current = current.next;
                }
                if (current.x == root.x)  //wenn es das erste Element ist
                {
                    root = root.next;  //dann wird das Zweite zum Ersten
                }
                else
                {
                    previous.next = current.next; //hier wird gelöscht
                }
                return true;
            }
            return false;
        }

        //komplette Liste ausgeben
        public void Print()
        {
            LElement current = root;
            if (current == null)        //wenn Liste leer ist
            {
                Console.WriteLine(" Leere Liste ");
                return;
            }
            while (current.next != null)  //bis ein Element kein Nachfolger mehr hat
            {
                Console.WriteLine(current.x);
                current = current.next;
            }
            Console.WriteLine(current.x);
        }
    }
}
