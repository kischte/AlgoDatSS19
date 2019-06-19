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
        Console.WriteLine("------Menü------");
        Console.WriteLine("Wählen Sie ein Dictionary aus:");
        Console.WriteLine("1. IMultiSet");
        Console.WriteLine("2. IMultiSetSorted");
        Console.WriteLine("3. ISet");
        Console.WriteLine("4. ISetSorted");
        Console.WriteLine("5. Programm beenden");


        int eingabe = -1;

        bool eingabeGueltig = false;
        while (!eingabeGueltig)
        {
          try
          {
            eingabe = Convert.ToInt32(Console.ReadLine());
            while (eingabe > 5 || eingabe < 1)
            {
              Console.WriteLine("Eingabe ungültig, bitte wählen Sie eine Zahl zwischen 1 und 5.");
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
            Console.WriteLine("Sie haben IMultiSet ausgewählt");
            Console.WriteLine("Wählen Sie ein Dictionary aus:");
            Console.WriteLine("1. MultiSetUnsortedList");
            Console.WriteLine("2. MultiSetUnsortedArray");

            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 2 || eingabe < 1)
                {
                  Console.WriteLine("Eingabe ungültig, bitte Wählen Sie zwischen 1 und 2");
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
                Console.WriteLine("Sie haben MultiSetUnsortedList ausgewählt");
                idict = new MultiSetUnsortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Sie haben MultiSetUnsortedArray ausgewählt");
                Console.WriteLine("Wieviele Werte möchten Sie speichern?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new MultiSetUnsortedArray(arraySize);
                break;
              default:
                Console.WriteLine("Eingabe ist ungültig");
                break;

            }
            break;

          case 2:
            Console.WriteLine("Sie haben IMultiSetSorted ausgewählt");
            Console.WriteLine("Wählen Sie ein Dictionary aus:");
            Console.WriteLine("1. MultiSetSortedList");
            Console.WriteLine("2. MultiSetSortedArray");

            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 2 || eingabe < 1)
                {
                  Console.WriteLine("Eingabe ungültig, bitte wählen Sie 1 oder 2");
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
                Console.WriteLine("Sie haben MultiSetSortedList ausgewählt");
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
            Console.WriteLine("1. SetUnsortedList");
            Console.WriteLine("2. SetUnsortedArray");
            Console.WriteLine("3. HashTableQuadProb");
            Console.WriteLine("4. HashTableSepChain");
                   
            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 4 || eingabe < 1)
                {
                  Console.WriteLine("Eingabe ungültig, bitte wählen Sie eine Zahl zwischen 1 und 4.");
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
                Console.WriteLine("Sie haben SetUnsortedList ausgewählt");
                idict = new SetUnsortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Sie haben SetUnsortedArray ausgewählt");
                Console.WriteLine("Wieviele Werte möchten Sie speichern?");
                arraySize = Convert.ToInt32(Console.ReadLine());
                idict = new SetUnsortedArray(arraySize);
                break;
              case 3:
                Console.WriteLine("Es wurde HashTableQuadProb gewählt\nBitte geben sie die Größe der Tabelle ein:");
                int maxSizeQuadProb = Convert.ToInt32(Console.ReadLine());
                idict = new HashTabQuadProb(maxSizeQuadProb);
                break;
              case 4:
                Console.WriteLine("Es wurde HashTableSepChain gewählt\nBitte geben sie die Größe der Tabelle ein:");
                                int maxSizeSepChain = Convert.ToInt32(Console.ReadLine());
                                idict = new HashTabSepChain(maxSizeSepChain);
                break;
              default:
                Console.WriteLine("Ungültige Eingabe");
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

            //eingabe = Convert.ToInt32(Console.ReadLine());
            eingabeGueltig = false;
            while (!eingabeGueltig)
            {
              try
              {
                eingabe = Convert.ToInt32(Console.ReadLine());
                while (eingabe > 5 || eingabe < 1)
                {
                  Console.WriteLine("Eingabe ungültig, bitte wählen Sie eine Zahl zwischen 1 und 5.");
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
                Console.WriteLine("Sie haben SetSortedLinkedList ausgewählt");
                idict = new SetSortedLinkedList();
                break;
              case 2:
                Console.WriteLine("Sie haben SetSortedArray ausgewählt");
                Console.WriteLine("Wieviele Werte möchten Sie speichern?");
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
              Console.WriteLine("Sie haben Insert ausgewählt");
             
                            if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                            {
                                Console.WriteLine("Geben Sie bitte einen Schlüssel ein: ");
                            }
                            else
                            {
                                Console.WriteLine("Geben Sie bitte einen Wert ein: ");
                            }


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

                                if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                                {



                                    Console.WriteLine("Der eingegebene Schlüssel ist also schon vorhanden!");
                                }

                                else
                                {

                                    Console.WriteLine("Die eingegebene Zahl ist bereits vorhanden!");
                                }

                            
                               
              }
              else
              {
                                if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                                {

                                    if(HashTabQuadProb.checkOpenSpace() == false) Console.WriteLine("");
                                    else Console.WriteLine("{0} wurde eingefügt", wert);
                                }

                                else
                                {
                                    Console.WriteLine("{0} wurde eingefügt", wert);
                                }
                             

              }
              break;

            //Aktion Search
            case "s":
            case "S":
              Console.WriteLine("Sie haben Search ausgewählt");

                            if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                            {
                                Console.WriteLine("Bitte geben Sie den Schlüssel ein, der gesucht werden soll:");
                            }
                            else
                            {
                                Console.WriteLine("Bitte geben Sie die Zahl ein, die gesucht werden soll:");
                            }

                            
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
                                if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                                {
                                    Console.WriteLine("Schlüssel {0} wurde gefunden", wert);
                                }
                                else
                                {
                                    Console.WriteLine("Zahl {0} wurde gefunden", wert);
                                }
                                
              }
              else
                                if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                            {
                                Console.WriteLine("Der Schlüssel {0} wurde nicht gefunden", wert);
                            }
                            else
                            {
                                Console.WriteLine("Die Zahl {0} wurde nicht gefunden", wert);
                            }

                          
              break;
            //Aktion Delete

            case "d":
            case "D":
              Console.WriteLine("Sie haben Delete ausgewählt");
                           
                            if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                            {
                                Console.WriteLine("Bitte geben Sie den Schlüssel ein der gelöscht werden soll!");
                            }
                            else
                            {
                                Console.WriteLine("Bitte geben Sie die Zahl ein, die gelöscht werden soll.");
                            }

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
                 

                                    if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                                    {
                                        Console.WriteLine("Der Schlüssel {0} wurde gelöscht", wert);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Die Zahl {0} wurde gelöscht", wert);
                                    }
                                }
                else
                                      if (idict.GetType().ToString().Equals("HashTabQuadProb") || idict.GetType().ToString().Equals("HashTabSepChain"))
                                {
                                    Console.WriteLine("Der Schlüssel {0} wurde nicht gefunden", wert);
                                }
                                else
                                {
                                    Console.WriteLine("Die Zahl {0} wurde nicht gefunden", wert);
                                }
                              
              }
              break;

            //Aktion Print
            case "p":
            case "P":
              Console.WriteLine("Sie haben Print ausgewählt");
              idict.Print();
              break;

            //Aktion Zurück
            case "z":
            case "Z":
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