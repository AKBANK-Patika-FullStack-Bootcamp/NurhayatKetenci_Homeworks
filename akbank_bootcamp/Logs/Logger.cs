namespace akbank_bootcamp.Logs
{
    public class Logger
    {
      
        public void createLog(string message,string location)
        {
            string _Path = @"C:\Users\deneme\Source\Repos\akbank_bootcamp\akbank_bootcamp\Logs\"+location+"" ;
            string _FileName = DateTime.Now.ToString("yyyMMdd") + ".txt";
            FileStream fs = new FileStream(_Path + _FileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + ":" + message);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
