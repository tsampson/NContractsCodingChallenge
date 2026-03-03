namespace CodingChallenge.PirateSpeak;

public class PirateSpeak
{
    public string[] GetPossibleWords(string pirateWord, string[] possibleWords)
    {
        var AlphabetizedPirateWord = new string(pirateWord.OrderBy(x => x).ToArray());
        var orderedWords = possibleWords
            .Select(word => new 
            { 
                Word = word, 
                AlphabetizedWord = new string(word.OrderBy(x => x).ToArray()) 
            });

        return orderedWords
            .Where(x => x.AlphabetizedWord == AlphabetizedPirateWord)
            .Select(x => x.Word)
            .ToArray();
    }
}