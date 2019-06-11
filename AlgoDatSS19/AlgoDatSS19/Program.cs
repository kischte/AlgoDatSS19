using System;

namespace AlgoDatSS19
{
  class Program
  {
    static void Main()
    {
      IDictionary idict = null;
      bool run = true;
      int arraySize = 0;

      while (run)
      {
        //Auswahlebene (Wörterbucharten)
        Console.WriteLine("-- Menü --");
        Console.WriteLine("Wählen Sie ein Dictionary aus:");
        Console.WriteLine("1. IMultiSet");
        Console.WriteLine("2. IMultiSetSorted");
        Console.WriteLine("3. ISet");
        Console.WriteLine("4. ISetSorted");
        Console.WriteLine("5. Programm beenden");


        int eingabe = -1;

        if (eingabe == 5)
        {
          run = false;
          break;
        }
        switch (eingabe)
        {
          case 1:
            Console.WriteLine("Sie haben IMultiSet ausgewählt");
            Console.WriteLine("Wählen Sie ein Dictionary aus:");
            Console.WriteLine("1. MultiSetUnsortedLinkedList");
            Console.WriteLine("2. MultiSetUnsortedArray");

            //Weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Sie haben MultiSetUnsortedLinkedList ausgewählt");
                idict = new MultiSetUnsortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Sie haben MultiSetUnsortedArray ausgewählt");
                Console.WriteLine("Wie viele Werte möchten Sie speichern?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new MultiSetUnsortedArray(arraySize);
                break;
              default:
                Console.WriteLine("Eingabe ist nicht gültig");
                break;
            }
            break;

          case 2:
            Console.WriteLine("Sie haben IMultiSetSorted ausgewählt");
            Console.WriteLine("Wählen Sie ein Dictionary aus:");
            Console.WriteLine("1. MultiSetSortedLinkedList");
            Console.WriteLine("2. MultiSetSortedArray");

            //weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Sie haben MultiSetSortedLinkedList ausgewählt");
                idict = new MultiSetSortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Sie haben MultiSetSortedArray ausgewählt");
                Console.WriteLine("Wieviele Werte möchten Sie speichern?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new MultiSetSortedArray(arraySize);
                break;
            }
            break;

          case 3:
            Console.WriteLine("Sie haben ISet ausgewählt");
            Console.WriteLine("Wählen Sie ein Dictionary aus:");
            Console.WriteLine("1. SetUnsortedLinkedList");
            Console.WriteLine("2. SetUnsortedArray");
            Console.WriteLine("3. HashTableQuadProb");
            Console.WriteLine("4. HashTableSepChain");

            //weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Sie haben SetUnsortedLinkedList ausgewählt");
                idict = new SetUnsortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Sie haben SetUnsortedArray ausgewählt");
                Console.WriteLine("Wieviele Werte möchten Sie speichern?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new SetUnsortedArray(arraySize);
                break;
              case 3:
                Console.WriteLine("Sie haben HashTableQuadProb ausgewählt");
                idict = new HashTabQuadProb();
                break;
              case 4:
                Console.WriteLine("Sie haben HashTableSepChain ausgewählt");
                idict = new HashTabSepChain();
                break;
              default:
                Console.WriteLine("Eingabe ist nicht gültig");
                break;
            }
            break;

          case 4:
            Console.WriteLine("Sie haben ISetSorted ausgewählt");
            Console.WriteLine("Wählen Sie ein Dictionary aus:");
            Console.WriteLine("1. SetSortedLinkedList");
            Console.WriteLine("2. SetSortedArray");
            Console.WriteLine("3. binärer Suchbaum");
            Console.WriteLine("4. AVL Baum");
            Console.WriteLine("5. Treap");

            //weitere Auswahl
            switch (eingabe)
            {
              case 1:
                Console.WriteLine("Sie haben SetSortedLinkedList ausgewählt");
                idict = new SetSortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Sie haben SetSortedArray ausgewählt");
                Console.WriteLine("Wie viele Werte möchten Sie speichern?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new SetSortedArray(arraySize);
                break;
              case 3:
                Console.WriteLine("Sie haben Binary Search Tree ausgewählt");
                idict = new BinSearchTree();
                break;
              case 4:
                Console.WriteLine("Sie haben AVL Tree ausgewählt");
                idict = new AVLTree();
                break;
              case 5:
                Console.WriteLine("Sie haben Treap ausgewählt");
                idict = new Treap();
                break;
              default:
                Console.WriteLine("Eingabe ist nicht gültig");
                break;
            }
            break;

        }
        bool agieren;
        do
        {
          //Auswahlebene (Aktionen)
          Console.WriteLine();
          Console.WriteLine("Bitte wählen Sie eine Funktion aus:");
          Console.WriteLine("1. Insert");
          Console.WriteLine("2. Search");
          Console.WriteLine("3. Delete");
          Console.WriteLine("4. Print");
          Console.WriteLine("5. Zurück zum Menü");

          string aktion = Console.ReadLine();
          bool eingGueltig = false;
          bool feedback = false;
          int wert = 0;
          agieren = true;

          switch (aktion)
          {
            //Aktion Insert
            case "1":
              Console.WriteLine("Sie haben Insert ausgewählt");
              Console.WriteLine("Geben Sie bitte einen Wert ein: ");

              feedback = idict.Insert(wert); //Hier wird feedback gesetzt ob die Aktion erfolgreich war oder nicht

              //Zahl existiert bereits NUR FÜR SET; NICHT MULTISET
              if (feedback == false)
              {
                Console.WriteLine("Die eingegebene Zahl ist bereits vorhanden!");
              }
              else
              {
                Console.WriteLine("{0} wurde eingefügt", wert);
              }
              break;

            //Aktion Search
            case "2":
              Console.WriteLine("Sie haben Search ausgewählt");
              Console.WriteLine("Bitte geben Sie die Zahl ein, die gesucht werden soll:");

              if (feedback == true)
              {
                Console.WriteLine("Zahl {0} wurde gefunden:", wert);
              }
              else
                Console.WriteLine("Zahl {0} wurde nicht gefunden:", wert);
              break;

            //Aktion Delete
            case "3":
              Console.WriteLine("Sie haben Delete ausgewählt");
              Console.WriteLine("Bitte geben Sie die Zahl ein, die gelöscht werden soll:");

              feedback = idict.Delete(wert);
              if (feedback)
              {
                Console.WriteLine("Die Zahl {0} wurde gelöscht", wert);
              }
              else
                Console.WriteLine("Die Zahl {0} wurde nicht gefunden.", wert);

              break;

            //Aktion Print
            case "4":
              Console.WriteLine("Sie haben Print ausgewählt");
              idict.Print();
              break;

            //Aktion Zurück
            case "5":
              Console.WriteLine("Sie haben Zurück ausgewählt");
              agieren = false;
              break;

            default:
              Console.WriteLine("Eingabe ist nicht gültig");
              break;

          }
        } while (agieren);
      }
    }
  }
}
