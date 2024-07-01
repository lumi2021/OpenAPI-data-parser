namespace Program.Contracts.Request
{
	public class ConsultaProtocoloDTO
	{
		public string cnpjCliente { get; set; }
		public string uf { get; set; }
		public string modeloNota { get; set; }
		public string tipoAmbiente { get; set; }
		public string chaveNFe { get; set; }
		public string tipoEmissao { get; set; }
	}
}
