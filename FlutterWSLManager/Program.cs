using System.Diagnostics;

// 获取运行时管理器位置
string? runtimeMgrPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
if (string.IsNullOrEmpty(runtimeMgrPath) || !Directory.Exists(runtimeMgrPath))
{
    Console.Error.WriteLine("What? Where did you running me?");
    Environment.Exit(-1);
    return;
}

// 从环境变量获取flutter位置
string? flutterPath = Environment.GetEnvironmentVariable("FLUTTER_ROOT");
if (string.IsNullOrEmpty(flutterPath) || !Directory.Exists(flutterPath))
{
    Console.Error.WriteLine("You MUST be set environment \"FLUTTER_ROOT\"'s value.");
    Environment.Exit(-1);
    return;
}

// 获取程序名
string program = Path.GetFileNameWithoutExtension(args[0]);
IEnumerable<string> arguments = args.Skip(1);

// 获取程序路径
string binPath = Path.Combine(flutterPath, "bin", program);
// 获取cache目录路径
string cachePath = Path.Combine(flutterPath, "bin", "cache");
string target;
if (OperatingSystem.IsWindows())
{
    target = Path.Combine(runtimeMgrPath, ".windows");
    // 为 Windows 运行添加 .bat 扩展名
    binPath += ".bat";
}
else if (OperatingSystem.IsLinux())
{
    target = Path.Combine(runtimeMgrPath, ".linux");
}
else
{
    Console.Error.WriteLine("Cannot Support this platform");
    Environment.Exit(-1);
    return;
}

// 删除已存在的软链接或文件夹
if (File.Exists(cachePath))
    File.Delete(cachePath);
else if (Directory.Exists(cachePath))
    Directory.Delete(cachePath, true);

// 当目标文件夹不存在时创建
if (!Directory.Exists(target))
    Directory.CreateDirectory(target);

// 创建软连链接
Directory.CreateSymbolicLink(cachePath, target);

// 运行程序
Process proc = Process.Start(binPath, arguments);
await proc.WaitForExitAsync();
