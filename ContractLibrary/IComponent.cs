namespace Contracts
{
    public interface IComponent
    {
        string Description { get; }
        string ManipulateOperation(params double[] args);
    }
}
