namespace Program.Contracts.Request
{
	public class ContadorImpostoEstadualBase
	{
		public int pessoaRelacaoId { get; set; }
		public string uf { get; set; }
		public int crt { get; set; }
		public bool consumidorFinal { get; set; }
		public bool industria { get; set; }
		public string cstIcms { get; set; }
		public double aliqIcms { get; set; }
		public double percMva { get; set; }
		public double percRedBci { get; set; }
		public string cfop { get; set; }
		public int produtoContadorImpostoEstadualId { get; set; }
		public int produtoId { get; set; }
		public int ncmid { get; set; }
	}
}
