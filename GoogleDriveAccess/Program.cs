using Google.Apis.Upload;
using GoogleDriveAccess.Properties;
using System;
using System.IO;

namespace GoogleDriveAccess
{
    public class Program
    {

        static void Main(string[] args)
        {
            GoogleDriveAccessService gda = new GoogleDriveAccessService("Drive API .NET SystemNote");
            String fileID = gda.GetFileID("SystemNote.xml");

            if (String.IsNullOrEmpty(fileID))
            {
                using(MemoryStream memoryStream = new MemoryStream(Resources.credentials))
                {
                    fileID = gda.Create(memoryStream, "SystemNote.xml", "application/json");
                    Console.WriteLine("{0} ({1})", "SystemNote", fileID);

                }
            }
            using (MemoryStream memoryStream = new MemoryStream(Resources.credentials))
            {
                fileID = gda.Update(fileID, memoryStream, "SystemNote.xml", "application/json");
                Console.WriteLine("{0} ({1})", "SystemNote", fileID);

            }


            Console.WriteLine("{0} ({1})", "SystemNote", gda.GetFileID("SystemNote.xml"));
            Console.WriteLine("終了");

            Console.Read();
        }
    }
}
