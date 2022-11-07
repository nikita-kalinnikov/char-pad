using System.Text;
using Newtonsoft.Json;
using SharpDX.DirectInput;

namespace CharPad
{
    internal class InputMap : Dictionary<Key, InputData[]>
    {
        private const string Path = "input_map.json";

        [JsonConstructor]
        protected InputMap() { }

        public static InputMap Read()
        {
            if (File.Exists(Path) is false) throw new FileNotFoundException($"Input map file was not found at path: {Path}");

            var settings = new JsonSerializerSettings();

            settings.Converters.Add(new InputDataConverter());

            var inputMapJson = File.ReadAllText(Path, Encoding.UTF8).Trim();
            var inputMap = JsonConvert.DeserializeObject<InputMap>(inputMapJson, settings);

            return inputMap ?? new InputMap();
        }

        public static void Write(InputMap inputMap)
        {
            File.WriteAllText(Path, inputMap.ToJson());
        }

        public string ToJson()
        {
            var settings = new JsonSerializerSettings();

            settings.Converters.Add(new InputDataConverter());
            settings.Formatting = Formatting.Indented;

            var inputMapJson = JsonConvert.SerializeObject(this, settings);

            return inputMapJson;
        }
    }
}
