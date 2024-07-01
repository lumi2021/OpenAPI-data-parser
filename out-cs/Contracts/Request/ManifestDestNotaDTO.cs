namespace Program.Contracts.Request
{
	public class ManifestDestNotaDTO
	{
		public string cnpjCliente { get; set; }
		public string uf { get; set; }
		public string modeloNota { get; set; }
		public string tipoAmbiente { get; set; }
		public int seqEvento { get; set; }
		public string tipoEmissao { get; set; }
		public string chaveNFe { get; set; }
		public TipoEvento tipoEvento { get; set; }
		public string justificativa { get; set; }
	}
}
