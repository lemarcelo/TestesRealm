using Realms;
using Realms.Schema;
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

        private List<Model> _listaModels;
        public List<Model> ListaModels
        {
            get { return _listaModels; }
            set
            {
                _listaModels = value;
                Notify("ListaModels");
            }
        }


        private Model _Model;
        public Model Model
        {
            get { return _Model; }
            set
            {
                _Model = value;
                Notify("Model");
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

            // Atualiza e persiste os objetos na thread-safe transaction
            realm.Write(() =>
            {
                realm.Add(new Model { Nome = TxtNome.Text, Quantidade = Convert.ToInt32(TxtQuantidade.Text) });
            });
        }
        //Pesquisar tabela no Realm
        private void Pesquisar()
        {
            var realm = Realm.GetInstance();
            var pesquisa = realm.All<Model>().Where(d => d.Quantidade < 2).ToList();

            ListaModels = pesquisa;


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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
