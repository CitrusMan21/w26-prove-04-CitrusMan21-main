namespace prove_04
{
    public class PriorityQueue
    {
        private List<PriorityItem> _queue = new();

        public void Enqueue(string value, int priority)
        {
            _queue.Add(new PriorityItem(value, priority));
        }

        public string Dequeue()
        {
            // REQUIRED: exception instead of null
            if (_queue.Count == 0)
                throw new InvalidOperationException();

            int highPriorityIndex = 0;

            for (int i = 1; i < _queue.Count; i++)
            {
                if (_queue[i].Priority > _queue[highPriorityIndex].Priority)
                {
                    highPriorityIndex = i;
                }
            }

            string value = _queue[highPriorityIndex].Value;
            _queue.RemoveAt(highPriorityIndex);
            return value;
        }

        public override string ToString()
        {
            return $"[{string.Join(", ", _queue)}]";
        }
    }

    internal class PriorityItem
    {
        internal string Value { get; }
        internal int Priority { get; }

        internal PriorityItem(string value, int priority)
        {
            Value = value;
            Priority = priority;
        }

        public override string ToString()
        {
            return $"{Value} (Pri:{Priority})";
        }
    }
}
