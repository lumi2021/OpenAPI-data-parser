namespace Program.Contracts.Response
{
	public class PessoaContadorClienteListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PessoaContadorCliente> data { get; set; }
	}
}
