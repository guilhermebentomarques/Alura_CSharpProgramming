using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_06
{
    public class _06_04_OperadoresDeConversao : IAulaItem
    {
        public void Executar()
        {
            AnguloEmGraus anguloEmGraus = 45;
            Console.WriteLine(anguloEmGraus);

            AnguloEmRadianos anguloEmRadianos = 180;
            Console.WriteLine(anguloEmRadianos);

            double graus = anguloEmGraus;

            anguloEmRadianos = (AnguloEmRadianos)anguloEmGraus;
            anguloEmGraus = anguloEmRadianos;
            Console.WriteLine($"anguloEmGraus: {anguloEmGraus.Graus}");
            Console.WriteLine($"anguloEmRadianos: {anguloEmRadianos.Radianos}");
        }
    }

    public struct AnguloEmRadianos
    {
        public double Radianos { get; }

        public AnguloEmRadianos(double radianos)
        {
            this.Radianos = radianos;
        }

        public static explicit operator AnguloEmRadianos(AnguloEmGraus graus)
        {
            return new AnguloEmRadianos(graus.Graus * System.Math.PI / 180);
        }

        public static implicit operator AnguloEmRadianos(double radianos)
        {
            return new AnguloEmRadianos(radianos);
        }

        public static implicit operator double(AnguloEmRadianos radianos)
        {
            return radianos.Radianos;
        }

        public override string ToString()
        {
            return String.Format($"Radianos: ", this.Radianos);
        }
    }

    public struct AnguloEmGraus
    {
        public double Graus { get; }

        public AnguloEmGraus(double graus)
        {
            this.Graus = graus;
        }

        public static implicit operator AnguloEmGraus(AnguloEmRadianos radianos)
        {
            return new AnguloEmGraus(radianos.Radianos * 180 / System.Math.PI);
        }

        public static implicit operator AnguloEmGraus(double graus)
        {
            return new AnguloEmGraus(graus);
        }

        public static implicit operator double(AnguloEmGraus graus)
        {
            return graus.Graus;
        }

        public override string ToString()
        {
            return String.Format($"Graus: ", this.Graus);
        }
    }
}
