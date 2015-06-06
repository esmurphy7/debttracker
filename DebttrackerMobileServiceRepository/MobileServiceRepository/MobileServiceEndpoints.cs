namespace DebttrackerMobileServiceRepository.MobileServiceRepository
{
    internal static class MobileServiceEndpoints
    {
        // Domains
        public static readonly string LocalURL = "http://localhost:50780";
        public static readonly string ProductionURL = "https://debttracker.azure-mobile.net/";

        // Custom API endpoints
        public static readonly string LoginURL = "CustomLogin";
        public static readonly string RegistrationURL = "CustomRegistration";
    }
}
