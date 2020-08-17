namespace ProAgil.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        int Commit();


        IEventRepository EventRepository { get; }
        ILotRepository LotRepository { get; }
    }
}