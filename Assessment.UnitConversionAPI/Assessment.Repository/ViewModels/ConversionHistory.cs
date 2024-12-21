namespace Assessment.Repository.ViewModels
{
    public class ConversionHistoryViewModel
    {
        public string UserName { get; set; }        
        public string SourceUnitName { get; set; }
        public string TargetUnitName { get; set; }
        public double InputValue { get; set; }
        public double OutputValue { get; set; }        
    }
    public class ConversionOperationModel
    {
        public string UserName { get; set; }
        public int SourceUnitId { get; set; }
        public int TargetUnitId { get; set; }
        public double InputValue { get; set; }        
    }
}
