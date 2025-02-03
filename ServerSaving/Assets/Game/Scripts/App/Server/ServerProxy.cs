using System.Text;
using UnityEngine.Networking;
using Cysharp.Threading.Tasks;
using Game.Scripts.Encryption;

namespace Game.Scripts.App.Server
{
    public sealed class ServerProxy : IServerProxy
    {
        private const string SERVER_URL = "http://127.0.0.1:8888";
        private const string SAVE_PART_LINK = "/save?version=";
        private const string LOAD_PART_LINK = "/load?version=";
        private const string PUT = "PUT";
        private const string CONTENT_TYPE = "Content-Type";
        private const string REQUEST_VALUE = "application/json";

        public async UniTask<bool> SaveToServer(int version, string data)
        {
            var encryptedData = AesEncryptionHelper.Encrypt(data);

            var url = $"{SERVER_URL}{SAVE_PART_LINK}{version}";
            using UnityWebRequest request = new(url, PUT)
            {
                uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(encryptedData)),
                downloadHandler = new DownloadHandlerBuffer()
            };
            request.SetRequestHeader(CONTENT_TYPE, REQUEST_VALUE);

            await request.SendWebRequest();
            return request.result == UnityWebRequest.Result.Success;
        }

        public async UniTask<(bool success, string data)> LoadFromServer(int version)
        {
            var url = $"{SERVER_URL}{LOAD_PART_LINK}{version}";
            using UnityWebRequest request = UnityWebRequest.Get(url);

            await request.SendWebRequest();

            if (request.result != UnityWebRequest.Result.Success)
                return (false, null);
            
            var decryptedData = AesEncryptionHelper.Decrypt(request.downloadHandler.text);
            return (true, decryptedData);
        }
    }
}