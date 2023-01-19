using ClinicServiceNamespace;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicDesctop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonLoadClients_Click(object sender, EventArgs e)
        {
            ClinicServiceClient clinicServiceClient = 
                new ClinicServiceClient("http://localhost:5210/", new HttpClient());

            ICollection<Client> clients = clinicServiceClient.ClientGetAllAsync().Result;

            listViewClients.Items.Clear();
            foreach (Client client in clients)
            {
                ListViewItem item = new ListViewItem();
                item.Text = client.ClientId.ToString();
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.Document
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.Surname
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.FirstName
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.Patronymic
                });
                item.SubItems.Add(new ListViewItem.ListViewSubItem()
                {
                    Text = client.Birthday.ToString()
                });

                listViewClients.Items.Add(item);
            }
        }

        private void buttonDeleteClient_Click(object sender, EventArgs e)
        {
            //TODO: Реализовать запрос id для удаления клиента.
        }

        private void buttonAddClient_Click(object sender, EventArgs e)
        {
            //TODO: Реализовать запрос параметров клиента для добавления.
        }

        private void buttonUpdateClient_Click(object sender, EventArgs e)
        {
            //TODO: Реализовать запрос параметров клиента для изменения.
        }

        private void buttonFindClient_Click(object sender, EventArgs e)
        {
            //TODO: Реализовать запрос id для поиска клиента.
        }
    }
}
