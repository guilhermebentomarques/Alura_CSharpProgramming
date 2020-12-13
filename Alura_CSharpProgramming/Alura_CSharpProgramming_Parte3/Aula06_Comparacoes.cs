﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Alura_CSharpProgramming_Parte3
{
    class Aula06_Comparacoes
    {
        public void Run()
        {
            Aluno aluno1 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            Aluno aluno2 = new Aluno
            {
                Nome = "José da Silva",
                DataNascimento = new DateTime(1996, 1, 1)
            };

            Aluno aluno3 = new Aluno
            {
                Nome = "josé da Silva",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            Console.WriteLine(aluno1.Equals(aluno2));
            Console.WriteLine(aluno1.Equals(aluno3));

            Aluno aluno4 = new Aluno
            {
                Nome = "ANDRÉ DO SANTOS",
                DataNascimento = new DateTime(1970, 1, 1)
            };

            Aluno aluno5 = new Aluno
            {
                Nome = "Ana de Souza",
                DataNascimento = new DateTime(1990, 1, 1)
            };

            List<Aluno> alunos = new List<Aluno>() { 
                aluno1,
                aluno2,
                aluno3,
                aluno4,
                aluno5
            };

            alunos.Sort();

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
        }
    }

    class Aluno : IComparable
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public override string ToString()
        {
            return $"Nome: {Nome}, Data de Nascimento: {DataNascimento:dd/MM/yyyy}";
        }

        public override bool Equals(Object obj)
        {
            Aluno outro = obj as Aluno;
            if (outro == null)
            {
                return false;
            }
            return this.Nome.Equals(outro.Nome, StringComparison.CurrentCultureIgnoreCase) && this.DataNascimento.Equals(outro.DataNascimento);
        }

        public int CompareTo(object obj)
        {
            //retorno 0 => objeto são iguais
            //retorno > 0 => objeto atual vem depois
            //retorno < 0 => objeto atual vem antes
            if(obj == null)
            {
                return 1;
            }

            Aluno outro = obj as Aluno;
            if(outro == null)
            {
                throw new ArgumentException("Objeto não é um aluno.");
            }

            int resultado = this.DataNascimento.CompareTo(outro.DataNascimento);

            if(resultado == 0)
            {
                resultado = this.Nome.CompareTo(outro.Nome);
            }


            return resultado;
        }
    }
}
