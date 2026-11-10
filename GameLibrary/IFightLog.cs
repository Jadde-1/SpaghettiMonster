using System;
using System.Collections.Generic;
using System.Text;

namespace GameLibrary.BattleLog;

public interface IBattleLog
{
    public static string BattleLog(string log)
    {
        List<string> BattleLogs = new List<string>();
        if (!string.IsNullOrEmpty(log) || log != "")
        {
            BattleLogs.Add(log);
            return "";
        }
        else
        {
            string LogString = "";
            foreach (string Log in BattleLogs)
            {
                LogString += Log + "\n";
            }
            return LogString;
        }

    }
}

