using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSVViewer
{
    class Program
    {
        static Interactors interactor = new Interactors();
        static UI userinput = new UI();

        public void Subscribe(UI m)
        {
            m.Tick += new UI.TickHandler(HeardIt);
        }
        private void HeardIt(UI m, PressedKey e)
        {
            List<List<string>> result = new List<List<string>>();
            Console.WriteLine("HEARD IT {0}", e.Key);
            switch(e.Key)
            {
                case "F":
                    interactor.currentPage = 1;
                    result = interactor.FilterFirstPage();
                    userinput.writeCSV(result);
                    break;

                case "P":
                    interactor.currentPage = interactor.currentPage - 10;
                    if(interactor.currentPage < 1)
                    {
                        interactor.currentPage = interactor.RecordsArray.Count - 10;
                    }
                    Console.WriteLine(interactor.currentPage);
                    result = interactor.FilterPreviousPage();
                    userinput.writeCSV(result);
                    break;

                case "N":
                    interactor.currentPage = interactor.currentPage + 10;
                    if (interactor.currentPage > interactor.RecordsArray.Count - 10)
                    {
                        interactor.currentPage = 1;
                    }
                    Console.WriteLine(interactor.currentPage);
                    result = interactor.FilterNextPage();
                    userinput.writeCSV(result);
                    break;

                case "L":
                    interactor.currentPage = interactor.RecordsArray.Count-10;
                    Console.WriteLine(interactor.currentPage);
                    result = interactor.FilterLastPage();
                    userinput.writeCSV(result);
                    break;

                case "X":
                    break;

            }
        }

        static void Main(string[] args)
        {
            string dateiname = userinput.getUserInput();
            string dateipfad = interactor.GetFileName(dateiname);
            List<string> rawRecords = interactor.GetFileContent(dateipfad);
            interactor.SplitIntoRecords(rawRecords);
            List<List<string>> result = interactor.FilterFirstPage();

            Program l = new Program();
            l.Subscribe(userinput);
            userinput.writeCSV(result);
        }
    }

    
}
