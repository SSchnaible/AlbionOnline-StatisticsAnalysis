using StatisticsAnalysisTool.Network.Events;
using System.Collections.Generic;

namespace StatisticsAnalysisTool.Models;

public class FullAchievementInfo
{
    public FullAchievementInfo()
    {
    }

    public Dictionary<short, AchievementInfo> nodes { get; } = new();

    public void Merge(FullAchievementInfoEvent infoEvent)
    {
        foreach (KeyValuePair<short, short> node in infoEvent.nodes)
        {
            if (!nodes.ContainsKey(node.Key))
            {
                nodes[node.Key] = new AchievementInfo();
            }
            nodes[node.Key].level = node.Value;
        }
    }

    public void Merge(FullAchievementProgressInfoEvent infoEvent)
    {
        foreach (KeyValuePair<short, long> node in infoEvent.nodes)
        {
            if (!nodes.ContainsKey(node.Key))
            {
                nodes[node.Key] = new AchievementInfo();
            }
            nodes[node.Key].progress = node.Value;
        }
    }

    public string ToJson()
    {
        return System.Text.Json.JsonSerializer.Serialize(nodes);
    }

}