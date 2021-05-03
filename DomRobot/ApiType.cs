using System;

namespace DomRobot
{
    public class ApiType
    {
        public static readonly ApiType JsonRpc = new("/jsonrpc/");
        public ApiType(string path)
        {
            Path = path;
        }

        public string Path { get; }
        
    }
}