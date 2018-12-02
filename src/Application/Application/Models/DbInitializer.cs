using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Models
{
    public static class DbInitializer
    {
        public static void Initialize(UserContext context)
        {
            context.Database.EnsureCreated();

            if (context.UserItems.Any())
            {
                return;   // DB has been seeded
            }

            var tutorItem = new UserItem()
            {
                Created = DateTime.Now,
                Name = "Sean",
                Surname = "Sean",
                Login = "sean",
                Email = "dont@know.com",
                Password = "MyPassword"
            };

            var studentItem = new UserItem()
            {
                Created = DateTime.Now,
                Name = "Bartosz",
                Surname = "Kowalczyk",
                Login = "kowalczykb",
                Email = "kowalczb@gmail.com",
                Password = "MyPassword"
            };

            var users = new UserItem[]
            {
                studentItem,
                tutorItem
            };
            foreach (var user in users)
            {
                context.Add(user);
            }

            context.SaveChanges();

            var tutors = new TutorItem[]
            {
                new TutorItem() {Profile = "I am a boss here", Students = new List<StudentItem>() { }, User = tutorItem},
            };
            foreach (var tutor in tutors)
            {
                context.Add(tutor);
            }

            context.SaveChanges();

            var students = new StudentItem[]
            {
                new StudentItem() {Country = "Poland", User = studentItem, Tutors = new List<TutorItem>()}
            };
            foreach (var student in students)
            {
                context.Add(student);
            }

            context.SaveChanges();
        }
    }
}
