namespace Program.Contracts.Request
{
	public class ConsultaConfigNFeDTO
	{
		public int pessoaId { get; set; }
		public string nome { get; set; }
		public string doc { get; set; }
		public DateTime certDigitalValidade { get; set; }
		public long nFeDestUltNSU { get; set; }
		public string certDigitalStringBase64 { get; set; }
		public string senha { get; set; }
	}
}
