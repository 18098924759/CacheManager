namespace INGA.Framework.Managers.Common
{
    public enum ResultStatus
    {
        Success = 1,
        Failed = 2
    }

    public enum ResultOperation
    {
        Insert = 1,
        Update = 2,
        Delete = 3,
        Upsert = 4,
        Retrieve = 5
    }

    public enum Type
    {
        Cache = 1,
        NoSql = 2,
        Log
    }

}
