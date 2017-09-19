using CustomerAppBLL.BusinessObjects;
using CustomerAppDAL.Entities;

namespace CustomerAppBLL.Converters
{
    class VideoConverter
    {

        internal Video Convert(VideoBO vid)
        {
            if (vid == null) { return null; }
            return new Video()
            {
                Id = vid.Id,
                Genre = vid.Genre,
                Title = vid.Title,
                PricePerDay = vid.PricePerDay
            };
        }

        internal VideoBO Convert(Video vid)
        {
            if (vid == null) { return null; }
            return new VideoBO()
            {
                Id = vid.Id,
                Genre = vid.Genre,
                Title = vid.Title,
                PricePerDay = vid.PricePerDay
            };
        }
    }
}
