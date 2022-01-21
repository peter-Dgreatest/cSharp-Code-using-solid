using System;
using System.Collections.Generic;

namespace Assignment
{
    public class User
    {
        public User(string userName)
        {
            this.userName = userName;
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("===========================");
            Console.WriteLine("Welcome "+userName);
            this.retrieveContacts();
        }

        String userName;
        List<Contact> userContacts;

        
        public void retrieveContacts()
        {
            this.userContacts= IContactFileManipulator.retrieveContacts(this.userName);
        }

        void logout()
        {
            Console.WriteLine("Signing out!");
            return;
        }

        internal void displayContact()
        {
            Console.WriteLine("User contacts Found : "+this.userContacts.Count);
        }

        internal void performAction(int act)
        {
            Contact contact = null;
            switch (act)
            {
                case 1:
                    displayAllContacts();
                    break;
                case 2:
                    requestNewContact();
                    break;
                case 3:
                    contact = UserFriendIterator.leastAgedContact(userContacts);
                    Console.WriteLine("Youngest Friend is " +contact.Getname()+" "+contact.GetAge());
                    break;
                case 4:
                    contact = UserFriendIterator.oldestAgedContact(userContacts);
                    Console.WriteLine("Oldest Friend is " + contact.Getname() + " " + contact.GetAge());
                    break;
                case 5:
                    double avgAge = UserFriendIterator.averageAgeOfContact(userContacts);
                    Console.WriteLine("Average Age of contacts is "+avgAge);
                    break;
                case 6:
                    requestContactNameToFind();
                    break;
                case 7:
                    logout();
                    break;
                default:
                    break;
            }
        }

        private void requestContactNameToFind()
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Enter name to search for");
            String name = Console.ReadLine();

            Contact c = UserFriendIterator.findFriend(userContacts,name);
            if (c != null)
            {
                Console.WriteLine("Contact found : "+c.Getname()+" aged "+c.GetAge());
            }
            else
            {
                Console.WriteLine("No contact found with name : "+name);
            }
        }

        private void requestNewContact()
        {
            int indxno = userContacts.Count + 1;
            Contact newFriend = new Contact();
            Console.WriteLine("Enter name for friend number " + indxno);
            newFriend.SetName(Console.ReadLine());


            Console.WriteLine("Enter age for friend number " + indxno);
            String inp = (Console.ReadLine());
            int age = 0;
            if (int.TryParse(inp, out age))
                newFriend.SetAge(int.Parse(inp));
            else
            {
                Console.WriteLine("");
                Console.WriteLine("===========================");
                Console.WriteLine("Invalid age entered!");
                Console.WriteLine("Program exiting!");
                return;
            }

            userContacts =IContactFileManipulator.saveContact(userName, newFriend);
           
        }

        private void displayAllContacts()
        {
            Console.WriteLine("User contacts Found : " + this.userContacts.Count + " - ");
            Console.WriteLine("");
            Console.WriteLine("===========================");

            // the next line was inspired by the use of the List.foreach function from microsoft website
            // https://docs.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.foreach?view=net-6.0
            this.userContacts.ForEach(Print);
        }

        //
        private void Print(Contact con)
        {
            Console.WriteLine(con.Getname() + " aged : " + con.GetAge());
        }


       
    }
}
