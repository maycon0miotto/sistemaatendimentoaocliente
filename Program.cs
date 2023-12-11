using mysqlefcore;
using System;


string nomeUsuario = mysqlefcore.Program.menu();
int opcao = mysqlefcore.Program.opcoes();


while (opcao != 8)
{

    switch (opcao)
    {
        case 0:
            opcao = mysqlefcore.Program.opcoes();
            break;

        case 1:
            insercao.Program.duvida(nomeUsuario);
            opcao = 0;
            break;

        case 2:
            insercao.Program.problema(nomeUsuario);
            opcao = 0;
            break;

        case 3:
            insercao.Program.reclamacao(nomeUsuario);
            opcao = 0;
            break;

        case 4:
            Console.Clear();
            DuvidaProgram.PrintData();
            opcao = 0;
            break;

        case 5:
            Console.Clear();
            ProblemaProgram.PrintData();
            opcao = 0;
            break;

        case 6:
            Console.Clear();
            ReclamacaoProgram.PrintData();
            opcao = 0;
            break;

        case 7:
            nomeUsuario = mysqlefcore.Program.menu();
            opcao = 0;
            break;

        default:
            Console.WriteLine("Tente Novamente.");
            opcao = 0;
            break;
    }
}

Console.WriteLine("<--VOCÊ SAIU");
