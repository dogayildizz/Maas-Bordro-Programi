using CLMaasBordro.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CLMaasBordro.Data
{
    public class Yonetici : Personel
    {

        public override string Kadro {get;} = "Yönetici";
        public decimal EkKazanc
        {
            get 
            { 
                return 2000; 
            }
        }
        public decimal AnaKazanc
        {
            get 
            { 
                return SaatlikUcret*CalismaSaati; 
            }
        }
        public override decimal SaatlikUcret
        {
            get
            {
                return 550;
            }
        }
        public override decimal ToplamMaasHesapla()
        {

            return AnaKazanc+EkKazanc;

        }
    }
}
