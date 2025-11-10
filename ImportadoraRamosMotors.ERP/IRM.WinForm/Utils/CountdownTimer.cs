namespace IRM.WinForm.Utils;

public class CountdownTimer
{
    private int _secondsRemaining;
    private readonly Action _onCountdownFinished;

    public CountdownTimer(int seconds, Action onCountdownFinished)
    {
        _secondsRemaining = seconds;
        _onCountdownFinished = onCountdownFinished;

    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var timer = new PeriodicTimer(TimeSpan.FromSeconds(1));

        while (_secondsRemaining > 0 && !cancellationToken.IsCancellationRequested)
        {
            await timer.WaitForNextTickAsync(cancellationToken);
            _secondsRemaining--;


            if (_secondsRemaining <= 0)
            {
                Console.WriteLine("¡Cuenta regresiva terminada!");
                _onCountdownFinished?.Invoke();
            }
        }
    }
}
