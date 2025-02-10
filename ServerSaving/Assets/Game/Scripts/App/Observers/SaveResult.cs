namespace Game.Scripts.Observers
{
    public class SaveResult
    {
        public bool Success { get; set;  }
        public int Version { get; set; }
        public string Data { get; set; }

        public SaveResult(bool success, int version, string data = null)
        {
            Success = success;
            Version = version;
            Data = data;
        }
    }
}