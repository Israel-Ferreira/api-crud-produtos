namespace ApiCrudProdutos.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    
    public DateTime CriadoEm { get; set; } = DateTime.Now;
    
    public virtual ICollection<Produto>  Produtos { get; set; } = new List<Produto>();
    
    
    public Categoria(){}

    public Categoria(string nome)
    {
        Nome = nome;
    }
}