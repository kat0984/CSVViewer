using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSVViewer
{

    public class PressedKey : EventArgs
    {
        private string pressedkey;
        public string Key
        {
            set
            {
                pressedkey = value;
            }
            get
            {
                return this.pressedkey;
            }
        }
    }

    class UI
    {
        public event TickHandler Tick;
        public EventArgs e = null;
        public delegate void TickHandler(UI m, PressedKey e);

        public string getUserInput()
        {
            Console.WriteLine("Bitte geben Sie den Dateinamen an:");
            return Console.ReadLine();
        }

        public void writeCSV(List<List<string>> result)
        {
            if (result.Count > 0)
            {
                int numberofColums = result[0].Count;
                List<int> ListOfMaxLength = GetMaxLength(result, numberofColums);
                int counterline;
                int counterrow;
                string writetheLine = "";
                int completeLength = 0;
                for (counterrow = 0; counterrow < numberofColums; counterrow++)
                {
                    writetheLine = writetheLine + result[0][counterrow].PadRight(ListOfMaxLength[counterrow]);
                    completeLength = completeLength + ListOfMaxLength[counterrow];
                }
                Console.WriteLine(writetheLine);
                writetheLine = "";

                for (counterrow = 0; counterrow < numberofColums; counterrow++)
                {
                    writetheLine = writetheLine + "".PadRight(ListOfMaxLength[counterrow] - 1, '-') + "+";
                }
                Console.WriteLine(writetheLine);
                writetheLine = "";


                for (counterline = 1; counterline < result.Count; counterline++)
                {
                    for (counterrow = 0; counterrow < numberofColums; counterrow++)
                    {
                        writetheLine = writetheLine + result[counterline][counterrow].PadRight(ListOfMaxLength[counterrow]);
                    }
                    Console.WriteLine(writetheLine);
                    writetheLine = "";
                }
                Console.WriteLine("N(ext page, P(revious page, F(irst page, L(ast page, eX(it");

                while (true)
                {
                    string pressedkey = Console.ReadLine();
                    PressedKey TOT = new PressedKey();
                    //System.Threading.Thread.Sleep(3000);
                    if (Tick != null)
                    {
                        //Tick(this, e);
                        if (pressedkey.ToUpper().Equals("N"))
                        {
                            TOT.Key = "N";
                            Tick(this, TOT);
                        }
                        else if (pressedkey.ToUpper().Equals("P"))
                        {
                            TOT.Key = "P";
                            Tick(this, TOT);
                        }
                        else if (pressedkey.ToUpper().Equals("F"))
                        {
                            TOT.Key = "F";
                            Tick(this, TOT);
                        }
                        else if (pressedkey.ToUpper().Equals("L"))
                        {
                            TOT.Key = "L";
                            Tick(this, TOT);
                        }
                        else if (pressedkey.ToUpper().Equals("X"))
                        {
                            TOT.Key = "X";
                            Tick(this, TOT);
                            break;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Die Datei ist leer.");
                Console.WriteLine("Press any key to continue.");

                while (true)
                {
                    string pressedkey = Console.ReadLine();
                    if (pressedkey != null)
                    {
                        break;
                    }
                }
            }
        }

        public List<int> GetMaxLength(List<List<string>> result, int numberofColums)
        {
            int counter;
            int counter2;
            List<int> ListOfMaxLength = new List<int>();
            int maxlength = 0;
            for (counter = 0; counter < numberofColums; counter++)
            {
                for (counter2 = 0; counter2 < result.Count - 1; counter2++)
                {
                    if (result[counter2][counter].Length > maxlength)
                    {
                        maxlength = result[counter2][counter].Length;
                    }
                }
                ListOfMaxLength.Add(maxlength + 1);
                maxlength = 0;
            }
            return ListOfMaxLength;
        }

    }
}
