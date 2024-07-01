namespace Program.Contracts.Request
{
	public class SpedPlanoContasBase
	{
		public int spedPlanoContaId { get; set; }
		public int pessoaRelacaoId { get; set; }
		public string codigoNaturezaConta { get; set; }
		public string indicadorTipoConta { get; set; }
		public string nivelConta { get; set; }
		public string codigoConta { get; set; }
		public string nomeConta { get; set; }
		public string codigoContaCorrelRFB { get; set; }
		public string grupoConta { get; set; }
	}
}
