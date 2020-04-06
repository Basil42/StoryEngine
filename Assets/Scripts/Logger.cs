using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Assertions;

public enum LogFile
{
    Main
}

public static class Logger
{
    static string _logPath = "";
    static Verisimilitude _engine = null;

    public static void Log(string message)
    {
        Log(message, LogFile.Main);
    }

    public static void Log(string message, LogFile file)
    {
        string path = _logPath + file.ToString() + ".txt";
        string loggedLine = System.DateTime.Now.ToString("HH:mm:ss");
        if (_engine)
        {
            loggedLine += " at tick " + _engine.Time.ToString();
        }
        loggedLine += ": " + message + "\n";
        File.AppendAllText(path, loggedLine);
    }

    static Logger()
    {
        _logPath = Application.dataPath + "/../Logs/" + System.DateTime.Now.ToString("MMddHHmmss") + "/";
        Directory.CreateDirectory(_logPath);
    }

    public static void SetEngine(Verisimilitude engine)
    {
        Log("Logging " + (engine ? engine.name : "no engine"));
        _engine = engine;
    }
}
