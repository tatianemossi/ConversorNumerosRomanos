using System;
using System.Collections.Generic;

namespace ConversorNumeros.Dominio
{
    public class ConversorNumeroRomanoParaArabico
    {
        private Dictionary<string, int> _dicionarioLetras;
        private int _numeroArabico = 0;
        private int _contadorLetra3 = 0;
        private int _contadorLetra2 = 0;
        private string _letraAnterior;

        public ConversorNumeroRomanoParaArabico()
        {
            _dicionarioLetras = new Dictionary<string, int>
            {
                ["I"] = 1,
                ["V"] = 5,
                ["X"] = 10,
                ["L"] = 50,
                ["C"] = 100,
                ["D"] = 500,
                ["M"] = 1000
            };
        }

        public int? ConverterNumeroRomanoParaArabico(string numeroRomano)
        {
            var listaNumeroRomano = numeroRomano.ToCharArray();

            for (int i = 0; i < listaNumeroRomano.Length; i++)
            {
                var letraAtual = listaNumeroRomano[i].ToString();

                if (_letraAnterior != null)
                {
                    if ((letraAtual == "V" || letraAtual == "X" || letraAtual == "C") && _letraAnterior == "I")
                        _numeroArabico = _numeroArabico - _dicionarioLetras[_letraAnterior];

                    else if ((letraAtual == "L" || letraAtual == "C") && _letraAnterior == "X")
                        _numeroArabico = _numeroArabico - _dicionarioLetras[_letraAnterior];

                    else if ((letraAtual == "D" || letraAtual == "M") && _letraAnterior == "C")
                        _numeroArabico = _numeroArabico - _dicionarioLetras[_letraAnterior];

                    else
                        _numeroArabico = _numeroArabico + _dicionarioLetras[_letraAnterior];
                }

                if (_letraAnterior != letraAtual)
                {
                    _contadorLetra2 = 0;
                    _contadorLetra3 = 0;
                }

                _letraAnterior = letraAtual;

                if (ValidarLetraComAte3Repeticoes(_letraAnterior, ref _contadorLetra3) == false)
                    return null;
                else if (ValidarLetraCom2Repeticoes(_letraAnterior, ref _contadorLetra2) == false)
                    return null;
            }

            return _numeroArabico = _numeroArabico + _dicionarioLetras[_letraAnterior];
        }

        private bool ValidarLetraComAte3Repeticoes(string letra, ref int contadorLetra)
        {
            if (letra == "I" || letra == "X" || letra == "C" || letra == "M")
                contadorLetra++;

            if (contadorLetra > 3)
                return false;

            return true;
        }

        private bool ValidarLetraCom2Repeticoes(string letra, ref int contadorLetra)
        { 
            if (letra == "V" || letra == "L" || letra == "D")
                contadorLetra++;

            if (contadorLetra > 1)
                return false;

            return true;
        }
    }
}
