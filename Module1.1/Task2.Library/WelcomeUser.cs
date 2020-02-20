using System;

namespace Task2.Library
{
    public class WelcomeUser
    {
        public static string Welcome(string name)
        {
            return $"{DateTime.Now:hh:mm:ss} Hello, {name}!";
        }
    }
}





