using System;
using System.Collections.Generic;
using System.Text;
using CustomerAppDAL;
using System.Linq;
using CustomerAppDAL.Entities;
using CustomerAppBLL.BusinessObjects;
using CustomerAppBLL.Converters;

namespace CustomerAppBLL.Services
{
    class VideoService : IVideoService
    {
        VideoConverter conv = new VideoConverter();
        DALFacade facade;
        public VideoService(DALFacade facade)
        {
            this.facade = facade;
        }

        public VideoBO Create(VideoBO vid)
        {
            using(var uow = facade.UnitOfWork)
            {
				var newVid = uow.VideoRepository.Create(conv.Convert(vid));
				uow.Complete();
				return conv.Convert(newVid);
            }
        }

        public void CreateAll(List<VideoBO> videos)
        {
            using (var uow = facade.UnitOfWork)
            {
                foreach (var video in videos)
                {
                    uow.VideoRepository.Create(conv.Convert(video));
                   

                }
                uow.Complete();


            }
        }

        public VideoBO Delete(int Id)
        {
			using (var uow = facade.UnitOfWork)
			{
				var newVid = uow.VideoRepository.Delete(Id);
				uow.Complete();
				return conv.Convert(newVid);
			}
        }

        public VideoBO Get(int Id)
        {
            using (var uow = facade.UnitOfWork)
			{
				return conv.Convert(uow.VideoRepository.Get(Id));
			}
        }

        public List<VideoBO> GetAll()
        {
			using (var uow = facade.UnitOfWork)
			{
                //Customer -> CustomerBO
                //return uow.CustomerRepository.GetAll();
                return uow.VideoRepository.GetAll().Select(conv.Convert).ToList();
			}
        }

        public VideoBO Update(VideoBO vid)
        {
            using (var uow = facade.UnitOfWork)
            {
                var videoFromDb = uow.VideoRepository.Get(vid.Id);
				if (videoFromDb == null)
				{
					throw new InvalidOperationException("Video not found!");
				}

				videoFromDb.Title = vid.Title;
				videoFromDb.PricePerDay = vid.PricePerDay;
				videoFromDb.Genre = vid.Genre;
                uow.Complete();
				return conv.Convert(videoFromDb);
            }

        }

    }
}
