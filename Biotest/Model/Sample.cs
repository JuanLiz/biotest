namespace Biotest.Model
{
    public class Sample
    {
        public required int SampleID { get; set; }
        public required string Name { get; set; }
        public required DateTime Date { get; set; }
        public required int SampleTypeID { get; set; }
        public required int SampleSourceID { get; set; }
        public required SampleType SampleType { get; set; }
        public required SampleSource SampleSource { get; set; }

    }
}
