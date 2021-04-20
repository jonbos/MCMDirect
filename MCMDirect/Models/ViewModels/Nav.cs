namespace MCMDirect.Models.ViewModels {
    public static class Nav {
        public static string Active(string value, string current) =>
            (value == current) ? "btn btn-outline-dark" : "";

        public static string Active(int value, int current) =>
            (value == current) ? "btn btn-outline-dark" : "";
    }
}