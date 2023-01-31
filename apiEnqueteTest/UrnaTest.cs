using APIEnquete.src.Entities;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Engine.ClientProtocol;
using Xunit;
using Xunit.Sdk;

namespace apiEnqueteTest
{
    public class UrnaTest
    {
        public AsyncTestSyncContext TestExecutionContext { get; set; } 
        [Fact]
        public void PossivelAdicionarVoto()
        {
            
            Urna urna = new Urna("UrnaTeste", new string[] { "opcao1", "opcao2" });
            int id = 1;
            urna.AdicionarVoto(id);

            Assert.Equal(urna.OpcoesEnquete.FirstOrDefault(x=>x.ID == id).votos,1);
        }
        [Fact]
        public void ImpossivelAdicionarVoto()
        {

            Urna urna = new Urna("UrnaTeste", new string[] { "opcao1", "opcao2" });
            var antesdoVoto = urna.TotalDeVotos;
            int id = 3;
            urna.AdicionarVoto(id);
            var depoisdoVoto = urna.TotalDeVotos;
            Assert.Equal(antesdoVoto,depoisdoVoto);
        }
        [Fact]
        public void PossivelSerializar()
        {
            Urna urna = new Urna("UrnaTeste", new string[] { "opcao1", "opcao2" });
            bool chamada;
            chamada = urna.SerializarXml(urna);
            
            Assert.True(chamada);
        }
        [Fact]
        public void ImpossivelSerializarPorNome()
        {
            Urna urna = new Urna("", new string[] { "opcao1", "opcao2" });
            bool chamada;
            chamada = urna.SerializarXml(urna);
            Assert.False(chamada);
        }
        [Fact]
        public void ImpossivelSerializarPorOpcao()
        {
            Urna urna = new Urna("UrnaTeste", new string[] { "opcao1", "" });
            bool chamada;
            chamada = urna.SerializarXml(urna);
            Assert.False(chamada);
        }

        [Fact]
        public void PossivelDesserializar()
        {
            string caminho = Path.Combine(Directory.GetCurrentDirectory(), "Enquetes", "UrnaTeste");
            Urna urna = Urna.DesserializarXml<Urna>(caminho);
            

            
            Assert.Equal(urna.NomeEnquete, "UrnaTeste");
        }
        [Fact]
        public void ImpossivelDesserializarPorNomeErrado()
        {
            string caminho = Path.Combine(Directory.GetCurrentDirectory(), "Enquetes", "UrnaTeste2");
            Urna urna = Urna.DesserializarXml<Urna>(caminho);


            Assert.Null(urna);
        }
    }
}