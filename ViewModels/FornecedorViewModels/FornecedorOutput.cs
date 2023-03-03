namespace ApiEstoque.ViewModels.FornecedorViewModels;

    public class FornecedorOutput
    {
        public FornecedorOutput(int id, string nome, string endereco, int numero, string bairro, string cep, string contato, string cnpj, string inscricao, int cidadeId)
        {
            this.Id = id;
            this.Nome = nome;
            this.Endereco = endereco;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Contato = contato;
            this.Cnpj = cnpj;
            this.Inscricao = inscricao;
            this.CidadeId = cidadeId;

        }
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Endereco { get; private set; }

        public int Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cep { get; private set; }

        public string Contato { get; private set; }

        public string Cnpj { get; private set; }

        public string Inscricao { get; private set; }

        public int CidadeId { get; private set; }
    }
