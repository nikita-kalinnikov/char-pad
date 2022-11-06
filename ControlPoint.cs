using SharpDX.DirectInput;

namespace CharPad
{
    internal class ControlPoint : IDisposable
    {
        private readonly JoystickOffset _offset;
        private readonly Predicate<int> _valuePredicate;
        private readonly LinkedList<Action<int>> _callbacks;
        private int? _lastValue = null;

        public int? Value => _lastValue;
        public bool Performed => _lastValue.HasValue ? _valuePredicate(_lastValue.Value) : false;

        public ControlPoint(JoystickOffset offset) : this(offset, x => true) { }
        public ControlPoint(JoystickOffset offset, Predicate<int> value)
        {
            _offset = offset;
            _valuePredicate = value;
            _callbacks = new LinkedList<Action<int>>();
        }

        public void Update(JoystickUpdate update)
        {
            if (_offset != update.Offset) return;

            _lastValue = update.Value;

            if (_valuePredicate(update.Value) is false) return;

            var node = _callbacks.First;
            while (node != null)
            {
                node.Value?.Invoke(update.Value);
                node = node.Next;
            }
        }

        public void Subscribe(Action onNext) => Subscribe(_ => onNext?.Invoke());
        public void Subscribe(Action<int> onNext) => _callbacks.AddLast(onNext);

        public ControlPoint AddTo(List<ControlPoint> list)
        {
            list.Add(this);
            return this;
        }

        public void Dispose() => _callbacks.Clear();
    }
}
