using TMP.Logs;

ILogger logger = new ConsoleLogger();

logger.Info("This is some info");
logger.Fatal("This message means the entire system has crashed.");