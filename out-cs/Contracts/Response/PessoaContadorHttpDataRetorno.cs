namespace Program.Contracts.Response
{
	public class PessoaContadorHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public PessoaContador data { get; set; }
	}
}
