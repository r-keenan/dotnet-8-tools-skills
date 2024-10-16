using System.Collections;

namespace BusinessLogicUnitTests
{
    internal class AddingNumbersData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            // Test adding 2 and 2 to return 4
            yield return new object[] {4, 2, 2};

            // Test adding 2 and 3 to return 5
            yield return new object[] {5, 3, 2};
        }

        // Non-generic implementation calls generic implementation
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}