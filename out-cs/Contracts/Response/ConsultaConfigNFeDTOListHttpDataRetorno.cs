namespace Program.Contracts.Response
{
	public class ConsultaConfigNFeDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ConsultaConfigNFeDTO> data { get; set; }
	}
}
