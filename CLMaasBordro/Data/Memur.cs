﻿using CLMaasBordro.Abstract;
using CLMaasBordro.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLMaasBordro.Data
{
    public class Memur : Personel
    {
        private decimal _saatlikUcret;
        private decimal _ekKazanc;

        public decimal EkKazanc
        {
            get { return _ekKazanc; }
        }

        public MemurDerecesi MemurunDerecesi { get; set; }
        public override decimal SaatlikUcret
        {
            get
            {
                _saatlikUcret = (int)MemurunDerecesi;
                return _saatlikUcret;
            }
            set
            {
                _saatlikUcret = value;
            }
        }

        public override decimal ToplamMaasHesapla(int calismaSaati)
        {
            decimal toplamMaas=0;

            if (calismaSaati <= 180)
            {
                toplamMaas = calismaSaati * _saatlikUcret;
            }
            else if (calismaSaati > 180)
            {
                _ekKazanc = ((decimal)(calismaSaati - 180) * _saatlikUcret)*1.5m;
                toplamMaas = _ekKazanc + (_saatlikUcret * 180);
            }

            return toplamMaas;
        }
    }
}
