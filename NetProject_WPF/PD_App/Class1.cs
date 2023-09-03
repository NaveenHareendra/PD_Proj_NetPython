using System;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Net.Sockets;

namespace PD_App
{
    internal class Class1
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", ExactSpelling = true, CharSet = CharSet.Ansi, SetLastError = true)]
        private static extern int record(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        
        public void recordManipulation()
        {
            record("open new Type waveaudio Alias recsound", "", 0, 0);

            record("record recsound", "", 0, 0);

       //     return "started recording from the manipulater...";
        }

        public float recordManipulationStop()
        {

            record("save recsound C:\\Users\\navee\\PycharmProjects\\pythonProject\\w2c.wav", "", 0, 0);

            record("close recsound", "", 0, 0);

            float Nhr_Vlaue;

            try
            {
                TcpClient tcp = new TcpClient("localhost", 8600);

                string message = "getNhrMethod";

                byte[] buffer = Encoding.UTF8.GetBytes(message);

                NetworkStream streamNet = tcp.GetStream();

                streamNet.Write(buffer, 0, buffer.Length);

                buffer = new byte[1024];

                int bytesRead = streamNet.Read(buffer, 0, buffer.Length);

                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                Debug.Write("Response from Python: " + response);

                Nhr_Vlaue = float.Parse(response);

                tcp.Close();

                return Nhr_Vlaue;
            }
            catch(Exception ex)
            {
                Debug.Write("error : "+ ex);
            }
            return 0;

        }
    }
}
