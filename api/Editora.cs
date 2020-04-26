using System;
using System.Security.Cryptography;

namespace biblio_api {
    public class Editora
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }

        protected Editora()
        {
        }

        public Editora(string nome)
        {
            var provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[4];
            provider.GetBytes(byteArray);
            Id = BitConverter.ToInt32(byteArray, 1);

            //var r = new Random();
            //Id = r.Next() + 1;
            Nome = nome?.Trim();
        }

        public void AlterarNome(string nome)
        {
            Nome = nome?.Trim();
        }
    }
}