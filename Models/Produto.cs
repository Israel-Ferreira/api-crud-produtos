namespace ApiCrudProdutos.Models;

public class Produto
{
    public int Id { get; set; }
    
    public string Sku { get; set; }
    
    public virtual Categoria Categoria { get; set; }
    
    public string Nome { get; set; }
    public string Descricao { get; set; }
    
    public bool Ativo { get; set; } = true;
    public DateTime DataCadastro { get; set; } = DateTime.Now;
    
}