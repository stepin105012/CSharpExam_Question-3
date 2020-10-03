using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExam
{
    [Serializable]
    class Student

    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string RollNo { get; set; }
        public float Mark { get; set; }
        public override string ToString()
        {
            return string.Format($"Name: {Name}\nDepartment: {Department}\nRollNo: {RollNo}\nMark: {Mark}");
        }
    }
    class BinarySerializationDemo
    {
        static void Main(string[] args)
        {
            BinarySerialization();
        }
        private static void BinarySerialization()
        {
            Console.Write("Serialize or Deserialize? (S/D): ");
            string choice = Console.ReadLine();
            if (choice.ToLower() == "s")
                serialize();
            else
                deserialize();
        }

        private static void serialize()
        {
            Student stu = new Student { Name = "Binitta", Department="IT", RollNo = "20", Mark = 25 };
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream("Demo.bin", FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, s);
            fs.Close();
        }

        private static void deserialize()
        {
            FileStream fs = new FileStream("Demo.bin", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            Student s = bf.Deserialize(fs) as Student;
            Console.WriteLine(s.Name);
            Console.WriteLine(s.Department);
            Console.WriteLine(s.RollNo);
            Console.WriteLine(s.Mark);
            fs.Close();
        }
    }
}