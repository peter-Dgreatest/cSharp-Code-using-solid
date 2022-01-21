using System;
namespace Assignment
{
    static public class ProgramHelper
    {

        public static int displayWelcomeMesage()
        {
            Console.WriteLine("Welcome to friends Manager App");
            Console.WriteLine("Please select an action to perform");
            Console.WriteLine("===========================");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Signup");
            Console.WriteLine("3. Exit");
            int action = 0;

            try
            {
                action = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                action = 0;
            }
            if (action == 0)
            {
                Console.WriteLine();
                action = ProgramHelper.displayWelcomeMesage();
            }

            return action;
        }

        internal static int requestUserAction()
        {
            Console.WriteLine("Please select an action to perform");
            Console.WriteLine("===========================");
            Console.WriteLine("1. View All Contact");
            Console.WriteLine("2. Add contact");
            Console.WriteLine("3. Find Youngest Friend");
            Console.WriteLine("4. Find Oldest Friend");
            Console.WriteLine("5. Calculate Average Age");
            Console.WriteLine("6. Search Friend");
            Console.WriteLine("7. Logout");
            int action = 0;

            try
            {
                action = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                action = 0;
            }
            if (action == 0)
            {
                Console.WriteLine();
                action = ProgramHelper.requestUserAction();
            }

            return action;
        }

        public static bool loginMessage()
        {
            return false;
        }
    }
}
