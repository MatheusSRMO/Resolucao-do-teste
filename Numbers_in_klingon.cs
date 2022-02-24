using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Resolução_do_teste {
    public class Numbers_in_klingon {

        static char[] klingon_alphabet = Program.klingon_alphabet;
        /*
        São números de base 20, cada letra é um número
        Menos significativo para mais (inverso do nosso)
        Primeira posição = unidade, Segunda = 20 e terceira = 400

        Os valores das letras são dados pela ordem em que eleas aparecem no alfabeto
        Ou seja, a primeira letra do alfabeto é 0, segunda é 1 (indice do array)

        Fórmula geral: Un*20^n + U(n+1)*20^(n+1) + U(n+2)*20^(n+2) + U(n+3)*20^(n+3) + ... +  Um*20^m
        onde U é o número, n o número da casa e m é o ultimo número. 

        OBS: os números nesse problema podem ser grandes, então se você está usando um tipo de dados de tamanho limitado, 
        tenha cuidado com possíveis overflows. <- IMPORTANTE

        Os Klingons consideram um número bonito se ele satisfaz essas duas propriedades:

        - é maior ou igual a 440566
        - é divisível por 3

        */
        public static int Amount_pretty_numbers(string[] text_list) {

            int amount_prety_numbers = 0;
            List<BigInteger> prety_numbers_read = new List<BigInteger>();

            foreach (string word in text_list) {
                string word_clear = word.Trim();
                char[] word_list = word_clear.ToCharArray();

                BigInteger number_klingon = 0;
                for(int i = 0; i < word_list.Length; i++) {
                    int number_value = Vocabulary_klingon.get_indice(klingon_alphabet, word_list[i]);
                    BigInteger _sqrt = Convert.ToInt64(Math.Pow(20, i));
                    number_klingon += number_value * _sqrt;
                }
                
                if(number_klingon >= 440566 && number_klingon % 3 == 0 && !prety_numbers_read.Contains(number_klingon)) {
                    amount_prety_numbers++;
                }
            }
            
            return amount_prety_numbers;
        }
    }
}
