using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment
{
    public class AuthFileManager
    {
        // use of serialization and deserialization is inspired from
        // https://www.c-sharpcorner.com/article/serialization-and-deserialization-in-c-sharp/
        static BinaryFormatter binaryFormatter = new BinaryFormatter();
        static string dir = System.IO.Path.GetFullPath("userInfo.txt");

        FileStream fileStream;// = new FileStream(@"" + dir, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        List<Auth> auth = new List<Auth>();

        public AuthFileManager()
        {

            try
            {
                fileStream = new FileStream(@"" + dir, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
                using (fileStream)
                {
                    auth = (List<Auth>)binaryFormatter.Deserialize(fileStream);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured! - " + e.Data.ToString());
            }
        }


        public Boolean signin(String userName, String password)
        {
            foreach(Auth a in auth)
            {
                if (a.Username.Equals(userName) && a.Password.Equals(password))
                    return true;
            }
            
            return false;
        }


        public String signup(String userName, String password)
        {
            fileStream = new FileStream(@"" + dir, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            if (auth.Contains(new Auth(userName, password)))
                return "User already registered";
            else
                auth.Add((new Auth(userName, password)));
            try
            {
                using (fileStream)
                {
                    binaryFormatter.Serialize(fileStream, auth);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error Occured! - " + e.StackTrace);

                return e.Data.ToString();
            }
            return "Successful";
        }
    }
}
