# ZegoExpressCSharp SDK Topics

ZegoExpressCSharp SDK，运行于 Windows 系统。

## 准备环境

请确保开发环境满足以下技术要求：

* Windows系统：Windows7、Windows8、Windows10。
* 已安装 Visual Studio 2019 及以上版本。
* Visual Studio 已安装 C# 开发环境和 Newtonsoft NuGet 程序包。
* 已安装 .NET FrameWork 4.5 或以上版本。
* 已安装 .NET Core3.1 或以上版本。
* 麦克风、摄像头等支持音视频功能的外部设备正常。

## 目录结构说明

> 如下所示是 **ZegoExpressCsharp** 目录的 文件结构，本文后面所涉及到的文件路径均相对于此目录：

```bash
📦ZegoExpressCsharp
 ┣ 📂Example
 ┃ ┣ 📂packages    --------------------- 依赖的 Nuget 包
 ┃ ┃ ┗ 📂Newtonsoft.Json.13.0.1
 ┃ ┣ 📂ZegoCsharpWinformDemo    -------- 项目文件夹
 ┃ ┃ ┣ 📂bin
 ┃ ┃ ┣ 📂Common
 ┃ ┃ ┣ 📂Examples
 ┃ ┃ ┣ 📂HomePage
 ┃ ┃ ┣ 📂obj
 ┃ ┃ ┣ 📂Properties
 ┃ ┃ ┣ 📂Utils
 ┃ ┃ ┣ 📜app.config
 ┃ ┃ ┣ 📜KeyCenter.cs    ------------------------ appid 配置文件
 ┃ ┃ ┣ 📜packages.config
 ┃ ┃ ┣ 📜Program.cs
 ┃ ┃ ┣ 📜ZegoCsharpWinformDemo.csproj    -------- 项目文件
 ┃ ┣ 📜README.md
 ┃ ┣ 📜README.ZH.md
 ┣ 📂libs    ------------------------------------ 依赖的 SDK C++ 版本的 .dll 库文件
 ┃ ┗ 📂ZegoExpress
 ┃ ┃ ┗ 📂win
 ┃ ┃ ┃ ┣ 📂x64
 ┃ ┃ ┃ ┃ ┣ 📜ZegoExpressEngine.dll
 ┃ ┃ ┃ ┗ 📂x86
 ┃ ┃ ┃ ┃ ┣ 📜ZegoExpressEngine.dll
 ┣ 📂ZegoExpressCsharp
 ┣ 📜.git
 ┣ 📜.gitignore
 ┣ 📜LICENSE
 ┣ 📜README.md
 ┗ 📜ZegoExpressCsharp.sln    ------------------- 解决方案文件
```

## 下载SDK

* 下载 [ZegoExpressVideoCsharp](https://storage.zego.im/express/video/windows-csharp/zego-express-video-windows-csharp.zip)，并解压。

## 运行

### 填写 AppID 和 AppSign

示例代码中缺少 SDK 创建引擎必须的 AppID 和 AppSign，请参考 [控制台 - 项目管理 \|_blank](https://doc-zh.zego.im/article/12107) 获取，并将 AppID 和 AppSign 填写进 `Example/ZegoCsharpWinformDemo/KeyCenter.cs` 文件。

```c#
public static uint appID()
{
    return 1234567890;// input AppID here
}

public static string appSign()
{
    return "63b******9e483864878bca4e3bc84c531eacf39e5f4ea1858180ee6934adf86";// input AppSign here
}
```

### 打开工程

示例源码中自带了 SDK C# 版本源码及解决方案文件，开发者可以在 Windows 系统中，使用 Visual Studio 打开示例源码同目录下的 “ZegoExpressCsharp.sln” 解决方案文件。

#### 使用 Visual Studio 打开项目

点击 "菜单栏 > 文件 > 打开 > 项目/解决方案"，打开 `/ZegoExpressCsharp.sln` 解决方案文件。

### 启动调试

点击 "启动" 开始调试。
