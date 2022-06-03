using System;
using System.Collections.Generic;

namespace ConversorNumeros.Dominio
{
    public class ConversorNumeroRomanoParaArabico
    {
        private Dictionary<string, int> _dicionarioLetras;
        private int _numeroArabico = 0;
        private int _contadorLetraI = 0;
        private int _contadorLetraX = 0;
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

                _letraAnterior = letraAtual;

                if (ValidarLetraI(_letraAnterior, _contadorLetraI) == false)
                    return null;
            }

            return _numeroArabico = _numeroArabico + _dicionarioLetras[_letraAnterior];
        }

        private bool ValidarLetraI(string letra, int contadorLetra)
        {
            if (letra == "I")
                contadorLetra++;

            if (contadorLetra > 3)
                return false;
            return true;
        }
    }
}
