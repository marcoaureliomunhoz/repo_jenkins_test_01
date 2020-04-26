using System;
using biblio_api;
using Xunit;

namespace biblio_test
{
    public class EditoraTest
    {
        public EditoraTest()
        {
        }

        [Fact]
        public void DeveCriarEditora()
        {
            var nome = "novatec";
            var editora = new Editora(nome);

            Assert.Equal(nome, editora.Nome);
            Assert.NotEqual(0, editora.Id);
        }

        [Fact]
        public void DeveAlterarEditora()
        {
            var nome = "novatec";
            var editora = new Editora(nome);
            var novoNome = "novatec2";
            editora.AlterarNome(novoNome);

            Assert.Equal(novoNome, editora.Nome);
        }

        [Fact]
        public void DeveRemoverEspacosEmBranco()
        {
            var nome = "novatec";
            var editora = new Editora(nome);
            var novoNomeComEspacosEmBranco = "novatec2   ";
            var novoNomeSemEspacosEmBranco = "novatec2";
            editora.AlterarNome(novoNomeComEspacosEmBranco);

            Assert.Equal(novoNomeSemEspacosEmBranco, editora.Nome);
        }
    }
}
