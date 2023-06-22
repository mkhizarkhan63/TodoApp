using System.Reflection.Metadata.Ecma335;

namespace TodoAPI.Static
{
    public class Response
    {
        public object data { get; set; }
        public int status { get; set; }
        public string msg { get; set; }

        public bool flag { get; set; }
    }
}
