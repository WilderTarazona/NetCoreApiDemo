namespace Demo.Application.Contracts
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Todos
        {
            public const string GetAll = Base + "/todos";
            public const string Get = Base + "/todos/{id}";
            public const string Create = Base + "/todos";
            public const string Update = Base + "/todos/{postId}";
            public const string Delete = Base + "/todos/{postId}";
            public const string Send = Base + "/todos/send";
        }

        //public static class Tags
        //{
        //    public const string GetAll = Base + "/tags";

        //    public const string Get = Base + "/tags/{tagName}";

        //    public const string Create = Base + "/tags";

        //    public const string Delete = Base + "/tags/{tagName}";
        //}

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }
    }
}