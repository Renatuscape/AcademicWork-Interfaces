using System.Reflection.Metadata;
using System.Text;

namespace AW_Interfaces
{
    public class BrightsCSharp : ICourse
    {
        List<string> _ParticipantNames = new();
        public int CourseYear { get; set; } = 2023;

        public void SignUpForCourse(string participantName)
        {
            _ParticipantNames.Add(participantName);
        }

        public string GetCourseParticipantName(int participantIndex)
        {
            return _ParticipantNames[participantIndex];
        }
        public List<string> GetCourseParticipantNames()
        {
            return _ParticipantNames;
        }

        public void SaveToFile(List<string> participantList, string? filePath = null)
        {
            string presetPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(@"\bin") + 1) + @"CourseParticipants.txt";

            var path = filePath ?? presetPath;

            try
            {
                using (StreamWriter streamWriter = new(path, false, Encoding.UTF8))
                {
                    streamWriter.WriteLine("Class of " + CourseYear);

                    foreach (string participantName in participantList)
                    {
                        streamWriter.WriteLine(participantName);
                    }

                    Console.WriteLine("Course participants saved to file.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void LoadFromFile(string? filePath = null)
        {
            string presetPath = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.LastIndexOf(@"\bin") + 1) + @"CourseParticipants.txt";

            var path = filePath ?? presetPath;

            using (StreamReader streamReader = new(path, Encoding.UTF8)) //.Unicode))
            {
                string? line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (line.Contains("Class of "))
                    {
                        CourseYear = int.Parse(line.Replace("Class of ", ""));
                    }
                    else
                    {
                        SignUpForCourse(line);
                    }
                }
            }
        }

    }
}