using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Graph;
using Microsoft.Identity.Client;
using SQLite;
using TimeTracker.MAUI.Models;

namespace TimeTracker.MAUI.Services
{
    public class SyncService
    {
        private readonly SQLiteAsyncConnection _database;
        private readonly string _oneDriveFolderPath = "TimeTracker";
        private readonly string _databaseFileName = "timetracker.db";
        private readonly IPublicClientApplication _publicClientApp;
        private readonly string[] _scopes = { "Files.ReadWrite.All" };

        public SyncService(SQLiteAsyncConnection database)
        {
            _database = database;
            _publicClientApp = PublicClientApplicationBuilder.Create("YOUR_CLIENT_ID")
                .WithRedirectUri("http://localhost")
                .Build();
        }

        public async Task SyncToOneDrive()
        {
            var authResult = await _publicClientApp.AcquireTokenInteractive(_scopes).ExecuteAsync();
            var graphClient = new GraphServiceClient(new DelegateAuthenticationProvider(
                requestMessage =>
                {
                    requestMessage.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult.AccessToken);
                    return Task.CompletedTask;
                }));

            var driveItem = await EnsureOneDriveFolderExists(graphClient);

            var localDbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), _databaseFileName);
            var dbStream = new FileStream(localDbPath, FileMode.Open, FileAccess.Read);

            await graphClient.Me.Drive.Items[driveItem.Id].ItemWithPath(_databaseFileName).Content.Request().PutAsync<DriveItem>(dbStream);
        }

        private async Task<DriveItem> EnsureOneDriveFolderExists(GraphServiceClient graphClient)
        {
            var driveItems = await graphClient.Me.Drive.Root.Children.Request().GetAsync();
            var folder = driveItems.FirstOrDefault(item => item.Name == _oneDriveFolderPath);

            if (folder == null)
            {
                var driveItem = new DriveItem
                {
                    Name = _oneDriveFolderPath,
                    Folder = new Folder()
                };

                folder = await graphClient.Me.Drive.Root.Children.Request().AddAsync(driveItem);
            }

            return folder;
        }
    }
}
