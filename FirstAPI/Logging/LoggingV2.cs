namespace FirstAPI.Logging
{
    public class LoggingV2 : ILogging
    {
        public void Log(string message, string type)
        {
            if(type=="error")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ForegroundColor = ConsoleColor.White;

            }
            else
            {
                if (type == "warning")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(message);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
    }
}
