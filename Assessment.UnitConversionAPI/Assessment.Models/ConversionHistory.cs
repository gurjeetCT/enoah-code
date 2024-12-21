namespace Assessment.Models
{
    public class ConversionHistory
    {
        public string UserName { get; set; }
        public int ConversionHistoryId { get; set; }
        public string UnitType { get; set; }
        public string SourceUnitName { get; set; }
        public string TargetUnitName { get; set; }
        public double DerivedFactor { get; set; }
        public double InputValue { get; set; }
        public double OutputValue { get; set; }        
    }
}
