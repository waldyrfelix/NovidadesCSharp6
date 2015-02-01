using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace NovidadesCSharp6
{
    [TestClass]
    public class ExemploNullPropagation
    {
        [TestMethod]
        public void TesteComCandidatoComNomePreenchido()
        {
            var vaga = new Vaga
            {
                CandidatoAprovado = new Candidato
                {
                    Nome = "Baltazar"
                }
            };

            Assert.AreEqual("Baltazar", vaga.NomeDoCandidatoAprovado);
        }

        [TestMethod]
        public void TesteComCandidatoPreenchidoENomeNulo()
        {
            var vaga = new Vaga
            {
                CandidatoAprovado = new Candidato()
            };

            Assert.IsNull(vaga.NomeDoCandidatoAprovado);
        }

        [TestMethod]
        public void TesteComCandidatoNulo()
        {
            var vaga = new Vaga();

            Assert.IsNull(vaga.NomeDoCandidatoAprovado);
        }


        [TestMethod]
        public void TesteComEntrevistasPreenchidasComCandidatos()
        {
            var vaga = new Vaga
            {
                Entrevistas = new List<Entrevista>
                {
                    new Entrevista
                    {
                        Candidato = new Candidato
                        {
                            Nome = "H. Upmann"
                        },
                        Data = DateTime.Now
                    }
                }
            };

            Assert.AreEqual("H. Upmann", vaga.ObterCandidatoProximaEntrevista());
        }


        [TestMethod]
        public void TesteComEntrevistasPreenchidasComCandidatoSemNome()
        {
            var vaga = new Vaga
            {
                Entrevistas = new List<Entrevista>
                {
                    new Entrevista
                    {
                        Candidato = new Candidato(),
                        Data = DateTime.Now
                    }
                }
            };

            Assert.IsNull(vaga.ObterCandidatoProximaEntrevista());
        }

        [TestMethod]
        public void TesteComEntrevistasPreenchidasSemCandidato()
        {
            var vaga = new Vaga
            {
                Entrevistas = new List<Entrevista>
                {
                    new Entrevista
                    {
                        Data = DateTime.Now
                    }
                }
            };

            Assert.IsNull(vaga.ObterCandidatoProximaEntrevista());
        }

        [TestMethod]
        public void TesteComListaDeEntrevistasVazia()
        {
            var vaga = new Vaga
            {
                Entrevistas = new List<Entrevista>()
            };

            Assert.IsNull(vaga.ObterCandidatoProximaEntrevista());
        }

        [TestMethod]
        public void TesteComListaDeEntrevistasNula()
        {
            var vaga = new Vaga();

            Assert.IsNull(vaga.ObterCandidatoProximaEntrevista());
        }
    }

    class Vaga
    {
        public Candidato CandidatoAprovado { get; set; }
        public IEnumerable<Entrevista> Entrevistas { get; set; }

        public string NomeDoCandidatoAprovado
        {
            get
            {
                return this.CandidatoAprovado?.Nome;
            }
        }

        public string ObterCandidatoProximaEntrevista()
        {
            return this.Entrevistas
                ?.OrderByDescending(c => c.Data).FirstOrDefault()
                ?.Candidato
                ?.Nome;
        }
    }

    class Entrevista
    {
        public DateTime Data { get; set; }
        public Candidato Candidato { get; set; }
    }

    class Candidato
    {
        public string Nome { get; set; }
    }
}
