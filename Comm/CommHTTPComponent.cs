using System;
using System.Text;
using System.Net.Http;

// using ActUtlTypeLib;
// using MCProtocol;

namespace HermleCS.Comm
{
//    public class CommHTTPComponent : CommModule
    public class CommHTTPComponent
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

                // 응답 내용을 문자열로 읽어서 반환
                string responseBody = response.Content.ReadAsStringAsync().Result;
                return responseBody;
            }
            catch (Exception ex)
            {
                // 예외 처리
                C.log($"Error occurred: {ex.Message}");
                return null;
            }
        }

        public string PostAPI(string url, string jsonData)
        {
            string rval = "";

            try
            {
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(url, content).Result;
                if (response.IsSuccessStatusCode)
                {
                    rval = response.Content.ReadAsStringAsync().Result;
                    C.log($"응답 성공: {rval}");
                } else
                {
                    C.log($"응답 실패: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                // 예외 처리
                C.log($"요청 중 오류 발생: {ex.Message}");
                return null;
            }

            return rval;
        }


        public bool commandAutoStart(string jsondata)
        {
            PostAPI("AUTO_START", jsondata);
            return true;
        }

        public bool commandWritePosition(string jsondata)
        {
            PostAPI("WRITE_POSITION", jsondata);
            return true;
        }

        public bool commandMove(string jsondata)
        {
            PostAPI("MOVE", jsondata);
            return true;
        }

        public bool commandCommand(string TPFilename)
        {
            GetAPI("MOVE", jsondata);
            return true;
        }

    }
}