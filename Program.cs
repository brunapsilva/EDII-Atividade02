// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Atividade02;

int num = 100;
Escola escola = new Escola();
while (num > 0)
{
    string desc;
    int id;
    int idPesq;
    
    Console.WriteLine("-------------------------------------------------------------");
    Console.WriteLine("                 0 - Sair");
    Console.WriteLine("                 1 - Adicionar curso");
    Console.WriteLine("                 2 - Pesquisar curso");
    Console.WriteLine("                 3 - Remover curso");
    Console.WriteLine("                 4 - Adicionar disciplina no curso");
    Console.WriteLine("                 5 - Pesquisar disciplina");
    Console.WriteLine("                 6 - Remover disciplina do curso");
    Console.WriteLine("                 7 - Matricular aluno na disciplina");
    Console.WriteLine("                 8 - Remover aluno da disciplina");
    Console.WriteLine("                 9 - Pesquisar aluno");
    Console.WriteLine("-------------------------------------------------------------");
    Console.Write("Digite uma opção desejada: ");
    num = Int32.Parse( Console.ReadLine());
    switch (num)
    {
        case 0:
            Console.WriteLine("SAINDO...");
            break;
        case 1:
            Console.Write("Digite a descrição do curso: ");
            desc = Console.ReadLine();
            Console.Write("Digite o codigo do curso: ");
            id = Int32.Parse(Console.ReadLine());
            Curso curso = new Curso( id, desc);
            if (escola.adicionarCurso(curso))
                Console.WriteLine("Curso adicionado com sucesso!!!");
            else
                Console.WriteLine("Não foi possivel adicionar o curso!!!");
            break;
        case 2:
            Console.Write("Digite o id do vendedor: ");
            id = Int32.Parse(Console.ReadLine());
            Curso cur1 = new Curso(id, "");
            Curso res = escola.pesquisarCurso(cur1);
            if(res.Id == -1)
                Console.WriteLine("Curso não encontrado!!!");
            else
                Console.WriteLine(res.ToString());
            break;
        case 3:
            Console.Write("Digite a codigo do curso: ");
            id = Int32.Parse(Console.ReadLine());
            Curso curs = new Curso(id, "");
            if (escola.removerCurso(curs))
                Console.WriteLine("Curso removido com sucesso!!!");
            else
                Console.WriteLine("Não foi possivel remover o curso!!!");
            break;
        case 4:
            Console.Write("Digite a codigo do curso: ");
            idPesq = Int32.Parse(Console.ReadLine());
            Console.Write("Digite a descrição do disciplina : ");
            desc = Console.ReadLine();
            Console.Write("Digite o codigo do disciplina : ");
            id = Int32.Parse(Console.ReadLine());
            Disciplina disciplina = new Disciplina(id, desc);
            foreach (Curso cur in escola.Cursos)
            {
                if (cur != null)
                {
                    if (cur.Id == idPesq)
                    {
                        if (cur.adicionarDisciplina(disciplina))
                            Console.WriteLine("Disciplina adicionado com sucesso!!!");
                        else
                            Console.WriteLine("Não foi possivel adicionar a Disciplina!!!");
                    }
                }
            }
            break;
        case 5:
            Console.Write("Digite a codigo do curso: ");
            id = Int32.Parse(Console.ReadLine());
            Curso c1 = new Curso(id, "");
            Curso resc = escola.pesquisarCurso(c1);
            if(resc.Id == -1)
                Console.WriteLine("Curso não encontrado!!!");
            else
            {
                Console.Write("Digite a codigo da disciplina: ");
                idPesq = Int32.Parse(Console.ReadLine());
                Disciplina d1 = new Disciplina(idPesq, "");
                Disciplina resd = resc.pesquisarDisciplina(d1);
                if(resd.Id == -1)
                    Console.WriteLine("Disciplina não encontrado!!!");
                else
                    Console.WriteLine(resd.ToString());
            }
            break;
        case 6:
            Console.Write("Digite a codigo do curso: ");
            id = Int32.Parse(Console.ReadLine());
            Curso c2 = new Curso(id, "");
            Curso resc2 = escola.pesquisarCurso(c2);
            if(resc2.Id == -1)
                Console.WriteLine("Curso não encontrado!!!");
            else
            {
                Console.Write("Digite a codigo da disciplina: ");
                id = Int32.Parse(Console.ReadLine());
                Disciplina dis = new Disciplina(id, "");
                if (resc2.removerDisciplina(dis))
                    Console.WriteLine("disciplina removida com sucesso!!!");
                else
                    Console.WriteLine("Não foi possivel remover a disciplina!!!");
            }

            break;
        case 7:
            Console.Write("Digite a codigo do Aluno: ");
            id = Int32.Parse(Console.ReadLine());
            Console.Write("Digite o nome do aluno : ");
            desc = Console.ReadLine();
            Aluno aluno = new Aluno(id, desc);
            if (aluno.podeMatricular(escola.Cursos))
            {
                Console.Write("Digite a codigo do curso: ");
                id = Int32.Parse(Console.ReadLine());
                Curso c3 = new Curso(id, "");
                Curso resc3 = escola.pesquisarCurso(c3);
                if(resc3.Id == -1)
                    Console.WriteLine("Curso não encontrado!!!");
                else
                {
                    Console.Write("Digite a codigo da disciplina: ");
                    id = Int32.Parse(Console.ReadLine());
                    Disciplina dis = new Disciplina(id, "");
                    Disciplina resd = resc3.pesquisarDisciplina(dis);
                    if(resd.Id == -1)
                        Console.WriteLine("Disciplina não encontrado!!!");
                    else
                    {
                        if ( resd.matricularAluno(aluno))
                            Console.WriteLine("Aluno adicionado com sucesso!!!");
                        else
                            Console.WriteLine("Não foi possivel adicionar o aluno!!!");
                    }
                }
            }
            break;
        case 8:
            Console.Write("Digite a codigo do curso: ");
            id = Int32.Parse(Console.ReadLine());
            Curso c4 = new Curso(id, "");
            Curso resc4 = escola.pesquisarCurso(c4);
            if(resc4.Id == -1)
                Console.WriteLine("Curso não encontrado!!!");
            else
            {
                Console.Write("Digite a codigo da disciplina: ");
                id = Int32.Parse(Console.ReadLine());
                Disciplina dis = new Disciplina(id, "");
                Disciplina resd = resc4.pesquisarDisciplina(dis);
                if(resd.Id == -1)
                    Console.WriteLine("Disciplina não encontrado!!!");
                else
                {
                    Console.Write("Digite a codigo do aluno: ");
                    id = Int32.Parse(Console.ReadLine());
                    Aluno aluno1 = new Aluno(id, "");
                    if (resd.desmatricularAluno(aluno1))
                        Console.WriteLine("disciplina removida com sucesso!!!");
                    else
                        Console.WriteLine("Não foi possivel remover a disciplina!!!");
                }
            }
            break;
        case 9:
            Aluno alu = new Aluno(-1, "");
            string ret = "";
            bool achou = false;
            Console.Write("Digite a codigo do curso: ");
            id = Int32.Parse(Console.ReadLine());
            Curso c5 = new Curso(id, "");
            Curso resc5 = escola.pesquisarCurso(c5);
            if(resc5.Id == -1)
                Console.WriteLine("Curso não encontrado!!!");
            else
            {
                Console.Write("Digite a codigo do aluno: ");
                id = Int32.Parse(Console.ReadLine());
                Aluno aluno0 = new Aluno(id, "");
                foreach (Disciplina dis in resc5.Diciplina)
                {
                    if (dis != null)
                    {
                        foreach (Aluno al in dis.Aluno)
                        {
                            if (al != null)
                            {
                                if (al.Equals(aluno0))
                                {
                                    achou = true;
                                    alu = al;
                                    ret += "\n Codigo:" + dis.Id + " Descrição: " + dis.Descricao;
                                }
                            }
                        }
                    }
                }
            }

            if (achou)
            {
                Console.WriteLine(alu.ToString() + "Disciplinas: " + ret);
            }
            
            break;
    }
}
