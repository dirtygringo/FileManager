namespace Client.Model
{
    public class DataRecords 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
        public Data Data { get; set; }
        public Data[] Records { get; set; }
    }
}
