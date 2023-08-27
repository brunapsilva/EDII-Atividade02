namespace Atividade02;

public class Curso
{
    private int id;
    private string descricao;
    private Disciplina[] _diciplina;
    private int qtde;

    public Curso(int id, string descricao)
    {
        this.id = id;
        this.descricao = descricao;
        _diciplina = new Disciplina[12];
    }

    public int Id
    {
        get => id;
        set => id = value;
    }

    public string Descricao
    {
        get => descricao;
        set => descricao = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Disciplina[] Diciplina
    {
        get => _diciplina;
    }

    public bool adicionarDisciplina(Disciplina disciplina)
    {
        bool podeAdicionar = (this.qtde < 12);
        if (podeAdicionar)
        {
            this._diciplina[this.qtde++] = disciplina;
        }
        return podeAdicionar;
    }
    
    public Disciplina pesquisarDisciplina(Disciplina disciplina)
    {
        Disciplina res = new Disciplina(-1,"");
        foreach (Disciplina dis in _diciplina)
        {
                
            if (dis != null)
            {
                if(dis.Id == disciplina.Id)
                    res = dis;
            }
                
        }
        return res;
    }
    
    public bool removerDisciplina(Disciplina disciplina)
    {
        bool podeRemover;
        bool naoPodeRemover = false;
        int i = 0;
        while (i < 12 && !this._diciplina[i].Equals(disciplina))
        {
            i++;
        }
        podeRemover = (i < 12);
        
        if (podeRemover)
        {
            foreach(Aluno aluno in this.Diciplina[i].Aluno)
            {
                if ( aluno != null)
                {
                    naoPodeRemover = true;
                }
            }

            if (!naoPodeRemover)
            {
                while (i < 11)
                {
                    this._diciplina[i] = this._diciplina[i+1];
                    i++;
                }
                this._diciplina[i] = new Disciplina(-1, "...");
                this.qtde--;
            }
            
            
        }
        return (!naoPodeRemover);
    }

    public override string ToString()
    {
        string disciplinas = "";
        foreach(var disciplina  in this.Diciplina )
        {
            if (disciplina != null)
            {
                disciplinas += "\n     Codigo:" + disciplina.Id +"     Descrição: " + disciplina.Descricao;
            }
            
        }
        return "Id: "+ this.id +  "\nDescrição: " + this.descricao + "\nDisciplina: " + disciplinas;
    }
    
    public override bool Equals(object obj)
    {
        return this.Id.Equals((((Curso)obj)).Id);
    }
}