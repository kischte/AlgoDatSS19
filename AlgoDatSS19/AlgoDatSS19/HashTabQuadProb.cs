using System;

//implements a quadratic probing hash table
class HashTabQuadProb : AlgoDatSS19.ISet
{
    class HashProbe
    {
        int key;
        string data;
        public HashProbe(int key, string data)
        {
            this.key = key;
            this.data = data;
        }
        public int getkey()
        {
            return key;
        }
        public string getdata()
        {
            return data;
        }
    }


    const int maxSize = 10; //our table size
    HashProbe[] table;
    public HashTabQuadProb()
    {
        table = new HashProbe[maxSize];
        for (int i = 0; i < maxSize; i++)
        {
            table[i] = null;
        }
    }
    public bool Search(int key)
    {

        int hash = key % maxSize;
        while (table[hash] != null && table[hash].getkey() != key)
        {
            hash = (hash + 1) % maxSize;
        }
        if (table[hash] == null)
        {
            return false;
        }
        else
        {
            Console.WriteLine("Der Schlüssel " + key + " enthält: " +table[hash].getdata());
            return true;
        }
    }
    public string retrieve(int key)
    {
        int hash = key % maxSize;
        while (table[hash] != null && table[hash].getkey() != key)
        {
            hash = (hash + 1) % maxSize;
        }
        if (table[hash] == null)
        {
            return "nothing found!";
        }
        else
        {
            return table[hash].getdata();
        }
    }
 
    public bool Insert(int key)
    {

        Console.WriteLine("Der Schlüssel " + key + " soll welchen Wert speichern?");

        string data = Console.ReadLine();
        quadraticHashInsert(key, data);
        return true;
       
    }
    private bool checkOpenSpace()//checks for open spaces in the table for insertion
    {
        bool isOpen = false;
        for (int i = 0; i < maxSize; i++)
        {
            if (table[i] == null)
            {
                isOpen = true;
            }
        }
        return isOpen;
    }
    public bool Delete(int key)
    {
        int hash = key % maxSize;
        while (table[hash] != null && table[hash].getkey() != key)
        {
            hash = (hash + 1) % maxSize;
        }
        if (table[hash] == null)
        {
            return false;
        }
        else
        {
            table[hash] = null;
            return true;
        }
    }
    public void Print()
    {
        for (int i = 0; i < table.Length; i++)
        {
            if (table[i] == null && i <= maxSize)//if we have null entries
            {
                continue;//dont print them, continue looping
            }
            else
            {
                Console.WriteLine("{0}{1}",i , table[i].getdata());
            }
        }
    }
    public void quadraticHashInsert(int key, string data)
    {
        //quadratic probing method
        if (!checkOpenSpace())//if no open spaces available
        {
            Console.WriteLine("table is at full capacity!");
            return;
        }

        int j = 0;
        int hash = key % maxSize;
        while (table[hash] != null && table[hash].getkey() != key)
        {
            j++;
            hash = (hash + j * j) % maxSize;
        }
        if (table[hash] == null)
        {
            table[hash] = new HashProbe(key, data);
            return;
        }
    }
}
