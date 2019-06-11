using System;

namespace AlgoDatSS19
{
    abstract public class SupportList
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
        LElement root;
        public SupportList()
        {
            root = null;
        }

        // nach Element x suchen
        public bool Search(int x)
        {
            LElement current = root;
            while (current != null)
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
            if (root == null)
            {
                root = new LElement(x);
            }
            else
            {
                LElement current = root;
                while (current.next != null)
                {
                    current = current.next;
                }
                current.next = new LElement(x);
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

            //Vor dem ersten x einfügen
            if (newElement.x <= root.x)
            {
                newElement.next = root;
                root = newElement;
                return;
            }


            //Stelle zum Einfügen suchen
            LElement current = root;

            while (current.next != null && newElement.x >= current.x)
            {
                current = current.next;
            }
            newElement.next = current.next;
            current.next = newElement;

        }
        abstract public bool Insert(int x);   //damit alle Unterklassen eine Methode Insert definieren müssen

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
                if (current.x == root.x)
                {
                    root = root.next;
                }
                else
                {
                    previous.next = current.next;
                }
                return true;
            }
            return false;
        }

        //komplette Liste ausgeben
        public void Print()
        {
            LElement current = root;
            if (current == null)
            {
                Console.WriteLine(" Leere Liste ");
                return;
            }
            while (current.next != null)
            {
                Console.WriteLine(current.x);
                current = current.next;
            }
            Console.WriteLine(current.x);
        }
    }
}
