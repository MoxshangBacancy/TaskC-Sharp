using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_2
{
    public class TrainingSession
    {
        public int SessionId { get; set; }
        public int TrainerID { get; set; }

        public string Topic { get; set; }
        public DateTime SessionDate { get; set; }

        public TrainingSession(int sessionId, int trainerID, string topic, DateTime sessionDate)
        {
            SessionId = sessionId;
            TrainerID = trainerID;
            Topic = topic;
            SessionDate = sessionDate;
        }   
    }

    public class TrainingSessionList
    {
        public static List<TrainingSession> GetTrainingSessionsDetails()
        {
            return new List<TrainingSession>
        {
            new TrainingSession(1, 1, "Introduction to Machine Learning", new DateTime(2024, 1, 10)),
    new TrainingSession(2, 2, "Modern Web Development with React", new DateTime(2024, 1, 15)),
    new TrainingSession(3, 3, null, new DateTime(2024, 1, 20)), // Null topic
    new TrainingSession(4, 4, "Cybersecurity Best Practices", new DateTime(2024, 2, 5)),
    new TrainingSession(5, 5, "Advanced Data Science Techniques", new DateTime(2024, 2, 10)),
    new TrainingSession(6, 6, "Mobile App Development with Flutter", new DateTime(2024, 2, 15)),
    new TrainingSession(7, 7, "AI and Deep Learning Concepts", new DateTime(2024, 3, 1)),
    new TrainingSession(8, 8, "Software Architecture Patterns", new DateTime(2024, 3, 5)),
    new TrainingSession(9, 9, "DevOps & CI/CD Strategies", new DateTime(2024, 3, 10)),
    new TrainingSession(10, 10, null, new DateTime(2024, 3, 15)), // Null topic
    new TrainingSession(11, 1, "Deep Learning with TensorFlow", new DateTime(2024, 4, 10)), // Trainer 1 - 2 Sessions
    new TrainingSession(12, 2, null, new DateTime(2024, 4, 15)), // Null topic
    new TrainingSession(13, 3, "Serverless Computing", new DateTime(2024, 4, 20)), // Trainer 3 - 2 Sessions
    new TrainingSession(14, 5, "Big Data Analytics", new DateTime(2024, 5, 5)), // Trainer 5 - 2 Sessions
    new TrainingSession(15, 7, "NLP and AI Ethics", new DateTime(2024, 5, 10)), // Trainer 7 - 2 Sessions
    new TrainingSession(16, 8, null, new DateTime(2024, 5, 15)), // Null topic
     new TrainingSession(17, 7, "AI, ML, DL", new DateTime(2024, 5, 10)),
     new TrainingSession(18, 7, "Blockchain", new DateTime(2024, 5, 19)),
        };
        }
    }
}
