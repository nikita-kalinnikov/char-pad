using CharPad;
using SharpDX.DirectInput;


var input = new DirectInput();
var gamepadDevices = input.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices);

if (gamepadDevices.Count == 0) throw new Exception($"No gamepad devices was found");

var gamepadDevice = gamepadDevices.First();
var gamepadGuid = gamepadDevice.InstanceGuid;

Console.WriteLine($"Found Joystick/Gamepad with GUID: {gamepadGuid}");

var gamepad = new Joystick(input, gamepadGuid);

gamepad.Properties.BufferSize = 128;
gamepad.Acquire();

var updates = Array.Empty<JoystickUpdate>();
var bindings = new Bindings();


bindings.Start_Pressed.Subscribe(() => Console.WriteLine($"Start button pressed"));
bindings.Start_Released.Subscribe(() => Console.WriteLine($"Start button released"));

bindings.Back_Pressed.Subscribe(() => Console.WriteLine($"Back button pressed"));
bindings.Back_Released.Subscribe(() => Console.WriteLine($"Back button released"));


bindings.Left_Trigger_Pressed.Subscribe(() => Console.WriteLine($"Left Trigger pressed"));
bindings.Left_Stick_Pressed.Subscribe(() => Console.WriteLine($"Left Stick pressed"));
bindings.Left_Stick_Released.Subscribe(() => Console.WriteLine($"Left Stick released"));
bindings.Left_Stick_Up.Subscribe(() => Console.WriteLine($"Left Stick up"));
bindings.Left_Stick_Down.Subscribe(() => Console.WriteLine($"Left Stick down"));
bindings.Left_Stick_Left.Subscribe(() => Console.WriteLine($"Left Stick left"));
bindings.Left_Stick_Right.Subscribe(() => Console.WriteLine($"Left Stick right"));
bindings.Left_Bumper_Pressed.Subscribe(() => Console.WriteLine($"Left Bumper pressed"));
bindings.Left_Bumper_Released.Subscribe(() => Console.WriteLine($"Left Bumper released"));


bindings.Right_Trigger_Pressed.Subscribe(() => Console.WriteLine($"Right Trigger pressed"));
bindings.Right_Stick_Pressed.Subscribe(() => Console.WriteLine($"Right Stick pressed"));
bindings.Right_Stick_Released.Subscribe(() => Console.WriteLine($"Right Stick released"));
bindings.Right_Stick_Up.Subscribe(() => Console.WriteLine($"Right Stick up"));
bindings.Right_Stick_Down.Subscribe(() => Console.WriteLine($"Right Stick down"));
bindings.Right_Stick_Left.Subscribe(() => Console.WriteLine($"Right Stick left"));
bindings.Right_Stick_Right.Subscribe(() => Console.WriteLine($"Right Stick right"));
bindings.Right_Bumper_Pressed.Subscribe(() => Console.WriteLine($"Right Bumper pressed"));
bindings.Right_Bumper_Released.Subscribe(() => Console.WriteLine($"Right Bumper released"));


bindings.X_Pressed.Subscribe(() => Console.WriteLine($"X button pressed"));
bindings.X_Released.Subscribe(() => Console.WriteLine($"X button released"));

bindings.Y_Pressed.Subscribe(() => Console.WriteLine($"Y button pressed"));
bindings.Y_Released.Subscribe(() => Console.WriteLine($"Y button released"));

bindings.B_Pressed.Subscribe(() => Console.WriteLine($"B button pressed"));
bindings.B_Released.Subscribe(() => Console.WriteLine($"B button released"));

bindings.A_Pressed.Subscribe(() => Console.WriteLine($"A button pressed"));
bindings.A_Released.Subscribe(() => Console.WriteLine($"A button released"));


bindings.DPad_Up_Pressed.Subscribe(() => Console.WriteLine($"DPad Up pressed"));
bindings.DPad_Down_Pressed.Subscribe(() => Console.WriteLine($"DPad Down pressed"));
bindings.DPad_Left_Pressed.Subscribe(() => Console.WriteLine($"DPad Left pressed"));
bindings.DPad_Right_Pressed.Subscribe(() => Console.WriteLine($"DPad Right pressed"));


while (true)
{
    gamepad.Poll();
    updates = gamepad.GetBufferedData();

    Array.ForEach(updates, bindings.Update);
}