namespace Program.Contracts.Response
{
	public class ContadorImpostoEstadualDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public ContadorImpostoEstadualDTO data { get; set; }
	}
}
