namespace SolidPrinciplesApp
{
    // Interface Segregation Principle (ISP)
    // no client should be forced to depend on methods that it does not use
    public interface IPrinter
    {
        void Print(Document d);
    }

    public interface IScanner
    {
        void Scan(Document d);
    }

    public interface IFax
    {
        void Fax(Document d);
    }

    public class Document { }

    public class MultiFunctionPrinter : IPrinter, IScanner, IFax
    {
        public void Fax(Document d)
        {
            WriteLine("Faxing the document");
        }

        public void Print(Document d)
        {
            WriteLine("Printing the document");
        }

        public void Scan(Document d)
        {
            WriteLine("Scanning the document");
        }
    }
}
