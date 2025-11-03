namespace ApiCrudProdutos.Models;

public class Estoque
{
    public int Id { get; set; }
    public virtual Produto Produto { get; set; }
    
    public int Quantidade { get; set; }
    
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}