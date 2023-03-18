namespace lab1.Models
{
    class TVViewModel
    {
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string Manufacturer { get; set; }

        public override string ToString()
        {
            return $"{this.Brand} ({Manufacturer}) ₴{this.Price}";
        }
    }
}
