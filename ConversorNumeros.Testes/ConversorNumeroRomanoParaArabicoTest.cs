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
        [DataRow("VI", 6)]
        [DataRow("VII", 7)]
        [DataRow("VIII", 8)]
        [DataRow("IX", 9)]
        [DataRow("X", 10)]
        [DataRow("XI", 11)]
        [DataRow("XII", 12)]
        [DataRow("XIII", 13)]
        [DataRow("XIV", 14)]
        [DataRow("XV", 15)]
        [DataRow("XVI", 16)]
        [DataRow("XVII", 17)]
        [DataRow("XVIII", 18)]
        [DataRow("XIX", 19)]
        [DataRow("XX", 20)]
        [DataRow("XXI", 21)]
        [DataRow("XXX", 30)]
        [DataRow("XL", 40)]
        [DataRow("L", 50)]
        [DataRow("LX", 60)]
        [DataRow("LXII", 62)]
        [DataRow("XC", 90)]
        [DataRow("C", 100)]
        [DataRow("CLVIII", 158)]
        [DataRow("CDLXXX", 480)]
        [DataRow("DCXX", 620)]
        [DataRow("CM", 900)]
        [DataRow("M", 1000)]
        [DataRow("MCXX", 1120)]
        [DataRow("MMCDL", 2450)]
        [DataRow("MMMCMXCIX", 3999)]

        public void Deve_converter_numeros_romanos_1_ao_3999(string numeroRomano, int resultadoEsperado)
        {
            //ação - action
            var resultado = _conversor.ConverterNumeroRomanoParaArabico(numeroRomano);

            //verificação - assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [TestMethod]
        [DataRow("IIII")]
        [DataRow("IIIIV")]
        [DataRow("XXXX")]
        [DataRow("IIIIXXXX")]
        [DataRow("XXXXC")]
        [DataRow("CCCC")]
        [DataRow("CCCCM")]
        [DataRow("MMMM")]
        public void Deve_retornar_nulo_quando_receber_4_letras_iguais(string numeroRomano)
        {
            //ação - action
            var resultado = _conversor.ConverterNumeroRomanoParaArabico(numeroRomano);

            //verificação - assert
            Assert.IsNull(resultado);
        }

        [TestMethod]
        [DataRow("VV")]
        [DataRow("VVX")]
        [DataRow("LLC")]
        [DataRow("XLL")]
        [DataRow("DD")]
        [DataRow("DDC")]
        [DataRow("DDLL")]
        public void Deve_retornar_nulo_quando_receber_2_letras_v_l_ou_d_iguais(string numeroRomano)
        {
            //ação - action 
            var resultado = _conversor.ConverterNumeroRomanoParaArabico(numeroRomano);
             
            //verificação - assert
            Assert.IsNull(resultado);
        }
    }
}
