using Cysharp.Threading.Tasks;

namespace Game.Scripts.App.Server
{
    public interface IServerProxy
    {
        UniTask<bool> SaveToServer(int version, string data);
        UniTask<(bool success, string data)> LoadFromServer(int version);
    }
}

