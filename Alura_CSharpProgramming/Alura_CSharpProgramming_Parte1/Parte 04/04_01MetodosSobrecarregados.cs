using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_04
{
    class _04_01MetodosSobrecarregados : IAulaItem
    {
        public void Executar()
        {
            int lado = 3;
            Console.WriteLine("VolumeCubo: " + Volume(lado));

            double raio = 2;
            int altura = 10;
            Console.WriteLine("VolumeCilindro: " + Volume(altura,raio));

            long largura = 10;
            altura = 6;
            int profundidade = 4;
            Console.WriteLine("VolumeDoPrisma: " + Volume(largura, profundidade, altura));
        }

        double Volume(double lado)
        {
            //VOLUME DO CUBO = lado ^ 3;
            return Math.Pow(lado,3);
        }

        double Volume(double altura, double raio)
        {
            //VOLUME DO CILINDRO = altura * PI * raio ^ 2;
            return altura * Math.PI * Math.Pow(raio, 2);
        }

        double Volume(double largura,double profundidade, double altura)
        {
            //VOLUME DO PRISMA = largura * profundidade * altura
            return largura * profundidade * altura;

        }
    }
}
