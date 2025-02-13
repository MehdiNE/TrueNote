namespace TrueNote.Api;

public static class ApiEndpoints
{
    private const string ApiBase = "api";

    public static class Notes
    {
        private const string Base = $"{ApiBase}/notes";

        public const string Create = Base;
        public const string Get = $"{Base}/{{id:guid}}";
        public const string GetAll = Base;
    }
}
