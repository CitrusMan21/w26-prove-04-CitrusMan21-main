namespace prove_04;

public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    public void AddPerson(string name, int turns)
    {
        _people.Enqueue(new Person(name, turns));
    }

    public string GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            return "ERROR: No one in the queue.";
        }

        Person person = _people.Dequeue();

        // Finite turns greater than 1
        if (person.Turns > 1)
        {
            person.Turns--;
            _people.Enqueue(person);
        }
        // Infinite turns (0 or less)
        else if (person.Turns <= 0)
        {
            _people.Enqueue(person);
        }
        // Turns == 1 → do NOT re-enqueue

        return person.Name;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
