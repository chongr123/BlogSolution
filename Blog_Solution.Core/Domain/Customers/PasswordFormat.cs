namespace Blog_Solution.Domain.Customers
{
    /// <summary>
    /// 密码加密的格式枚举
    /// </summary>
    public enum PasswordFormat:int
    {
        Clear = 0,
        Hashed = 1,
        Encrypted = 2
    }
}
