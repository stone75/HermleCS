using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Web;

// using ActUtlTypeLib;
// using MCProtocol;

namespace HermleCS.Comm
{
    public class CommHTTPComponent : CommModule
    {
        private string IP;
        private int Port;
        private static readonly HttpClient httpClient = new HttpClient();

        private string buffer;
        private int errcode;
        private string errmsg;


        private static readonly CommHTTPComponent instance = new CommHTTPComponent();
        private CommHTTPComponent() { }

//        private Mitsubishi.Plc plc = null;

        public static CommHTTPComponent Instance
        {
            get
            {
                return instance;
            }
        }

        public string GetAPI(string url)
        {
            try
            {
                HttpResponseMessage response = httpClient.GetAsync(url).Result;
                response.EnsureSuccessStatusCode();

                // ���� ������ ���ڿ��� �о ��ȯ
                string responseBody = response.Content.ReadAsStringAsync().Result;
                return responseBody;
            }
            catch (Exception ex)
            {
                // ���� ó��
                Console.WriteLine($"Error occurred: {ex.Message}");
                return null;
            }
        }

        public string PostAPI(string url, string jsonData)
        {
            string rval = "";

            try
            {
                /*
                                StringContent content = new StringContent(
                                System.json .Json.JsonSerializer.Serialize (jsonData),
                                Encoding.UTF8,
                                "application/json");
                */
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    rval = response.Content.ReadAsStringAsync().Result;
                    Console.WriteLine($"���� ����: {rval}");
                } else
                {
                    Console.WriteLine($"���� ����: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // ���� ó��
                Console.WriteLine($"��û �� ���� �߻�: {ex.Message}");
                return null;
            }

            return rval;
        }

        public override bool readMessage(string deviceid, int length, out string readVal)
        {
            C.log("HTTP Connection - readMessage : ");
            readVal = "";

            return true;
        }

        public override bool sendMessage(string deviceid, int length, int[] val)
        {
            /*
            Console.WriteLine("sendMessage..............");

            int retCode;

            try
            {
                retCode = plc.WriteDeviceRandom2(deviceid, 1, ref val);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            */
            return true;
        }

        public override string test()
        {
            /*
            Console.WriteLine("Comm Module Test..........");

            string ret;
            int value;
            try
            {
                plc.GetDevice("D1010", out value);
                ret = "Device Read : " + value;
            }
            catch (Exception e)
            {
                ret = e.Message;
            }

            return ret;
            */

            return "";
        }
    }
}