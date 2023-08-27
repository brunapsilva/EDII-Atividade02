namespace Atividade02;

public class Escola
{
    private Curso[] _cursos;
    private int qtde;
    
    public Escola()
    {
        _cursos = new Curso[5];
    }

    public Curso[] Cursos
    {
        get => _cursos;
    }
    
    public int Qtde
    {
        get => qtde;
    }

    public bool adicionarCurso(Curso curso)
    {
        bool podeAdicionar = (this.qtde < 5);
        if (podeAdicionar)
        {
            this._cursos[this.qtde++] = curso;
        }
        return podeAdicionar;
    }
    public Curso pesquisarCurso(Curso curso)
    {
        Curso res = new Curso(-1,"");
        foreach (Curso cur in Cursos)
        {
                
            if (cur != null)
            {
                if(cur.Id == curso.Id)
                    res = cur;
            }
                
        }
        return res;
    }
    public bool removerCurso(Curso curso)
    {
        bool podeRemover;
        bool naoPodeRemover = false;
        int i = 0;
        while (i < 5 && !this._cursos[i].Equals(curso))
        {
            i++;
        }
        podeRemover = (i < 5);
        
        if (podeRemover)
        {
            foreach(Disciplina disciplina in this._cursos[i].Diciplina)
            {
                if ( disciplina != null)
                {
                    naoPodeRemover = true;
                }
            }

            if (!naoPodeRemover)
            {
                while (i < 4)
                {
                    this._cursos[i] = this._cursos[i+1];
                    i++;
                }
                this._cursos[i] = new Curso(-1, "...");
                this.qtde--;
            }
            
            
        }
        return (!naoPodeRemover);
    }
}