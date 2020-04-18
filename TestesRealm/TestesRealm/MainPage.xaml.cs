using Realms;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using TestesRealm.Models;
using Xamarin.Forms;

namespace TestesRealm
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        private ObservableCollection<Model> _listaModels;

        public ObservableCollection<Model> ListaModels
        {
            get { return _listaModels; }
            set { _listaModels = value;
                Notify("ListaModels");
            }
        }


        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;
        }


        //Criar tabela no Realm
        private void Incluir()
        {
            var realm = Realm.GetInstance();

            // Update and persist objects with a thread-safe transaction
            realm.Write(() =>
            {
                realm.Add(new Model { Name = Nome.Text, Age = Convert.ToInt32(Quantidade.Text) });
            });
        }
        //Pesquisar tabela no Realm
        private void Pesquisar()
        {
            var realm = Realm.GetInstance();
            var pesquisa = realm.All<Model>().Where(d => d.Age < 2).ToArray();

            ListaModels = new ObservableCollection<Model>(pesquisa.ToList<Model>());

            //var oldDogs = from d in realm.All<Dog>() where d.Age > 8 select d;


        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Incluir();
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Pesquisar();
        }
        void example()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void Notify(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
