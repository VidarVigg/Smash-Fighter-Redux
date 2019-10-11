public abstract class AiState
{
    protected Character character;

    protected AiState(Character character)
    {
        this.character = character;
    }

    public abstract void EnterState();
    public abstract void Update();

}