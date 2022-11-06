using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CharPad
{
    internal struct InputMap
    {
        private const string Path = "input_map.json";


        [JsonConstructor]
        public InputMap() { }


        public static InputMap Read()
        {
            if (File.Exists(Path) is false) throw new FileNotFoundException($"Input map file was not found at path: {Path}");

            var inputMapJson = File.ReadAllText(Path, Encoding.UTF8).Trim();
            var inputMap = JsonSerializer.Deserialize<InputMap>(inputMapJson);

            return inputMap;
        }
    }
}
