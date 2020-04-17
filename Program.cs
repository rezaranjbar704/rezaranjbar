using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace ConsoleApp1
{
    
    
    
    
    class Program
    {
        static void Main(string[] args)
        {
            DbInit();
            Create(name:"Reza.Ranjbar",email:"rezaranjbar704@gmail.com");
            Read(1);
            Upadte(1 , newName: "Reza Ranjbar" , newEmail: "rezaranjbar704");
            Delete(1);

            Console.WriteLine("Hello World!");
        }

        private static void Delete(int id)
        {
            using (Applivationdb db = new Applivationdb())
            {
                Student stu = db.Students.Find(id);
                db.Students.Remove(stu);
            }
        }

        private static void Upadte(int id , string newEmail , string newName)
        {
            using (Applivationdb db = new Applivationdb())
            {
                Student stu = db.Students.Find(id);
                stu.Name = newName;
                stu.Email = newEmail;
                db.SaveChanges();
            }
        }

        private static void Read(int Id)
        {
            using (Applivationdb db = new Applivationdb())
            {
                Student stu = db.Students.Find(Id);
                Console.WriteLine(stu);
            }
        }

        private static void DbInit()
        {
            using (Applivationdb db = new Applivationdb())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }
        
        public static void Create(string name , string email)
        {
            using (Applivationdb db = new Applivationdb())
            {
                Student student = new Student() {Name = name, Email = email};
                db.Students.Add(student);
                db.SaveChanges();
            }
        }

    }
}