using ConversorNumeros.Dominio;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConversorNumeros.Testes
{
    [TestClass]
    public class ConversorNumeroRomanoParaArabicoTest
    {
        private ConversorNumeroRomanoParaArabico _conversor;

        public ConversorNumeroRomanoParaArabicoTest()
        {
            _conversor = new ConversorNumeroRomanoParaArabico();
        }

        [TestMethod]
        [DataRow("I", 1)]
        [DataRow("II", 2)]
        [DataRow("III", 3)]
        [DataRow("IV", 4)]
        [DataRow("V", 5)]
        [DataRow("VII", 7)]
        [DataRow("IX", 9)]
        [DataRow("X", 10)]
        [DataRow("XI", 11)]
        [DataRow("XV", 15)]
        [DataRow("XIX", 19)]
        [DataRow("XX", 20)]
        [DataRow("XXI", 21)]
        [DataRow("XXX", 30)]
        [DataRow("XL", 40)]
        [DataRow("L", 50)]
        [DataRow("LX", 60)]
        [DataRow("XC", 90)]
        [DataRow("C", 100)]
        [DataRow("CDLXXX", 480)]
        [DataRow("DCXX", 620)]
        [DataRow("CM", 900)]
        [DataRow("M", 1000)]
        [DataRow("MMCDL", 2450)]

        public void Deve_converter_numeros_romanos_1_ao_3999(string numeroRomano, int resultadoEsperado)
        {
            //ação - action
            var resultado = _conversor.ConverterNumeroRomanoParaArabico(numeroRomano);

            //verificação - assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

    }
}
