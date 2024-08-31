using StatisticsAnalysisTool.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace StatisticsAnalysisTool.Network.Events;

[DataContract]
public class FullAchievementInfoEvent
{
    [DataMember(Name = "nodes")]
    private readonly List<short[]> _nodes = new();

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
                    _nodes.Add(new short[] { idData[index], levelData[index] });
                }
            }
        }
        catch (Exception e)
        {
            ConsoleManager.WriteLineForError(MethodBase.GetCurrentMethod()?.DeclaringType, e);
        }
    }

    public string ToJson()
    {
        var serializer = new DataContractJsonSerializer(typeof(FullAchievementInfoEvent));

        using (var stream = new MemoryStream())
        {
            using (var writer = JsonReaderWriterFactory.CreateJsonWriter(stream))
            {
                serializer.WriteObject(writer, this);
            }

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }

}