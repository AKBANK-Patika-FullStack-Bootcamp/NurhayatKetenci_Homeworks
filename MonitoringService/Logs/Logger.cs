namespace akbank_bootcamp.Logs
{
    public class Logger
    {
        string _Path = @"C:\Users\deneme\Source\Repos\akbank_homeworkone\MonitoringService\Log\";
        string _FileName = DateTime.Now.ToString("yyyMMdd") + ".txt";
        public void createLog(string message)
        {
           
            FileStream fs = new FileStream(_Path + _FileName, FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString() + ":" + message);
            sw.Flush();
            sw.Close();
            fs.Close();
        }
    }
}
