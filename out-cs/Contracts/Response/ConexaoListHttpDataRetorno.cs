namespace Program.Contracts.Response
{
	public class ConexaoListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<Conexao> data { get; set; }
	}
}
