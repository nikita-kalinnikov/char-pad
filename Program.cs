using SharpDX.DirectInput;

var input = new DirectInput();
var gamepadDevices = input.GetDevices(DeviceType.Gamepad, DeviceEnumerationFlags.AllDevices);

if (gamepadDevices.Count == 0)
{
    Console.WriteLine($"No gamepad devices was found");
    Console.ReadKey();

    Environment.Exit(1);
}

var gamepadDevice = gamepadDevices.First();
var gamepadGuid = gamepadDevice.InstanceGuid;

Console.WriteLine($"Found Joystick/Gamepad with GUID: {gamepadGuid}");

var gamepad = new Joystick(input, gamepadGuid);

gamepad.Properties.BufferSize = 128;
gamepad.Acquire();

// Poll events from joystick
while (gamepad.GetCurrentState().Buttons[6] is false)
{
    gamepad.Poll();

    var datas = gamepad.GetBufferedData();
    foreach (var state in datas) Console.WriteLine(state);
}

gamepad.Dispose();
input.Dispose();



// Left Trigger         Z                           32766 -> 65408
// Left Bumper          Buttons4                    0 -> 128

// Right Trigger        Z                           32767 -> 128
// Right Bumper         Buttons5                    0 -> 128

// Left Stick           X/Y                         0 -> 65535 (32766 middle)
// Left Stick Pressed   Buttons8                    0 -> 128

// Right Stick          Rotation-X/Y                0 -> 65535 (32766 middle)
// Right Stick Pressed  Buttons9                    0 -> 128

// D-pad Up             PointOfViewControllers0     -1 -> 0
// D-pad Down           PointOfViewControllers0     -1 -> 18000
// D-pad Left           PointOfViewControllers0     -1 -> 27000
// D-pad Right          PointOfViewControllers0     -1 -> 9000

// Button X             Buttons2                    0 -> 128
// Button Y             Buttons3                    0 -> 128
// Button B             Buttons1                    0 -> 128
// Button A             Buttons0                    0 -> 128

// Start                Buttons7                    0 -> 128
// Back                 Buttons6                    0 -> 128