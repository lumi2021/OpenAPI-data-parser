namespace Program.Contracts.Request
{
	public class AtualizarCertDigDTO
	{
		public string cnpjPessoa { get; set; }
		public string certDigitalStringBase64 { get; set; }
		public string senha { get; set; }
	}
}
