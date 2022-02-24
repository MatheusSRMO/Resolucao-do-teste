using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolução_do_teste {
    public class Verbs {

        public static int[] verbs(string[] text_list) {

            int amount_verbs = 0;
            int amount_first_person_verbs = 0;

            char[] foo_type = Program.foo_type;

            foreach (string word in text_list) {
                if (word.Trim().Length >= 8) {

                    char[] word_char_list = word.Trim().ToCharArray();
                    char first_caractere = word_char_list[0];
                    char last_caractere = word_char_list[word_char_list.Length - 1];

                    if (foo_type.Contains(last_caractere)) {
                        amount_verbs++;
                        if (!foo_type.Contains(first_caractere)) {

                            amount_first_person_verbs++;
                        }
                            
                    }
                }
            }
            
            int[] result_list = { amount_verbs, amount_first_person_verbs };
            return result_list;
        }
    }
}
