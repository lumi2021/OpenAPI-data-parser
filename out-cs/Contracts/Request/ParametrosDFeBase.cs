namespace Program.Contracts.Request
{
	public class ParametrosDFeBase
	{
		public int parametroDFeId { get; set; }
		public int pessoaRelacaoId { get; set; }
		public int numeroCaixa { get; set; }
		public int serie { get; set; }
		public string tipoNf { get; set; }
		public int numeroNf { get; set; }
		public bool tef { get; set; }
		public int tokenNfceId { get; set; }
		public string nomeComputador { get; set; }
	}
}
