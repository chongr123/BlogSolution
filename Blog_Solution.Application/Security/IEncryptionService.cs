using Abp.Application.Services;

namespace Blog_Solution.Security
{

    /// <summary>
    /// 加密服务
    /// </summary>
    public interface IEncryptionService : IApplicationService
    {
        /// <summary>
        /// 创建秘钥
        /// </summary>
        /// <param name="size">长度</param>
        /// <returns>私钥</returns>
        string CreateSaltKey(int size);

        /// <summary>
        /// 创建哈希密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <param name="saltkey">私钥</param>
        /// <param name="passwordFormat">密码格式，默认为哈希</param>
        /// <returns>哈希密码</returns>
        string CreatePasswordHash(string password, string saltkey, string passwordFormat = "SHA1");

        /// <summary>
        /// 加密文本
        /// </summary>
        /// <param name="plainText">加密文本</param>
        /// <param name="encryptionPrivateKey">加密私钥</param>
        /// <returns>加密后的文本</returns>
        string EncryptText(string plainText, string encryptionPrivateKey = "");

        /// <summary>
        /// 解密文本
        /// </summary>
        /// <param name="cipherText">需要解密的文本</param>
        /// <param name="encryptionPrivateKey">加密私钥</param>
        /// <returns>解密后的文本</returns>
        string DecryptText(string cipherText, string encryptionPrivateKey = "");
    }
}
