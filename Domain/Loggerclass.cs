public static class Loggerclass
{
    private static readonly string LogFilePath = "Logger.txt";

    public static void logtimein(string message)
        { try{
            //write to file
            using(StreamWriter writer = new StreamWriter(LogFilePath, true))
            {
                writer.Write("\n UserName :{0}",message);
                writer.Write("Time Out : {0}",DateTime.Now.ToLongDateString());
            }
        }
        catch(Exception e){

        }
        }
}