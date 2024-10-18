using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCProtocol;

namespace Raon.Lib.Plc
{
    public class MelsecPlcData<T>
    {
        public  Mitsubishi.Plc PLC
        {
            set 
            {
                this.__plc = value;
            }
        }

        private Mitsubishi.PlcDeviceType DeviceType;

        private int             Address;

        private int             Length;

        private int             LENGTH;

        private byte[]          bytes;

        private Mitsubishi.Plc __plc    = null;

        public T this[int i]
        {
            get
            {
                Union union = new Union();

                switch (typeof(T).Name)
                {
                    case "Boolean":
                        return (T)Convert.ChangeType((bytes[i / 8] >> i % 8) % 2 == 1, typeof(T));
                    case "Int32":
                        union.a = bytes[i * 4];
                        union.b = bytes[i * 4 + 1];
                        union.c = bytes[i * 4 + 2];
                        union.d = bytes[i * 4 + 3];
                        return (T)Convert.ChangeType(union.DINT, typeof(T));
                    case "Int16":
                        union.a = bytes[i * 2];
                        union.b = bytes[i * 2 + 1];
                        return (T)Convert.ChangeType(union.INT, typeof(T));
                    case "UInt16":
                        union.a = bytes[i * 2];
                        union.b = bytes[i * 2 + 1];
                        return (T)Convert.ChangeType(union.UINT, typeof(T));
                    case "UInt32":
                        union.a = bytes[i * 4];
                        union.b = bytes[i * 4 + 1];
                        union.c = bytes[i * 4 + 2];
                        union.d = bytes[i * 4 + 3];
                        return (T)Convert.ChangeType(union.UDINT, typeof(T));
                    case "Single":
                        union.a = bytes[i * 4];
                        union.b = bytes[i * 4 + 1];
                        union.c = bytes[i * 4 + 2];
                        union.d = bytes[i * 4 + 3];
                        return (T)Convert.ChangeType(union.REAL, typeof(T));
                    case "Char":
                        return (T)Convert.ChangeType(ToString()[i], typeof(T));
                    default:
                        throw new Exception("Type not recognized.");
                }
            }
            set
            {
                Union union = new Union();
                switch (typeof(T).Name)
                {
                    case "Boolean":
                        {
                            bool flag = Convert.ToBoolean(value);
                            if (flag && (bytes[i / 8] >> i % 8) % 2 == 0)
                            {
                                bytes[i / 8] += (byte)(1 << i % 8);
                            }
                            else if (!flag && (bytes[i / 8] >> i % 8) % 2 == 1)
                            {
                                bytes[i / 8] -= (byte)(1 << i % 8);
                            }

                            break;
                        }
                    case "Int32":
                        union.DINT = Convert.ToInt32(value);
                        bytes[i * 4] = union.a;
                        bytes[i * 4 + 1] = union.b;
                        bytes[i * 4 + 2] = union.c;
                        bytes[i * 4 + 3] = union.d;
                        break;
                    case "Int16":
                        union.INT = Convert.ToInt16(value);
                        bytes[i * 2] = union.a;
                        bytes[i * 2 + 1] = union.b;
                        break;
                    case "UInt32":
                        union.UDINT = Convert.ToUInt32(value);
                        bytes[i * 4] = union.a;
                        bytes[i * 4 + 1] = union.b;
                        bytes[i * 4 + 2] = union.c;
                        bytes[i * 4 + 3] = union.d;
                        break;
                    case "UInt16":
                        union.UINT = Convert.ToUInt16(value);
                        bytes[i * 2] = union.a;
                        bytes[i * 2] = union.b;
                        break;
                    case "Single":
                        union.REAL = Convert.ToSingle(value);
                        bytes[i * 4] = union.a;
                        bytes[i * 4 + 1] = union.b;
                        bytes[i * 4 + 2] = union.c;
                        bytes[i * 4 + 3] = union.d;
                        break;
                    default:
                        throw new Exception("Type not recognized.");
                }
            }
        }
        public MelsecPlcData (Mitsubishi.PlcDeviceType DeviceType, int Address, int Length)
        {
            this.DeviceType = DeviceType;
            this.Address = Address;

            switch (typeof(T).Name)
            {
                case "Boolean":
                    LENGTH = (Length / 16 + (Length % 16 > 0 ? 1 : 0)) * 2;
                    this.Length = Length;
                    break;
                case "Int32":
                    LENGTH = 4 * Length;
                    this.Length = Length * 2;
                    break;
                case "Int16":
                    LENGTH = 2 * Length;
                    this.Length = Length;
                    break;
                case "UInt16":
                    LENGTH = 2 * Length;
                    this.Length = Length;
                    break;
                case "UInt32":
                    LENGTH = 4 * Length;
                    this.Length = Length * 2;
                    break;
                case "Single":
                    LENGTH = 4 * Length;
                    this.Length = Length * 2;
                    break;
                case "Double":
                    LENGTH = 8 * Length;
                    this.Length = Length * 4;
                    break;
                case "Char":
                    LENGTH = Length;
                    this.Length = Length;
                    break;
                default:
                    throw new Exception("Type not supported by PLC.");
            }

            bytes = new byte[LENGTH];
        }

        public MelsecPlcData(Mitsubishi.Plc plc, Mitsubishi.PlcDeviceType DeviceType, int Address, int Length)
        {
            __plc = plc;
            this.DeviceType = DeviceType;
            this.Address = Address;

            switch (typeof(T).Name)
            {
                case "Boolean":
                    LENGTH = (Length / 16 + (Length % 16 > 0 ? 1 : 0)) * 2;
                    this.Length = Length;
                    break;
                case "Int32":
                    LENGTH = 4 * Length;
                    this.Length = Length * 2;
                    break;
                case "Int16":
                    LENGTH = 2 * Length;
                    this.Length = Length;
                    break;
                case "UInt16":
                    LENGTH = 2 * Length;
                    this.Length = Length;
                    break;
                case "UInt32":
                    LENGTH = 4 * Length;
                    this.Length = Length * 2;
                    break;
                case "Single":
                    LENGTH = 4 * Length;
                    this.Length = Length * 2;
                    break;
                case "Double":
                    LENGTH = 8 * Length;
                    this.Length = Length * 4;
                    break;
                case "Char":
                    LENGTH = Length;
                    this.Length = Length;
                    break;
                default:
                    throw new Exception("Type not supported by PLC.");
            }

            bytes = new byte[LENGTH];
        }

        public async Task WriteData()
        {
            await __plc.WriteDeviceBlock (DeviceType, Address, Length, bytes);
        }

        public async Task ReadData()
        {
            bytes = await __plc.ReadDeviceBlock (DeviceType, Address, Length);
        }
    }
}
