using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NovidadesCSharp6
{
    [TestClass]
    public class ExceptionFilters
    {
        [TestMethod]
        public void TesteUtilizandoInnerException()
        {
            try
            {
                throw new Exception("Erro com inner exception", new Exception("Erro anterior"));
            }
            catch (Exception e) when (e.InnerException != null)
            {
                Assert.AreEqual("Erro com inner exception", e.Message);
                Assert.AreEqual("Erro anterior", e.InnerException.Message);
            }
            catch (Exception e)
            {
                Assert.Fail("Falha no teste");
            }
        }


        [TestMethod]
        public void TesteSemInnerException()
        {
            try
            {
                throw new Exception("Erro sem inner exception");
            }
            catch (Exception e) when (e.InnerException != null)
            { 
                Assert.Fail("Falha no teste");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Erro sem inner exception", e.Message);
            }
        }
    }
}
