namespace AW_Interfaces
{
    public interface ICourse
    {
        void SignUpForCourse(string participantName);
        string GetCourseParticipantName(int participantIndex);
        List<string> GetCourseParticipantNames();

        void SaveToFile(List<string> participantList, string filePath);
        public void LoadFromFile(string? filePath = null);
    }
}