namespace Entity.Concrete.RealEstateAds
{
    public class Property
    {
        public int propertyID { get; set; }
        public string name { get; set; }
        public string formerName { get; set; }
        public string streetAddress { get; set; }
        public string city { get; set; }
        public string market { get; set; }
        public string state { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
    }
}