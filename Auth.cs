using System;
using System.Threading;

namespace Assignment
{
    [Serializable]
    public class Auth
    {
        public Auth()
        {
        }

        String username;

        public Auth(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public Auth(AuthFileManager authFileManager)
        {
            this.authFileManager = authFileManager;
        }

        [NonSerialized]
        int loginStatus = -1;
        int signupStaus = -1;

        internal String requestLogin()
        {
            Console.WriteLine("Enter Username to continue");
            this.username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            this.password = Console.ReadLine();
            Console.Write("Please wait");
            // usage of the Thread is copied from
            // https://stackoverflow.com/questions/363377/how-do-i-run-a-simple-bit-of-code-in-a-new-thread
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                login(username, password);
            }).Start();
            while (loginStatus == -1)
            {
                Console.Write("..");
            }
            if (loginStatus == 0)
            {
                Console.WriteLine("Login Incorrect or user not found!");
                Console.WriteLine("Do you want to signup?");
                Console.WriteLine("1. Yes");
                Console.WriteLine("2. Retry Login");
                Console.WriteLine("3. Exit");

                try
                {
                    int act = int.Parse(Console.ReadLine());
                    if (act == 1)
                        return this.requestSignUp();
                    else if (act == 2)
                        return this.requestLogin();
                    else
                        Environment.Exit(0);
                }
                catch (Exception e)
                {
                    return this.requestLogin();
                }
            }
            else
                return this.username;
            return "";
        }

        public String requestSignUp()
        {
            Console.WriteLine("Enter Username to continue");
            this.username = Console.ReadLine();
            Console.WriteLine("Enter Password");
            this.password = Console.ReadLine();
            Console.Write("Please wait");
            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                this.signup(username, password);
            }).Start();
            while (signupStaus == -1)
            {
                Console.Write("..");
            }
            if(signupStaus==1)
                return this.username;
            return "";
        }

        String password;

        [NonSerialized]
        public AuthFileManager authFileManager;

        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public void login(string username, string password)
        {
            loginStatus = authFileManager.signin(this.username, this.password) ? 1 : 0;
        }

        public void signup(string userName, string password)
        {
            String response = authFileManager.signup(this.username, this.password);
            if(response.Equals("Successful") || response.Equals("User already registered"))
            {
                signupStaus = 1;
            }
            else
            {
                Console.WriteLine(response);
                signupStaus = 0;
            }
        }

       
    }
}
