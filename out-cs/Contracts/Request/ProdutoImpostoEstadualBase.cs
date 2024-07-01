namespace Program.Contracts.Request
{
	public class ProdutoImpostoEstadualBase
	{
		public int pessoaRelacaoId { get; set; }
		public string cstIcms { get; set; }
		public double aliqIcms { get; set; }
		public double percMva { get; set; }
		public double percRedBci { get; set; }
		public string cfop { get; set; }
		public bool consumidorFinal { get; set; }
		public int produtoImpostoEstadualId { get; set; }
		public int produtoId { get; set; }
	}
}
