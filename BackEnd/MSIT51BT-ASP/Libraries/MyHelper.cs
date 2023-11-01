using Azure.Core;
using System.Security.Cryptography;
using System.Text;

namespace MSIT51BT_ASP.Libraries {
    public static class MyHelper {
		public static string GetRandomChar(int length) {
			Random random = new Random();
			string letterAndNumber = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

			string result = "";
			for (int i = 0; i < length; i++) {
				result += letterAndNumber[random.Next(letterAndNumber.Length)];
			}

			return result;
		}

		public static string GetFilePath(HttpContext httpContext, string file) {
			return $"{httpContext.Request.Scheme}://{httpContext.Request.Host}/{file}";
		}



        /// <summary>
        /// 密碼加密:丟入帳號及未加密的密碼->回傳加密後的密碼
        /// </summary>
        public static string SecrectPwd(string userEmail, string userPassword)
        {
            string mySalt = userEmail.Substring(0, 1).ToLower(); //使用帳號第一碼當作密碼鹽
            SHA256 mySha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(mySalt + userPassword); //將密碼鹽及原密碼組合
            byte[] hash = mySha256.ComputeHash(bytes); //組合後一起加密
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)  //將 hash 的每個元素轉換為兩位十六進位字元
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }


    }
}
