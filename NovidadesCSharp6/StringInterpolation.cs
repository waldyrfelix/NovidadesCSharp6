using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NovidadesCSharp6
{
    [TestClass]
    public class StringInterpolation
    {
        [TestMethod]
        public void TesteInterpolaçãoSimples()
        {
            const string nome = "Maria";
            var str = $"{nome} comprou pão.";

            Assert.AreEqual("Maria comprou pão.", str);
        }


        [TestMethod]
        public void TesteInterpolaçãoComFormatação()
        {
            var p = new Produto
            {
                Nome = "Colírio",
                Preço = 25.9m,
                SKU = 123
            };

            var sentença = $"{p.Nome} ({p.SKU :d5}) - VLR: {p.Preço :n2}";
            // Colírio (00123) - VLR: 25.90

            Assert.AreEqual("Colírio (00123) - VLR: 25.90", sentença);
        }


        [TestMethod]
        public void TesteInterpolaçãoComData()
        {
            var p = new Produto
            {
                Nome = "Mouse"
            };

            var sentença = $"Meu {{{p.Nome}}} pifou as {DateTime.Now :t}.";
            // sentença: Meu {Mouse} pifou as 12:34.

            Assert.AreEqual("Meu {Mouse} pifou as " + DateTime.Now.ToShortTimeString() + ".", sentença);
        }


        [TestMethod]
        public void TesteInterpolaçãoComExpressões()
        {
            var p = new Produto
            {
                Nome = "Post It",
                Preço = 4.5m
            };

            var sentença = $"{p.Nome} {p.Preço:c} {(p.Preço < 10 ? "promoção!" : "" )}";
            // sentença: Post It $4.50 promoção!

            Assert.AreEqual("Post It $4.50 promoção!", sentença);
        }
    }

    public class Produto
    {
        public int SKU { get; set; }
        public string Nome { get; set; }

        public decimal Preço { get; set; }
    }
}
