namespace Program.Contracts.Response
{
	public class ProdImpFedInsertAllErrosDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ProdImpFedInsertAllErrosDTO> data { get; set; }
	}
}
