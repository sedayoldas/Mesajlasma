using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesajlasma
{
    class Fihrist
    {
        //tüm kontaktları saklayacak olan yapı
        public static ArrayList contacts = new ArrayList();

        public static void CreateContactList()
        {
            contacts.Add(Contact.CreateContact("İnci Çavuş", "inci@gmail.com", "Çavuş"));

            contacts.Add(Contact.CreateContact("Barış Önbaşlıca", "baris@live.com", "Barut"));

            contacts.Add(Contact.CreateContact("Korhan Onuk", "korhan@windows.com", "abykrin"));//WTH 
        }
    }
}
