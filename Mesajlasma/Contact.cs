using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesajlasma
{
    class Contact
    {
        public string Name { get; set; }
        public string Mail { get; set; }
        public string NickName { get; set; }

        //biz bir kontağa mesaj attığımızda bu bilgiler saklansın
        public ArrayList messageHistory = new ArrayList();

        //her kontak nesnesi bir mesaj tarihçesi tutar. ListBox içinden seçilen kişiye mesaj aktarılmış olsun.
        public void ReceiveMessage(string mesaj)
        {
            messageHistory.Add(mesaj);
        }

        // kontağın aldığı mesajları getir
        public string ShowMessageHistory()
        {
            string mesajIcerik = "";
            foreach (var m in messageHistory)
            {
                mesajIcerik += m.ToString();
            }
            return mesajIcerik;
        }
        //sınıfla beraber kullanılacak ve bir contact nesnesi geri verecek
        public static Contact CreateContact(string isim, string mail, string nick)
        {
            return new Contact { Name = isim, Mail = mail, NickName = nick };
        }
    }
}
