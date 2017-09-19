using CustomerAppBLL;
using CustomerAppBLL.BusinessObjects;
using System;

namespace CustomerAppUI
{
   class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">dskdkslksd</param>
        static void Main(string[] args)
        {
            var video1 = new VideoBO()
            {
                Title = "Purple Forest",
                PricePerDay = "15 DKK",
                Genre = "Drama"
            };
            bllFacade.VideoService.Create(video1);

            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = "Blood Skulls",
                PricePerDay = "5 DKK",
                Genre = "Horror/Action"
            });

            string[] menuItems = {
                "List All Videos",
                "Add a Video",
                "Delete a Video",
                "Edit a Video",
                "Exit"
            };

            //Show Menu
            //Wait for Selection
            // - Show selection or
            // - Warning and go back to menu

            var selection = ShowMenu(menuItems);

            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        ListVideos();
                        break;
                    case 2:
                        AddVideos();
                        break;
                    case 3:
                        DeleteVideo();
                        break;
                    case 4:
                        EditVideo();
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("See you later!");

            Console.ReadLine();
        }

        private static void EditVideo()
        {
            var video = FindVideoById();
            if(video != null)
            {
                Console.WriteLine("Title: ");
                video.Title = Console.ReadLine();
                Console.WriteLine("PricePerDay: ");
                video.PricePerDay = Console.ReadLine();
                Console.WriteLine("Genre: ");
                video.Genre = Console.ReadLine();
				bllFacade.VideoService.Update(video);
			}
            else
            {
                Console.WriteLine("Video not Found!");
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>kdjfjkdf</returns>
        private static VideoBO FindVideoById()
        {
            Console.WriteLine("Insert Video Id: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Please insert a number");
            }
            return bllFacade.VideoService.Get(id);
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            if(videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }

            var response = 
                videoFound == null ?
                "Video not Found" : "Video was Deleted";
            Console.WriteLine(response);
        }

        private static void AddVideos()
        {
            Console.WriteLine("Title: ");
            var title = Console.ReadLine();

            Console.WriteLine("PricePerDay: ");
            var pricePerDay = Console.ReadLine();

            Console.WriteLine("Genre: ");
            var genre = Console.ReadLine();

            bllFacade.VideoService.Create(new VideoBO()
            {
                Title = title,
                PricePerDay = pricePerDay,
                Genre = genre
            });
        }

        private static void ListVideos()
        {
            Console.WriteLine("\nList of Videos");
            foreach (var customer in bllFacade.VideoService.GetAll())
            {
                Console.WriteLine($"Id: {customer.Id} Title: {customer.Title} " +
                                $"Genre: {customer.Genre}");
            }
            Console.WriteLine("\n");

        }

        private static int ShowMenu(string[] menuItems)
        {
            Console.WriteLine("Select What you want to do:\n");

            for (int i = 0; i < menuItems.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuItems[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("Please select a number between 1-5");
            }

            return selection;
        }
    }
}
