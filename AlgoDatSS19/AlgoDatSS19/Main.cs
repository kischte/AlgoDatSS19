using System;

namespace AlgoDatSS19
{
  class Main
  {
    static void AlgoDatMain()
    {
      IDictionary idict = null;
      bool run = true;
      int arraySize = 0;

      while (run)
      {
        //Auswahlebene (Wörterbucharten)
        Console.WriteLine("------Hauptmenü------");
        Console.WriteLine("Auswahl der Wörterbuchart:");
        Console.WriteLine("(1) IMultiSet");
        Console.WriteLine("(2) IMultiSetSorted");
        Console.WriteLine("(3) ISet");
        Console.WriteLine("(4) ISetSorted");
        Console.WriteLine("(5) Programm beenden");


        int eingabe = -1;

        bool eingabeGueltig = false;
        while (!eingabeGueltig)
        {
          try
          {
            eingabe = Convert.ToInt32(Console.ReadLine());
            while (eingabe > 5 || eingabe < 1)
            {
              Console.WriteLine("Ungültige Eingabe, bitte Zahl von 1-5 eingeben");
              eingabe = Convert.ToInt32(Console.ReadLine());
            }
            eingabeGueltig = true;
          }
          catch (OverflowException)
          {
            Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", eingabe);
          }
          catch (FormatException)
          {
            Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
          }
        }
        if (eingabe == 5)
        {
          eingabeGueltig = true;
          run = false;
          break;
        }
        switch (eingabe)
        {
          case 1:
            Console.WriteLine("Es wurde IMultiSet gewählt");
            Console.WriteLine("Auswahl des Wörterbuchs");
            Console.WriteLine("(1) MultiSetUnsortedList");
            Console.WriteLine("(2) MultiSetUnsortedArray");

            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 2 || eingabe < 1)
                {
                  Console.WriteLine("Ungültige Eingabe, bitte Zahl von 1-2 eingeben");
                  eingabe = Convert.ToInt32(Console.ReadLine());
                }
                eingabeGueltig = true;
              }
              catch (OverflowException)
              {
                Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", eingabe);
              }
              catch (FormatException)
              {
                Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
              }
            }

            //Weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Es wurde MultiSetUnsortedList gewählt");
                idict = new MultiSetUnsortedList();
                break;
              case 2:
                Console.WriteLine("Es wurde MultiSetUnsortedArray gewählt");
                Console.WriteLine("Wieviele Werte sollen gespeichert werden?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new MultiSetUnsortedArray(arraySize);
                break;
              default:
                Console.WriteLine("Ungültige Eingabe");
                break;

            }
            break;

          case 2:
            Console.WriteLine("Es wurde IMultiSetSorted gewählt");
            Console.WriteLine("Auswahl des Wörterbuchs");
            Console.WriteLine("(1) MultiSetSortedList");
            Console.WriteLine("(2) MultiSetSortedArray");

            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 2 || eingabe < 1)
                {
                  Console.WriteLine("Ungültige Eingabe, bitte Zahl von 1-2 eingeben");
                  eingabe = Convert.ToInt32(Console.ReadLine());
                }
                eingabeGueltig = true;
              }
              catch (OverflowException)
              {
                Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", eingabe);
              }
              catch (FormatException)
              {
                Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
              }
            }

            //weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Es wurde MultiSetSortedList gewählt");
                idict = new MultiSetSortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Es wurde MultiSetSortedArray gewählt");
                Console.WriteLine("Wieviele Werte sollen gespeichert werden?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new MultiSetSortedArray(arraySize);
                break;
            }
            break;

          case 3:
            Console.WriteLine("Es wurde ISet gewählt");
            Console.WriteLine("Auswahl des Wörterbuchs");
            Console.WriteLine("(1) SetUnsortedList");
            Console.WriteLine("(2) SetUnsortedArray");
            Console.WriteLine("(3) HashTableQuadProb");
            Console.WriteLine("(4) HashTableSepChain");

            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 4 || eingabe < 1)
                {
                  Console.WriteLine("Ungültige Eingabe, bitte Zahl von 1-4 eingeben");
                  eingabe = Convert.ToInt32(Console.ReadLine());
                }
                eingabeGueltig = true;
              }
              catch (OverflowException)
              {
                Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", eingabe);
              }
              catch (FormatException)
              {
                Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
              }
            }

            //weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Es wurde SetUnsortedList gewählt");
                idict = new SetUnsortedList();
                break;
              case 2:
                Console.WriteLine("Es wurde SetUnsortedArray gewählt");
                Console.WriteLine("Wieviele Werte sollen gespeichert werden?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new SetUnsortedArray(arraySize);
                break;
              case 3:
                Console.WriteLine("Es wurde HashTableQuadProb gewählt");
                idict = new HashTabQuadProb();
                break;
              case 4:
                Console.WriteLine("Es wurde HashTableSepChain gewählt");
                idict = new HashTabSepChain();
                break;
              default:
                Console.WriteLine("Ungültige Eingabe");
                break;
            }
            break;

          case 4:
            Console.WriteLine("Es wurde ISetSorted gewählt");
            Console.WriteLine("Auswahl des Wörterbuchs");
            Console.WriteLine("(1) SetSortedList");
            Console.WriteLine("(2) SetSortedArray");
            Console.WriteLine("(3) binärer Suchbaum");
            Console.WriteLine("(4) AVL Baum");
            Console.WriteLine("(5) Treap");

            //eingabe = Convert.ToInt32(Console.ReadLine());
            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 5 || eingabe < 1)
                {
                  Console.WriteLine("Ungültige Eingabe, bitte Zahl von 1-5 eingeben");
                  eingabe = Convert.ToInt32(Console.ReadLine());
                }
                eingabeGueltig = true;
              }
              catch (OverflowException)
              {
                Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", eingabe);
              }
              catch (FormatException)
              {
                Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
              }
            }
            //weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Es wurde SetSortedList gewählt");
                idict = new SetSortedList();
                break;
              case 2:
                Console.WriteLine("Es wurde SetSortedArray gewählt");
                Console.WriteLine("Wieviele Werte sollen gespeichert werden?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new SetSortedArray(arraySize);
                break;
              case 3:
                Console.WriteLine("Es wurde Binary Search Tree gewählt");
                idict = new BinSearchTree();
                break;
              case 4:
                Console.WriteLine("Es wurde AVL Tree gewählt");
                idict = new AVLTree();
                break;
              case 5:
                Console.WriteLine("Es wurde Treap gewählt");
                idict = new Treap();
                break;
              default:
                Console.WriteLine("Ungültige Eingabe");
                break;
            }
            break;

        }
        bool agieren;
        do
        {
          //Auswahlebene (Aktionen)
          Console.WriteLine();
          Console.WriteLine("Bitte Aktion wählen:");
          Console.WriteLine("(I)nsert");
          Console.WriteLine("(S)earch");
          Console.WriteLine("(D)elete");
          Console.WriteLine("(P)rint");
          Console.WriteLine("(Z)urück zum Hauptmenü");

          string aktion = Console.ReadLine();
          bool eingGueltig = false;
          bool feedback = false;
          int wert = 0;
          agieren = true;

          switch (aktion)
          {
            //Aktion Insert
            case "i":
            case "I":
              Console.WriteLine("Es wurde Insert gewählt");
              Console.WriteLine("Bitte Wert eingeben: ");


              eingGueltig = false;
              while (!eingGueltig)
              {
                try
                {
                  wert = Convert.ToInt32(Console.ReadLine());
                  eingGueltig = true;
                }
                catch (OverflowException)
                {
                  Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", wert);
                }
                catch (FormatException)
                {
                  Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
                }
              }
              feedback = idict.Insert(wert); //Hier wird feedback gesetzt ob die Aktion erfolgreich war oder nicht

              //Zahl existiert bereits NUR FÜR SET; NICHT MULTISET
              if (feedback == false)
              {
                Console.WriteLine("Die eingegebene Zahl existiert bereits");
              }
              else
              {
                Console.WriteLine("{0} wurde eingefügt", wert);
              }
              break;

            //Aktion Search
            case "s":
            case "S":
              Console.WriteLine("Es wurde Search gewählt");
              Console.WriteLine("Bitte gesuchte Zahl eingeben");
              eingGueltig = false;
              while (!eingGueltig)
              {
                try
                {
                  wert = Convert.ToInt32(Console.ReadLine());
                  eingGueltig = true;
                }
                catch (OverflowException)
                {
                  Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", wert);
                }
                catch (FormatException)
                {
                  Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
                }
                feedback = idict.Search(wert);

              }
              if (feedback == true)
              {
                Console.WriteLine("Zahl {0} befindet sich in der Struktur", wert);
              }
              else
                Console.WriteLine("Zahl {0} wurde nicht in der Struktur gefunden", wert);
              break;

            //Aktion Delete
            case "d":
            case "D":
              Console.WriteLine("Es wurde Delete gewählt");
              Console.WriteLine("Bitte zu löschende Zahl eingeben");
              eingGueltig = false;
              while (!eingGueltig)
              {
                try
                {
                  wert = Convert.ToInt32(Console.ReadLine());
                  eingGueltig = true;
                }
                catch (OverflowException)
                {
                  Console.WriteLine("{0} ist zu groß, bitte neue Zahl eingeben!", wert);
                }
                catch (FormatException)
                {
                  Console.WriteLine("Es wurde keine Zahl eingegeben, bitte neue Zahl eingeben");
                }
                feedback = idict.Delete(wert);
                if (feedback)
                {
                  Console.WriteLine("Es wurde {0} aus der Struktur entfernt", wert);
                }
                else
                  Console.WriteLine("{0} wurde nicht in der Struktur gefunden", wert);
              }
              break;

            //Aktion Print
            case "p":
            case "P":
              Console.WriteLine("Es wurde Print gewählt");
              idict.Print();
              break;

            //Aktion Zurück
            case "z":
            case "Z":
              Console.WriteLine("Es wurde Zurück gewählt");
              agieren = false;
              break;

            default:
              Console.WriteLine("Ungültige Eingabe");
              break;

          }
        } while (agieren);
      }
    }
  }
}
