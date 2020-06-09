using System;

namespace DependencyInjectionWithUserName
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger;
            String loggerType = "database"; 
            switch(loggerType)
            {
                case "database":
                    logger = new DatabaseLogger(); 
                    break;

                default:
                    logger = new TextLogger();
                    break;
            }




            
            LogManager logManager = new LogManager(logger);
            

            try
            {
                throw new DivideByZeroException(); 
            }
            catch(Exception e)
            {
                logger.Log(e.Message);
                Console.ReadLine(); 
            }
        }
    }

    //interface for the log class, single method, Log. acts as a binding contract for both classes: TextLogger and DatabaseLogger
    interface ILogger
    {
        void Log(String message); 
    }

    //
    class LogManager
    {
        //variable of ILogger
        private ILogger _logger; 
        //constructor supplies an argument of ILogger type. 
        public LogManager(ILogger logger)
        {
            _logger = logger; 
        }

        //logger.log is being called with message
        public void Log(String message )
        {
            _logger.Log(message); 
        }
    }
    class TextLogger: ILogger
    {
        public void Log(String message )
        {
            Console.WriteLine("Log to a text file:" + message); 
        }
    }
    class DatabaseLogger: ILogger
    {
        public void Log(String message)
        {
            Console.WriteLine("Log to a Database:" + message);
        }
    }
}
