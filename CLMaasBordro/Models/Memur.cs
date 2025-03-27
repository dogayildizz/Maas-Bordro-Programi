using CLMaasBordro.Abstract;
using CLMaasBordro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLMaasBordro.Data
{
    public class Memur : Personel
    {

        public override string Kadro { get; } = "Memur";
        public decimal EkKazanc  //180 saatten fazla çalışan memurlar ek mesai yapmış sayılır, normalde aldığı ücretin 1.5 katını alır.
        {
            get 
            { 
                if(CalismaSaati>180)
                {
                    return Convert.ToDecimal(((decimal)CalismaSaati - 180) * SaatlikUcret * 1.5m);
                }
                else
                {
                    return 0;
                }

            }
        }
        public decimal AnaKazanc //180 ve altı çalışma ana kazanç olarak geçer. Eğer 180 saatten fazla çalıştıysa, 180 saatlik çalışması ana kazancı olur. Gerisi ek kazancı olur.
        {
            get
            {
                if(CalismaSaati<=180)
                return (decimal)CalismaSaati * SaatlikUcret;

                else
                    return 180 * SaatlikUcret;
            }
        }
        public MemurDerecesi MemurunDerecesi { get; set; }
        public override decimal SaatlikUcret  //Memurun derecesine göre saatlik ücreti belirlendi.
        {
            get
            {
                switch (MemurunDerecesi)
                {
                    case MemurDerecesi.UstKidemli:
                        return 570;
                    case MemurDerecesi.Kidemli:
                        return 550;
                    case MemurDerecesi.OrtaKidemli:
                        return 530;
                    case MemurDerecesi.Deneyimli:
                        return 515;
                    case MemurDerecesi.YeniBaslayan:
                        return 500;
                    default:
                        return 0;
                }
            }

        }
        public override decimal ToplamMaasHesapla() //Total maaşı anakazanç ve ekmesailerinin toplamıdır.
        {
            return AnaKazanc + EkKazanc;
        }
    }
}
