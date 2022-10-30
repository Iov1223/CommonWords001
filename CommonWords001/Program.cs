using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonWords001
{
    public class Contents
    {
        private string _path001; 
        private string _path002;
        private string[] ContentsOfText001;
        private string[] ContentsOfText002;
        public Contents()
        {
            _path001 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Text001.txt";
            _path002 = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Text002.txt";
            ContentsOfText001 = File.ReadAllText(_path001).Split(' ');
            ContentsOfText002 = File.ReadAllText(_path002).Split(' ');
        }
        public IEnumerable<string> SearchDuplicate() 
        {
            var selectedDuplicate = from c1 in ContentsOfText001
                                 from c2 in ContentsOfText002
                                 where c1 == c2
                                 select c1;
            return selectedDuplicate;
        }
        public void ShowDuplicate()
        {
            Console.WriteLine("\tОбщие слова для двух файдов:\n");
            foreach (var item in SearchDuplicate())
            {
                Console.WriteLine(item);
            }
        }
    }
    public class Record
    {
        private string _path;
        public Record()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Result.txt";
        }
        public void WriteToFile(IEnumerable<string> selectedDuplicate)
        {
            try
            {
                File.WriteAllLines(_path, selectedDuplicate);
                Console.WriteLine("\nЗапись файла \"Result.txt\" прошла успешно.");
            }
            catch 
            {
                Console.WriteLine("Что-то пошло не так!");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Contents contents = new Contents();
            Record record = new Record();
            contents.ShowDuplicate();
            record.WriteToFile(contents.SearchDuplicate());
        }
    }
}
