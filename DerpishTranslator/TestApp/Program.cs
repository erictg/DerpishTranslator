using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TranslatorBackend;
using TranslatorBackend.framework;
using TranslatorBackend.framework.objects;
namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TranslationManager translator = new TranslationManager();

            do
            {
                Console.WriteLine("1-New Word\n2-New phrase\n3-List Words");
                int response = int.Parse(Console.ReadLine());
                if (response == 1)
                {
                    addWord(translator);
                }
                else if (response == 2)
                {
                    addPhrase(translator);
                }
                else if (response == 3)
                {

                }
                Console.Clear();
            } while (true);
        }

        static void addWord(TranslationManager translator){
            String englishWord;
            String derpishWord;
            Case wordCase;

            Console.Write("Derpish word: ");
            derpishWord = Console.ReadLine();
            Console.WriteLine("\n"); 
            Console.Write("English word: ");
            englishWord = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("1-Noun\n2-Pronoun\n3-Verb\n4-Adjective\n5-Adverb\n6-Preposition\n7-Conjunction\n8-Interjection\n9-None\n");
            int xI = int.Parse(Console.ReadLine());
            switch (xI)
            {
                case 1:
                    wordCase = Case.Noun;
                    break;
                case 2:
                    wordCase = Case.Pronoun;
                    break;
                case 3:
                    wordCase = Case.Verb;
                    break;
                case 4:
                    wordCase = Case.Adjective;
                    break;
                case 5:
                    wordCase = Case.Adverb;
                    break;
                case 6:
                    wordCase = Case.Preposition;
                    break;
                case 7:
                    wordCase = Case.Conjunction;
                    break;
                case 8:
                    wordCase = Case.Interjection;
                    break;
                case 9:
                    wordCase = Case.None;
                    break;
                default:
                    wordCase = Case.Noun;
                    break;
            }
            Console.WriteLine("English word:" + englishWord + "\nDerpsihWord: " + derpishWord + "\nCase: " + wordCase.ToString() + "\n");
            Console.WriteLine("Would you like to save\n 1 - yes\n2 - no\n\n");
            int x = int.Parse(Console.ReadLine());

            if(x == 1){
                translator.addWord(new Word(derpishWord, englishWord, wordCase));
            }else{
                return;
            }
        }

        static void addPhrase(TranslationManager translator)
        {
            String englishWord;
            String derpishWord;
            Case wordCase;
            Console.Write("Derpish phrase: ");
            derpishWord = Console.ReadLine();
            Console.WriteLine("\n");
            Console.Write("English phrase: ");
            englishWord = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("1-Noun\n2-Pronoun\n3-Verb\n4-Adjective\n5-Adverb\n6-Preposition\n7-Conjunction\n8-Interjection\n9-None\n");
            int xI = int.Parse(Console.ReadLine());
            switch (xI)
            {
                case 1:
                    wordCase = Case.Noun;
                    break;
                case 2:
                    wordCase = Case.Pronoun;
                    break;
                case 3:
                    wordCase = Case.Verb;
                    break;
                case 4:
                    wordCase = Case.Adjective;
                    break;
                case 5:
                    wordCase = Case.Adverb;
                    break;
                case 6:
                    wordCase = Case.Preposition;
                    break;
                case 7:
                    wordCase = Case.Conjunction;
                    break;
                case 8:
                    wordCase = Case.Interjection;
                    break;
                case 9:
                    wordCase = Case.None;
                    break;
                default:
                    wordCase = Case.None;
                    break;
            }
           
            Console.WriteLine("English word:" + englishWord + "\nDerpsihWord: " + derpishWord + "Case: " + wordCase.ToString() + "\n");
            Console.WriteLine("Would you like to save\n 1 - yes\n2 - no\n\n");
            int x = int.Parse(Console.ReadLine());

            if (x == 1)
            {
                translator.addWord(new Word(derpishWord, englishWord, wordCase));
            }
            else
            {
                return;
            }
        }

        static void listWords(TranslationManager translator)
        {
            string[] letters = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "PHRASES" };

            foreach (string s in letters)
            {
                foreach (Word w in translator.words[s])
                {
                    Console.WriteLine("Derpish Word: " + w.DerpishWord + "   English Word: " + w.EnglishWord);
                }

                Console.ReadLine();
            }
        }
    }

   

}

