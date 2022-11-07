using Newtonsoft.Json;

namespace CharPad
{
    internal class InputDataConverter : JsonConverter<InputData>
    {
        public override InputData ReadJson(JsonReader reader, Type objectType, InputData existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var dataString = reader.Value.ToString().Split(' ');
            var gamepadKey = Enum.Parse<GamepadKey>(dataString[0]);
            var direction = dataString.Length == 2 ? Enum.Parse<Direction>(dataString[1]) : Direction.None;

            return new InputData(gamepadKey, direction);
        }

        public override void WriteJson(JsonWriter writer, InputData value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }
    }
}
