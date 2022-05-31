using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileSystemProblem.Solution
{
    public class Solution
    {
        public IEnumerable<string> Getfiles(string SourceFolder)
        {
            var files = Directory.GetFiles(SourceFolder, "*.txt", SearchOption.AllDirectories);
            return files;
        }

        public Dictionary<string, IList<string>> MakeIndex(IEnumerable<string> files)
        {
            Dictionary<string, IList<string>> result = new Dictionary<string, IList<string>>();
            foreach (var item in files)
            {
                using (var reader = new StreamReader(item))
                {
                    var line = reader.ReadLine();
                    var words = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    foreach (var word in words)
                    {
                        if (result.ContainsKey(word))
                        {
                            var fileIndex = result[word];
                            fileIndex.Add(item);
                        }
                        else
                        {
                            List<string> fileReffrence = new List<string>();
                            fileReffrence.Add(item);
                            result.Add(word, fileReffrence);

                        }
                    }

                }
            }
            return result;
        }

    //    public int ReadFileBySentence(IEnumerable<string> files,string word)
    //    {
           
    //        int wordCounter = 0;
    //        foreach (var item in files)
    //        {
    //            using (var reader = new StreamReader(item))
    //            {
                    
    //                var line = reader.ReadLine();
    //                var Sentences = line.Split(".", StringSplitOptions.RemoveEmptyEntries);
    //                foreach (var sentence in Sentences)
    //                {
    //                    if (sentence.Contains(word))
    //                    {
    //                        wordCounter++;
    //                    }
    //                }

    //            }
    //        }
    //        return wordCounter;
    //    }


    }
}
