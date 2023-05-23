namespace ConnectElectronics.Models
{
    public class CartItem
    {
        public int ProduktId { get; set; }
        public string ProduktEmri { get; set; }=String.Empty;
        public int Sasi { get; set; }
        public double Cmimi { get; set; }
        public decimal Total
        {
            get { return (decimal)(Sasi * Cmimi); }
        }
        public string Image { get; set; } = String.Empty;

        public CartItem()
        {
        }
        public CartItem(Produkt produkt)
        {
            ProduktId = produkt.Id;
            ProduktEmri = produkt.Emri;
            Cmimi = produkt.Cmimi;
            Sasi = 1;
            Image = produkt.Foto;
        }

    }
}

