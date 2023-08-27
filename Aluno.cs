namespace Atividade02;

public class Aluno
{
    private int id;
    private string nome;

    public Aluno(int id, string nome)
    {
        this.id = id;
        this.nome = nome;
    }

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Nome
    {
        get => nome;
        set => nome = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool podeMatricular(Curso[] cursos)
    {
        bool existe = false;
        foreach (Curso cur in cursos)
        {
            if (cur != null)
            {
                foreach (Disciplina dis in cur.Diciplina)
                {
                    if (dis != null)
                    {
                        foreach (Aluno aluno in dis.Aluno)
                        {
                            if (aluno != null)
                            {
                                if(aluno.Id == id && aluno.nome == nome)
                                    existe = true;
                            }
                        }
                    }
                }
            }
        }
        return !existe;
    }

    public override string ToString()
    {
        return "Id: " + id + " Nome: " + nome;
    }

    public override bool Equals(object obj)
    {
        return this.Id.Equals((((Aluno)obj)).Id);
    }
}