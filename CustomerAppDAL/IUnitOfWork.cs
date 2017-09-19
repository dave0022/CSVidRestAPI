using System;
namespace CustomerAppDAL
{
    public interface IUnitOfWork : IDisposable
    {
        IVideoRepository VideoRepository { get; }
        IOrderRepository OrderRepository { get; }


        int Complete();
    }
}
