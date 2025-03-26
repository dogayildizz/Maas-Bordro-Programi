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
        public decimal EkKazanc
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
        public decimal AnaKazanc
        {
            get
            {
                return (decimal)CalismaSaati * SaatlikUcret;
            }
        }
        public MemurDerecesi MemurunDerecesi { get; set; }
        public override decimal SaatlikUcret
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
        public override decimal ToplamMaasHesapla()
        {
            return AnaKazanc + EkKazanc;
        }
    }
}
