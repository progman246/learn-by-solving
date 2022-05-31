// See https://aka.ms/new-console-template for more information
using FileSystemProblem.Solution;

Solution solution2 = new Solution();

var path = @"c:\temp\Folder1";
var FileInfo = solution2.Getfiles(path);
var GetIndex = solution2.MakeIndex(FileInfo);

//string userInput=string.Empty;

//Console.WriteLine("Please Enter Your Words:");

//while (userInput != "END")
//{
//    userInput = Console.ReadLine();
//    var userInputs = userInput.Split(" ",StringSplitOptions.RemoveEmptyEntries);

//    if (userInputs.Length > 0)
//    {
//        foreach (string item in userInputs)
//        {

//            try
//            {
//                var indexofInput = GetIndex[item];
//                //var repeatCount = indexofInput.Select(x=>x==userInput).Count();
//                //Console.WriteLine(repeatCount);
//                int sentenceCount = solution2.ReadFileBySentence(indexofInput, item);
//                Console.WriteLine($"File:{string.Join(",", indexofInput)},Sentence:{sentenceCount}");

//            }
//            catch
//            {
//                Console.WriteLine($"Your Word {item} does not exist in documents!!!please Try another word or to Exit type END");

//            }

//        }
//    }
//    else
//    {
//        Console.WriteLine("Please Enter your words ");
//    }
//}






