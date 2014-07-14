namespace PersonFactory
{
    internal class PersonFactory
    {
        public Person CreatePerson(string name, ushort? age, Sex sex)
        {
            Person person = new Person(name, age, sex);
            return person;
        }
    }
}
