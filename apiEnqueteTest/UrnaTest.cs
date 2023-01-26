using APIEnquete.src.Entities;
using Xunit;

namespace apiEnqueteTest
{
    public class UrnaTest
    {
        [Fact]
        public void PossivelAdicionarVoto()
        {
            Urna urna = new Urna("UrnaTeste", new string[] { "opcao1", "opcao2" });
            int id = 1;
            urna.AdicionarVoto(id);

            Assert.Equal(urna.OpcoesEnquete.FirstOrDefault(x=>x.ID == id).votos,1);
        }


    }
}