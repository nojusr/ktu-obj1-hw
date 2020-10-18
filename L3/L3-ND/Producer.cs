namespace L3
{
    /// <summary>
    /// class defining list variables
    /// </summary>
    public class Producer
    {
        public string ProducerName { get; set; }
        public int NumberOfVehicles { get; set; }
        public Producer(string producer, int numberOfVehicles)
        {
            this.ProducerName = producer;
            this.NumberOfVehicles = numberOfVehicles;
        }
    }
}
