using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace EngineArt.Mathematic
{
    public static class JSON
    {
        public static string ReadText(string addictionalPath, string file)
        {
            string path = Path.Combine(addictionalPath, file);
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return $"Can't find: {path}";
        }
        public static string ReadText(string file)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return $"Can't find: {path}";
        }
        public static void ReplaceData(string file, string path, object data)
        {
            string text = ReadText(file);
            JsonNode json = JsonObject.Parse(text)!;
            JsonNode current = json;
            string[] keys = path.Split('/');

            for (int i = 0; i < keys.Length - 1; i++)
            {
                current = current[keys[i]]!;
                if (current == null)
                {
                    throw new Exception($"Path not found: {string.Join("/", keys, 0, i + 1)}");
                }
            }
            string lastKey = keys[^1];
            if (data is String)
                current[lastKey] = data.ToString();
            if (data is Boolean)
                current[lastKey] = (Boolean)data;
            if (data is float)
                current[lastKey] = (float)data;
            if (data is int)
                current[lastKey] = (int)data;

            File.WriteAllText(file, json.ToString());
        }
        public static object GetData(string file, string path)
        {
            string text = ReadText(file);
            JsonNode current = JsonObject.Parse(text)!;
            string[] keys = path.Split("/");
            for (int i = 0; i < keys.Length - 1; i++)
            {
                current = current[keys[i]]!;
                if (current == null)
                {
                    throw new Exception($"Path not found: {string.Join("/", keys, 0, i + 1)}");
                }
            }
            return current[keys[^1]]!;
        }
        //How to use it:
        // string file: name of the file example: level.json
        // T: is the class that need to be created as
        // returns said class as T
        // class (example: LoadData.cs) need to have the same parameters name as level.json

        // example: string Name {get; set;} <=> "Name": "Some Cool Name"
        public static T Unpack<T>(string file)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, file);
            if (File.Exists(path))
            {
                string data = File.ReadAllText(path);
                return JsonSerializer.Deserialize<T>(data)!;
            }
            Debug.WriteLine($"Can't find: {path}");
            return default!;
        }


    }
}
