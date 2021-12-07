# ZegoExpressCSharp Topics

ZegoExpressCSharp SDK 示例，运行于 Windows 系统。

## 准备环境

请确保开发环境满足以下技术要求：

* Windows系统：Windows7、Windows8、Windows10。
* 已安装 Visual Studio 2015 及以上版本，已安装 C# 语言支持框架，已安装 .NET FrameWork 4.5 或以上版本。
* 麦克风、摄像头等支持音视频功能的外部设备。

## 目录结构说明

> 如下所示是 **ZegoCsharpWinformDemo** 目录的 文件结构，本文后面所涉及到的文件路径均相对于此目录：

```bash
📦ZegoCsharpWinformDemo
 ┣ 📂lib    -------------------------- 包含 C# 版本的库文件以及依赖的库文件
 ┃ ┣ 📂x64
 ┃ ┃ ┣ 📜ZegoExpressEngine.dll    ---- 依赖的 C++ 版本的 64 位 .dll 库文件
 ┃ ┣ 📂x86
 ┃ ┃ ┣ 📜ZegoExpressEngine.dll    ---- 依赖的 C++ 版本的 32 位 .dll 库文件
 ┃ ┗ 📜ZegoExpressCsharp.dll    ------ C# 版本目标平台为 Any CPU 的 .dll 库文件
 ┣ 📂packages
 ┃ ┗ 📂Newtonsoft.Json.13.0.1    ----- 依赖的 Nuget 包
 ┣ 📂ZegoCsharpWinformDemo    -------- 项目文件夹
 ┃ ┣ 📂bin
 ┃ ┣ 📂Common
 ┃ ┣ 📂Examples
 ┃ ┣ 📂HomePage
 ┃ ┣ 📂obj
 ┃ ┣ 📂Properties
 ┃ ┣ 📂Utils
 ┃ ┣ 📜app.config
 ┃ ┣ 📜KeyCenter.cs    ------------------------ appid 配置文件
 ┃ ┣ 📜packages.config
 ┃ ┣ 📜Program.cs
 ┃ ┣ 📜ZegoCsharpWinformDemo.csproj    -------- 项目文件
 ┣ 📜README.md
 ┣ 📜README.ZH.md
 ┗ 📜ZegoCsharpWinformDemo.sln    ------------- 解决方案文件
```

## 下载SDK

> **若如上所示的 SDK 存放目录中已经有了对应的 SDK 文件，则请跳过此步**。

* 下载 [ZegoExpressVideo-Win](https://storage.zego.im/express/video/windows-csharp/zego-express-video-windows-csharp.zip)，解压后放到当前目录下。

## 运行

### 填写 AppID 和 AppSign

示例代码中缺少 SDK 创建引擎必须的 AppID 和 AppSign，请参考 [获取 AppID 和 AppSign 指引 \|_blank](https://doc.zego.im/API/HideDoc/GetExpressAppIDGuide/GetAppIDGuideline.html) 获取，并将 AppID 和 AppSign 填写进 `/ZegoCsharpWinformDemo/KeyCenter.cs` 文件。

```c#
public static uint appID()
{
    return ;// input AppID here
}

public static string appSign()
{
    return "";// input AppSign here
}
```

### 打开工程

示例自带了 Winform 工程文件，支持在 Windows 上使用 Visual Studio 打开。

#### 使用 Visual Studio 打开项目

点击 "菜单栏-->文件-->打开-->项目/解决方案"，打开 `/ZegoCsharpWinformDemo.sln` 工程文件

### 启动调试

点击 "启动" 开始调试。
