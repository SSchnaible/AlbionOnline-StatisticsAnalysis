using StatisticsAnalysisTool.Network.Events;
using StatisticsAnalysisTool.Network.Manager;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Network.Handler;

public class FullAchievementInfoHandler : EventPacketHandler<FullAchievementInfoEvent>
{
    private readonly TrackingController _trackingController;

    public FullAchievementInfoHandler(TrackingController trackingController) : base((int) EventCodes.FullAchievementInfo)
    {
        _trackingController = trackingController;
    }

    protected override async Task OnActionAsync(FullAchievementInfoEvent value)
    {
        _trackingController.EntityController.AchievementData = value.ToJson();

        await Task.CompletedTask;
    }
}