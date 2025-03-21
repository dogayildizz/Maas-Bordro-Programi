using CLMaasBordro.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLMaasBordro.Data
{
    public class Yonetici : Personel
    {
        private decimal _saatlikUcret=550;

        public override decimal SaatlikUcret
        {
            get { return _saatlikUcret; }
            set { _saatlikUcret = value;}
        }


        public override decimal ToplamMaasHesapla(int calismaSaati)
        {
            throw new NotImplementedException();
        }
    }
}
