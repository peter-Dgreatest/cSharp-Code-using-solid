using System;

namespace Assignment
{
    class Program
    {

        static string username = "";
        static Auth auth = new Auth(new AuthFileManager());

        static void requestuserAction(User user)
        {
            int action = ProgramHelper.requestUserAction();
            user.performAction(action);
            if (action == 7)
            {
                username = "";
                requestLoginAction();
            }
            Console.WriteLine("Press any key to contine!");
            Console.ReadKey();
            requestuserAction(user);
        }

        static void requestLoginAction()
        {
            int action = ProgramHelper.displayWelcomeMesage();
            switch (action)
            {
                case 1:
                    username = auth.requestLogin();
                    break;
                case 2:
                    username = auth.requestSignUp();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }


        static void Main(string[] args)
        {
            requestLoginAction();
            

            if (username.Length > 0)
            {
                User user = new User(username);
                user.displayContact();
                requestuserAction(user);
            }
            else
            {
                Console.WriteLine("===========================");
                Console.WriteLine("Cant login or signin");
            }

           
            //Contact leastAgedFriend = friends[0];
            //Contact oldestFriend = friends[0];

            //double avgAge = 0.0;
            //int totalAge = 0;

            //for (int i = 0; i < friends.Length; i++)
            //{
            //    Contact thisFriend = friends[i];

            //    if (thisFriend.GetAge() > oldestFriend.GetAge())
            //    {
            //        oldestFriend = thisFriend;
            //    }else if (thisFriend.GetAge() < oldestFriend.GetAge())
            //    {
            //        leastAgedFriend = thisFriend;
            //    }

            //    totalAge += thisFriend.GetAge(); 

            //}

            //avgAge = totalAge / (friends.Length * 1.0);


            //Console.WriteLine("You have "+friends.Length+" friends");
            //Console.WriteLine("Your oldest friend is " + oldestFriend.Getname() +
            //    " - aged(" + oldestFriend.GetAge() + ")");


            //Console.WriteLine("Your youngest friend is " + leastAgedFriend.Getname() +
            //    " - aged(" + leastAgedFriend.GetAge() + ")");


            //Console.WriteLine("The average age of your friends is " + avgAge);

        }
    }
}
