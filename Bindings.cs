using SharpDX.DirectInput;

namespace CharPad
{
    internal class Bindings
    {
        private readonly List<ControlPoint> _list = new List<ControlPoint>();


        public ControlPoint DPad_Up_Pressed { get; }       = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 0);
        public ControlPoint DPad_Down_Pressed { get; }     = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 18000);
        public ControlPoint DPad_Left_Pressed { get; }     = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 27000);
        public ControlPoint DPad_Right_Pressed { get; }    = new ControlPoint(JoystickOffset.PointOfViewControllers0, x => x == 9000);


        public ControlPoint Left_Trigger_Pressed { get; }  = new ControlPoint(JoystickOffset.Z, x => x == 65408);

        public ControlPoint Left_Stick_Pressed { get; }    = new ControlPoint(JoystickOffset.Buttons8, x => x == 128);
        public ControlPoint Left_Stick_Released { get; }   = new ControlPoint(JoystickOffset.Buttons8, x => x == 0);

        public ControlPoint Left_Stick_Up { get; }         = new ControlPoint(JoystickOffset.Y, x => x == 0);
        public ControlPoint Left_Stick_Down { get; }       = new ControlPoint(JoystickOffset.Y, x => x == 65535);
        public ControlPoint Left_Stick_Left { get; }       = new ControlPoint(JoystickOffset.X, x => x == 0);
        public ControlPoint Left_Stick_Right { get; }      = new ControlPoint(JoystickOffset.X, x => x == 65535);

        public ControlPoint Left_Bumper_Pressed { get; }   = new ControlPoint(JoystickOffset.Buttons4, x => x == 128);
        public ControlPoint Left_Bumper_Released { get; }  = new ControlPoint(JoystickOffset.Buttons4, x => x == 0);


        public ControlPoint Right_Trigger_Pressed { get; } = new ControlPoint(JoystickOffset.Z, x => x == 128);

        public ControlPoint Right_Stick_Pressed { get; }   = new ControlPoint(JoystickOffset.Buttons9, x => x == 128);
        public ControlPoint Right_Stick_Released { get; }  = new ControlPoint(JoystickOffset.Buttons9, x => x == 0);

        public ControlPoint Right_Stick_Up { get; }        = new ControlPoint(JoystickOffset.RotationY, x => x == 0);
        public ControlPoint Right_Stick_Down { get; }      = new ControlPoint(JoystickOffset.RotationY, x => x == 65535);
        public ControlPoint Right_Stick_Left { get; }      = new ControlPoint(JoystickOffset.RotationX, x => x == 0);
        public ControlPoint Right_Stick_Right { get; }     = new ControlPoint(JoystickOffset.RotationX, x => x == 65535);

        public ControlPoint Right_Bumper_Pressed { get; }  = new ControlPoint(JoystickOffset.Buttons5, x => x == 128);
        public ControlPoint Right_Bumper_Released { get; } = new ControlPoint(JoystickOffset.Buttons5, x => x == 0);


        public ControlPoint Start_Pressed { get; }         = new ControlPoint(JoystickOffset.Buttons7, x => x == 128);
        public ControlPoint Start_Released { get; }        = new ControlPoint(JoystickOffset.Buttons7, x => x == 0);

        public ControlPoint Back_Pressed { get; }          = new ControlPoint(JoystickOffset.Buttons6, x => x == 128);
        public ControlPoint Back_Released { get; }         = new ControlPoint(JoystickOffset.Buttons6, x => x == 0);


        public ControlPoint X_Pressed { get; }             = new ControlPoint(JoystickOffset.Buttons2, x => x == 128);
        public ControlPoint X_Released { get; }            = new ControlPoint(JoystickOffset.Buttons2, x => x == 0);

        public ControlPoint Y_Pressed { get; }             = new ControlPoint(JoystickOffset.Buttons3, x => x == 128);
        public ControlPoint Y_Released { get; }            = new ControlPoint(JoystickOffset.Buttons3, x => x == 0);

        public ControlPoint B_Pressed { get; }             = new ControlPoint(JoystickOffset.Buttons1, x => x == 128);
        public ControlPoint B_Released { get; }            = new ControlPoint(JoystickOffset.Buttons1, x => x == 0);

        public ControlPoint A_Pressed { get; }             = new ControlPoint(JoystickOffset.Buttons0, x => x == 128);
        public ControlPoint A_Released { get; }            = new ControlPoint(JoystickOffset.Buttons0, x => x == 0);


        public Bindings()
        {
            void Add(params ControlPoint[] points) => _list.AddRange(points);

            Add(DPad_Up_Pressed, DPad_Down_Pressed, DPad_Left_Pressed, DPad_Right_Pressed);

            Add(Left_Trigger_Pressed, Left_Bumper_Pressed, Left_Bumper_Released);
            Add(Left_Stick_Up, Left_Stick_Down, Left_Stick_Left, Left_Stick_Right, Left_Stick_Pressed, Left_Stick_Released);

            Add(Right_Trigger_Pressed, Right_Bumper_Pressed, Right_Bumper_Released);
            Add(Right_Stick_Up, Right_Stick_Down, Right_Stick_Left, Right_Stick_Right, Right_Stick_Pressed, Right_Stick_Released);

            Add(Start_Pressed, Start_Released);
            Add(Back_Pressed, Back_Released);
            Add(X_Pressed, X_Released);
            Add(Y_Pressed, Y_Released);
            Add(B_Pressed, B_Released);
            Add(A_Pressed, A_Released);
        }

        private void Add(params ControlPoint[] points) => Array.ForEach(points, x => _list.Add(x));
        public void Update(JoystickUpdate update) => _list.ForEach(x => x.Update(update));
    }
}
