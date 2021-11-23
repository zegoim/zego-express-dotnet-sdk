using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Concurrent;
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

    class ZegoImplCallChangeUtil
    {
        public static ArrayList mixerPtrArrayList;

        public static ZegoDataRecordConfig ChangeZegoDataRecordConfigStructToClass(zego_data_record_config config)
        {
            return new ZegoDataRecordConfig
            {
                filePath = config.file_path,
                recordType = config.record_type,
            };
        }

        public static zego_engine_config ChangeZegoEngineConfigClassToStruct(ZegoEngineConfig config)
        {
            if (config == null)
            {
                throw new Exception("SetEngineConfig param can not be null");
            }
            zego_engine_config engineConfig = new zego_engine_config();
            if (config.logConfig != null)
            {
                zego_log_config logConfig = new zego_log_config();
                logConfig.log_path = config.logConfig.logPath;
                logConfig.log_size = config.logConfig.logSize;
                engineConfig.log_config = ZegoUtil.GetStructPointer(logConfig);
                Console.WriteLine(string.Format("SetEngineConfig  logConfig.log_path:{0} logConfig.log_size:{1}", logConfig.log_path, logConfig.log_size));
            }
            else
            {
                Console.WriteLine("SetEngineConfig  logConfig is null");
            }
            if (config.advancedConfig != null)
            {
                string advancedConfig = "";
                foreach (KeyValuePair<string, string> item in config.advancedConfig)
                {
                    advancedConfig += item.Key + "=" + item.Value + ";";
                }
                Console.WriteLine(string.Format("SetEngineConfig  advancedConfig:{0}", advancedConfig));
                engineConfig.advanced_config = advancedConfig;
            }
            else
            {
                Console.WriteLine("SetEngineConfig  advancedConfig is null");
            }
            return engineConfig;

        }

        public static ZegoVideoConfig ChangeVideoConfigStructToClass(zego_video_config zego_Video_Config)
        {
            ZegoVideoConfig zegoVideoConfig = new ZegoVideoConfig();
            zegoVideoConfig.bitrate = zego_Video_Config.bitrate;
            zegoVideoConfig.captureHeight = zego_Video_Config.capture_resolution_height;
            zegoVideoConfig.captureWidth = zego_Video_Config.capture_resolution_width;
            zegoVideoConfig.encodeHeight = zego_Video_Config.encode_resolution_height;
            zegoVideoConfig.encodeWidth = zego_Video_Config.encode_resolution_width;
            zegoVideoConfig.codecID = zego_Video_Config.video_codec_id;
            zegoVideoConfig.fps = zego_Video_Config.fps;
            return zegoVideoConfig;
        }

        public static ZegoAudioConfig ChangeAudioConfigStructToClass(zego_audio_config zego_Audio_Config)
        {
            ZegoAudioConfig zegoAudioConfig = new ZegoAudioConfig();
            zegoAudioConfig.bitrate = zego_Audio_Config.bitrate;
            zegoAudioConfig.channel = zego_Audio_Config.channel;
            zegoAudioConfig.codecID = zego_Audio_Config.audio_codec_id;
            return zegoAudioConfig;
        }

        public static zego_video_frame_param ChangeZegoVideoFrameParamClassToStruct(ZegoVideoFrameParam param)
        {
            zego_video_frame_param result = new zego_video_frame_param();
            if (param != null)
            {
                result.format = param.format;
                result.height = param.height;
                result.width = param.width;
                result.rotation = param.rotation;
                result.strides = param.strides;
            }
            return result;
        }

        public static zego_custom_video_capture_config ChangeCustomVideoCaptureConfigClassToStruct(ZegoCustomVideoCaptureConfig config)
        {
            zego_custom_video_capture_config result = new zego_custom_video_capture_config();
            if (config != null)
            {
                result.buffer_type = config.bufferType;
            }
            return result;
        }
        public static IntPtr ChangeZegoRoomConfigClassToStructPoniter(ZegoRoomConfig config)
        {
            if (config == null)
            {
                return IntPtr.Zero;
            }
            else
            {
                zego_room_config roomConfig = new zego_room_config();
                roomConfig.max_member_count = config.maxMemberCount;
                roomConfig.thrid_token = config.token;
                roomConfig.is_user_status_notify = config.isUserStatusNotify;
                Console.WriteLine(string.Format("LoginRoom ZegoRoomConfig max_member_count:{0} thrid_token:{1} is_user_status_notify:{2}", roomConfig.max_member_count, roomConfig.thrid_token, roomConfig.is_user_status_notify));
                return ZegoUtil.GetStructPointer(roomConfig);
            }
        }
        public static zego_user ChangeZegoUserClassToStruct(ZegoUser user)
        {
            zego_user zegoUser;
            if (user == null)
            {
                throw new Exception("ZegoUser should not be null");
            }
            else
            {
                if (user.userID == null)
                {
                    throw new Exception("ZegoUser userId should not be null");
                }
                if (user.userName == null)
                {
                    throw new Exception("ZegoUser userName should not be null");
                }
                zegoUser = new zego_user
                {
                    user_id = user.userID,
                    user_name = user.userName
                };
            }
            return zegoUser;
        }

        public static zego_engine_profile ChangeZegoEngineProfileClassToStruct(ZegoEngineProfile profile)
        {
            zego_engine_profile engine_profile;
            if (profile == null)
            {
                throw new Exception("ZegoEngineProfile should not be null");
            }
            else
            {
                if (profile.appID == 0)
                {
                    throw new Exception("ZegoEngineProfile appID should not be 0");
                }
                if (profile.appSign == null)
                {
                    throw new Exception("ZegoEngineProfile appSign should not be null");
                }
                engine_profile = new zego_engine_profile
                {
                    app_id = profile.appID,
                    app_sign = profile.appSign,
                    scenario = profile.scenario
                };
            }
            return engine_profile;
        }

        public static zego_user[] ChangeZegoUserClassListToStructList(List<ZegoUser> toUserList)
        {
            zego_user[] zegoUsers;
            if (toUserList == null)
            {
                throw new Exception("SendCustomCommand toUserList should not be null");
            }
            else
            {
                zegoUsers = new zego_user[toUserList.Count];
                for (int i = 0; i < toUserList.Count; i++)
                {
                    zegoUsers[i] = ChangeZegoUserClassToStruct(toUserList[i]);
                }
            }
            return zegoUsers;
        }
        public static ZegoDeviceInfo[] ChangeZegoDeviceInfoStructListToClassList(zego_device_info[] zego_Device_Info)
        {
            ZegoDeviceInfo[] result = null;
            if (zego_Device_Info != null)
            {
                result = new ZegoDeviceInfo[zego_Device_Info.Length];
                for (int i = 0; i < zego_Device_Info.Length; i++)
                {
                    ZegoDeviceInfo zegoDevice = new ZegoDeviceInfo();
                    zegoDevice.deviceID = zego_Device_Info[i].device_id;
                    zegoDevice.deviceName = zego_Device_Info[i].device_name;
                    result[i] = zegoDevice;
                }
            }
            return result;
        }

        public static zego_player_config ChangeZegoPlayerConfigClassToStruct(ZegoPlayerConfig config)
        {
            zego_player_config zegoPlayerConfig;
            if (config == null)
            {
                throw new Exception("ZegoPlayerConfig should not be null");
            }
            else
            {
                zegoPlayerConfig = new zego_player_config();
                zegoPlayerConfig.resource_mode = config.resourceMode;
                zegoPlayerConfig.cdn_config = ZegoUtil.GetStructPointer(ChangeCDNConfigClassToStruct(config.cdnConfig));
                zegoPlayerConfig.video_layer = config.videoLayer;
                Console.WriteLine(string.Format("StartPlayingStream ZegoPlayerConfig url:{0} authParam:{1} video_layer{2}", config.cdnConfig.url, config.cdnConfig.authParam, config.videoLayer));
                return zegoPlayerConfig;
            }

        }

        public static zego_cdn_config ChangeCDNConfigClassToStruct(ZegoCDNConfig cDNConfig)
        {
            zego_cdn_config config = new zego_cdn_config();
            if (cDNConfig != null)
            {
                config.auth_param = cDNConfig.authParam;
                config.url = cDNConfig.url;
            }
            return config;
        }

        public static zego_video_config ChangeVideoConfigClassToStruct(ZegoVideoConfig config)
        {
            zego_video_config zegoVideoConfig;
            if (config == null)
            {
                throw new Exception("ZegoVideoConfig should not be null");
            }
            else
            {
                zegoVideoConfig = new zego_video_config();
                zegoVideoConfig.capture_resolution_width = config.captureWidth;
                zegoVideoConfig.capture_resolution_height = config.captureHeight;
                zegoVideoConfig.encode_resolution_width = config.encodeWidth;
                zegoVideoConfig.encode_resolution_height = config.encodeHeight;
                zegoVideoConfig.bitrate = config.bitrate;
                zegoVideoConfig.fps = config.fps;
                zegoVideoConfig.video_codec_id = config.codecID;
            }
            return zegoVideoConfig;
        }

        public static zego_audio_config ChangeAudioConfigClassToStruct(ZegoAudioConfig config)
        {
            zego_audio_config zegoAudioConfig;
            if (config == null)
            {
                throw new Exception("ZegoAudioConfig should not be null");
            }
            else
            {
                zegoAudioConfig.bitrate = config.bitrate;
                zegoAudioConfig.channel = config.channel;
                zegoAudioConfig.audio_codec_id = config.codecID;
            }
            return zegoAudioConfig;
        }

        public static zego_beautify_option ChangeZegoBeautifyOptionToStruct(ZegoBeautifyOption option)
        {
            zego_beautify_option option1 = new zego_beautify_option();
            if (option == null)
            {
                throw new Exception("ZegoBeautifyOption should not be null");
            }
            else
            {
                option1.polish_step = option.polishStep;
                option1.sharpen_factor = option.sharpenFactor;
                option1.whiten_factor = option.whitenFactor;
                return option1;
            }
        }
        public static zego_watermark ChangeWaterMarkClassToStruct(ZegoWatermark watermark)
        {
            if (watermark == null)
            {
                throw new Exception("ZegoWatermark should not be null");
            }
            else
            {
                zego_watermark zegoWatermark = new zego_watermark();
                zegoWatermark.image = watermark.imageURL;
                zegoWatermark.layout = ChangeRectClassToStruct(watermark.layout);
                return zegoWatermark;
            }
        }

        public static zego_rect ChangeRectClassToStruct(ZegoRect layout)
        {
            if (layout == null)
            {
                throw new Exception("ZegoRect in ZegoWatermark should not be null");
            }
            else
            {
                zego_rect rect = new zego_rect();
                rect.top = layout.y;
                rect.bottom = layout.height;
                rect.left = layout.x;
                rect.right = layout.width;
                return rect;
            }
        }
        public static zego_mixer_task ChangeZegoMixerTaskClassToStruct(ZegoMixerTask task)
        {
            mixerPtrArrayList = new ArrayList();
            zego_mixer_task result = new zego_mixer_task();
            if (task == null)
            {
                throw new Exception("ZegoMixerTask Class should not be null");
            }
            else
            {
                result.task_id = task.taskID;
                zego_mixer_input[] zego_Mixer_Inputs = ChangeZegoMixerInputClassListToStructList(task.inputList);
                result.input_list_count = (uint)zego_Mixer_Inputs.Length;
                IntPtr inputListPtr = GetMixerInputListPtr(zego_Mixer_Inputs);
                mixerPtrArrayList.Add(inputListPtr);
                result.input_list = inputListPtr;
                zego_mixer_output[] zego_Mixer_Outputs = ChangeZegoMixerOutputClassListToStructList(task.outputList);
                result.output_list_count = (uint)zego_Mixer_Outputs.Length;
                IntPtr outPutListPtr = GetMixerOutputListPtr(zego_Mixer_Outputs);
                mixerPtrArrayList.Add(outPutListPtr);
                result.output_list = outPutListPtr;
                result.audio_config = ChangeZegoMixerAudioConfigClassToStruct(task.audioConfig);
                result.video_config = ChangeZegoMixerVideoConfigClassToStruct(task.videoConfig);
                if (task.watermark != null)
                {
                    result.watermark = ZegoUtil.GetStructPointer(ChangeWaterMarkClassToStruct(task.watermark));
                }
                result.background_image_url = task.backgroundImageURL;
                result.enable_sound_level = task.soundLevel;
            }
            return result;
        }

        public static IntPtr GetMixerOutputListPtr(zego_mixer_output[] zego_Mixer_Outputs)
        {
            int size = Marshal.SizeOf(typeof(zego_mixer_output));
            IntPtr result = Marshal.AllocHGlobal(zego_Mixer_Outputs.Length * size);
            long LongPtr = result.ToInt64();
            for (int i = 0; i < zego_Mixer_Outputs.Length; i++)
            {
                IntPtr a = new IntPtr(LongPtr);
                Marshal.StructureToPtr(zego_Mixer_Outputs[i], a, true);
                LongPtr += Marshal.SizeOf(typeof(zego_mixer_output));
            }
            return result;
        }

        public static IntPtr GetMixerInputListPtr(zego_mixer_input[] zego_Mixer_Inputs)
        {
            int size = Marshal.SizeOf(typeof(zego_mixer_input));
            IntPtr result = Marshal.AllocHGlobal(zego_Mixer_Inputs.Length * size);
            long LongPtr = result.ToInt64();
            for (int i = 0; i < zego_Mixer_Inputs.Length; i++)
            {
                IntPtr a = new IntPtr(LongPtr);
                Marshal.StructureToPtr(zego_Mixer_Inputs[i], a, true);
                LongPtr += Marshal.SizeOf(typeof(zego_mixer_input));
            }
            return result;
        }


        public static zego_mixer_video_config ChangeZegoMixerVideoConfigClassToStruct(ZegoMixerVideoConfig videoConfig)
        {
            zego_mixer_video_config config = new zego_mixer_video_config();
            if (videoConfig != null)
            {
                config.bitrate = videoConfig.bitrate;
                config.fps = videoConfig.fps;
                config.resolution_height = videoConfig.height;
                config.resolution_width = videoConfig.width;
            }
            return config;
        }

        public static zego_mixer_audio_config ChangeZegoMixerAudioConfigClassToStruct(ZegoMixerAudioConfig audioConfig)
        {
            zego_mixer_audio_config config = new zego_mixer_audio_config();
            if (audioConfig != null)
            {
                config.audio_codec_id = audioConfig.codecID;
                config.channel = audioConfig.channel;
                config.bitrate = audioConfig.bitrate;
            }
            return config;
        }

        public static zego_mixer_input[] ChangeZegoMixerInputClassListToStructList(List<ZegoMixerInput> inputList)
        {
            zego_mixer_input[] result = new zego_mixer_input[inputList.Count];
            if (inputList == null)
            {
                throw new Exception("List<ZegoMixerInput> should not be null");
            }
            else
            {
                for (int i = 0; i < inputList.Count; i++)
                {
                    zego_mixer_input zegoMixerInput = ChangeZegoMixerInputClassToStruct(inputList[i]);
                    result[i] = zegoMixerInput;
                }
                return result;

            }
        }

        public static zego_mixer_input ChangeZegoMixerInputClassToStruct(ZegoMixerInput zegoMixerInput)
        {
            zego_mixer_input zego_Mixer_Input = new zego_mixer_input();
            if (zegoMixerInput != null)
            {
                zego_Mixer_Input.content_type = zegoMixerInput.contentType;
                zego_Mixer_Input.sound_level_id = zegoMixerInput.soundLevelID;
                zego_Mixer_Input.stream_id = zegoMixerInput.streamID;
                zego_Mixer_Input.layout = ChangeRectClassToStruct(zegoMixerInput.layout);
                zego_Mixer_Input.is_audio_focus = zegoMixerInput.isAudioFocus;
                zego_Mixer_Input.audio_direction = zegoMixerInput.audioDirection;
            }
            return zego_Mixer_Input;
        }
        public static zego_mixer_output[] ChangeZegoMixerOutputClassListToStructList(List<ZegoMixerOutput> outputList)
        {
            zego_mixer_output[] result = new zego_mixer_output[outputList.Count];
            if (outputList == null)
            {
                throw new Exception("List<ZegoMixerOutput> should not be null");
            }
            else
            {
                for (int i = 0; i < outputList.Count; i++)
                {
                    zego_mixer_output zegoMixerOutput = ChangeZegoMixerOutputClassToStruct(outputList[i]);
                    result[i] = zegoMixerOutput;
                }
                return result;

            }
        }

        public static zego_mixer_output ChangeZegoMixerOutputClassToStruct(ZegoMixerOutput zegoMixerOutput)
        {
            zego_mixer_output zego_Mixer_Output = new zego_mixer_output();
            zego_Mixer_Output.target = zegoMixerOutput.target;
            return zego_Mixer_Output;
        }

        public static int GetIndexFromObject<T>(ConcurrentDictionary<int, T> dics, T obj)
        {
            int index = -1;
            foreach (KeyValuePair<int, T> kvp in dics)
            {
                if (EqualityComparer<T>.Default.Equals(kvp.Value, obj))
                {
                    index = kvp.Key;
                }
            }

            return index;
        }
        //public static zego_audio_effect_play_config ChangeZegoAudioEffectPlayConfigClassToStruct(ZegoAudioEffectPlayConfig config)
        //{
        //    zego_audio_effect_play_config zego_Audio_Effect_Play_Config = new zego_audio_effect_play_config();
        //    if (config != null)
        //    {
        //        zego_Audio_Effect_Play_Config.is_publish_out = config.isPublishOut;
        //        zego_Audio_Effect_Play_Config.play_count = config.playCount;
        //    }
        //    return zego_Audio_Effect_Play_Config;
        //}

        public static zego_audio_frame_param ChangeZegoAudioFrameParamClassToStruct(ZegoAudioFrameParam param)
        {
            zego_audio_frame_param result = new zego_audio_frame_param();
            if (param == null)
            {
                throw new Exception("EnableAudioDataCallback ZegoAudioFrameParam should not be null");
            }
            else
            {
                result.channel = param.channel;
                result.samples_rate = param.sampleRate;
            }
            return result;
        }
        public static zego_custom_audio_config ChangeZegoCustomAudioConfigClassToStruct(ZegoCustomAudioConfig config)
        {
            zego_custom_audio_config result = new zego_custom_audio_config();
            if (config == null)
            {
                throw new Exception("EnableCustomAudioIO ZegoCustomAudioConfig should not be null");
            }
            else
            {
                result.source_type = config.sourceType;
            }
            return result;
        }
        public static zego_data_record_config ChangeZegoDataRecordConfigClassToStruct(ZegoDataRecordConfig config)
        {
            var result = new zego_data_record_config();
            if (config != null)
            {
                result.file_path = config.filePath;
                result.record_type = config.recordType;
            }
            return result;
        }

        //public static zego_custom_video_process_config ChangeZegoCustomVideoProcessConfigToStruct(ZegoCustomVideoProcessConfig config)
        //{
        //    var result = new zego_custom_video_process_config();
        //    if (config != null)
        //    {
        //        result.buffer_type = config.bufferType;
        //    }
        //    return result;
        //}
        public static zego_custom_video_process_config ChangeZegoCustomVideoProcessConfigToStruct(ZegoCustomVideoProcessConfig config)
        {
            var result = new zego_custom_video_process_config();
            if (config != null)
            {
                result.buffer_type = config.bufferType;
            }
            return result;
        }

        public static zego_sound_level_config ChangeZegoSoundLevelConfigToStruct(ZegoSoundLevelConfig config)
        {
            var result = new zego_sound_level_config();
            if (config != null)
            {
                result.enable_vad = config.enableVAD;
                result.millisecond = config.millisecond;
            }
            return result;
        }

        public static zego_publisher_config ChangeZegoPublisherConfigToStruct(ZegoPublisherConfig config)
        {
            var result = new zego_publisher_config();
            if (config != null)
            {
                result.room_id = config.roomID;
            }
            return result;
        }
    }
}

