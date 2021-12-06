# ZegoExpressCSharp Topics

ZegoExpressCSharp SDK example, running on Windows system.

## Prepare the environment

Please ensure that the development environment meets the following technical requirements:

* Windows system: Windows7, Windows8, Windows10
* Visual Studio 2015 and above have been installed, C# language support framework has been installed, .NET FrameWork 4.5 or above has been installed
* Microphones, cameras and other external devices that support audio and video functions

## Directory structure description

> The following is the file structure of the **ZegoCsharpWinformDemo** directory. The file paths mentioned later in this article are relative to this directory:

```bash
📦ZegoCsharpWinformDemo
 ┣ 📂lib    -------------------------- Contains C# version of library files and dependent library files
 ┃ ┣ 📂x64
 ┃ ┃ ┣ 📜ZegoExpressEngine.dll    ---- Dependent C++ version of the 64-bit .dll library file
 ┃ ┣ 📂x86
 ┃ ┃ ┣ 📜ZegoExpressEngine.dll    ---- The 32-bit .dll library file of the dependent C++ version
 ┃ ┗ 📜ZegoExpressCsharp.dll    ------ C# version target platform is Any CPU .dll library file
 ┣ 📂packages
 ┃ ┗ 📂Newtonsoft.Json.13.0.1    ----- Dependent Nuget package
 ┣ 📂ZegoCsharpWinformDemo    -------- Project folder
 ┃ ┣ 📂bin
 ┃ ┣ 📂Common
 ┃ ┣ 📂Examples
 ┃ ┣ 📂HomePage
 ┃ ┣ 📂obj
 ┃ ┣ 📂Properties
 ┃ ┣ 📂Utils
 ┃ ┣ 📜app.config
 ┃ ┣ 📜KeyCenter.cs    ------------------------ appid configuration file
 ┃ ┣ 📜packages.config
 ┃ ┣ 📜Program.cs
 ┃ ┣ 📜ZegoCsharpWinformDemo.csproj    -------- project files
 ┣ 📜README.md
 ┣ 📜README.ZH.md
 ┗ 📜ZegoCsharpWinformDemo.sln    ------------- Solution file
```

## Download SDK

> **If there is already a corresponding SDK file in the SDK storage directory as shown above, please skip this step**.

* Download [ZegoExpressCsharp](https://storage.zego.im/express/video/windows-csharp/zego-express-video-windows-csharp.zip), decompress and put it in the current directory.

## Run

### 填写 AppID 和 AppSign

The AppID and AppSign required by SDK initialization are missing default, please refer to [ZEGO Admin Console User Manual \| _blank](https://doc-en.zego.im/en/1271.html) to obtain AppID and AppSign, and then fill the `/ZegoExpressExample/KeyCenter.cpp` file.

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

The sample comes with a Winform project file, which can be opened with Visual Studio on Windows.

#### Open the project with Visual Studio

Click "Menu Bar-->File-->Open-->Project/Solution" to open the `/ZegoCsharpWinformDemo.sln` project file

### Start debugging

Click "Start" to start debugging.
