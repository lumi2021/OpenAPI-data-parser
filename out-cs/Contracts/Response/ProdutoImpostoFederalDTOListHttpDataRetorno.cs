namespace Program.Contracts.Response
{
	public class ProdutoImpostoFederalDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ProdutoImpostoFederalDTO> data { get; set; }
	}
}
