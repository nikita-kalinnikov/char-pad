namespace CharPad
{
    internal class Combination : IDisposable
    {
        private readonly LinkedList<Action> _callbacks;
        private readonly List<ControlPoint> _elements;

        public bool Performed => _elements.All(x => x.Performed);

        public Combination(params ControlPoint[] elements)
        {
            _callbacks = new LinkedList<Action>();
            _elements = new List<ControlPoint>(elements);

            _elements.ForEach(x => x.Subscribe(OnElementPerformed));
        }

        private void OnElementPerformed()
        {
            if (Performed is false) return;

            var node = _callbacks.First;
            while (node != null)
            {
                node.Value?.Invoke();
                node = node.Next;
            }
        }

        public Combination AddTo(List<Combination> list)
        {
            list.Add(this);
            return this;
        }

        public void Subscribe(Action onNext) => _callbacks.AddLast(onNext);
        public void Dispose() => _callbacks.Clear();

        public override string ToString() => string.Join(" + ", _elements);
    }
}
