using SharpDX.DirectInput;

namespace CharPad
{
    internal class ControlPoint : IDisposable
    {
        private readonly JoystickOffset _offset;
        private readonly Predicate<int> _valuePredicate;
        private readonly LinkedList<Action> _callbacks;

        public ControlPoint(JoystickOffset offset) : this(offset, x => true) { }
        public ControlPoint(JoystickOffset offset, Predicate<int> value)
        {
            _offset = offset;
            _valuePredicate = value;
            _callbacks = new LinkedList<Action>();
        }

        public void Update(JoystickUpdate update)
        {
            if (update.Offset != _offset) return;
            if (_valuePredicate(update.Value) is false) return;

            var node = _callbacks.First;
            while (node != null)
            {
                node.Value?.Invoke();
                node = node.Next;
            }
        }

        public ControlPoint Subscribe(Action onNext)
        {
            _callbacks.AddLast(onNext);
            return this;
        }

        public ControlPoint AddTo(List<ControlPoint> list)
        {
            list.Add(this);
            return this;
        }

        public void Dispose() => _callbacks.Clear();
    }
}
