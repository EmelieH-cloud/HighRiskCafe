namespace HighRiskCafe
{
    internal class Coffee
    {
        public bool IsDone { get; set; }
        public string CoffeeType { get; set; }
        public List<string> Fails { get; set; }


        public Coffee(bool i, string type, List<string> failed)
        {
            IsDone = i;
            Fails = failed;
            CoffeeType = type;
        }
    }
}
