using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NovidadesCSharp6
{
    [TestClass]
    public class ExpressionBodied
    {
        [TestMethod]
        public void TesteCalculoDeImposto()
        {
            const decimal taxa = 0.16m;
            const decimal custo = 1000;
            const decimal valor = 1500;

            var projeto = new Projeto(custo, valor);
            var impostos = projeto.CalularImpostos(taxa);

            Assert.AreEqual(240m, impostos);
        }


        [TestMethod]
        public void TesteCalculoDeLucro()
        {
            const decimal taxa = 0.16m;
            const decimal custo = 800;
            const decimal valor = 1500;

            var projeto = new Projeto(custo, valor);
            var lucro = projeto.CalcularLucro(taxa);

            Assert.AreEqual(460m, lucro);
        }

        [TestMethod]
        public void TestePropriedadeMargem()
        {
            const decimal custo = 800;
            const decimal valor = 1500;

            var projeto = new Projeto(custo, valor);

            Assert.AreEqual(0.27m, projeto.Margem);
        }
    }

    public class Projeto
    {
        public Projeto(decimal custo, decimal valorTotal)
        {
            this.Custo = custo;
            this.ValorTotal = valorTotal;
        }

        public decimal Custo { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal Margem => Math.Round(CalcularLucro(0.2m) / ValorTotal, 2);

        public decimal CalularImpostos(decimal taxa) => ValorTotal * taxa;

        public decimal CalcularLucro(decimal taxa) => ValorTotal - CalularImpostos(taxa) - Custo;


    }


}

