using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace ZEGO
{
    class ZegoUtil
    {
        public static string PtrToString(IntPtr p)
        {
            if (p == IntPtr.Zero)
                return null;
            return Marshal.PtrToStringAnsi(p);
        }

        public static void GetStructListByPtr<StructType>(ref StructType[] list, IntPtr ptr, uint count)
        {
            for (int i = 0; i < count; ++i)
            {
                IntPtr item_ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(StructType)) * i);

                if ((list != null) && (item_ptr != null))
                {
                    list[i] = (StructType)Marshal.PtrToStructure(item_ptr, typeof(StructType));
                }
            }
        }
        public static void GetStructListByPtr<StructType>(ref StructType[] list, IntPtr ptr, int count)
        {
            for (int i = 0; i < count; ++i)
            {
                IntPtr item_ptr = new IntPtr(ptr.ToInt64() + Marshal.SizeOf(typeof(StructType)) * i);

                if ((list != null) && (item_ptr != null))
                {
                    list[i] = (StructType)Marshal.PtrToStructure(item_ptr, typeof(StructType));
                }
            }
        }
        public static StructType GetStructByPtr<StructType>(IntPtr ptr)
        {
            return (StructType)Marshal.PtrToStructure(ptr, typeof(StructType));
        }
        //private static ArrayList arrayList = new ArrayList();
        public static IntPtr GetStructPointer(ValueType a)
        {
            int nSize = Marshal.SizeOf(a);                 //定义指针长度
            IntPtr pointer = Marshal.AllocHGlobal(nSize);        //定义指针
            Marshal.StructureToPtr(a, pointer, true);                //将结构体a转为结构体指针
                                                                     // arrayList.Add(pointer);
            return pointer;
        }
        public static IntPtr GetObjPointer(Object obj)
        {
            GCHandle handle = GCHandle.Alloc(obj);
            IntPtr result = (IntPtr)handle;
            handle.Free();
            return result;
        }

        public static void ReleaseAllStructPointers(ArrayList arrayList)
        {
            foreach (System.IntPtr item in arrayList)
            {

                Marshal.FreeHGlobal(item);//释放分配的非托管内存

            }
            arrayList.Clear();

        }
        public static void ReleaseStructPointer(IntPtr ptr)
        {
            Marshal.FreeHGlobal(ptr);//释放分配的非托管内存
        }

        public class UTF8StringMarshaler : ICustomMarshaler//不能修饰结构体，不能解决结构体字符串属性对应utf-8转码问题
        {
            public void CleanUpManagedData(object ManagedObj)
            {
            }

            public void CleanUpNativeData(IntPtr pNativeData)
            {
                Marshal.FreeHGlobal(pNativeData);
            }

            public int GetNativeDataSize()
            {
                return -1;
            }

            public IntPtr MarshalManagedToNative(object ManagedObj)
            {
                if (object.ReferenceEquals(ManagedObj, null)) return IntPtr.Zero;
                if (!(ManagedObj is string)) throw new InvalidOperationException();
                byte[] utf8bytes = Encoding.UTF8.GetBytes(ManagedObj as string);
                IntPtr ptr = Marshal.AllocHGlobal(utf8bytes.Length + 1);
                Marshal.Copy(utf8bytes, 0, ptr, utf8bytes.Length);
                Marshal.WriteByte(ptr, utf8bytes.Length, 0);
                return ptr;
            }

            public object MarshalNativeToManaged(IntPtr pNativeData)
            {
                if (pNativeData == IntPtr.Zero) return null;
                List<byte> bytes = new List<byte>();
                for (int offset = 0; ; offset++)
                {
                    byte b = Marshal.ReadByte(pNativeData, offset);
                    if (b == 0) break;
                    else bytes.Add(b);
                }
                return Encoding.UTF8.GetString(bytes.ToArray(), 0, bytes.Count);
            }
            // 添加以下静态GetInstance方法
            static UTF8StringMarshaler instance = new UTF8StringMarshaler();
            public static ICustomMarshaler GetInstance(string cookie)
            {
                return instance;
            }
            // 以上添加
        }
        public static string GetUTF8String(byte[] data)
        {
            string result = null;
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == 0)
                {
                    result = Encoding.UTF8.GetString(data, 0, i);
                    break;
                }
            }
            return result;
        }
        private static void ZegoLog(string log)
        {
            IExpressPrivateInternal.zego_express_custom_log(log, ZegoConstans.MOUDLE);
        }

        private static void HandleDebug(int module, int errorCode, string funcName)
        {
            IntPtr detail = IExpressPrivateInternal.zego_express_get_print_debug_info(module, funcName, errorCode);
            if (errorCode != 0)
            {
                IExpressPrivateInternal.zego_express_trigger_on_debug_error(errorCode, funcName, ZegoUtil.PtrToString(detail));
            }
        }
        public static void ZegoPrivateLog(int errorCode, string log, bool handleDebugFlag, int moudle, bool writeFile = true, [CallerMemberName] string funcName = "")
        {
            if (errorCode != 0)
            {
                Console.WriteLine(log);
            }
            if (writeFile)
            {
                ZegoUtil.ZegoLog(log);
            }
            if (handleDebugFlag)
            {
                ZegoUtil.HandleDebug(moudle, errorCode, funcName);
            }
        }

    }
}

