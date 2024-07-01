namespace Program.Contracts.Response
{
	public class ContadorImpEstInsertAllErrosDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ContadorImpEstInsertAllErrosDTO> data { get; set; }
	}
}
