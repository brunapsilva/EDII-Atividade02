namespace Atividade02;

public class Disciplina
{
    private int _id;
    private string _descricao;
    private Aluno[] _aluno;
    private int qtde;

    public Disciplina(int id, string descricao)
    {
        _id = id;
        _descricao = descricao;
        _aluno = new Aluno[15];
    }

    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Descricao
    {
        get => _descricao;
        set => _descricao = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Aluno[] Aluno
    {
        get => _aluno;
    }

    public bool matricularAluno(Aluno aluno)
    {
        bool podeAdicionar = (this.qtde < 12);
        if (podeAdicionar)
        {
            this._aluno[this.qtde++] = aluno;
        }
        return podeAdicionar;
    }
    
    public bool desmatricularAluno(Aluno aluno)
    {
        bool podeRemover;
        bool naoPodeRemover = false;
        int i = 0;
        while (i < 15 && !this._aluno[i].Equals(aluno))
        {
            i++;
        }
        podeRemover = (i < 15);
        
        if (podeRemover)
        {
            if (!naoPodeRemover)
            {
                while (i < 14)
                {
                    this.Aluno[i] = this.Aluno[i+1];
                    i++;
                }
                this.Aluno[i] = new Aluno(-1, "...");
                this.qtde--;
            }
        }
        return (!naoPodeRemover);
    }
    
    public override string ToString()
    {
        string alunos = "";
        foreach(var aluno  in this.Aluno )
        {
            if (aluno != null)
            {
                alunos += "\n     Codigo:" + aluno.Id +"     Descrição: " + aluno.Nome;
            }
            
        }
        return "Id: "+ this._id +  "\nDescrição: " + this._descricao + "\nAlunos: " + alunos;
    }
    
    public override bool Equals(object obj)
    {
        return this.Id.Equals((((Disciplina)obj)).Id);
    }
}