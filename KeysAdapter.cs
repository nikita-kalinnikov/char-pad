using SharpDX.DirectInput;

namespace CharPad
{
    internal static class KeysAdapter
    {
        public static KeyValuePair<JoystickOffset, int> Get(InputData data) => Get(data.Key, data.Direction);
        public static KeyValuePair<JoystickOffset, int> Get(GamepadKey key, Direction direction)
        {
            if (key == GamepadKey.DPad)
            {
                if (direction == Direction.Up) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.PointOfViewControllers0, 0);
                if (direction == Direction.Down) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.PointOfViewControllers0, 18000);
                if (direction == Direction.Left) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.PointOfViewControllers0, 27000);
                if (direction == Direction.Right) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.PointOfViewControllers0, 9000);
            }

            if (key == GamepadKey.X) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons2, 128);
            if (key == GamepadKey.Y) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons3, 128);
            if (key == GamepadKey.B) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons1, 128);
            if (key == GamepadKey.A) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons0, 128);

            if (key == GamepadKey.Start) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons7, 128);
            if (key == GamepadKey.Back) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons6, 128);

            if (key == GamepadKey.LeftTrigger) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Z, 65408);
            if (key == GamepadKey.LeftBumper) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons4, 128);
            if (key == GamepadKey.LeftStick)
            {
                if (direction == Direction.None) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons8, 128);
                if (direction == Direction.Up) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Y, 0);
                if (direction == Direction.Down) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Y, 65535);
                if (direction == Direction.Left) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.X, 0);
                if (direction == Direction.Right) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.X, 65535);
            }

            if (key == GamepadKey.RightTrigger) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Z, 128);
            if (key == GamepadKey.RightBumper) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons5, 128);
            if (key == GamepadKey.RightStick)
            {
                if (direction == Direction.None) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.Buttons9, 128);
                if (direction == Direction.Up) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.RotationY, 0);
                if (direction == Direction.Down) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.RotationY, 65535);
                if (direction == Direction.Left) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.RotationX, 0);
                if (direction == Direction.Right) return new KeyValuePair<JoystickOffset, int>(JoystickOffset.RotationX, 65535);
            }

            throw new Exception($"Unknown key-direction: {key} {direction}");
        }
    }
}
