using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resolução_do_teste {
    public class Vocabulary_klingon {
        public static string Vocabulary_list_klingon(string[] text_list) {

            string ordered_text = "";

            for (var i = 0; i < text_list.Length; i++) {

                // do elemento em questão até o primeiro, colocando na ordem
                for (int x = i; x > 0; x--) {

                    string current_element = text_list[x].Trim();
                    string previous_element = text_list[x - 1].Trim();

                    int word_Size = Comparate(current_element, previous_element);

                    // se esta com a ordem trocada, realizar a permuta

                    if (word_Size > 0) {

                        text_list[x] = previous_element;
                        text_list[x - 1] = current_element;
                    }

                    // quando as palavras se parecem, ordenar pelo menor
                    else if (word_Size == 0) {

                        text_list[x] = current_element.Length <= previous_element.Length ? previous_element : current_element;
                        text_list[x - 1] = current_element.Length > previous_element.Length ? previous_element : current_element;
                    }
                }
            }

            // Verifica se a palavra está na lista ordenada, se não estiver, adiciona e soma a string
            List<string> text_read_read = new List<string>();
            foreach (string word in text_list) {
                if (!text_read_read.Contains(word)){
                    text_read_read.Add(word);
                    ordered_text += $"{word} ";
                }
            }

            return ordered_text;
        }

        public static int Comparate(string first_word, string second_word) {

            char[] klingon_alphabet = Program.klingon_alphabet;

            char[] first_word_char_list = first_word.ToCharArray();
            char[] second_word_char_list = second_word.ToCharArray();

            int lower_lenght = first_word_char_list.Length <= second_word_char_list.Length ? first_word_char_list.Length : second_word_char_list.Length;

            int x = 0;
            while (x < lower_lenght && first_word_char_list[x] == second_word_char_list[x]) {
                x++;
            }

            if (first_word == second_word || x == lower_lenght) return 0; // são iguais ou muito parecidos

            // maior que zero se primeira palavra esta depois da segunda, menor que zero caso o contrario 

            x = x == lower_lenght ? x - 1 : x;
            int indice_first_word = get_indice(klingon_alphabet, first_word_char_list[x]);
            int indice_second_word = get_indice(klingon_alphabet, second_word_char_list[x]);

            return indice_second_word - indice_first_word;
        }

        public static int get_indice(char[] array, char element) {

            int indice = -1;

            for (int i = 0; i < array.Length; i++) {

                if (array[i] == element) {
                    indice = i;
                    break;
                }
            }

            return indice;
        }
    }
}
