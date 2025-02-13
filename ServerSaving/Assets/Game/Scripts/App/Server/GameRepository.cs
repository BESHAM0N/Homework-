using System.Text;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using Game.Scripts.Encryption;
using Game.Scripts.Observers;
using UnityEngine;

namespace Game.Scripts.App.Server
{
    public sealed class GameRepository : IGameRepository
    {
        private const string SERVER_URL = "http://127.0.0.1:8888";
        private const string SAVE_PART_LINK = "/save?version=";
        private const string LOAD_PART_LINK = "/load?version=";
        private const string PUT = "PUT";
        private const string CONTENT_TYPE = "Content-Type";
        private const string REQUEST_VALUE = "application/json";
        private const string LOCAL_VERSION_KEY = "LocalGameVersion";

        public async UniTask<SaveResult> Save(string data)
        {
            var latestVersion = GetLastVersion();
            var newVersion = latestVersion + 1;

            var encryptedData = AesEncryptionHelper.Encrypt(data);
            var url = $"{SERVER_URL}{SAVE_PART_LINK}{newVersion}";

            using UnityWebRequest request = new(url, PUT)
            {
                uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(encryptedData)),
                downloadHandler = new DownloadHandlerBuffer()
            };
            request.SetRequestHeader(CONTENT_TYPE, REQUEST_VALUE);

            await request.SendWebRequest();
            var success = request.result == UnityWebRequest.Result.Success;

            if (success)
            {
                SaveVersion(newVersion);
            }

            return new SaveResult(success, newVersion);
        }

        private static int GetLastVersion() => PlayerPrefs.GetInt(LOCAL_VERSION_KEY, 0);
        
        private static void SaveVersion(int newVersion)
        {
            PlayerPrefs.SetInt(LOCAL_VERSION_KEY, newVersion);
            PlayerPrefs.Save();
        }

        public async UniTask<SaveResult> Load(int version)
        {
            var url = $"{SERVER_URL}{LOAD_PART_LINK}{version}";
            using UnityWebRequest request = UnityWebRequest.Get(url);

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
            {
                return new SaveResult(false, version);
            }

            var decryptedData = AesEncryptionHelper.Decrypt(request.downloadHandler.text);
            return new SaveResult(true, version, decryptedData);
        }
    }
}