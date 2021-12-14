# ZegoExpressCSharp SDK Topics

ZegoExpressCSharp SDK, running on Windows system.

## Prepare the environment

Please ensure that the development environment meets the following technical requirements:

* Windows system: Windows7, Windows8, Windows10
* Installed Visual Studio 2019 and above
* Visual Studio has installed C# development environment and Newtonsoft NuGet package
* .NET FrameWork 4.5 or above has been installed
* .NET Core 3.1 or above installed
* Microphones, cameras and other external devices that support audio and video functions

## Directory structure description

> The following is the file structure of the **ZegoExpressCsharp** directory. The file paths mentioned later in this article are relative to this directory:

```bash
📦ZegoExpressCsharp
 ┣ 📂Example
 ┃ ┣ 📂packages    --------------------- Dependent Nuget package
 ┃ ┃ ┗ 📂Newtonsoft.Json.13.0.1
 ┃ ┣ 📂ZegoCsharpWinformDemo    -------- Project folder
 ┃ ┃ ┣ 📂bin
 ┃ ┃ ┣ 📂Common
 ┃ ┃ ┣ 📂Examples
 ┃ ┃ ┣ 📂HomePage
 ┃ ┃ ┣ 📂obj
 ┃ ┃ ┣ 📂Properties
 ┃ ┃ ┣ 📂Utils
 ┃ ┃ ┣ 📜app.config
 ┃ ┃ ┣ 📜KeyCenter.cs    ------------------------ appid configuration file
 ┃ ┃ ┣ 📜packages.config
 ┃ ┃ ┣ 📜Program.cs
 ┃ ┃ ┣ 📜ZegoCsharpWinformDemo.csproj    -------- project file
 ┃ ┣ 📜README.md
 ┃ ┣ 📜README.ZH.md
 ┣ 📂libs    ------------------------------------ ependent SDK C++ version of the .dll library file
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
 ┗ 📜ZegoExpressCsharp.sln    ------------------- Solution file
```

## Download SDK

* Download [ZegoExpressVideoCsharp](https://storage.zego.im/express/video/windows-csharp/zego-express-video-windows-csharp.zip), and unzip it to the "/libs/ZegoExpress/win" directory.

## Run

### Input AppID and AppSign

The AppID and AppSign required by SDK initialization are missing default, please refer to [Control Panel-Project Management \| _blank](https://doc-en.zego.im/article/1271.html) to obtain AppID and AppSign, and then fill the `Example/ZegoCsharpWinformDemo/KeyCenter.cs` file.

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

### Open the project

The sample source code comes with the SDK C# version source code and solution file. Developers can use Visual Studio to open the "ZegoExpressCsharp.sln" solution file in the same directory as the sample source code in the Windows system.

#### Open the project with Visual Studio

Click "Menu Bar > File > Open > Project/Solution" to open the `/ZegoExpressCsharp.sln` project file

### Start debugging

Click "Start" to start debugging.
