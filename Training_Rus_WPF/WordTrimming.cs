using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WordProcessing
{
    public class ErrorSymbol
    {
        public ErrorSymbol(bool iserr)
        {
            IserrorS = iserr;
        }
        public ErrorSymbol(int SymbolNumber,char Symbol)
        {
            this.SymbolNumber = SymbolNumber;
            this.Symbol = Symbol;
        }
        public bool IserrorS { get; set; } = false;
        public int SymbolNumber { get; set; }
        public char Symbol { get; set; }
    }

    public class WordError
    {
        public WordError(int WordNumber)
        {
            this.WordNumber = WordNumber;
        }
        public bool Iserror { get; set; } = false;

        public int WordNumber { get; set; }
        public List<ErrorSymbol> SimbolError = new List<ErrorSymbol>();
    }

    public class WordTrimming
    {
        // Текста на разделение слов
        public enum TrimmingType
        {
            word = 1,
            Comma = 2
        }

        // обрезание строки на слова
        public static List<string> Trim(string text, TrimmingType Type)
        {
            Regex regex = null;

            if (Type == TrimmingType.word)
                regex = new Regex(@"[А-я_ё\‒\-\—""«»\:]+", RegexOptions.IgnoreCase);
            else if (Type == TrimmingType.Comma)
                regex = new Regex(@"[А-я,\?\.\!_ё\‒\-\—""«»\:]+", RegexOptions.IgnoreCase);
            else
            {
                Console.WriteLine("Error type Processing");
                return null;
            }
            
            List<string> set = new List<string>();
            foreach (Match match in regex.Matches(text))
            {
                set.Add(match.Value);
            }

            return set;
        }

        public static string trimLast(string text)
        {
            int SimIndex = text.Length - 1;
            text.Remove(SimIndex);
            return text;
        }

        // поиск буквенных ошибок в тексте
        public static List<WordError> SearchWordError(List<string> inputedText, List<string> OriginalText)
        {
            if (inputedText.Count != OriginalText.Count)
            {
                Console.WriteLine("error");
                return null;
            }
            List<WordError> ErrorWordList = new List<WordError>();
            //List<char> errorList = new List<char>();
            // проверка на совпадение символов
            int wordErrorCount = 0;
            int errorSimbols = 0;
            for (int i = 0; i < inputedText.Count; i++)
            {
                ErrorWordList.Add(new WordError(i));
                for (int j = 0; j < inputedText[i].Length; j++)
                {
                    ErrorWordList[wordErrorCount].SimbolError.Add(new ErrorSymbol(false));
                    if (inputedText[i][j] != OriginalText[i][j])
                    {
                        //errorList.Add(inputedText[i][j]);
                        ErrorSymbol ES = new ErrorSymbol(j, OriginalText[i][j]);
                        ErrorWordList[wordErrorCount].SimbolError[j] = ES; //add
                        ErrorWordList[wordErrorCount].Iserror = true;
                        ErrorWordList[wordErrorCount].SimbolError[j].IserrorS = true; //errorsymbol
                        errorSimbols++;
                    }
                }
                errorSimbols = 0;
                wordErrorCount++;
            }

            return ErrorWordList; 
        }

        // поиск ошибок запятых
        public static List<WordError> SearchCommaError(List<string> inputedText, List<string> OriginalText)
        {
            if (inputedText.Count != OriginalText.Count)
            {
                Console.WriteLine("error");
                //return null;
            }

            List<WordError> ErrorCommaList = new List<WordError>();

            int wordCommaCount = 0;
            for (int i = 0; i < inputedText.Count; i++)
            {
                //добавление нового объекта ошибочное слово
                ErrorCommaList.Add(new WordError(i));

                //for (int j = 0; j < inputedText[i].Length; j++)
                //{
                //OriginalText[i].Length - 1

                 
                if (inputedText[i][inputedText[i].Length -1] != OriginalText[i][OriginalText[i].Length - 1] && (OriginalText[i][OriginalText[i].Length - 1] == ','
                    || inputedText[i][inputedText[i].Length - 1] == ','))
                {
                          
                    
                        ErrorSymbol ES = new ErrorSymbol(OriginalText[i].Length - 1, OriginalText[i][OriginalText[i].Length - 1]);
                        
                        ErrorCommaList[wordCommaCount].SimbolError.Add(ES);
                        ErrorCommaList[wordCommaCount].Iserror = true;
                        ////////////////////////////////////////////
                }
             
                wordCommaCount++; 
            }
            //Console.WriteLine(ErrorCommaList[0].WordNumber + ":" + ErrorCommaList[0].SimbolError[0].SymbolNumber + ":" + ErrorCommaList[0].SimbolError[0].Symbol);
            return ErrorCommaList;
        }









        //public static List<WordError> SearchCommaError(List<string> inputedText, List<string> OriginalText)
        //{
        //    if (inputedText.Count != OriginalText.Count)
        //    {
        //        Console.WriteLine("error");
        //        //return null;
        //    }

        //    List<WordError> ErrorCommaList = new List<WordError>();

        //    int wordCommaCount = 0;
        //    for (int i = 0; i < inputedText.Count; i++)
        //    {
        //        //добавление нового объекта ошибочное слово
        //        ErrorCommaList.Add(new WordError(i));

        //        for (int j = 0; j < inputedText[i].Length; j++)
        //        {
        //            //OriginalText[i].Length - 1
        //            if (inputedText[i][j] != OriginalText[i][j] && OriginalText[i][j] == ',')
        //            {

        //                //инициализация объекта ошибочный символ и присвоение ему номер символа и сам символ
        //                //ErrorSymbol ES = new ErrorSymbol(OriginalText[i].Length - 1, OriginalText[i][OriginalText[i].Length - 1]);
        //                ErrorSymbol ES = new ErrorSymbol(j, OriginalText[i][j]);

        //                // добавление в список слов с ошибками ошибочного символа
        //                ErrorCommaList[wordCommaCount].SimbolError.Add(ES);

        //                ////////////////////////////////////////////
        //            }
        //        }
        //        wordCommaCount++;
        //    }
        //    //Console.WriteLine(ErrorCommaList[0].WordNumber + ":" + ErrorCommaList[0].SimbolError[0].SymbolNumber + ":" + ErrorCommaList[0].SimbolError[0].Symbol);
        //    return ErrorCommaList;
        //}
    }
}
