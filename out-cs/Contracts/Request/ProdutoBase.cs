namespace Program.Contracts.Request
{
	public class ProdutoBase
	{
		public int produtoId { get; set; }
		public string codBarras { get; set; }
		public string nome { get; set; }
		public int ncmid { get; set; }
	}
}
