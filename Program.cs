
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