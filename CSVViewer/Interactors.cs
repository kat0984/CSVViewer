using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSVViewer
{
    public class Interactors
    {
        public List<List<string>> RecordsArray = new List<List<string>>();
        public int currentPage = 0;

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

        public List<List<string>> FilterFirstPage()
        {
            int counter;
            List<string> resultlist = new List<string>();
            List<List<string>> result = new List<List<string>>();
            int max;
            if(RecordsArray.Count < 11)
            {
                max = RecordsArray.Count;
            }
            else
            {
                max = 11;
            }
            for (counter = 0; counter < max; counter++)
            {
                resultlist = RecordsArray[counter];
                result.Add(resultlist);
            }
            return result;
        }

        public List<List<string>> FilterNextPage()
        {
            int counter;
            List<string> resultlist = new List<string>();
            List<List<string>> result = new List<List<string>>();
            int max;
            int max_;
            max_ = 11 + currentPage;
            if (RecordsArray.Count < max_)
            {
                max = RecordsArray.Count;
            }
            else
            {
                max = max_;
            }
            resultlist = RecordsArray[0];
            result.Add(resultlist);
            for (counter = currentPage; counter < max - 1; counter++)
            {
                resultlist = RecordsArray[counter];
                result.Add(resultlist);
            }
            return result;
        }

        public List<List<string>> FilterPreviousPage()
        {
            int counter;
            List<string> resultlist = new List<string>();
            List<List<string>> result = new List<List<string>>();
            int max;
            int max_;
            max_ = currentPage + 11;
            if (RecordsArray.Count < max_)
            {
                max = RecordsArray.Count;
            }
            else
            {
                max = max_;
            }
            resultlist = RecordsArray[0];
            result.Add(resultlist);
            for (counter = currentPage; counter < max - 1; counter++)
            {
                resultlist = RecordsArray[counter];
                result.Add(resultlist);
            }
            return result;
        }

        public List<List<string>> FilterLastPage()
        {
            int counter;
            List<string> resultlist = new List<string>();
            List<List<string>> result = new List<List<string>>();
            int max = RecordsArray.Count;
            
            resultlist = RecordsArray[0];
            result.Add(resultlist);
            for (counter = RecordsArray.Count - 10; counter < max; counter++)
            {
                resultlist = RecordsArray[counter];
                result.Add(resultlist);
            }
            return result;
        }
    }
}
