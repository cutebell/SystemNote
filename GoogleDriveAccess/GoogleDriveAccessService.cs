using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;
using Google.Apis.Upload;
using Google.Apis.Util.Store;
using GoogleDriveAccess.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GoogleDriveAccess
{
    public class GoogleDriveAccessService
    {
        private String ApplicationName;
        private static string[] Scopes = { DriveService.Scope.DriveFile};
        /// <summary>
        /// googleDriveアクセスサービス
        /// </summary>
        public DriveService DriveService;

        public GoogleDriveAccessService(String applicationName)
        {
            this.ApplicationName = applicationName;

            this.DriveService = this.Login();
        }

        /// <summary>
        /// GoogleDriveにログインする
        /// </summary>
        /// <returns></returns>
        public DriveService Login()
        {
            UserCredential credential;
            using (MemoryStream memoryStrem = new MemoryStream(Resources.credentials))
            {
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                                    GoogleClientSecrets.Load(memoryStrem).Secrets,
                                    GoogleDriveAccessService.Scopes,
                                    "user",
                                    CancellationToken.None,
                                    new FileDataStore(Settings.Default.CredPath, true)).Result;
            }

            BaseClientService.Initializer initializer = new BaseClientService.Initializer() {
                HttpClientInitializer = credential,
                ApplicationName = this.ApplicationName,
            };

            return new DriveService(initializer);
        }

        /// <summary>
        /// googleDrive上のファイルIDを取得する
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public String GetFileID(String fileName)
        {
            string nextPageToken = null;
            do
            {
                FilesResource.ListRequest request = this.DriveService.Files.List();
                request.PageToken = nextPageToken;
                request.Q = String.Format("name = '{0}'", fileName);
                request.Fields = "nextPageToken, files(id, name)";
                var result = request.Execute();
                if (result.Files.Count > 0)
                {
                    return result.Files[0].Id;
                }
                nextPageToken = result.NextPageToken;
            } while (!string.IsNullOrEmpty(nextPageToken));

            return String.Empty;
        }

        /// <summary>
        /// GoogleDrive上にファイルを新規作成する
        /// </summary>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public String Create(Stream fileStream, String fileName, String mimeType)
        {
           // folder_id = this.DriveService.F

            Google.Apis.Drive.v3.Data.File meta = new Google.Apis.Drive.v3.Data.File
            {
                Name = System.IO.Path.GetFileName(fileName),
                MimeType = mimeType
            };
            FilesResource.CreateMediaUpload request = this.DriveService.Files.Create(meta, fileStream, mimeType);
            request.Fields = "id, name";

            IUploadProgress uploadProgress = request.Upload();
            switch(uploadProgress.Status)
            {
                case UploadStatus.Completed:
                    return request.ResponseBody.Id;

                default:
                    return String.Empty;
            }
        }

        /// <summary>
        /// GoogleDrive上のファイルを更新する
        /// </summary>
        /// <param name="originalFileId"></param>
        /// <param name="fileStream"></param>
        /// <param name="fileName"></param>
        /// <param name="mimeType"></param>
        /// <returns></returns>
        public String Update(String originalFileId, Stream fileStream, String fileName, String mimeType)
        {
            Google.Apis.Drive.v3.Data.File file = new Google.Apis.Drive.v3.Data.File();
            file.Name = fileName; // リネームしたいファイル名に
            file.Description = String.Empty;
            var request = this.DriveService.Files.Update(file, originalFileId, fileStream, mimeType);
            IUploadProgress uploadProgress = request.Upload();
            switch (uploadProgress.Status)
            {
                case UploadStatus.Completed:
                    return request.ResponseBody.Id;

                default:
                    return String.Empty;
            }
        }

        public String GetFile(String googleDriveFileID)
        {
            FilesResource.GetRequest request = this.DriveService.Files.Get(googleDriveFileID);
            string name = Path.GetTempFileName();
            using (FileStream stream = new System.IO.FileStream(name, System.IO.FileMode.Create, System.IO.FileAccess.Write))
            {
                request.Download(stream);
            }
            return name;
        }
    }
}
