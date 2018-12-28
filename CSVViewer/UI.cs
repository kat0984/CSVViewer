using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSVViewer
{
    class UI
    {
        public string getUserInput()
        {
            Console.WriteLine("Bitte geben Sie den Dateinamen an:");
            return Console.ReadLine();
        }
        public void writeCSV(List<string> Result)
        {
            if(Result.Count > 0)
            {
                Console.WriteLine(Result[0]);
                Console.WriteLine("----------------------------+");
                int counter;
                for (counter = 1; counter < Result.Count; counter++)
                {
                    Console.WriteLine(Result[counter][0]);
                }
                Console.WriteLine("N(ext page, P(revious page, F(irst page, L(ast page, eX(it");
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }

        }
    }
}
