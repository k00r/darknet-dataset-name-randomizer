using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace darknetDatasetNameRandomizer
{
    class Program
    {
        static void Main()
        {
            string datasetOldPath = "";
            string datasetNewPath = "";
			
            DirectoryInfo d = new DirectoryInfo(datasetOldPath);
            FileInfo[] images = d.GetFiles("*.jpg");
            FileInfo[] textFiles = d.GetFiles("*.txt");

            foreach (FileInfo image in images)
            {
                string imagePath = image.FullName;
                string imageName = Path.GetFileNameWithoutExtension(imagePath);

                foreach (FileInfo textFile in textFiles)
                {
                    string textFilePath = textFile.FullName;
                    string textFileName = Path.GetFileNameWithoutExtension(textFilePath);

                    if (textFileName == imageName)
                    {
                        string myGuid = Guid.NewGuid().ToString();
                        File.Move(imagePath,datasetNewPath + "\\" + myGuid + ".jpg");
                        File.Move(textFilePath, datasetNewPath + "\\" + myGuid + ".txt");
                        break;
                    }
                }
            }
        }
    }
}
