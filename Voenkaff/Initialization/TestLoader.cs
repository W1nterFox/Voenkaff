using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Voenkaff.Wrappers;

namespace Voenkaff
{
    public class TestLoader
    {
        private static Tests LoadTestsFromFile(string pathToTest)
        {
            var json = File.ReadAllText(pathToTest);
            return JsonConvert.DeserializeObject<Tests>(json);
        }

        public Tests LoadTestsFromFolder(string pathToFolder)
        {

            var result = new Tests();

            foreach (var pathToTest in GetTestFilePaths(pathToFolder))
            {
                Tests test = LoadTestsFromFile(pathToTest);
                foreach (var testResult in test.PlatoonList)
                {
                    try
                    {
                        result.PlatoonList.Add(testResult.Key, testResult.Value);
                    }
                    catch (ArgumentException)
                    {
                        result.PlatoonList.Remove(testResult.Key);
                        result.PlatoonList.Add(testResult.Key, testResult.Value);
                    }
                }
                result.TestList.AddRange(test.TestList);

                foreach (var testCourse in test.CourseList)
                {
                    
                    if (result.CourseList.Find(x => x == testCourse) == null)
                    {
                        result.CourseList.Add(testCourse);
                    }
                    
                }
                //result.CourseList.AddRange(test.CourseList);
            }

            return result;
        }

        private static IEnumerable<string> GetTestFilePaths(string pathToFolder)
        {
            var directoryInfo = new DirectoryInfo(pathToFolder);
            var testFiles = directoryInfo.GetFiles("*.test");
            return testFiles.Select(testFile => testFile.FullName);
        }
    }
}
