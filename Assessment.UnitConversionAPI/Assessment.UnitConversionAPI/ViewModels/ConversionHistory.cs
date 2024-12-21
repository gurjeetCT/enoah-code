namespace Assessment.UnitConversionAPI.ViewModels
{
    public class ConversionHistory
    {
        public string UserName { get; set; }
        public int ConversionHistoryId { get; set; }
        public int UnitConversionRatesId { get; set; }
        public double InputValue { get; set; }
        public double OutputValue { get; set; }
        public UnitConversionRates ConversionRateUsed { get; set; }
    }
}
