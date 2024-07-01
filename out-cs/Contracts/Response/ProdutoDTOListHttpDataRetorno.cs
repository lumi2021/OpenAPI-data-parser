namespace Program.Contracts.Response
{
	public class ProdutoDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ProdutoDTO> data { get; set; }
	}
}
