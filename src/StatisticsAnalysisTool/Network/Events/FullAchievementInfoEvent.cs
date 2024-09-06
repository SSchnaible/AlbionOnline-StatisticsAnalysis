using StatisticsAnalysisTool.Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StatisticsAnalysisTool.Network.Events;

public class FullAchievementInfoEvent
{
    public List<KeyValuePair<short, short>> nodes { get; } = new();

    public FullAchievementInfoEvent(Dictionary<byte, object> parameters)
    {
        ConsoleManager.WriteLineForNetworkHandler(GetType().Name, parameters);

        try
        {
            if (parameters.ContainsKey(2) && parameters.ContainsKey(3))
            {
                short[] idData = (short[]) parameters[2];
                byte[] levelData = (byte[]) parameters[3];

                for (int index = 0; index < idData.Length; index++)
                {
                    nodes.Add(new KeyValuePair<short, short>( idData[index], levelData[index] ));
                }
            }
        }
        catch (Exception e)
        {
            ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
        }
    }

}