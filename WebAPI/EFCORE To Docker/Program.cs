using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace EFCORE_To_Docker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //用法一样前提打开Docker run docker上的镜像
            //连接mysql
            //前提下载Docker 下载镜像 然后run
            //Docker 是个好东西
            string connectstr = "server=localhost;port=3306;user=root;password=123456;SslMode = none;";
            MySqlConnection conn = new MySqlConnection(connectstr);
            try
            {
                conn.Open();
                Console.WriteLine("连接成功!!!");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.ToString());
            }
            finally
            {
                conn.Close();
                Console.WriteLine("正常关闭!!!");
            }
        }

    }
}