namespace Program.Contracts.Response
{
	public class SistemasDTOHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public SistemasDTO data { get; set; }
	}
}
