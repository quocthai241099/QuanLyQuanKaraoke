using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HopDen
{
    public class XuLy
    {
        private int layViTri(string email)
        {
            for (int i = 0; i < email.Length; i++)
            {
                if (email[i].Equals('@') == true)
                    return i;
            }
            return -1;
        }
        public bool kiemTraEmail(string email)
        {
            if (layViTri(email) == -1)
                return false;
            string ten = email.Substring(0, layViTri(email));
            if (kiemTraKTDB(ten) == true)
                return false;
            for (int i = 0; i < ten.Length; i++)
            {
                if (ten[i].Equals(' '))
                    return false;
            }
            string tenmien = email.Substring(layViTri(email), email.Length - ten.Length);
            if (tenmien.Equals("@gmail.com") == true)
                return true;
            return false;
        }
        public bool kiemTraKTDB(string kytu)
        {
            for (int i = 0; i < kytu.Length; i++)
            {
                if (kytu[i].Equals('~') || kytu[i].Equals('`') || kytu[i].Equals('!') || kytu[i].Equals('@') || kytu[i].Equals('#') || kytu[i].Equals('$') || kytu[i].Equals('%') || kytu[i].Equals('^') || kytu[i].Equals('&') || kytu[i].Equals('*') || kytu[i].Equals('(') || kytu[i].Equals(')') || kytu[i].Equals('-') || kytu[i].Equals('_') || kytu[i].Equals('=') || kytu[i].Equals('+') || kytu[i].Equals('[') || kytu[i].Equals('{') || kytu[i].Equals(']') || kytu[i].Equals('}') || kytu[i].Equals(';') || kytu[i].Equals(':') || kytu[i].Equals(',') || kytu[i].Equals('<') || kytu[i].Equals('.') || kytu[i].Equals('>') || kytu[i].Equals('/') || kytu[i].Equals('?'))
                {
                    return true;
                }
            }
            return false;
        }
        public bool kiemTraSDT(string sdt)
        {
            string[] nhamang = { "086", "096", "097", "098", "032", "033", "034", "035", "036", "037", "038", "039", "089", "090", "093", "070", "079", "077", "076", "078", "088", "091", "094", "083", "085", "081", "082", "092", "056", "058", "099", "059" };
          
            if(sdt.Length==10)
            {
                string dauso = sdt.Substring(0, 3);
                for(int i=0;i<nhamang.Length;i++)
                {
                    if (dauso.Equals(nhamang[i])==true)
                        return true;
                }
            }
            else
                return false;
            return false;
        }
    }
}
