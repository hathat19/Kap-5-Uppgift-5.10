using System;
namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            //Färger
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();

            //-------------------------------------------

            int[] numbers = {1,1,1,4,4,4,5,5,5,0,0,0};

            int[,] repeatingNr = new int[(numbers.Length), 2]; 
            /*repeatingNr[n, 0] = vilket tal som förekommer
             repeatingNr[n, 1] = hur många gånger talet förekommer*/

            //x är hur många gånger ett särskilt tal förekommer 
            int x;
            int repeats = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                x = 0;

                for (int j = 0; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        x++;
                    }
                }

                repeatingNr[i, 0] = numbers[i];
                repeatingNr[i, 1] = x;


                //Hittar hur många gånger det mest förekommande talet har upprepats.
                repeats = x >= repeats ? x : repeats;
            }


            Console.WriteLine($"Följande tal är vanligast (förekommer {repeats} gånger): ");
            for (int i = 0; i < numbers.Length ; i++)
            {
                bool next = false;
                //Har siffran redan observerats? Skippa i så fall.
                for (int j = 0; j < i; j++)
                {
                    if (repeatingNr[i, 0] == repeatingNr[j, 0])
                    {
                        next = true;
                    }
                }
                if (next)
                {
                    continue;
                }

                if (repeats == repeatingNr[i, 1])
                {
                    Console.Write(repeatingNr[i, 0]);

                    //Ska "och" skrivas?
                    for (int j = i + 1; j < numbers.Length; j++)
                    {
                        //Om de finns ett till tal som förekommer flest gånger ska "och" skrivas
                        if (repeatingNr[j, 1] == repeats && repeatingNr[i, 0] != repeatingNr[j, 0])
                        {
                            Console.Write(" och ");
                            break;
                        }
                    }
                }
            }
        }
    }
}
/*Skapa ett program som skriver ut det vanligaste talet i en array som består av heltal.
Om flera tal är på delad förstaplats så ska de alla skrivas ut.
Om arrayen består av talen 1, 2, 2, 3 ska programmet skriva ut
Följande tal är vanligast: 2
Om arrayen består av talen 1, 2, 2, 3, 3 ska programmet skriva ut
Följande tal är vanligast: 2 och 3*/