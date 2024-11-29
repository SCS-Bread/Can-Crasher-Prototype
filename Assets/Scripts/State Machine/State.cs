

public interface IState
{
    Fsm Fsm { get; }
    void Enter();
    void Stay();
    void Exit();
}


public class StartState : IState
{
    public Fsm Fsm { get; private set; }


    public StartState(Fsm fsm)
    {
        Fsm = fsm;
    }   

    public void Enter()
    {
        Fsm.GameManager.UIManager.SetStartCanvasActive(true);
        Fsm.GameManager.UIManager.SetGameCanvasActive(false);
        Fsm.GameManager.UIManager.SetResultCanvasActive(false);

        Fsm.GameManager.UIManager.OnStartButtonClick += StartGame;
    }

    public void Stay()
    {

    }

    public void Exit()
    {
        Fsm.GameManager.UIManager.OnStartButtonClick -= StartGame;
    }

    private void StartGame()
    {
        Fsm.ChangeState(new GameState(Fsm));
    }
}


public class GameState : IState
{
    public Fsm Fsm { get; private set; }

    private Countdown countdown;
    private int score;

    public GameState(Fsm fsm)
    {
        Fsm = fsm;
    }

    public void Enter()
    {
        score = 0;
        Fsm.GameManager.UIManager.SetStartCanvasActive(false);
        Fsm.GameManager.UIManager.SetGameCanvasActive(true);
        Fsm.GameManager.UIManager.SetResultCanvasActive(false);
        countdown = new Countdown(Fsm.GameManager.Setting.CountdownTime);
        countdown.Start();
    }

    public void Stay()
    {
        if (Fsm.GameManager.InputManager.Tap)
        {
            score++;
        }

        Fsm.GameManager.UIManager.SetCountdownText(GetCountdownTimeMS(countdown.Remain));
        Fsm.GameManager.UIManager.SetGameScoreText($"Score: {score.ToString("000")}");

        if (countdown.Remain <= 0) 
        {
            Fsm.ChangeState(new ResultState(Fsm, score));
        }
    }

    public void Exit()
    {
        countdown.Reset();
    }

    private string GetCountdownTimeMS(float sec)
    {
        int minute = (int)(sec / 60);
        int second = (int)(sec % 60);
        return $"{minute.ToString("00")}:{second.ToString("00")}";
    }
}


public class ResultState : IState
{
    public Fsm Fsm { get; private set; }
    private int resultScore;

    public ResultState(Fsm fsm, int score)
    {
        Fsm = fsm;
        resultScore = score;
    }

    public void Enter()
    {
        Fsm.GameManager.UIManager.SetStartCanvasActive(false);
        Fsm.GameManager.UIManager.SetGameCanvasActive(false);
        Fsm.GameManager.UIManager.SetResultCanvasActive(true);

        Fsm.GameManager.UIManager.OnRetryButtonClick += RetryGame;
        Fsm.GameManager.UIManager.SetResultScoreText(GetScoreString(resultScore));
    }

    public void Stay()
    {

    }

    public void Exit()
    {
        Fsm.GameManager.UIManager.OnRetryButtonClick -= RetryGame;
    }

    private string GetScoreString(int score)
    {
        return $"Score: {score.ToString()}";
    }

    private void RetryGame() 
    {
        Fsm.ChangeState(new StartState(Fsm));
    }
}