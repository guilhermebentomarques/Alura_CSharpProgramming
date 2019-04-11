using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1.Parte_04
{
    class _04_01MetodosSobrecarregados : IAulaItem
    {
        public void Executar()
        {
            //VOLUME DO CUBO = lado ^ 3;
            int lado = 3;

            //VOLUME DO CILINDRO = altura * PI * raio ^ 2;
            double raio = 2;
            int altura = 10;

            //VOLUME DO PRISMA = largura * profundidade * altura
            long largura = 10;
            altura = 6;
            int profundidade = 4;
        }
    }
}
