namespace Program.Contracts.Response
{
	public class ProdutoInsertAllErrosDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ProdutoInsertAllErrosDTO> data { get; set; }
	}
}
