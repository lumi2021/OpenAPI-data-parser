namespace Program.Contracts.Response
{
	public class ParametrosDFeDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ParametrosDFeDTO> data { get; set; }
	}
}
