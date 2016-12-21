namespace Blog_Solution.Customers.Dto
{

    /// <summary>
    /// 登录反馈
    /// </summary>
    public enum LoginResults:int
    {   /// <summary>
        /// 登录成功
        /// </summary>
        Successful = 1,
        /// <summary>
        /// 密码错误
        /// </summary>
        WrongPassword = 2,
        /// <summary>
        /// 用户未激活
        /// </summary>
        NotActive = 3,
        /// <summary>
        /// 用户已删除
        /// </summary>
        Deleted = 4,
        /// <summary>
        /// 未注册
        /// </summary>
        NotRegistered = 5,
    }
}
