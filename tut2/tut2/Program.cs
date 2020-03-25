using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

using static System.Console;

namespace tut2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Dima\source\repos\tut2\tut2\tut2\data.csv";
            var FileWriter = new FileStream("results.xml", FileMode.Create);
            var LogWriter = new FileStream("log.txt", FileMode.Create);

            if (args.Length == 3)
            {
                if (args[0] != null) { path = args[0]; }
                if (args[1] != null) { FileWriter = new FileStream(args[1], FileMode.Create); }
            }

            using (var writer = new StreamWriter(LogWriter))
                try
                {
                    var students = new List<Student>();
                    using (var stream = new StreamReader(File.OpenRead(path)))
                    {

                        string line = null;
                        while ((line = stream.ReadLine()) != null)
                        {
                            string[] student = line.Split(';');
                            var stud = new Student
                            {
                                FirstName = student[0],
                                LastName = student[1],
                                Studies = new Studies(student[2], student[3]),
                                StudentNumber = student[4],
                                DateOfBirth = student[5],
                                Email = student[6],
                                MotherName = student[7],
                                FatherName = student[8]
                            };
                            students.Add(stud);
                        }
                        var uni = new University
                        {
                            CreatedAt = DateTime.Now.ToString("dd.MM.yyyy", DateTimeFormatInfo.InvariantInfo),
                            Author = "Jan Kowalski",
                            Students = students
                        };

                        if (args.Length != 3 || !args[2].ToLower().Equals("json"))
                        {
                            var serializer = new XmlSerializer(typeof(University));
                            serializer.Serialize(FileWriter, uni);
                        }
                        else
                        {
                            var UniWrapper = new UniversityWrapper { University = uni };
                            var jsonString = JsonSerializer.Serialize(UniWrapper);
                            File.WriteAllText("data.json", jsonString);
                        }

                    }
                }
                catch (FileNotFoundException fnfe)
                {
                    writer.WriteLine("File does not exist");
                    WriteLine(fnfe.Message);
                }
                catch (ArgumentException ae)
                {
                    writer.WriteLine("The path is incorrect");
                    WriteLine(ae.Message);
                }
        }
    }
}
