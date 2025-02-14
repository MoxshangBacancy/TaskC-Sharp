using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace linq_2
{
    public class Linq_Operations
    {
        public static void performQueries() {
            List<Trainer1> trainers = TrainerList.GetTrainerDetails();
            List<Trainer2> trainers2 = TrainerList2.GetTrainerDetails2();
            List<TrainingSession> sessions = TrainingSessionList.GetTrainingSessionsDetails();

            // 1. List all trainers and the training sessions they have conducted.
            //3. Modify the first query to include all trainers, even those with no training sessions recorded.
            var uniqueTrainers = trainers.GroupBy(t => t.TrainerID).Select(g => g.First()).ToList();

            var trainerSessions = uniqueTrainers.GroupJoin(
                sessions,
                trainer => trainer.TrainerID,
                session => session.TrainerID,
                (trainer, sessionGroup) => new
                {
                    TrainerName = trainer.Name,
                    Expertise = trainer.Expertise,
                    Sessions = sessionGroup.Any() ? sessionGroup : new List<TrainingSession>()
                    //    : new List<TrainingSession> { new TrainingSession(0, trainer.TrainerID, "No sessions conducted", DateTime.MinValue) }; can use this just for good practise.
                    // Empty list instead of dummy session
                });
            Console.WriteLine("1. and 3.");
            foreach (var trainer in trainerSessions)
            {
                Console.WriteLine($"Trainer: {trainer.TrainerName} ({trainer.Expertise})");
                foreach (var session in trainer.Sessions)
                {
                    Console.WriteLine($"  - Session: {session.Topic ?? "No Topic"}");
                }
                Console.WriteLine();
            }


            Console.WriteLine();    

            //2. Generate a dataset that pairs each trainer with every training session, regardless of any relationship.
            var trainerSessionPairs = trainers.Join( sessions,
                                                          trainer=>true, sessions => true,
                                                          (trainer, session) => new
                                                            {
                                                               TrainerName = trainer.Name,
                                                               Expertise = trainer.Expertise,
                                                               SessionId = session.SessionId,
                                                               Topic = session.Topic,
                                                               SessionDate = session.SessionDate
                                                            }
);

            foreach (var pair in trainerSessionPairs)
            {
                Console.WriteLine($"Trainer: {pair.TrainerName} ({pair.Expertise}) -> Session: {pair.Topic} on {pair.SessionDate.ToShortDateString()}");
            }
            Console.WriteLine();

            //4. Retrieve a list of trainers who have conducted training sessions, displaying their name along with the topics they have taught. Ensure that only trainers with sessions appear in the output.
            var onlytrainerSessions = trainers.Join(//inner join.
                                                sessions.Where(s => s.Topic != null), 
                                                trainer => trainer.TrainerID,
                                                session => session.TrainerID,
                                                (trainer, session) => new
                                                 {
                                                  TrainerName = trainer.Name,
                                                  Expertise = trainer.Expertise,
                                                  Topic = session.Topic
                                                 }
                                                ).ToList(); 
            Console.WriteLine("4.");
            foreach (var item in onlytrainerSessions)
            {
                Console.WriteLine($"Trainer: {item.TrainerName} ({item.Expertise}) -> Topic: {item.Topic}");
            }
            Console.WriteLine();

            //5. Group all training sessions based on trainer names, displaying the total number of sessions each trainer has conducted.
            var trainerSessionCounts = sessions
     .Where(s => s.Topic != null)
     .GroupBy(s => s.TrainerID)
     .Select(g => new
     {
         TrainerID = g.Key,
         SessionCount = g.Count()
     })
     .Join(trainers,
           sessionGroup => sessionGroup.TrainerID,
           trainer => trainer.TrainerID,
           (sessionGroup, trainer) => new
           {
               TrainerName = trainer.Name,
               SessionCount = sessionGroup.SessionCount
           })
     .ToList();
     // var trainerSessionCounts = trainers
     //.GroupJoin(
     //    sessions.Where(s => s.Topic != null),
     //    trainer => trainer.TrainerID,
     //    session => session.TrainerID,
     //    (trainer, sessionGroup) => new
     //    {
     //        TrainerName = trainer.Name,
     //        SessionCount = sessionGroup.Count()
     //    }
     //)
     //.ToList();


            Console.WriteLine("5. USING GROUPBY");// Deferred Execution
            // Iterating over results
            foreach (var trainer in trainerSessionCounts)
            {
                Console.WriteLine($"Trainer: {trainer.TrainerName}, Sessions Conducted: {trainer.SessionCount}");
            }

            Console.WriteLine();
            //6. Implement a different LINQ query to achieve the same result and compare the outputs.
           

            var sessionLookup = sessions
    .Where(s => s.Topic != null) // Exclude null topics
    .ToLookup(s => s.TrainerID);

            var trainerSessionCountslookup = trainers 
                .Select(trainer => new
                {
                    TrainerName = trainer.Name,
                    SessionCount = sessionLookup[trainer.TrainerID].Count()
                })
                .ToList();


            Console.WriteLine("6. USING LOOKUP"); //immediate executions
            // Iterating over results
            foreach (var trainer in trainerSessionCountslookup)
            {
                Console.WriteLine($"Trainer: {trainer.TrainerName}, Sessions Conducted: {trainer.SessionCount}");
            }
            Console.WriteLine();

            //7.List all trainers who have conducted more than 3 training sessions, using a nested LINQ query.
            var experiencedTrainers = trainers
                                     .Where(trainer => sessions.Count(session => session.TrainerID == trainer.TrainerID) > 3)
                                     .Select(trainer => new
                                     {
                                     TrainerName = trainer.Name,
                                     SessionCount = sessions.Count(session => session.TrainerID == trainer.TrainerID)
                                     })
                                     .ToList();

            foreach (var trainer in experiencedTrainers)
            {
                Console.WriteLine($"7. Trainer: {trainer.TrainerName}, Total Sessions: {trainer.SessionCount}");
            }
            Console.WriteLine();

            //8.Retrieve a distinct list of training topics that have been covered.
            var distinctTopics = sessions
                .Where(s => !string.IsNullOrEmpty(s.Topic)) 
                .Select(s => s.Topic)
                .Distinct()
                .ToList();

            Console.WriteLine("8. Total topics covered are : ");
            foreach (var topics in distinctTopics) {
                Console.WriteLine($"{topics}");
            }
            Console.WriteLine();


            //9.Merge two trainer lists (from different departments), ensuring no duplicate trainer names.

            var mergedTrainers = trainers
                                 .Select(t => new { t.Name })
                                 .Concat(trainers2.Select(t => new { t.Name}))
                                 .GroupBy(t => t.Name)
                                 .Select(g => g.First())
                                 .ToList();
            // Output using foreach
            Console.WriteLine("9. Total Trainers from both lists Name: ");
            foreach (var trainer in mergedTrainers)
            {
                Console.WriteLine($"{trainer.Name}");
            }
            Console.WriteLine();
            //10. Identify trainers who appear in both lists.
            var commonTrainers = trainers
                                 .Select(t => t.Name) 
                                 .Intersect(trainers2.Select(t => t.Name))
                                 .ToList();

            // Output
            Console.WriteLine("10. Common Trainers :");
            foreach (var trainer in commonTrainers)
            {
                Console.WriteLine($"{trainer}");
            }
            Console.WriteLine() ;

            //11. Find trainers who exist in one list but not in the other.

            // Trainers in List 1 but not in List 2
            var trainersOnlyInList1 = trainers
                .Select(t => t.Name)
                .Except(trainers2.Select(t => t.Name))
                .ToList();

            // Trainers in List 2 but not in List 1
            var trainersOnlyInList2 = trainers2
                .Select(t => t.Name)
                .Except(trainers.Select(t => t.Name))
                .ToList();

            // Output
            Console.WriteLine("11,a. Trainers only in List 1:");
            foreach (var trainer in trainersOnlyInList1)
            {
                Console.WriteLine(trainer);
            }

            Console.WriteLine("\n 11,b. Trainers only in List 2:");
            foreach (var trainer in trainersOnlyInList2)
            {
                Console.WriteLine(trainer);
            }
            Console.WriteLine();

            //12. A dataset contains duplicate trainer names due to data entry errors.
            //Write a LINQ query to filter out duplicates and return a distinct list of trainer names.
            var distinctTrainerNames = trainers
                                      .Select(t => t.Name)
                                      .Distinct()
                                      .ToList();

            // Output
            Console.WriteLine("12. Distinct Trainer Names:");
            foreach (var name in distinctTrainerNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            //13. Write a LINQ query that retrieves trainer names but delays execution.Modify the dataset before
            //execution and analyze how the results change.
            // LINQ query with deferred execution
            var trainerNames = trainers.Select(t => t.Name);

            // Modify dataset before execution
            trainers.Add(new Trainer1(4, "Moxshang Shah", "Cybersecurity"));

            // Execution happens here (AFTER modification)
            Console.WriteLine("13. Deferred Execution Results:");
            foreach (var name in trainerNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            //14. Convert the query to execute immediately and compare the results.
            // Immediate Execution - forces execution now
            var ItrainerNames = trainers.Select(t => t.Name).ToList();

            // Modify dataset AFTER execution
            trainers.Add(new Trainer1(4, "Moxshang Shah", "Cybersecurity"));

            Console.WriteLine("14. Immediate Execution Results:");
            foreach (var name in ItrainerNames) 
            {
                Console.WriteLine(name);  
            }
            Console.WriteLine();

        }
    }

}
