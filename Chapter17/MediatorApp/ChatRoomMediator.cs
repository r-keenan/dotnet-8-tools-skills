namespace MediatorApp
{
    public class ChatRoomMediator : IMediator
    {
        private List<Colleague> _colleagues;

        public ChatRoomMediator()
        {
            _colleagues = new List<Colleague>();
        }

        public void Register(Colleague colleague)
        {
            _colleagues.Add(colleague);
        }

        public void SendMessage(string message, Colleague originator)
        {
            foreach (Colleague colleague in _colleagues)
            {
                if (colleague != originator)
                    colleague.Receive(message);
            }
        }
    }
}
