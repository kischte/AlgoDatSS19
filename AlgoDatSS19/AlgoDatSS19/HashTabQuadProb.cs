using System;

//implements a quadratic probing hash table
class HashTabQuadProb : AlgoDatSS19.ISet
{
    class HashProbe
    {
        int hash;
        int key;
        public HashProbe(int hash, int key)
        {
            this.hash = hash;
            this.key = key;
        }
        public int gethash()
        {
            return hash;
        }
        public int getkey()
        {
            return key;
        }
    }


     static int maxSize; //our table size
     static  HashProbe[] table;
    public HashTabQuadProb(int maxSize)
    {
        HashTabQuadProb.maxSize = maxSize;
        table = new HashProbe[maxSize];
        for (int i = 0; i < maxSize; i++)
        {
            table[i] = null;
        }
    }
    public bool Search(int key)
    {


        int j = 0;
        int hash = HashTabQuadProb.hash(key);
        while (table[hash] != null && table[hash].getkey() != key)
        {
            j++;
            hash = mod((HashTabQuadProb.hash(key) + (j * j)), maxSize);
            if (table[hash] != null) hash = mod((HashTabQuadProb.hash(key) + ((j * j) * -1)), maxSize);
        }
        if (table[hash] == null)
        {
            return false;
        }
        else
        {
            Console.WriteLine("Der Schlüssel " + key + " ist im folgenden hash gespeichert: " +hash);
            return true;
        }
    }
    public int retrieve(int key)
    {
        int hash = key % maxSize;
        while (table[hash] != null && table[hash].getkey() != key)
        {
            hash = (hash + 1) % maxSize;
        }
        if (table[hash] == null)
        {
            return -1;
        }
        else
        {
            return table[hash].getkey();
        }
    }
 
    public bool Insert(int key)
    {
        quadraticHashInsert(key);
        return true;
       
    }
  public static bool checkOpenSpace()//checks for open spaces in the table for insertion
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
                Console.WriteLine("{0}: {1}",i , table[i].getkey());
            }
        }
    }

    public static int hash(int key)
    {
        return key % maxSize;
    }

    int mod(int x, int m)
    {
        return (x % m + m) % m;
    }

    public void quadraticHashInsert(int key)
    {
        //quadratic probing method
        if (!checkOpenSpace())//if no open spaces available
        {
            Console.WriteLine("table is at full capacity!");
            return;
        }


        int j = 0;
        int hash = HashTabQuadProb.hash(key);
        while (table[hash] != null)
        {
            j++;
            hash = mod((HashTabQuadProb.hash(key) + (j * j)), maxSize);
            if (table[hash] != null) hash = mod((HashTabQuadProb.hash(key) + ((j * j) * -1)), maxSize); 
          
        }
        if (table[hash] == null)
        {
            table[hash] = new HashProbe(key, key);
            return;
        }
    }



 
}
