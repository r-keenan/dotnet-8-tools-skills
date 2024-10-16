namespace BusinessLogicUnitTests
{
    public class AddingNumbersDataTyped: TheoryData<double, double, double>
    {
       public AddingNumbersDataTyped() 
       {
        // Test adding 2 and 2 to return 4
        Add(4, 2, 2);

        // Test adding 2 and 3 to return 5
        Add(5, 2, 3);
       } 
    }
}