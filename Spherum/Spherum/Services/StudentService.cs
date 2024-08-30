using System;
using Spherum.Models;

namespace Spherum.Services
{
	public class StudentService
	{
        private int _lastId = 0;
        private readonly Random _random = new();
        private List<string> names = new List<string> { "Vivek Negi", "Vikas", "Rahul", "Rohan", "Adam", "Richerd", "Aiden bles", "Olivia", "Jackson", "Emma", "Liam", "Sophia", "Lucas", "Ava",
    "Noah", "Isabella Calon", "Ethan", "Mia", "Mason", "Amelia", "Caden", "Harper",
    "Logan", "Charlotte", "James", "Abigail", "Alexander", "Emily", "Elijah",
    "Madison", "Benjamin", "Elizabeth", "Jacob", "Scarlett", "Michael", "Evelyn",
    "Sebastian", "Victoria", "Matthew", "Grace", "Henry", "Chloe", "Daniel",
    "Ellie", "Owen", "Nora", "Samuel", "Lily", "Jackson", "Zoe", "David", "Hannah",
    "Joseph", "Lillian", "John", "Addison","Vivek Negi", "Vikas", "Rahul", "Rohan", "Adam", "Richerd", "Aiden bles", "Olivia", "Jackson", "Emma", "Liam", "Sophia", "Lucas", "Ava",
    "Noah", "Isabella Calon", "Ethan", "Mia", "Mason", "Amelia", "Caden", "Harper",
    "Logan", "Charlotte", "James", "Abigail", "Alexander", "Emily", "Elijah",
    "Madison", "Benjamin", "Elizabeth", "Jacob", "Scarlett", "Michael", "Evelyn",
    "Sebastian", "Victoria", "Matthew", "Grace", "Henry", "Chloe", "Daniel",};
        public async Task<List<Student>> GetStudentsAsync()
        {
            await Task.Delay(1000);

            // Generate some fake data
            var students = new List<Student>();
            for (int i = 0; i < 50; i++)
            {
                students.Add(new Student
                {
                    Id = ++_lastId,
                    Name = names[i],
                    Age = _random.Next(10,60),
                    PhoneNumber = "+91 8282728" + _lastId
                });
            }

            return students;
        }
    }
}

