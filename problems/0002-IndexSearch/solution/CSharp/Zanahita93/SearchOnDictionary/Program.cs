// See https://aka.ms/new-console-template for more information


using System.Diagnostics;


Console.WriteLine("Enter the PathsFile path :");
var pathFilePath = Console.ReadLine();


Console.WriteLine("Enter the input path :");
var inputPath = Console.ReadLine();


Console.WriteLine("Enter the output path:");
var outputPath = Console.ReadLine();

//Read the path and their index File
var pathsFile = File.ReadAllLines(pathFilePath);

//make the dictionary
IDictionary<string, Tuple<string, List<string>>> DocSentences = new Dictionary<string, Tuple<string, List<string>>>();

Char[] delimiters = { '.', '!', '?' };

foreach (var path in pathsFile)
{
    //spliting the paths and their index 
    var pathFileArr = path.Split('|');


    var docContext = File.ReadAllLines(pathFileArr[0]);
    List<string> Sentences = new List<string>();
    foreach (var Line in docContext)
    {
        var pathLines = Line.Split(delimiters);
        foreach (var pathLine in pathLines)
        {
            Sentences.Add(pathLine);
        }
    }

    var dicTuple = Tuple.Create(pathFileArr[0], Sentences);
    DocSentences.Add(pathFileArr[1], dicTuple);
}


for (; ;)
{
    //Get the word
    Console.WriteLine("Enter the input word:");
    var enteredWord = Console.ReadLine();
    if (enteredWord == "END")
    {
        break;
    }

    List<string> allIndexs = new List<string>();

    //spliting the word
    var enteredSplitedWords = enteredWord.Split(' ');

    foreach (string word in enteredSplitedWords)
    {
        string inputRelatedFiles = Directory.GetFiles(inputPath).FirstOrDefault(x => x.Contains(word.Substring(0, 1).ToUpper())).ToString();
        var inputFIleRead = File.ReadAllLines(inputRelatedFiles).FirstOrDefault(x => x.Contains(word)).Split('|');
        var indexs = inputFIleRead[1].Split(',');
        foreach (string index in indexs)
        {
            allIndexs.Add(index);
        }
    }

    IEnumerable<string> commonIndexs = new List<string>();
    if (allIndexs.Count > 1)
    {
        commonIndexs = allIndexs.GroupBy(x => x).SelectMany(g => g.Skip(enteredSplitedWords.Count() - 1));
    }
    else
    {
        commonIndexs = allIndexs;
    }

    foreach (var index in commonIndexs)
    {
        List<string> allSentences = new List<string>();
        foreach (string word in enteredSplitedWords)
        {
            var sentences = DocSentences[index].Item2.Where(x => x.Contains(word)).ToList();
            foreach (var sentence in sentences)
            {
                allSentences.Add(sentence);
            }
        }

        IEnumerable<string> commonSentences = new List<string>();

        if (allSentences.Count > 1)
        {
            commonSentences = allSentences.GroupBy(x => x).SelectMany(g => g.Skip(enteredSplitedWords.Count() - 1));
        }
        else
        {
            commonSentences = allSentences;
        }

        if (!File.Exists($"{outputPath}\\Output.dic"))
        {
            using (StreamWriter pth = new StreamWriter($"{outputPath}\\Output.dic"))
            {
                pth.WriteLine($"< --Search results for '{enteredWord}'-- >");
                pth.WriteLine("");
                pth.WriteLine($"File: '{Path.GetFileName(DocSentences[index].Item1)}', Sentences {commonSentences.Count()}");
                foreach (var sentence in commonSentences)
                {
                    pth.WriteLine($"{sentence.ToString()}");
                }
                pth.WriteLine("");
                pth.WriteLine("");
            }
        }
        else
        {
            using (StreamWriter pth = File.AppendText($"{outputPath}\\Output.dic"))
            {
                pth.WriteLine($"< --Search results for '{enteredWord}'-- >");
                pth.WriteLine("");
                pth.WriteLine($"File: '{Path.GetFileName(DocSentences[index].Item1)}', Sentences {commonSentences.Count()}");
                foreach (var sentence in commonSentences)
                {
                    pth.WriteLine($"{sentence.ToString()}");
                }
                pth.WriteLine("");
                pth.WriteLine("");
            }
        }
    }
}


