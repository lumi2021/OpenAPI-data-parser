namespace Program.Contracts.Response
{
	public class ProdImpEstInsertAllErrosDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ProdImpEstInsertAllErrosDTO> data { get; set; }
	}
}
