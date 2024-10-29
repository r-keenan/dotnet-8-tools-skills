namespace MediatorApp
{
    public class Participant : Colleague
    {
        public Participant(IMediator mediator, string name)
            : base(mediator)
        {
            Name = name;
        }

        public string Name { get; }

        public override void Receive(string message)
        {
            WriteLine($"{Name} received: {message}");
        }
    }
}
