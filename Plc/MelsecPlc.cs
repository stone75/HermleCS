using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MCProtocol;


namespace Raon.Lib.Plc
{
    public class MelsecPlc : IDisposable
    {
        public string IP            { get; set; }
        public int Port             { get; set; }
        public Mitsubishi.McFrame FrameType     { get; set; } = Mitsubishi.McFrame.MC3E;
        public Mitsubishi.Plc  PLC
        {
            get
            {
                return __plc;
            }
        }

        private bool                __disposedValue     = false;
        private Mitsubishi.Plc     __plc = null;

        public MelsecPlc()
        {
            init();
        }

        public MelsecPlc(MelsecConfig cfg)
        {
            IP          = cfg.IP;
            Port        = cfg.Port;
            FrameType   = cfg.FrameType;

            init();
        }

        private void init()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!__disposedValue)
            {
                if (disposing)
                {
                    Disconnect();
                }

                __disposedValue = true;
            }
        }

        // // TODO: 비관리형 리소스를 해제하는 코드가 'Dispose(bool disposing)'에 포함된 경우에만 종료자를 재정의합니다.
        // ~DortstPlc()
        // {
        //     // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public async void Connect()
        {
            try
            {
                //PLCData.PLC = new Mitsubishi.McProtocolTcp (IP, Port, Mitsubishi.McFrame.MC3E);
                __plc = new Mitsubishi.McProtocolTcp(IP, Port, FrameType);

                if (__plc.Connected == false)
                {
                    await __plc.Open();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async void Connect (string ip, int port, Mitsubishi.McFrame  type = Mitsubishi.McFrame.MC3E)
        {
            try
            {
                IP          = ip;
                Port        = port;
                FrameType   = type;

                await Task.Run(() => Connect ());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public void Disconnect()
        {
            try
            {
                __plc?.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public bool IsConnected ()
        {
            if (__plc == null)
            {
                return false;
            }

            return __plc.Connected;
        }
    }
}
