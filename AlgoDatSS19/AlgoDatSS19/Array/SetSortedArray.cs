namespace AlgoDatSS19
{
  class SetSortedArray : MultiSetSortedArray, ISetSorted
  {
    public SetSortedArray(int size) : base(size) { }

    //Suchfunktion implementiert in MultiSetSortedArray

    public new bool Insert(int x)
    {
      //Wenn Element x schon vorhanden, wird es nicht neu hinzugefügt
      if (Search(x) == true)
      {
        return false;
      }

      //Sortiertes Einfügen von Element x an entprechender Stelle
      for (int i = 0; i < array.Length ; i++)
      {
        if (array[i] > x)
        {
          for (int pos = array.Length ; pos >= i + 1; pos--)
          {
            //Alle Elemente rechts von x um eins nach rechts verschieben
            array[pos] = array[pos - 1];
          }
          array[i] = x;
          return true;
        }

        //Falls das Array leer ist, füge x an Position 0 ein
        else if (array[i] == 0)
        {
          array[i] = x;
          return true;
        }
      }
      return false;
    }

    //Delete Funktion implementiert in MultiSetSortedArray
    //Print Funktion implementiert in SupportArray
  }
}
