namespace Program.Contracts.Request
{
	public class ConsultaStatusDTO
	{
		public string cnpjCliente { get; set; }
		public string uf { get; set; }
		public string modeloNota { get; set; }
		public string tipoAmbiente { get; set; }
		public string tipoEmissao { get; set; }
	}
}
