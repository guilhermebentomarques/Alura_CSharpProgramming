using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte3
{
    class _03_ProjetarInterface
    {
        public void Run()
        {
            IEletrodomestico eletro1 = new Televisao();
            IEletrodomestico eletro2 = new Abajur();
            IEletrodomestico eletro3 = new Lanterna();
            IEletrodomestico eletro4 = new Radio();

            eletro1 = new Abajur();
            eletro2 = new Televisao();
            eletro3 = new Radio();
            eletro4 = new Lanterna();
        }
    }

    interface IRadioReceptor
    {
        public double Frequencia { get; set; }
    }

    interface IEletrodomestico
    {
        event EventHandler Ligou;
        event EventHandler Desligou;

        void Desligar();
        void Ligar();
    }

    interface IIluminacao
    {
        public double PotenciaDaLampada { get; set; }
    }

    class Televisao : IEletrodomestico, IRadioReceptor
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;
        public double Frequencia { get; set; }
        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }

    class Abajur : IEletrodomestico, IIluminacao
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;
        public double PotenciaDaLampada { get; set; }
        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }

    class Lanterna : IEletrodomestico, IIluminacao
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;
        public double PotenciaDaLampada { get; set; }

        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }

    class Radio : IEletrodomestico, IRadioReceptor
    {
        public event EventHandler Ligou;
        public event EventHandler Desligou;
        public double Frequencia { get; set; }

        public void Desligar()
        {

        }

        public void Ligar()
        {

        }
    }
}
