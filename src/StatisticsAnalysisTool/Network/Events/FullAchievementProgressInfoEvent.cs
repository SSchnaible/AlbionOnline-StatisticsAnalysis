using HarfBuzzSharp;
using StatisticsAnalysisTool.Common;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace StatisticsAnalysisTool.Network.Events;

public class FullAchievementProgressInfoEvent
{
    public List<KeyValuePair<short,long>> nodes { get; } = new();

    public FullAchievementProgressInfoEvent(Dictionary<byte, object> parameters)
    {
        ConsoleManager.WriteLineForNetworkHandler(GetType().Name, parameters);

        try
        {
            if (parameters.ContainsKey(1) && parameters.ContainsKey(4))
            {
                short[] idData = ToShortArray(parameters[1]);
                string[] progressData = (string[]) parameters[4];

                for (int index = 0; index < idData.Length; index++)
                {
                    long progress = long.Parse(progressData[index].Substring(2, progressData[index].Length - 8));
                    nodes.Add(new KeyValuePair<short, long>(idData[index], progress));
                }
            }
        }
        catch (Exception e)
        {
            ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
        }
    }

    private short[] ToShortArray(object obj)
    {
        if (obj is byte[])
        {
            byte[] bytes = (byte[]) obj;
            short[] result = new short[bytes.Length];
            for (int index = 0; index < bytes.Length; index++)
            {
                result[index] = (short) bytes[index];
            }
            return result;
        }
        else if (obj is short[])
        {
            return (short[]) obj;
        }
        else
        {
            throw new Exception("Unsupported type " + obj.GetType().Name);
        }
    }

}