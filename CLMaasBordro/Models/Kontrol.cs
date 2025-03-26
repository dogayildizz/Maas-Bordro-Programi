using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLMaasBordro.Models
{
    static public class Kontrol
    {
        static public bool CalismaSaatiMi(string strCalismaSaati)
        {
            bool calismaSaatiMi = false;

            if (int.TryParse(strCalismaSaati, out int calismaSaati) && calismaSaati <= 500 && calismaSaati >= 0)
            {
                calismaSaatiMi = true;
            }

            return calismaSaatiMi;
        }
        static public bool AdSoyadMi(string adSoyad)
        {
            bool adSoyadMi = true;

            foreach (char c in adSoyad)
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    adSoyadMi = false;
                    return adSoyadMi;
                }
            }
            if (!adSoyad.Contains(" "))
            {
                adSoyadMi = false;
                return adSoyadMi;
            }
            return adSoyadMi;
        }

    }
}
