using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment
{
    static public class UserFriendIterator
    {
        // use of lambda was inspired from
        // https://stackoverflow.com/questions/3309188/how-to-sort-a-listt-by-a-property-in-the-object
        // for sorting the list
        public static List<Contact> sortContactsByAge(List<Contact> contacts)
        {
            return contacts.OrderBy(x => x.GetAge()).ToList();
        }

        public static Contact leastAgedContact(List<Contact> contacts)
        {
            return contacts[0];
        }


        public static Contact oldestAgedContact(List<Contact> contacts)
        {
            return contacts[contacts.Count-1];
        }



        // use of lamda in the next two functions
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/operators/lambda-expressions
        // to search by name and get average age

        public static double averageAgeOfContact(List<Contact> contacts)
        {
            double avg = 0.0;
            int sum = 0;
            int count = 0;
            contacts.ForEach(x => {
                sum += x.GetAge();
                count++;
                });
            avg = sum / (count * 1.0);
            return avg;
        }


        public static Contact findFriend(List<Contact> contacts,String name)
        {
            Contact _2find = null;
            contacts.ForEach(x => {
                if (_2find != null)
                    return;
                _2find = (x.Getname().Equals(name)) ? x : null;
                
                }
            );

            return _2find;
        }


    }
}
