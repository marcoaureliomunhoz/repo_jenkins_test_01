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
    }
}
