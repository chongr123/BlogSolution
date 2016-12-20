namespace Blog_Solution.Domain.Customers
{
    /// <summary>
    /// 密码加密的格式枚举
    /// </summary>
    public enum PasswordFormat:int
    {
        /// <summary>
        /// 不加密
        /// </summary>
        Clear = 0,
        /// <summary>
        /// Hashed加密法
        /// </summary>
        Hashed = 1,
        /// <summary>
        /// Encrypted加密法
        /// </summary>
        Encrypted = 2,
    }
}
