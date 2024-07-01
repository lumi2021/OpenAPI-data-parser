namespace Program.Contracts.Response
{
	public class ProdutoNcmBaseListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ProdutoNcmBase> data { get; set; }
	}
}
