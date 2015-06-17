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
                Console.WriteLine("1-New Word\n2-List Words");
                int response = int.Parse(Console.ReadLine());
                if (response == 1)
                {
                    addWord(translator);
                }
                Console.Clear();
            } while (true);
        }

        static void addWord(TranslationManager translator){
            String englishWord;
            String derpishWord;

            Console.Write("Derpish word: ");
            derpishWord = Console.ReadLine();
            Console.WriteLine("\n"); 
            Console.Write("English word: ");
            englishWord = Console.ReadLine();
            Console.WriteLine("\n"); 

            Console.WriteLine("English word:" + englishWord + "\nDerpsihWord: " + derpishWord + "\n");
            Console.WriteLine("Would you like to save\n 1 - yes\n2 - no\n\n");
            int x = int.Parse(Console.ReadLine());

            if(x == 1){
                translator.addWord(new Word(derpishWord, englishWord));
            }else{
                return;
            }
        }
    }

   

}

