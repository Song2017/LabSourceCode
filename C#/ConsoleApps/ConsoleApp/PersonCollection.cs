using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp
{
    public class PersonCollection : IEnumerable
    {
        private ArrayList arPeople = new ArrayList();
        public Person this[int index]
        {
            get { return (Person)arPeople[index]; }
            set { arPeople.Insert(index, value); }
        }

        private Dictionary<string, Person> dictionaryPerson = new Dictionary<string, Person>();

        public Person this[string name]
        {
            get { return dictionaryPerson[name]; }
            set { dictionaryPerson.Add(name, value); }
        }

        public IEnumerator GetEnumerator()
        {
            return arPeople.GetEnumerator();
        }

        public void AddPerson(Person person)
        {
            arPeople.Add(person);
        }

        public Person GetPerson(int pos)
        {
            return arPeople[pos] as Person;
        }

        public int PersonCount()
        {
            return arPeople.Count;
        }
    }

    public interface IStringContainer
    {
        string this[int index] { get; set; }
    }
}