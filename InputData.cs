using Newtonsoft.Json;

namespace CharPad
{
    internal struct InputData
    {
        [JsonIgnore] public GamepadKey Key { get; }
        [JsonIgnore] public Direction Direction { get; }

        public InputData(GamepadKey key) : this(key, Direction.None) { }
        public InputData(GamepadKey key, Direction direction)
        {
            Key = key;
            Direction = direction;
        }

        public override string ToString() => Key.ToString() + (Direction == Direction.None ? string.Empty : $" {Direction}");
    }
}
