namespace Program.Contracts.Request
{
	public class ConsultaCadContribDTO
	{
		public string cnpjCliente { get; set; }
		public string uf { get; set; }
		public string modeloNota { get; set; }
		public string tipoAmbiente { get; set; }
		public string numDoc { get; set; }
		public TipoDoc tipoDoc { get; set; }
	}
}
