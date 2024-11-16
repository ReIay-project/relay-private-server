using ServerCore.Debugging;

namespace ServerCore
{
    public class RelayConsts
    {
        public const string LocalizationSourceName = "Relay";

        public const string ConnectionStringName = "DefaultConnection";

        public const bool MultiTenancyEnabled = false;
        
        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "eecc48d3cc534e909d444452a43c9077";
    }
}