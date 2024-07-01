namespace Program.Contracts.Response
{
	public class PessoaRelacaoTipoDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PessoaRelacaoTipoDTO> data { get; set; }
	}
}
