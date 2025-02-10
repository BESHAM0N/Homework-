using Cysharp.Threading.Tasks;
using Game.Scripts.Observers;

namespace Game.Scripts.App.Server
{
    public interface IGameRepository
    {
        UniTask<SaveResult> Save(string data);
        UniTask<SaveResult> Load(int version);
    }
}

