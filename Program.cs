// See https://aka.ms/new-console-template for more information


using System.Collections.Generic;

Dictionary<string, int> favoriteWords = new Dictionary<string, int>();

var text = File.ReadAllText(@"Text1.txt");
string textNoPunctuation = new string(text.Where(x => !char.IsPunctuation(x)).ToArray());
char[] decim = new char[3]{' ', '\n', '\t'};
string[] words = textNoPunctuation.Split(decim, StringSplitOptions.RemoveEmptyEntries);



foreach (string word in words)
{   
    var newword = word.ToLower().TrimEnd();
    if (favoriteWords.ContainsKey(newword))
    {
        favoriteWords[newword] += 1;
    }
    else
    {
        favoriteWords.Add(newword, 1);
    }

}

var ordered = favoriteWords.OrderByDescending(x => x.Value).Take(10);



foreach (var word in ordered){
    Console.WriteLine(word.Key + " Количество повторений: " +  word.Value);
}