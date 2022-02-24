using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Resolução_do_teste {

    
    public class Program {

        public static char[] klingon_alphabet = "kbwrqdnfxjmlvhtcgzps".ToCharArray();
        public static char[] foo_type = { 's', 'l', 'f', 'w', 'k' };

        static void Main(string[] args) {
            string text_A = get_text("https://raw.githubusercontent.com/f360-dev/provas/master/klingon-textoA.txt");
            string text_B = get_text("https://raw.githubusercontent.com/f360-dev/provas/master/klingon-textoB.txt");


            // Preposições
            int amount_prepositions = Prepositions.prepositions(text_to_list(text_B));
            Console.WriteLine($"Existem {amount_prepositions} preposições!");


            // Verbos
            int[] result_list = Verbs.verbs(text_to_list(text_B));
            Console.WriteLine($"\n\nExistem {result_list[0]} verbos!");
            Console.WriteLine($"Existem {result_list[1]} verbos em primeira pessoa!");


            // Lista de vocabulário em Klingon
            Console.WriteLine("\n\nLista de vocabulário em Klingon Texto B");
            Console.WriteLine(Vocabulary_klingon.Vocabulary_list_klingon(text_to_list(text_B)));


            // Números em Klingon
            int amount_prety_numbers = Numbers_in_klingon.Amount_pretty_numbers(text_to_list(text_B));
            Console.WriteLine($"\n\nExistem {amount_prety_numbers} números bonitos");
        }

        static string get_text(string url) {
            var request = WebRequest.Create(url);
            request.Method = "GET";

            using var webResponse = request.GetResponse();
            using var webStream = webResponse.GetResponseStream();

            using var reader = new StreamReader(webStream);
            var data = reader.ReadToEnd();
            return data;
        }

        static string[] text_to_list(string text) => text.Trim().Split(" ");
    }
}
