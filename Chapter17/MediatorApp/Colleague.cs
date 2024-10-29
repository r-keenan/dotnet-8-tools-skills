namespace MediatorApp
{
    public abstract class Colleague
    {
        protected IMediator _mediator;

        protected Colleague(IMediator mediator)
        {
            _mediator = mediator;
        }

        public virtual void Send(string message)
        {
            _mediator.SendMessage(message, this);
        }

        public abstract void Receive(string message);
    }
}
