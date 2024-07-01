namespace Program.Contracts.Request
{
	public class NFeInutNF
	{
		public string cnpjCliente { get; set; }
		public string tipoAmbiente { get; set; }
		public string uf { get; set; }
		public string modeloDoc { get; set; }
		public int numFaixaInicial { get; set; }
		public int numFaixaFinal { get; set; }
		public string serieNF { get; set; }
		public int ano { get; set; }
		public string justificativa { get; set; }
	}
}
