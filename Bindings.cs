using System.Collections;
using SharpDX.DirectInput;

namespace CharPad
{
    internal class Bindings : List<ControlPoint>
    {
        public ControlPoint DPad_Up { get; } = new ControlPoint(GamepadKey.DPad, Direction.Up);
        public ControlPoint DPad_Down { get; } = new ControlPoint(GamepadKey.DPad, Direction.Down);
        public ControlPoint DPad_Left { get; } = new ControlPoint(GamepadKey.DPad, Direction.Left);
        public ControlPoint DPad_Right { get; } = new ControlPoint(GamepadKey.DPad, Direction.Right);

        public ControlPoint LeftTrigger { get; } = new ControlPoint(GamepadKey.LeftTrigger);
        public ControlPoint LeftBumper { get; } = new ControlPoint(GamepadKey.LeftBumper);
        public ControlPoint LeftStick { get; } = new ControlPoint(GamepadKey.LeftStick);
        public ControlPoint LeftStick_Up { get; } = new ControlPoint(GamepadKey.LeftStick, Direction.Up);
        public ControlPoint LeftStick_Down { get; } = new ControlPoint(GamepadKey.LeftStick, Direction.Down);
        public ControlPoint LeftStick_Left { get; } = new ControlPoint(GamepadKey.LeftStick, Direction.Left);
        public ControlPoint LeftStick_Right { get; } = new ControlPoint(GamepadKey.LeftStick, Direction.Right);


        public ControlPoint RightTrigger { get; } = new ControlPoint(GamepadKey.RightTrigger);
        public ControlPoint RightBumper { get; } = new ControlPoint(GamepadKey.RightBumper);
        public ControlPoint RightStick { get; } = new ControlPoint(GamepadKey.RightStick);
        public ControlPoint RightStick_Up { get; } = new ControlPoint(GamepadKey.RightStick, Direction.Up);
        public ControlPoint RightStick_Down { get; } = new ControlPoint(GamepadKey.RightStick, Direction.Down);
        public ControlPoint RightStick_Left { get; } = new ControlPoint(GamepadKey.RightStick, Direction.Left);
        public ControlPoint RightStick_Right { get; } = new ControlPoint(GamepadKey.RightStick, Direction.Right);

        public ControlPoint Start { get; } = new ControlPoint(GamepadKey.Start);
        public ControlPoint Back { get; } = new ControlPoint(GamepadKey.Back);

        public ControlPoint X { get; } = new ControlPoint(GamepadKey.X);
        public ControlPoint Y { get; } = new ControlPoint(GamepadKey.Y);
        public ControlPoint B { get; } = new ControlPoint(GamepadKey.B);
        public ControlPoint A { get; } = new ControlPoint(GamepadKey.A);


        public Bindings(bool log)
        {
            void Add(params ControlPoint[] points) => base.AddRange(points);

            Add(DPad_Up, DPad_Down, DPad_Left, DPad_Right);

            Add(LeftTrigger, LeftBumper);
            Add(LeftStick_Up, LeftStick_Down, LeftStick_Left, LeftStick_Right, LeftStick);

            Add(RightTrigger, RightBumper);
            Add(RightStick_Up, RightStick_Down, RightStick_Left, RightStick_Right, RightStick);

            Add(Start, Back);
            Add(A, B, Y, X);

            if (log is false) return;

            Start.Subscribe(() => Console.WriteLine($"Start button pressed"));
            Back.Subscribe(() => Console.WriteLine($"Back button pressed"));

            LeftTrigger.Subscribe(() => Console.WriteLine($"Left Trigger pressed"));
            LeftStick.Subscribe(() => Console.WriteLine($"Left Stick pressed"));
            LeftStick_Up.Subscribe(() => Console.WriteLine($"Left Stick up"));
            LeftStick_Down.Subscribe(() => Console.WriteLine($"Left Stick down"));
            LeftStick_Left.Subscribe(() => Console.WriteLine($"Left Stick left"));
            LeftStick_Right.Subscribe(() => Console.WriteLine($"Left Stick right"));
            LeftBumper.Subscribe(() => Console.WriteLine($"Left Bumper pressed"));

            RightTrigger.Subscribe(() => Console.WriteLine($"Right Trigger pressed"));
            RightStick.Subscribe(() => Console.WriteLine($"Right Stick pressed"));
            RightStick_Up.Subscribe(() => Console.WriteLine($"Right Stick up"));
            RightStick_Down.Subscribe(() => Console.WriteLine($"Right Stick down"));
            RightStick_Left.Subscribe(() => Console.WriteLine($"Right Stick left"));
            RightStick_Right.Subscribe(() => Console.WriteLine($"Right Stick right"));
            RightBumper.Subscribe(() => Console.WriteLine($"Right Bumper pressed"));

            X.Subscribe(() => Console.WriteLine($"X button pressed"));
            Y.Subscribe(() => Console.WriteLine($"Y button pressed"));
            B.Subscribe(() => Console.WriteLine($"B button pressed"));
            A.Subscribe(() => Console.WriteLine($"A button pressed"));

            DPad_Up.Subscribe(() => Console.WriteLine($"DPad Up pressed"));
            DPad_Down.Subscribe(() => Console.WriteLine($"DPad Down pressed"));
            DPad_Left.Subscribe(() => Console.WriteLine($"DPad Left pressed"));
            DPad_Right.Subscribe(() => Console.WriteLine($"DPad Right pressed"));
        }

        public void Update(JoystickUpdate update) => base.ForEach(x => x.Update(update));
}
}
