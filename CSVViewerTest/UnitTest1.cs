using NUnit.Framework;
using CSVViewer;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    
    public class Tests
    {


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetFileNameTest()
        {
            string name = "besucher";
            var interactor = new Interactors();
            var path = interactor.GetFileName(name);
            Assert.AreEqual(@"C:\Users\Cheshire\source\repos\CSVViewer\CSVViewer\besucher.csv", path);
        }

        [Test]
        public void FilterPageTest()
        {
            var interactor = new Interactors();
            List<List<string>> RecordsArray = new List<List<string>>();
            List<string> RecordsArraySingle = new List<string>();
            string RecordsArrayString = "A;B;C";
            RecordsArraySingle = RecordsArrayString.Split(';').ToList();
            RecordsArray.Add(RecordsArraySingle);
            RecordsArrayString = "A;C;D";
            RecordsArraySingle = RecordsArrayString.Split(';').ToList();
            RecordsArray.Add(RecordsArraySingle);
            RecordsArrayString = "D;C;E";
            RecordsArraySingle = RecordsArrayString.Split(';').ToList();
            RecordsArray.Add(RecordsArraySingle);

            interactor.RecordsArray = RecordsArray;
            
            var result = interactor.FilterFirstPage();
            Assert.AreEqual(3, result.Count);

        }
    }
}