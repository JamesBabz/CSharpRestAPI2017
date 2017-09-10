using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using VideoAppBLL;
using VideoAppEntity;

namespace VideoAppUI
{
    class Program
    {
        static BLLFacade bllFacade = new BLLFacade();
        static List<Video> videosToAdd = new List<Video>();

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
                searchList.ForEach(x => Console.WriteLine($"ID: {x.Id}. Name: {x.Name}. Genre: {x.Genre}."));
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
                Console.WriteLine($"Current Genre: {videoFound.Genre}");
                Console.WriteLine("Insert new genre:");
                videoFound.Genre = Console.ReadLine();
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

        private static Video FindVideoById()
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
            Console.WriteLine("Input genre:");
            var genre = Console.ReadLine();

            bllFacade.VideoService.Create(new Video()
            {
                Name = name,
                Genre = genre
            });
        }

        private static void AddVideoToList()
        {
            Console.WriteLine("Input name:");
            var name = Console.ReadLine();
            Console.WriteLine("Input genre:");
            var genre = Console.ReadLine();

            videosToAdd.Add(new Video()
            {
                Name = name,
                Genre = genre
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
                Console.WriteLine($"Id: {video.Id} Name: {video.Name}. Genre: {video.Genre}");
            }
        }

        private static void AddDefaultVideos()
        {
            bllFacade.VideoService.Create(new Video()
            {
                Name = "First Video",
                Genre = "Action"
            });
            bllFacade.VideoService.Create(new Video()
            {
                Name = "Second Video",
                Genre = "Comedy"
            });
            bllFacade.VideoService.Create(new Video()
            {
                Name = "Third Video",
                Genre = "Thriller"
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