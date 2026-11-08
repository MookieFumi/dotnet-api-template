namespace Acme.Worker;

/// <summary>
/// Placeholder background service: logs a heartbeat and stops cleanly. Replace it with your own work.
/// </summary>
public sealed partial class HeartbeatWorker(ILogger<HeartbeatWorker> logger) : BackgroundService
{
    private static readonly TimeSpan Interval = TimeSpan.FromSeconds(30);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var timer = new PeriodicTimer(Interval);

        while (await WaitForNextTickAsync(timer, stoppingToken))
        {
            LogAlive(DateTimeOffset.UtcNow);
        }
    }

    [LoggerMessage(Level = LogLevel.Information, Message = "Worker is alive at {Time}")]
    private partial void LogAlive(DateTimeOffset time);

    private static async Task<bool> WaitForNextTickAsync(PeriodicTimer timer, CancellationToken stoppingToken)
    {
        try
        {
            return await timer.WaitForNextTickAsync(stoppingToken);
        }
        catch (OperationCanceledException)
        {
            return false;
        }
    }
}
