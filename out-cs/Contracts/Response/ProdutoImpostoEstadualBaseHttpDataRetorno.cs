namespace Program.Contracts.Response
{
	public class ProdutoImpostoEstadualBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public ProdutoImpostoEstadualBase data { get; set; }
	}
}
