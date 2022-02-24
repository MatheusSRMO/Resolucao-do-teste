using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolução_do_teste {
    public class Prepositions {

        public static int prepositions(string[] text_list) {
            int amount_prepositions = 0;


            foreach (string word in text_list) {
                char[] word_char_list = word.ToCharArray();

                char last_caractere = word_char_list[word.Length - 1];

                // Verificar se a palavra tem 3 letras, que termine no tipo bar (ou seja, que NÂO contenha no foo_type) e que não contenha a letra "d"
                if (word.Length == 3 && !Program.foo_type.Contains(last_caractere) && !word.Contains('d')) {

                    amount_prepositions++;
                }
            }


            return amount_prepositions;
        }
    }
}
