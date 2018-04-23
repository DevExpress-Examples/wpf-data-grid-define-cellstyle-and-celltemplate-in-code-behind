using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace fGrid11
{
    public class Person
    {
        public Person(int i) {
            LastName = "LastName #" + i;
            Age = i * 10;
        }
        public static ObservableCollection<Person> CreateList {
            get {
                ObservableCollection<Person> list = new ObservableCollection<Person>();
                for (int i = 0; i < 10; i++)
                    list.Add(new Person(i) { NameFontSize = 12 + (i % 6) });
                return list;
            }
        }
        public int Age { get; set; }
        public string LastName { get; set; }
        public double NameFontSize { get; set; }
    }
}
