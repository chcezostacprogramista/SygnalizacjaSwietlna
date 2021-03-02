using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Windows.Media;
using System.Runtime.CompilerServices;

namespace SygnalizacjaSwietlna
{
    public class Sygnalizator : INotifyPropertyChanged
    {
        public Sygnalizator()
        {
            SwiatloGorne = Brushes.Red;
            SwiatloSrodkowe = Brushes.Transparent;
            SwiatloDolne = Brushes.Transparent;

            SwiatlaSaZmieniane = false;
            UstawieniaSygnalizatora = SygnalizatorPozycjaSwiatelEnum.CzerwoneSwiatlo;
        }

        private Brush _swiatloGorne;
        private Brush _swiatloSrodkowe;
        private Brush _swiatloDolne;

        public Brush SwiatloGorne
        {
            get
            {
                return _swiatloGorne;
            }
            set
            {
                if (value != _swiatloGorne)
                {
                    _swiatloGorne = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Brush SwiatloSrodkowe
        {
            get
            {
                return _swiatloSrodkowe;
            }
            set
            {
                if (value != _swiatloSrodkowe)
                {
                    _swiatloSrodkowe = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public Brush SwiatloDolne
        {
            get
            {
                return _swiatloDolne;
            }
            set
            {
                if (value != _swiatloDolne)
                {
                    _swiatloDolne = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private bool SwiatlaSaZmieniane { get; set; }
        private SygnalizatorPozycjaSwiatelEnum UstawieniaSygnalizatora { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ZmienSwiatlo()
        {
            if (SwiatlaSaZmieniane == false)
            {
                switch (UstawieniaSygnalizatora)
                {
                    case SygnalizatorPozycjaSwiatelEnum.CzerwoneSwiatlo:
                        SwiatlaSaZmieniane = true;

                        SwiatloGorne = Brushes.Red;
                        SwiatloSrodkowe = Brushes.Yellow;
                        SwiatloDolne = Brushes.Transparent;
                        Thread.Sleep(1000);
                        SwiatloGorne = Brushes.Transparent;
                        SwiatloSrodkowe = Brushes.Transparent;
                        SwiatloDolne = Brushes.Green;

                        UstawieniaSygnalizatora = SygnalizatorPozycjaSwiatelEnum.ZieloneSwiatlo;
                        SwiatlaSaZmieniane = false;
                        break;
                    case SygnalizatorPozycjaSwiatelEnum.ZieloneSwiatlo:
                        SwiatlaSaZmieniane = true;

                        SwiatloGorne = Brushes.Transparent;
                        SwiatloSrodkowe = Brushes.Yellow;
                        SwiatloDolne = Brushes.Transparent;
                        Thread.Sleep(500);
                        SwiatloGorne = Brushes.Red;
                        SwiatloSrodkowe = Brushes.Transparent;
                        SwiatloDolne = Brushes.Transparent;

                        UstawieniaSygnalizatora = SygnalizatorPozycjaSwiatelEnum.CzerwoneSwiatlo;
                        SwiatlaSaZmieniane = false;
                        break;
                }
            }
        }
    }
}
