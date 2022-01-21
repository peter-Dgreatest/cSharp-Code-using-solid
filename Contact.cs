using System;
namespace Assignment
{
    public class Contact
    {
        public Contact(String name,int age)
        {
            this.age = age;
            this.name = name;
        }

        public Contact()
        {
        }

        private String name;
        private int age;

        public String Getname()
        {
            return this.name;
        }

        public void SetName(String value)
        {
            name = value;
        }

        public int GetAge()
        {
            return age;
        }

        public void SetAge(int value)
        {
            age = value;
        }
    }
}
