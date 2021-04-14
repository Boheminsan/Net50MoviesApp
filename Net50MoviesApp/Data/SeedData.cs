using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net50MoviesApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Net50MoviesApp.Data
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();
            context.Database.Migrate();

            var genres = new List<Genre>()
                    {
                                new Genre(){Name="Romantik",Movies=new List<Movie>()
                                {
                                    new Movie() {
                                Title= "Başlık7",
                                Description = "Aras Bulut Çok Nemli açıklama. Çok önemli, açıklama.",
                                //Director= "Sektöründe Öncü Yönetmen",
                                Year= "2007",
                                ImageUrl="1.jpg"},
                                    new Movie() {
                                Title= "Başlık8",
                                Description = "Çok nemli açıklama. Çok önemli, açıklama.",
                                //Director= "Sektöründe Öncü Yönetmen",
                                Year= "2015",
                                ImageUrl="2.jpg"},
                                }
                                },
                                new Genre(){Name="Macera"},
                                new Genre(){Name="Komedi"},
                                new Genre(){Name="Aksiyon"},
                                new Genre(){Name="Dram"},
                                new Genre(){Name="Polisiye"}
                    };
            var movies = new List<Movie>() {
                            new Movie() {
                                Title= "Başlık1",
                                Description = "Çok önemli açıklama. Çok önemli, açıklama.",
                                //Director= "Sektöründe Öncü Yönetmen",
                                Year= "2021",
                                ImageUrl="1.jpg",
Genres=new List<Genre>(){genres[1],genres[4],new Genre() { Name="Savaş"} }                            },
                            new Movie() {
                                Title= "Başlık2",
                                Description = "Yok sana açıklama falan. Çok önemli bir açıklama.",
                                //Director= "İsmini Vermek İstemeyen Yönetmen",
                                Year= "2005",
                                ImageUrl="2.jpg",
Genres=new List<Genre>(){genres[2],genres[3]}                            },
                            new Movie() {
                                Title= "Başlık3",
                                Description = "Tek açıklama. Pek güzel açıklama.",
                                //Director= "Alemin Hızlı Yönetmeni",
                                Year= "2011",
                                ImageUrl="3.jpg",
Genres=new List<Genre>(){genres[3],genres[4]}                            },
                            new Movie() {
                                Title= "Başlık4",
                                Description = "Çok iyi açıklama. Çok önemliyse açıklama.",
                                //Director= "Gizli Yönetmen",
                                Year= "2014",
                                ImageUrl="4.jpg",
Genres=new List<Genre>(){genres[0],genres[2]}                            },
                            new Movie() {
                                Title= "Başlık5",
                                Description = "Çok güzel açıklama. Çok açıklama.",
                                //Director= "Çakma Yönetmen",
                                Year= "2008",
                                ImageUrl="5.jpg",
                                Genres=new List<Genre>(){genres[1],genres[5]}
                            }
                        };
            var users = new List<User>() {
                new User(){UserName="usera",Email="usera@cousera.com",Password="abcd213456",UserImg="user1.jpg"},
                new User(){UserName="userb",Email="userb@bousera.com",Password="abcd213456",UserImg="user2.jpg"},
                new User(){UserName="userc",Email="userc@cccourse.com",Password="ccc123123",UserImg="user3.jpg"},
                 new User(){UserName="userd",Email="userd@doursena.com",Password="d123123",UserImg="user4.jpg"},
                new User(){UserName="usere",Email="usere@userehahehehe.com",Password="dh123123",UserImg="user5.jpg"},
                  new User(){UserName="userf",Email="userf@foursoma.com",Password="forgy123123",UserImg="user6.jpg"}
            };
            var people = new List<Person>() {
            new Person()
                    {
                        Name="Cahit Gürel",
                ImgUrl="cgurel.jpg",
                Biography="Boğmadan döndüm ben.", User=users[0]
                    },
            new Person(){
                Name="Ramazan Akalar",
                ImgUrl="akalarr.jpg",
                Biography="Doğmadan öldüm ben.",
                User=users[1]
            },
            new Person()
                    {
                        Name="Hakan Geldiler",
                ImgUrl="hakanyavas.jpg",
                Biography="Sökmeden ciğerimi.", User=users[2]
                    },
            new Person()
                    {
                        Name="Güliz Yalpak",
                ImgUrl="yalpak.jpg",
                Biography="Boğmacadan söndüm ben.", User=users[3]
                    },
            new Person()
                    {
                        Name="Aslıhan Dolgun",
                ImgUrl="dolgun.jpg",
                Biography="Kaş döndüren dolgun kaşlar.", User=users[4]
                    },
            new Person()
                    {
                        Name="Toygar Yetkin",
                ImgUrl="tyetkin.jpg",
                Biography="Bulmacadan gördüm seni.", User=users[5]
                    },
            };
            var crew = new List<Crew>()
            {
                new Crew() {Movie=movies[0], Person=people[0], Job="Yönetmen"},
                new Crew() {Movie=movies[0], Person=people[5], Job="Yönetmen yrd."},
                new Crew() {Movie=movies[1], Person=people[1], Job="2. Yönetmen"},
                new Crew() {Movie=movies[3], Person=people[5], Job="Senarist"},
            };
            var cast = new List<Cast>()
            {
               new Cast()
               {
                   Movie=movies[0], Person=people[0], Name="Cahit Gürel",CharacterName="Ders Sevmez Hamdi"
               },
               new Cast()
               {
                   Movie=movies[2], Person=people[1], Name="Ramazan Akalar",CharacterName="Nedim Hamakçı"
               },

               new Cast()
               {
                   Movie=movies[1], Person=people[2], Name="Hakan Geldiler",CharacterName="Memur Muzaffer"
               },
               new Cast()
               {
                   Movie=movies[3], Person=people[3], Name="Güliz Yalpak",CharacterName="Özel Sekreter"
               },
               new Cast()
               {
                   Movie=movies[3], Person=people[4], Name="Aslıhan Dolgun",CharacterName="Apartman Sakini"
               }
            };
            if (context.Genres.Count() == 0)
            {
                context.Genres.AddRange(genres);
            }
            if (context.People.Count() == 0)
            {
                context.People.AddRange(people);
            }
            if (context.Crew.Count() == 0)
            {
                context.Crew.AddRange(crew);
            }
            if (context.Players.Count() == 0)
            {
                context.Players.AddRange(cast);
            }
            if (context.Users.Count() == 0)
            {
                context.Users.AddRange(users);
            }

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Movies.Count() == 0)
                {
                    context.Movies.AddRange(movies);
                }

                context.SaveChanges();
            }
        }
    }
}