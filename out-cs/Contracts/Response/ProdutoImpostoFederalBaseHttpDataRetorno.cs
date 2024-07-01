namespace Program.Contracts.Response
{
	public class ProdutoImpostoFederalBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public ProdutoImpostoFederalBase data { get; set; }
	}
}
