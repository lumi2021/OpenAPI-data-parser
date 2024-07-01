namespace Program.Contracts.Response
{
	public class SistemasDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<SistemasDTO> data { get; set; }
	}
}
