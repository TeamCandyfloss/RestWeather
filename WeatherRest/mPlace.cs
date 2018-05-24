namespace WeatherRest
{
    public class mPlace
    {
        private string _place;
        public mPlace()
        {
            Place = "default";
        }

        public mPlace(string place)
        {
            _place = place;
        }

        public string Place { get => _place; set => _place = value; }
    }
}