using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLMaasBordro.Models
{
    static public class Kontrol //Her formda kontrolleri tekrar tekrar yazmamak için static classta bu metotları tanımladık.
    {

        static public bool CalismaSaatiMi(string strCalismaSaati) 
        {
            bool calismaSaatiMi = false;

            //Sayı mı, pozitif mi, 500'den az mı kontrolleri yapıldı.
            if (int.TryParse(strCalismaSaati, out int calismaSaati) && calismaSaati <= 500 && calismaSaati >= 0)
            {
                calismaSaatiMi = true;
            }

            return calismaSaatiMi;
        }

        static public bool AdSoyadMi(string adSoyad)
        {
            bool adSoyadMi = true;

            foreach (char c in adSoyad)  //Yalnızca harflerden mi oluşuyor diye kontrol ettik.
            {
                if (!char.IsLetter(c) && c != ' ')
                {
                    adSoyadMi = false;
                    return adSoyadMi;
                }
            }
            if (!adSoyad.Contains(" ")) //Boşluk içeriyor mu diye kontrol ettik. (Her insanın adı ve soyadı vardır, bu yüzden en az bir boşluk içermesi zorunludur.
            {
                adSoyadMi = false;
                return adSoyadMi;
            }
            return adSoyadMi;
        }

    }
}
