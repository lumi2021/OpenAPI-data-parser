namespace Program.Contracts.Response
{
	public class PessoaRelacaoGrupoDTOListHttpDataRetorno
	{
		public bool sucesso { get; set; }
		public string message { get; set; }
		public List<PessoaRelacaoGrupoDTO> data { get; set; }
	}
}
