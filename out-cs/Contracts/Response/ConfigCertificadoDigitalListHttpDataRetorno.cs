namespace Program.Contracts.Response
{
	public class ConfigCertificadoDigitalListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<ConfigCertificadoDigital> data { get; set; }
	}
}
