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
        static void Main(string[] args)
        {
            UI userinput = new UI();
            string dateiname = userinput.getUserInput();
            Interactors interactor = new Interactors();
            string dateipfad = interactor.GetFileName(dateiname);
            List<string> rawRecords = interactor.GetFileContent(dateipfad);
            interactor.SplitIntoRecords(rawRecords);
            List<string> result = interactor.FilterFirstPage();
            userinput.writeCSV(result);
        }
    }
}
