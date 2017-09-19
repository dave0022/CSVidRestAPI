using CustomerAppDAL.Entities;
using System.Collections.Generic;

namespace CustomerAppDAL
{
    public interface IVideoRepository
    {
        //C
        Video Create(Video cust);
        //R
        List<Video> GetAll();
        Video Get(int Id);
        //U
        //No Update for Repository, It will be the task of Unit of Work
        //D
        Video Delete(int Id);
    }
}
