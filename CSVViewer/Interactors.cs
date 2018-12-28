using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSVViewer
{
    class Interactors
    {
        List<List<string>> RecordsArray = new List<List<string>>();
        int CurrentPage = 0;

        public string GetFileName(string name)
        {
            string path = @"C:\Users\Cheshire\source\repos\CSVViewer\CSVViewer\";
            if (name.Contains(".csv")){
                return path + name;
            }
            else
            {
                return path + name + ".csv";
            }
            
        }

        public List<string> GetFileContent(string path)
        {
            List<string> RecordsRawArray = new List<string>();
            string [] lines = System.IO.File.ReadAllLines(path);
            foreach (string person in lines)
            {
                RecordsRawArray.Add(person);
            }
            return RecordsRawArray;
        }

        public void SplitIntoRecords(List<string> RecordsRawArray)
        {
            int counter;
            for (counter = 0; counter < RecordsRawArray.Count; counter++)
            {
                List<string> record = RecordsRawArray[counter].Split(';').ToList();
                RecordsArray.Add(record);
            }
        }

        public List<string> FilterFirstPage()
        {
            int counter;
            List<string> result = new List<string>();
            int max;
            if(RecordsArray.Count < 12)
            {
                max = RecordsArray.Count;
            }
            else
            {
                max = 12;
            }
            for (counter = 0; counter < max; counter++)
            {
                result.Add(RecordsArray[counter].ToString());
            }
            return result;
        }
    }
}
