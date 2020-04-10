# PolygonOperate
GpcLibPack
调用方法  
多边形坐标点参数格式为"1,1;2,2;3,3;4,4"
```csharp
string strConsoleRoot = System.Environment.CurrentDirectory + "\\GpcLib";//文件夹
string strConsolePath = Path.Combine(strConsoleRoot, "PolygonOperate.exe");//exe路径
string strFingerTemplate1 = "\"" + ConvertPointToString(polyon1) + "\"";//参数1
string strFingerTemplate2 = "\"" + ConvertPointToString(polyon2) + "\"";//参数2
string strFingerTemplate3 = "\"" + type.ToString() + "\"";				//参数3
ProcessStartInfo start = new ProcessStartInfo();
start.Arguments = strFingerTemplate1 + " " + strFingerTemplate2 + " " + strFingerTemplate3;
start.WorkingDirectory = strConsoleRoot;
start.FileName = strConsolePath;
start.UseShellExecute = false;
start.RedirectStandardInput = true;
start.RedirectStandardOutput = true;
start.RedirectStandardError = true;
start.CreateNoWindow = true;
_process = Process.Start(start);
_process.OutputDataReceived += (sender, e) =>
{
    if (!string.IsNullOrEmpty(e.Data))
    {
        //调用成功e.Data
    }
    else
    {
        //调用异常处理
    }
    _process.CancelOutputRead();
    _process.Close();
    _process.Dispose();
};
_process.BeginOutputReadLine();
//Thread.Sleep(1200);
```
