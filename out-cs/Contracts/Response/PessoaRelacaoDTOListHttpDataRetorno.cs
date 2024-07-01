namespace Program.Contracts.Response
{
	public class PessoaRelacaoDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PessoaRelacaoDTO> data { get; set; }
	}
}
