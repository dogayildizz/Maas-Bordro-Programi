namespace CLMaasBordro.Abstract
{
    public abstract class Personel
    {
        public uint Id {get;}   //enkapsüle et
        public string AdSoyad { get; set; }
        public uint CalismaSaati { get; set; }
        public abstract decimal SaatlikUcret { get; set; }  //Saatlik ücret dışarıdan değiştirilemez bu yüzden sadece get
        public abstract decimal ToplamMaasHesapla(int calismaSaati);
    }
}
