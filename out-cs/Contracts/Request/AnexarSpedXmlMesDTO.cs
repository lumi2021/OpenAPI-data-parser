namespace Program.Contracts.Request
{
	public class AnexarSpedXmlMesDTO
	{
		public int ano { get; set; }
		public int mes { get; set; }
		public string cnpj { get; set; }
		public List<Arquivo> arquivos { get; set; }
	}
}
