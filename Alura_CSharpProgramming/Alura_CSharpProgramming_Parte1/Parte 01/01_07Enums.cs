﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte1e2.Parte_01
{
    class _07Enums : IAulaItem
    {
        public void Executar()
        {
            const int Seg = 0;
            const int Ter = 1;
            const int Qua = 2;

            DiasDaSemana primeiroDia = DiasDaSemana.Seg;

            DiasDeTrabalho diasDeTrabalho
                = DiasDeTrabalho.Ter | DiasDeTrabalho.Qui | DiasDeTrabalho.Sex;

            Console.WriteLine(diasDeTrabalho);

        }
    }

    enum DiasDaSemana : long { Seg = 3, Ter = 10, Qua = 15, Qui, Sex, Sab, Dom }

    [Flags]
    enum DiasDeTrabalho { Seg = 0, Ter = 1, Qua = 2, Qui = 4, Sex = 8, Sab = 16, Dom = 32 }
}
