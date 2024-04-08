namespace GenericApi.Domain;

public class Cards
{
    public string id { get; set; }
    public string idCartao { get; set; }
    public string titular { get; set; }
    public string idPessoa { get; set; }
    public string sequencialCartao { get; set; }
    public string idEmissor { get; set; }
    public string idConta { get; set; }
    public string idProduto { get; set; }
    public string cartaoVirtual { get; set; }
    public string statusCartao { get; set; }
    public string dataStatusCartao { get; set; }
    public string estagioCartao { get; set; }
    public string dataEstagioCartao { get; set; }
    public string numeroBin { get; set; }
    public string numeroCartaoHash { get; set; }
    public string dataEmissao { get; set; }
    public string dataValidade { get; set; }
    public string dataImpressao { get; set; }
    public string nomeArquivoImpressao { get; set; }
    public string nomeImpresso { get; set; }
}