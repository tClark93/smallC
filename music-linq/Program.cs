using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
                             
            // IEnumerable<Artist> result = from artist in Artists.Where(artist => artist.Hometown == "Mount Vernon")
            // select artist;
            // Console.WriteLine(result.Count());
            // foreach (Artist i in result)
            // {
            //     Console.WriteLine("Name: {0}, Age: {1}",i.ArtistName,i.Age);
            // }

            //Who is the youngest artist in our collection of artists?

            Artist young = Artists.OrderByDescending(Artist => Artist.Age).Last();
            System.Console.WriteLine("Name: {0}, Age: {1}", young.ArtistName, young.Age);

            //Display all artists with 'William' somewhere in their real name

            // IEnumerable<Artist> will = from artist in Artists.Where(artist => artist.RealName.Contains("William"))
            // select artist;
            // Console.WriteLine(will.Count());
            // foreach (Artist i in will)
            // {
            //     Console.WriteLine("Artist Name: {0}, Real Name: {1}", i.ArtistName, i.RealName);
            // }

            //Display the 3 oldest artist from Atlanta

            // IEnumerable<Artist> old = from artist in Artists.Where(artist => artist.Hometown == "Atlanta")
            // select artist;
            // IEnumerable<Artist> old2 = old.OrderByDescending(artist => artist.Age).Take(3);
            // foreach(Artist i in old2){
            //     Console.WriteLine("Name: {0}, Age: {1}",i.ArtistName,i.Age);
    
            // }

            //(Optional) Display the Group Name of all groups that have members that are not from New York City

            // IEnumerable<Artist> group = from artist in Artists.Where(artist => artist.Hometown != "New York City")
            // select artist;
            // List<int> IDs = new List<int>();
            // foreach(Artist i in group)
            // {
            //     IDs.Add(i.GroupId);
            // }
            // IEnumerable<int> distinct = IDs.Distinct();
            // foreach(int i in distinct){
            //     var name = Groups.Select(Group.Id == i);
            //     System.Console.WriteLine("Name: {0}", name.GroupName);
            //     Console.WriteLine(i);
            // }
            
            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
        }
    }
}
