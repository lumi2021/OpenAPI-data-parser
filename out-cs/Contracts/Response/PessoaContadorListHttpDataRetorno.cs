namespace Program.Contracts.Response
{
	public class PessoaContadorListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PessoaContador> data { get; set; }
	}
}
