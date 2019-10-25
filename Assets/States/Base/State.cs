public abstract class State
{

    protected Character character;

    protected State(Character character)
    {
        this.character = character;
    }

    public abstract void EnterState();
    public abstract void Update();
    public abstract void ExitState();
    public abstract void Handle(State state);

}