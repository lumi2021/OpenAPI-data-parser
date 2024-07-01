namespace Program.Contracts.Response
{
	public class PeriodoBaixaXmlDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PeriodoBaixaXmlDTO> data { get; set; }
	}
}
