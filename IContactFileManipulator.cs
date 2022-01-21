using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment
{
    public class IContactFileManipulator
      
    {
        public static List<Contact> saveContact(string userName,Contact contact)
        {

            String filename = userName + "_contacts.txt";


            // used code sample from https://www.guru99.com/c-sharp-stream.html
            // to perform this using operation to write string to file
            using (StreamWriter sw = File.AppendText(filename))
            {
                sw.WriteLine(contact.Getname()+" "+contact.GetAge());
            }
            return retrieveContacts(userName);
        }

        public static List<Contact> retrieveContacts(string userName)
        {
            List<Contact> contacts = new List<Contact>();
            String filename  = userName+"_contacts.txt";
            string[] lines = File.ReadAllLines(@"" + filename);

            foreach(string line in lines)
            {
                string[] info = line.Split(" ");
                contacts.Add(new Contact(info[0], int.Parse(info[1])));
            }

          
            return UserFriendIterator.sortContactsByAge(contacts);
        }
    }
}
