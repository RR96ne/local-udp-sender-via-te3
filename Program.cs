using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LocalUdpSenderViaTE3
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            string message = "";
            int port = 5565; // デフォルトのポート番号
            string serverIp = "127.0.0.1"; // 送信先のIPアドレス
            
            if (args.Length < 1)
            {
                Debug.WriteLine("引数が不足しています。Base64エンコードされたメッセージを入力してください。");
                return;
            }
            if (args.Length > 2)
            {
                Debug.WriteLine("引数が多すぎます。");
                return;
            }
            
            // 引数にBase64エンコードされた-p<数字>が含まれている場合、その数字をポート番号として設定
            foreach (var arg in args)
            {            
                string decodedMessage="";
                
                // Base64デコードしてメッセージを取得
                try
                {
                    byte[] decodedBytes = Convert.FromBase64String(arg);
                    decodedMessage = Encoding.UTF8.GetString(decodedBytes);
                }
                catch (FormatException)
                {
                    Debug.WriteLine("無効なBase64エンコード文字列です。メッセージを送信しません。");
                    return;
                }
                
                if (decodedMessage.StartsWith("-p"))
                {
                    string strPort = decodedMessage.Substring("-p".Length);
                    if (int.TryParse(strPort, out int parsedPort))
                    {
                        port = parsedPort;
                    }
                    else
                    {
                        Debug.WriteLine("無効なポート番号が指定されました。メッセージを送信しません。");
                        return;
                    }
                }
                else
                {
                    message = decodedMessage;
                }
            }

            if (message == "")
            {
                return;
            }
            
            // 最大63文字に制限
            if (message.Length > 63)
            {
                message = message.Substring(0, 63);
            }


            using (UdpClient udpClient = new UdpClient())
            {
                try
                {
                    // UTF-8エンコードして送信
                    byte[] sendBytes = Encoding.UTF8.GetBytes(message);
                    IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(serverIp), port);
                    udpClient.Send(sendBytes, sendBytes.Length, endPoint);

                    Debug.WriteLine($"送信したメッセージ: {message}");
                    Debug.WriteLine($"使用したポート番号: {port}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("エラー: " + ex.Message);
                }
            }
        }
    }
}