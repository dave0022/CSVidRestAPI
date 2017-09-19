using CustomerAppBLL.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL
{
    /// <summary>
    /// I made a Contract!!!!
    /// </summary>
    public interface IVideoService
    {
        //C
        VideoBO Create(VideoBO vid);
        //R
        List<VideoBO> GetAll();
        VideoBO Get(int Id);
        //U
        VideoBO Update(VideoBO vid);
        //D
        VideoBO Delete(int Id);
    }
}
