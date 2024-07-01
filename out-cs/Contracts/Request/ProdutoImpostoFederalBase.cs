namespace Program.Contracts.Request
{
	public class ProdutoImpostoFederalBase
	{
		public int pessoaRelacaoId { get; set; }
		public string cstPisCofins { get; set; }
		public double aliqPis { get; set; }
		public double aliqCofins { get; set; }
		public double aliqIpi { get; set; }
		public string cstIpi { get; set; }
		public int naturezaReceitaId { get; set; }
		public int produtoImpostoFederalId { get; set; }
		public int produtoId { get; set; }
		public int ncmid { get; set; }
	}
}
