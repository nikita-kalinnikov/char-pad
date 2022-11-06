﻿using SharpDX.DirectInput;

namespace CharPad
{
    internal class Bindings
    {
        private readonly List<ControlPoint> _list = new List<ControlPoint>();


        public ControlPoint DPad_Up { get; }       = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 0);
        public ControlPoint DPad_Down { get; }     = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 18000);
        public ControlPoint DPad_Left { get; }     = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 27000);
        public ControlPoint DPad_Right { get; }    = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 9000);

        public ControlPoint LeftTrigger { get; }  = new ControlPoint(JoystickOffset.Z, x => x == 65408);
        public ControlPoint LeftBumper { get; } = new ControlPoint(JoystickOffset.Buttons4, x => x == 128);
        public ControlPoint LeftStick { get; }    = new ControlPoint(JoystickOffset.Buttons8, x => x == 128);
        public ControlPoint LeftStick_Up { get; }         = new ControlPoint(JoystickOffset.Y, x => x == 0);
        public ControlPoint LeftStick_Down { get; }       = new ControlPoint(JoystickOffset.Y, x => x == 65535);
        public ControlPoint LeftStick_Left { get; }       = new ControlPoint(JoystickOffset.X, x => x == 0);
        public ControlPoint LeftStick_Right { get; }      = new ControlPoint(JoystickOffset.X, x => x == 65535);


        public ControlPoint RightTrigger { get; } = new ControlPoint(JoystickOffset.Z, x => x == 128);
        public ControlPoint RightBumper { get; } = new ControlPoint(JoystickOffset.Buttons5, x => x == 128);
        public ControlPoint RightStick { get; }   = new ControlPoint(JoystickOffset.Buttons9, x => x == 128);
        public ControlPoint RightStick_Up { get; }        = new ControlPoint(JoystickOffset.RotationY, x => x == 0);
        public ControlPoint RightStick_Down { get; }      = new ControlPoint(JoystickOffset.RotationY, x => x == 65535);
        public ControlPoint RightStick_Left { get; }      = new ControlPoint(JoystickOffset.RotationX, x => x == 0);
        public ControlPoint RightStick_Right { get; }     = new ControlPoint(JoystickOffset.RotationX, x => x == 65535);

        public ControlPoint Start { get; }         = new ControlPoint(JoystickOffset.Buttons7, x => x == 128);
        public ControlPoint Back { get; }          = new ControlPoint(JoystickOffset.Buttons6, x => x == 128);

        public ControlPoint X { get; }             = new ControlPoint(JoystickOffset.Buttons2, x => x == 128);
        public ControlPoint Y { get; }             = new ControlPoint(JoystickOffset.Buttons3, x => x == 128);
        public ControlPoint B { get; }             = new ControlPoint(JoystickOffset.Buttons1, x => x == 128);
        public ControlPoint A { get; }             = new ControlPoint(JoystickOffset.Buttons0, x => x == 128);


        public Bindings()
        {
            void Add(params ControlPoint[] points) => _list.AddRange(points);

            Add(DPad_Up, DPad_Down, DPad_Left, DPad_Right);

            Add(LeftTrigger, LeftBumper);
            Add(LeftStick_Up, LeftStick_Down, LeftStick_Left, LeftStick_Right, LeftStick);

            Add(RightTrigger, RightBumper);
            Add(RightStick_Up, RightStick_Down, RightStick_Left, RightStick_Right, RightStick);

            Add(Start, Back);
            Add(A, B, Y, X);
        }

        private void Add(params ControlPoint[] points) => Array.ForEach(points, x => _list.Add(x));
        public void Update(JoystickUpdate update) => _list.ForEach(x => x.Update(update));
    }
}
