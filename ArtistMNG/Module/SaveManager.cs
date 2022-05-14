using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArtistMNG.Module
{
    public static class SaveManager
    {
        static string accountSavePath = "/App.vanhaodev";
        static IFormatter formatter;
        static Stream stream;
        public static void SaveLoginAccount(string user, string pass, bool rememberPwd = false)
        {
            formatter = new BinaryFormatter();
            Stream stream = new FileStream(string.Concat(Application.StartupPath, accountSavePath), FileMode.Create, FileAccess.Write);
            Account account = new Account(user, pass, rememberPwd);
            formatter.Serialize(stream, account);
            stream.Close();
        }
        public static Tuple<string, string> LoadLoginAccount()
        {
            try
            {
                if (File.Exists(string.Concat(Application.StartupPath, accountSavePath)))
                {
                    formatter = new BinaryFormatter();
                    stream = new FileStream(string.Concat(Application.StartupPath, accountSavePath), FileMode.Open, FileAccess.Read);
                    Account account = new Account("", "", false);
                    account = (Account)formatter.Deserialize(stream);
                    stream.Close();
                    return account.rememberPwd ? Tuple.Create(account.userName, account.password) : Tuple.Create(account.userName, string.Empty);
                }
                return Tuple.Create(string.Empty, string.Empty);
            }
            catch
            {
                return Tuple.Create(string.Empty, string.Empty);
            }
        }
    }
    [System.Serializable]
    public class Account
    {
        public string userName;
        public string password;
        public bool rememberPwd;
        public Account(string u, string p, bool r)
        {
            userName = u;
            password = p;
            rememberPwd = r;
        }
    }
}
