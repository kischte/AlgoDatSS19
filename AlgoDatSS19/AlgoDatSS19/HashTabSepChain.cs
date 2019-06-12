using System;

//implements a separate chaining hash table
class HashTabSepChain : AlgoDatSS19.ISet
{
    class HashNode
    {
        int key;
        string data;
        HashNode next;
        public HashNode(int key, string data)
        {
            this.key = key;
            this.data = data;
            next = null;
        }
        public int getkey()
        {
            return key;
        }
        public string getdata()
        {
            return data;
        }
        public void setNextNode(HashNode obj)
        {
            next = obj;
        }
        public HashNode getNextNode()
        {
            return this.next;
        }
    }

    HashNode[] table;
    const int size = 10;

    public HashTabSepChain()
    {
        table = new HashNode[size];
        for (int i = 0; i < size; i++)
        {
            table[i] = null;
        }
    }
    public bool Insert(int key)
    {
        Console.WriteLine("Der Schlüssel " +key +" soll welchen Wert speichern?");

        string data = Console.ReadLine();
        HashNode nObj = new HashNode(key, data);
        int hash = key % size;
        while (table[hash] != null && table[hash].getkey() % size != key % size)
        {
            hash = (hash + 1) % size;
        }
        if (table[hash] != null && hash == table[hash].getkey() % size)
        {
            nObj.setNextNode(table[hash].getNextNode());
            table[hash].setNextNode(nObj);
            return true;
        }
        else
        {
            table[hash] = nObj;
            return true;
        }
        Console.WriteLine("Der Schlüssel " + key + " entählt " +data);
    }

    public string retrieve(int key)
    {
        int hash = key % size;
        while (table[hash] != null && table[hash].getkey() % size != key % size)
        {
            hash = (hash + 1) % size;
        }
        HashNode current = table[hash];
        while (current.getkey() != key && current.getNextNode() != null)
        {
            current = current.getNextNode();
        }
        if (current.getkey() == key)
        {
            return current.getdata();
        }
        else
        {
            return "nothing found!";
        }
    }

    public bool Search(int key)
    {
        int hash = key % size;
        while (table[hash] != null && table[hash].getkey() % size != key % size)
        {
            hash = (hash + 1) % size;
        }
        HashNode current = table[hash];
        while (current.getkey() != key && current.getNextNode() != null)
        {
            current = current.getNextNode();
        }
        if (current.getkey() == key)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Delete(int key)
    {
        int hash = key % size;
        while (table[hash] != null && table[hash].getkey() % size != key % size)
        {
            hash = (hash + 1) % size;
        }
        //a current node pointer used for traversal, currently points to the head
        HashNode current = table[hash];
        bool isRemoved = false;
        while (current != null)
        {
            if (current.getkey() == key)
            {
                table[hash] = current.getNextNode();
                Console.WriteLine("entry removed successfully!");
                isRemoved = true;
                break;
            }

            if (current.getNextNode() != null)
            {
                if (current.getNextNode().getkey() == key)
                {
                    HashNode newNext = current.getNextNode().getNextNode();
                    current.setNextNode(newNext);
                    Console.WriteLine("entry removed successfully!");
                    isRemoved = true;
                    break;
                }
                else
                {
                    current = current.getNextNode();
                }
            }

        }

        if (!isRemoved)
        {
            Console.WriteLine("nothing found to delete!");
            return false;
        }
        return true;
    }
    public void Print()
    {
        HashNode current = null;
        for (int i = 0; i < size; i++)
        {
            int chainCounter = 0;
            current = table[i];
            while (current != null)
            {
                
                if (chainCounter > 0)
                {
                    Console.Write(current.getdata() + " ");
                }else
                {
                    Console.Write(i + " " +current.getdata() + " ");
                }
                current = current.getNextNode();
                chainCounter++;
            }

            Console.WriteLine();
        }
    }

}