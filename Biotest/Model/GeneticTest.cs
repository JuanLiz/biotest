namespace Biotest.Model
{
    public class GeneticTest
    {
        public required int GeneticTestID { get; set; }
        public required int GeneticTestTypeID { get; set; }
        public required int PatientID { get; set; }
        public required int EmployeeID { get; set; }
        public required DateTime Date { get; set; }
        public required string Result { get; set; }

        public required GeneticTestType GeneticTestType { get; set; }
        public required Patient Patient { get; set; }
        public required Employee Employee { get; set; }
    }
}
