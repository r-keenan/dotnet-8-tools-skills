namespace SolidPrinciplesApp
{
    // Open/Closed Principle
    // software entities like classes and functions should be open for extension but close for modification
    public abstract class ReportGenerator
    {
        public abstract void GenerateReport();
    }

    public class PDFReportGenerator : ReportGenerator
    {
        public override void GenerateReport()
        {
            WriteLine("Implement logic for generating a PDF report");
        }
    }

    public class ExcelReportGenerator : ReportGenerator
    {
        public override void GenerateReport()
        {
            WriteLine("Implement logic for generating an Excel report");
        }
    }
}
