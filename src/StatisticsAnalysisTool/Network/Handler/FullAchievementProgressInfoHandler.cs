using StatisticsAnalysisTool.Network.Events;
using StatisticsAnalysisTool.Network.Manager;
using System.Threading.Tasks;

namespace StatisticsAnalysisTool.Network.Handler;

public class FullAchievementProgressInfoHandler : EventPacketHandler<FullAchievementProgressInfoEvent>
{
    private readonly TrackingController _trackingController;

    public FullAchievementProgressInfoHandler(TrackingController trackingController) : base((int) EventCodes.FullAchievementProgressInfo)
    {
        _trackingController = trackingController;
    }

    protected override async Task OnActionAsync(FullAchievementProgressInfoEvent value)
    {
        _trackingController.EntityController.AchievementInfo.Merge(value);

        await Task.CompletedTask;
    }
}