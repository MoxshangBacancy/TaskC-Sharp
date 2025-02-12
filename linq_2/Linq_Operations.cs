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

            //List all trainers and the training sessions they have conducted, even if they haven't conducted any sessions.
            var trainerSessions = trainers.GroupJoin(
                                                    sessions,
                                                    trainer => trainer.TrainerID,
                                                    session => session.TrainerID,  
                                                    (trainer, sessionGroup) => new  
                                                     {
                                                      TrainerName = trainer.Name,
                                                      Expertise = trainer.Expertise,
                                                      Sessions = sessionGroup.DefaultIfEmpty() // Ensures trainers with no sessions are included
                                                     }
);

            foreach (var trainer in trainerSessions)
            {
                Console.WriteLine($"Trainer: {trainer.TrainerName}, Expertise: {trainer.Expertise}");
                foreach (var session in trainer.Sessions)
                {
                    Console.WriteLine($"  - Session: {session.Topic} on {session.SessionDate}");
                }
            }
            Console.WriteLine();    

            //Generate a dataset that pairs each trainer with every training session, regardless of any relationship.
            var trainerSessionPairs = trainers.SelectMany(
                                                          trainer => sessions,
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

            //Retrieve a list of trainers who have conducted training sessions, displaying their name along with the topics they have taught. Ensure that only trainers with sessions appear in the output.
            var onlytrainerSessions = trainers.Join(
                                                sessions.Where(s => s.Topic != null), // Exclude sessions with null topics
                                                trainer => trainer.TrainerID,
                                                session => session.TrainerID,
                                                (trainer, session) => new
                                                 {
                                                  TrainerName = trainer.Name,
                                                  Expertise = trainer.Expertise,
                                                  Topic = session.Topic
                                                 }
                                                ).ToList(); // Convert to list for immediate execution

            foreach (var item in onlytrainerSessions)
            {
                Console.WriteLine($"Trainer: {item.TrainerName} ({item.Expertise}) -> Topic: {item.Topic}");
            }
            Console.WriteLine();

            //Group all training sessions based on trainer names, displaying the total number of sessions each trainer has conducted.
            var trainerSessionCounts = trainers.GroupJoin(
                                                        sessions,
                                                        trainer => trainer.TrainerID,
                                                        session => session.TrainerID,
                                                        (trainer, sessionGroup) => new
                                                         {
                                                          TrainerName = trainer.Name,
                                                          SessionCount = sessionGroup.Count(s => s.Topic != null) // Excludes null topics
                                                          }
                                                         ).ToList();
           // Convert to list for execution

            foreach (var trainer in trainerSessionCounts)
            {
                Console.WriteLine($"Trainer: {trainer.TrainerName}, Total Sessions: {trainer.SessionCount}");
            }
            Console.WriteLine();


            //List all trainers who have conducted more than 3 training sessions, using a nested LINQ query.
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
                Console.WriteLine($"Trainer: {trainer.TrainerName}, Total Sessions: {trainer.SessionCount}");
            }
            Console.WriteLine();

            //Retrieve a distinct list of training topics that have been covered.
            var distinctTopics = sessions
                .Where(s => !string.IsNullOrEmpty(s.Topic)) // Exclude null or empty topics
                .Select(s => s.Topic)
                .Distinct()
                .ToList();

            foreach (var topics in distinctTopics) {
                Console.WriteLine($"Total topics covered are : {topics}");
            }
            Console.WriteLine();

            //Merge two trainer lists (from different departments), ensuring no duplicate trainer names.
            var mergedTrainers = trainers
                                 .Select(t => new { t.Name, t.Expertise })
                                 .Concat(trainers2.Select(t => new { t.Name, t.Expertise }))
                                 .GroupBy(t => t.Name)
                                 .Select(g => g.First())
                                 .ToList();
            // Output using foreach
            foreach (var trainer in mergedTrainers)
            {
                Console.WriteLine($" Name: {trainer.Name}, Expertise: {trainer.Expertise}");
            }
            Console.WriteLine();
            //Identify trainers who appear in both lists.
            var commonTrainers = trainers
                                 .Select(t => t.Name) // Extract only names from Trainer1
                                 .Intersect(trainers2.Select(t => t.Name)) // Find common names in both lists
                                 .ToList();

            // Output
            Console.WriteLine("Common Trainers :");
            foreach (var trainer in commonTrainers)
            {
                Console.WriteLine($"{trainer}");
            }
            Console.WriteLine() ;

            //Find trainers who exist in one list but not in the other.

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
            Console.WriteLine("Trainers only in List 1:");
            foreach (var trainer in trainersOnlyInList1)
            {
                Console.WriteLine(trainer);
            }

            Console.WriteLine("\nTrainers only in List 2:");
            foreach (var trainer in trainersOnlyInList2)
            {
                Console.WriteLine(trainer);
            }
            Console.WriteLine();

            //A dataset contains duplicate trainer names due to data entry errors. Write a LINQ query to filter out duplicates and return a distinct list of trainer names.
            var distinctTrainerNames = trainers
                                      .Select(t => t.Name)
                                      .Distinct()
                                      .ToList();

            // Output
            Console.WriteLine("Distinct Trainer Names:");
            foreach (var name in distinctTrainerNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            //Write a LINQ query that retrieves trainer names but delays execution.Modify the dataset before execution and analyze how the results change.
            // LINQ query with deferred execution
            var trainerNames = trainers.Select(t => t.Name);

            // Modify dataset before execution
            trainers.Add(new Trainer1(4, "Moxshang Shah", "Cybersecurity"));

            // Execution happens here (AFTER modification)
            Console.WriteLine("Deferred Execution Results:");
            foreach (var name in trainerNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();

            //Convert the query to execute immediately and compare the results.
            // Immediate Execution - forces execution now
            var ItrainerNames = trainers.Select(t => t.Name).ToList();

            // Modify dataset AFTER execution
            trainers.Add(new Trainer1(4, "Moxshang Shah", "Cybersecurity"));

            Console.WriteLine("Immediate Execution Results:");
            foreach (var name in ItrainerNames)  // Uses already executed result
            {
                Console.WriteLine(name);  // Does NOT include "Emma Wilson"
            }
            Console.WriteLine();

        }
    }

}
