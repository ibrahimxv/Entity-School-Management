using ConsoleApp23.Entity;
using Microsoft.EntityFrameworkCore;

using var context = new ConsoleApp23.DbContext.SchoolDbContext();

Students student = new Students
{
    FirstName = "Ali",
    LastName = "Mammadov",
    Age = 20,
    Email = "ali@gmail.com"
};

context.Students.Add(student);
await context.SaveChangesAsync();
Console.WriteLine("Student added.");

Students student2 = new Students
{
    FirstName = "Hebib",
    LastName = "Ramazanov",
    Age = 30,
    Email = "habib@gmail.com"
};

context.Students.Add(student2);
await context.SaveChangesAsync();
Console.WriteLine("Student added.");

var students = await context.Students.ToListAsync();

foreach (var s in students)
{
    Console.WriteLine($"Id: {s.Id}, Name: {s.FirstName} {s.LastName}, Age: {s.Age}, Email: {s.Email}");
}

int updatedStudentId = 1;
int newAge = 21;

var studentToUpdate = await context.Students.FindAsync(updatedStudentId);
if (studentToUpdate is not null)
{
    studentToUpdate.Age = newAge;
    await context.SaveChangesAsync();
}

int deleteId = 2;

var studentToDelete = await context.Students.FindAsync(deleteId);
if (studentToDelete is not null)
{
    context.Students.Remove(studentToDelete);
    await context.SaveChangesAsync();
}

var students = await context
    .Students
    .Where(s => s.Age > 18)
    .ToListAsync();

var students1 = context.Students
    .OrderBy(s => s.FirstName)
    .ToListAsync();

var students2 = await context.Students
    .OrderByDescending(s => s.Age)
    .Take(3)
    .ToListAsync();

foreach (var student in students2)
{
    Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Age}");
}

var studentsByName = await context.Students
    .Where(s => s.FirstName.Contains("Ali"))
    .ToListAsync();

foreach (var student in studentsByName)
{
    Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Age}");
}

var studentsCount = await context.Students.CountAsync();

Console.WriteLine(studentsCount);

var studensAges = await context.Students
    .Where(s => s.Age >= 20 && s.Age <= 25)
    .ToListAsync();

foreach (var student in studensAges)
{
    Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Age}");
}

var studentsWithEmail = await context.Students
    .Where(s => s.Email.EndsWith("@outlook.com"))
    .ToListAsync();

foreach (var student in studentsWithEmail)
{
    Console.WriteLine($"{student.FirstName} {student.LastName} - {student.Email}");
}