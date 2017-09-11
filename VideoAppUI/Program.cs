using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using VideoAppBLL;
using VideoAppBLL.BusinessObjects;

namespace VideoAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        static List<VideoBO> videosToAdd = new List<VideoBO>();

        static void Main(string[] args)
        {
            string[] menuItems =
            {
                "Show Videos",
                "Search for video",
                "Add Video",
                "Delete Video",
                "Edit Video",
                "Exit"
            };

            AddDefaultVideos();
            

            var selection = ShowMenu(menuItems);

            while (selection != 6)
            {
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        ShowVideos();
                        break;
                    case 2:
                        SearchForVideo();
                        break;
                    case 3:
                        HowManyNewVideos();
                        break;
                    case 4:
                        DeleteVideo();
                        break;
                    case 5:
                        EditVideo();
                        break;
                    default:
                        Console.WriteLine("Something went terribly wrong!");
                        break;
                }
                selection = ShowMenu(menuItems);
            }
            Console.WriteLine("Mojn");
            Console.ReadLine();
        }

        private static void HowManyNewVideos()
        {
            Console.WriteLine("How many videos do you want to add?");
            int inputId;
            while (!int.TryParse(Console.ReadLine(), out inputId))
            {
                Console.WriteLine("That is not a valid input");
            }
            if (inputId == 1)
            {
                AddVideo();
            }
            else
            {
                for (int i = 0; i < inputId; i++)
                {
                    AddVideoToList();
                }
                AddVideos();
            }
        }

        private static void SearchForVideo()
        {
            Console.Write("Search: ");
            var query = Console.ReadLine().ToLower();
            var searchList = bllFacade.VideoService.Search(query);
            if (!searchList.Any())
            {
                Console.WriteLine("No videos found");
            }
            else
            {
                searchList.ForEach(x => Console.WriteLine($"ID: {x.Id}. Name: {x.Name}. Price: {x.Price}."));
            }
        }

        private static void EditVideo()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                Console.WriteLine($"Current Name: {videoFound.Name}");
                Console.WriteLine("Insert new name:");
                videoFound.Name = Console.ReadLine();
                Console.WriteLine($"Current price: {videoFound.Price}");
                Console.WriteLine("Insert new price:");
                float inputPrice;
                while (!float.TryParse(Console.ReadLine(), out inputPrice))
                {
                    Console.WriteLine("That is not a valid input");
                }
                videoFound.Price = inputPrice;
                bllFacade.VideoService.Update(videoFound);
            }
            else
            {
                Console.WriteLine("Video not found");
            }
        }

        private static void DeleteVideo()
        {
            var videoFound = FindVideoById();
            if (videoFound != null)
            {
                bllFacade.VideoService.Delete(videoFound.Id);
            }
            var response = videoFound == null ? "Video not found" : "Video was deleted";
            Console.WriteLine(response);
        }

        private static VideoBO FindVideoById()
        {
            Console.WriteLine("Insert video id:");
            int inputId;
            while (!int.TryParse(Console.ReadLine(), out inputId))
            {
                Console.WriteLine("That is not a valid input");
            }
            return bllFacade.VideoService.GetById(inputId);
        }

        private static void AddVideo()
        {
            Console.WriteLine("Input name:");
            var name = Console.ReadLine();
            Console.WriteLine("Input price:");
            float price;
            while (!float.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("That is not a valid input");
            }

            bllFacade.VideoService.Create(new VideoBO()
            {
                Name = name,
                Price = price
            });
        }

        private static void AddVideoToList()
        {
            Console.WriteLine("Input name:");
            var name = Console.ReadLine();
            Console.WriteLine("Input price:");
            float price;
            while (!float.TryParse(Console.ReadLine(), out price))
            {
                Console.WriteLine("That is not a valid input");
            }

            videosToAdd.Add(new VideoBO()
            {
                Name = name,
                Price = price
            });

        }

        private static void AddVideos()
        {
            bllFacade.VideoService.AddVideos(videosToAdd);
            videosToAdd.Clear();
        }

        private static void ShowVideos()
        {
            foreach (var video in bllFacade.VideoService.GetAll())
            {
                Console.WriteLine($"Id: {video.Id} Name: {video.Name}. Price: {video.Price}");
            }
        }

        private static void AddDefaultVideos()
        {
            bllFacade.VideoService.Create(new VideoBO()
            {
                Name = "First Video",
                Price = 100
            });
            bllFacade.VideoService.Create(new VideoBO()
            {
                Name = "Second Video",
                Price = 200
            });
            bllFacade.VideoService.Create(new VideoBO()
            {
                Name = "Third Video",
                Price = 300
            });
        }

        private static int ShowMenu(string[] menuItems)
        {
            //Clear();
            Console.WriteLine("Select what to do:\n");
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {menuItems[i]}");
            }
            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                   || selection < 1 || selection > menuItems.Length)
            {
                Console.WriteLine("That is not a valid input");
            }
            return selection;
        }
    }
}