using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesajlasma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Fihrist.CreateContactList();//kişi listesini hazırla
            ShowContactList();
        }

        //hem form açıldığında hem de kişi ekle/sil işlemlerinde tekrar ihtiyaç duyulabilir.
        void ShowContactList()
        {
            //aynı verileri tekrar etmemesi için temizlenmeli
            lbContacts.Items.Clear();
            //for (int i = 0; i < Fihrist.contacts.Count; i++)
            //{
            //    lbContacts.Items.Add(
            //       ((Contact)Fihrist.contacts[i]).NickName
            //        );
            //}

            //contacts içinde sadece Contact nesnesi varsa 
            foreach (Contact item in Fihrist.contacts)
            {
                lbContacts.Items.Add(item.NickName);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtMail.Text) && !string.IsNullOrEmpty(txtNick.Text))
            {
                Fihrist.contacts.Add(Contact.CreateContact(txtName.Text, txtMail.Text, txtNick.Text));
                ShowContactList();//yeni eklenen kişiyi de listede göster
                txtNick.Clear();
                txtName.Clear();
                txtMail.Clear();
                //içeriği temizle

            }
            else { }
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = lbContacts.SelectedIndex;
            if (index >= 0)
            {
                Contact c = (Contact)Fihrist.contacts[index];
                MessageBox.Show(string.Format("Adı:{0}\nMail:{1}\nNick:{2}", c.Name, c.Mail, c.NickName), "Contact Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //listbox içindeki sıralama ve index dizilimi Arraylist ile aynıdır.
            int index = lbContacts.SelectedIndex;
            if (index >= 0)
            {
                Fihrist.contacts.RemoveAt(index);
                // ShowContactList();
                lbContacts.Items.RemoveAt(index);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            int index = lbContacts.SelectedIndex;
            if (index >= 0 && !string.IsNullOrEmpty(txtMessage.Text))
            {
                txtSent.AppendText(string.Format("{0} - {1}\n", DateTime.Now.ToShortTimeString(), txtMessage.Text));

                Contact c = (Contact)Fihrist.contacts[index];
                c.messageHistory.Add(string.Format("{0} - {1}\n", DateTime.Now.ToShortTimeString(), txtMessage.Text));

                txtMessage.Clear();
            }
        }

        private void lbContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSent.Clear();//gönderileni temizle
            int index = lbContacts.SelectedIndex;
            if (index >= 0)
            {
                Contact c = (Contact)Fihrist.contacts[index];
                //seçilen kişiye gönderilen mesajları aktar
                foreach (var mesaj in c.messageHistory)
                {
                    txtSent.AppendText(mesaj.ToString());
                }
            }
        }
    }
}
