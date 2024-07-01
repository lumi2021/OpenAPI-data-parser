namespace Program.Contracts.Response
{
	public class ProdutoImpostoEstadualDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public ProdutoImpostoEstadualDTO data { get; set; }
	}
}
