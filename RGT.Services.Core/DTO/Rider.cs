namespace RGT.Services.Core.DTO
{
    public class Rider
    {
        public string UUID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int Gender { get; set; }
        public int Age { get; set; }
        public string CountryISOCode { get; set; }
        public string CountryName { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
