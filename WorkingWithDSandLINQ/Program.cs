using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDSandLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is some sample code for DS and LINQ tutorial");

            // Action doSomething;
            //  Boss boss = new Boss();

            //The use of a delegate here is not necessary, but a remnant of the Week 7 tutorial
            //  doSomething = boss.Display;
            // doSomething();

            //For testing optional implementation of step 2.3.4:
            /*
            int start = 2014, end = 2015;
            foreach (Employee e in boss.Workers) {
                Console.WriteLine("Employee {0} has attended {1} training sessions during {2}-{3}",
                    e.Name, Agency.EmployeeTrainingCount(e, start, end), start, end);
            }
            */

            /* Task 1 */
            
            List<TrainingSession> trainingSessions = Program.CreateTrainingSessions();
            List<TrainingSession> filterdSessions = Program.FilteredSessions(279, trainingSessions);
            List<TrainingSession> rangeList = Program.FilteredSessions(2021, 2019, trainingSessions);

            Console.WriteLine("Here is the Complete List");

            foreach (TrainingSession T in trainingSessions)
            {
                Console.WriteLine(T);
            }

            Console.WriteLine("Here is the Filtered List");

            foreach (TrainingSession T in filterdSessions)
            {
                Console.WriteLine(T);
            }

            Console.WriteLine("Here is the Filtered List with Range");

            foreach (TrainingSession T in rangeList)
            {
                Console.WriteLine(T);
            }

            
            /* Task 2 */

             Boss boss = new Boss();

            // 2.3.2 Printing Training Sessions for id=123460
            List<TrainingSession> trainingSessionsOne = Agency.LoadTrainingSessions(123460);

            foreach (TrainingSession t in trainingSessionsOne)
            {
                Console.WriteLine(t.Title);
            }
          

            Console.ReadLine();
        }

        static List<TrainingSession> CreateTrainingSessions()
        {
            List<TrainingSession> trainingSessions = new List<TrainingSession>()
            {
                new TrainingSession{Title="TS1", Certified=new DateTime(2019,04,23), Year=2019, Mode= Mode.Conference},
                 new TrainingSession{Title="TS2", Certified=new DateTime(2015,04,23), Year=2015, Mode= Mode.Conference},
                  new TrainingSession{Title="TS3", Certified=new DateTime(2020,06,13), Year=2020, Mode= Mode.Journal},
                   new TrainingSession{Title="TS4", Certified=new DateTime(2020,09,26), Year=2020, Mode= Mode.Journal},
                    new TrainingSession{Title="TS5", Certified=new DateTime(2021,02,25), Year=2021, Mode= Mode.Other},
            };

            return trainingSessions;
        }

        static List<TrainingSession> FilteredSessions(int freshness, List<TrainingSession> trainingSessions)
        {

            var filtered = from TrainingSession ts in trainingSessions
                           where ts.Freshness <= freshness
                           select ts;

            return new List<TrainingSession>(filtered);
        }

        static List<TrainingSession> FilteredSessions(int fYear, int tYear, List<TrainingSession> trainingSessions)
        {
            var filtered = from TrainingSession ts in trainingSessions
                           where ts.Year <= fYear && ts.Year > tYear
                           select ts;

            return new List<TrainingSession>(filtered);
        }

    }
}
