namespace Program.Contracts.Response
{
	public class ContadorImpostoEstadualBaseHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public ContadorImpostoEstadualBase data { get; set; }
	}
}
