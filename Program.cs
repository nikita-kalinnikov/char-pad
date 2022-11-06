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


bindings.Start.Subscribe(() => Console.WriteLine($"Start button pressed"));
bindings.Back.Subscribe(() => Console.WriteLine($"Back button pressed"));

bindings.Left_Trigger.Subscribe(() => Console.WriteLine($"Left Trigger pressed"));
bindings.Left_Stick.Subscribe(() => Console.WriteLine($"Left Stick pressed"));
bindings.Left_Stick_Up.Subscribe(() => Console.WriteLine($"Left Stick up"));
bindings.Left_Stick_Down.Subscribe(() => Console.WriteLine($"Left Stick down"));
bindings.Left_Stick_Left.Subscribe(() => Console.WriteLine($"Left Stick left"));
bindings.Left_Stick_Right.Subscribe(() => Console.WriteLine($"Left Stick right"));
bindings.Left_Bumper.Subscribe(() => Console.WriteLine($"Left Bumper pressed"));

bindings.Right_Trigger.Subscribe(() => Console.WriteLine($"Right Trigger pressed"));
bindings.Right_Stick.Subscribe(() => Console.WriteLine($"Right Stick pressed"));
bindings.Right_Stick_Up.Subscribe(() => Console.WriteLine($"Right Stick up"));
bindings.Right_Stick_Down.Subscribe(() => Console.WriteLine($"Right Stick down"));
bindings.Right_Stick_Left.Subscribe(() => Console.WriteLine($"Right Stick left"));
bindings.Right_Stick_Right.Subscribe(() => Console.WriteLine($"Right Stick right"));
bindings.Right_Bumper.Subscribe(() => Console.WriteLine($"Right Bumper pressed"));

bindings.X.Subscribe(() => Console.WriteLine($"X button pressed"));
bindings.Y.Subscribe(() => Console.WriteLine($"Y button pressed"));
bindings.B.Subscribe(() => Console.WriteLine($"B button pressed"));
bindings.A.Subscribe(() => Console.WriteLine($"A button pressed"));

bindings.DPad_Up.Subscribe(() => Console.WriteLine($"DPad Up pressed"));
bindings.DPad_Down.Subscribe(() => Console.WriteLine($"DPad Down pressed"));
bindings.DPad_Left.Subscribe(() => Console.WriteLine($"DPad Left pressed"));
bindings.DPad_Right.Subscribe(() => Console.WriteLine($"DPad Right pressed"));


while (true)
{
    gamepad.Poll();
    updates = gamepad.GetBufferedData();

    Array.ForEach(updates, bindings.Update);
}