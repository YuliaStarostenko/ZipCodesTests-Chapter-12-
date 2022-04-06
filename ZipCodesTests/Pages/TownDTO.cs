
namespace ZipCodesTests.Pages
{
    public class TownDTO
    {

        public string TownName { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }

        public string GoogleMapLink()
        {
            return $"https://maps.google.com/?q={Latitude},{Longitude}";
        }

    }
}
