using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslatorBackend.framework.objects
{
    public class Word
    {
        public String DerpishWord { get; protected set; }
        public String EnglishWord { get; protected set; }
        public Case wordCase { get; private set; }
        public String Id { get; private set; }

        public Word()
        {
            DerpishWord = "";
            EnglishWord = "";
            wordCase = Case.Noun;
            Id = generateHexValue();
        }

        public Word(String _derpWord, String _englishWord, Case _wordCase)
        {
            DerpishWord = _derpWord;
            EnglishWord = _englishWord;
            Id = generateHexValue();
            wordCase = _wordCase;
        }


        private String generateHexValue()
        {
            Random random = new Random();
            int num = random.Next();
            return num.ToString("X");
        }
    }
}
