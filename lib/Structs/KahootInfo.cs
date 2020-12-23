namespace Kahoot.NET.Structs
{
    public struct KahootInfoJson
    {
        public bool twoFactorAuth;
        public bool namerator;
        public bool participantId;
        public bool smartPractice;
        public string challenge;
    }

    public struct KahootInfo
    {
        public bool twoFactorAuth;
        public bool namerator;
        public bool participantId;
        public bool smartPractice;
        public string challenge;
        public string header;
        public string token;
    }
}