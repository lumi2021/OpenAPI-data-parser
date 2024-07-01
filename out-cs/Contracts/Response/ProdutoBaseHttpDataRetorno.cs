namespace Program.Contracts.Response
{
	public class ProdutoBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public ProdutoBase data { get; set; }
	}
}
