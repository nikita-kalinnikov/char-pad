using CharPad;
using SharpDX.DirectInput;
using System.Linq;


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
var bindings = new Bindings(false);
var inputMap = InputMap.Read();

foreach (var entry in inputMap)
{
    var controlPoints = entry.Value.Select(x => new ControlPoint(x.Key, x.Direction).AddTo(bindings));
    var combination = new Combination(controlPoints.ToArray());

    combination.Subscribe(() => Console.WriteLine($"Combination performed: {entry.Key} ({combination})"));
}


while (true)
{
    gamepad.Poll();
    updates = gamepad.GetBufferedData();

    Array.ForEach(updates, bindings.Update);
}