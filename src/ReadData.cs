using System;
using System.IO;
using System.Reflection;
namespace EngineArt
{
    internal class ReadData
    {
        //public static TypeOf LoadContent<TypeOf>(string file)
        //{
        //    return ;
        //}
        public static StreamReader Read_Embedded_CSV(string file)
        {
            file = "." + file.Replace("/", ".");
            var assembley = Assembly.GetEntryAssembly();
            string fullpath = assembley!.GetName().Name + file;
            var stream = assembley!.GetManifestResourceStream(fullpath);
            if (stream == null)
            {
                throw new Exception("ERROR. This file doesn't exist or you forgot to change file to Embedded resource");
            }
            StreamReader reader = new StreamReader(stream);
            return reader;
        }
    }
}
