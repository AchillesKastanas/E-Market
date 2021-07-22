using System;

namespace emarket.Helpers
{
    public class ErrorCatcher
    {
        public static void ErrorCatch(Exception e)
        {
            Console.WriteLine(e);
        }
    }
}