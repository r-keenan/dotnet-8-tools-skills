namespace GenericHostApp
{
    public interface ICounterService
    {
        int Counter { get; set; } 
        void IncrementCounter();
    }
    public class CounterService : ICounterService
    {
        public int Counter { get; set; } 

        public void IncrementCounter()
        {
            ++Counter;
        }
    }
}