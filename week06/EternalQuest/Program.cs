using System;

/*
========================================================================================
Added:
1. Gamification Leveling Algorithm: I expanded the 'GoalManager' class to feature a dynamic 
   leveling system calculate from current point metrics (1 level unlock per 1000 points accumulated).
2. Live Level Up Alerts: When completing objectives pushes users past level milestones, the console 
   instantly halts to display a customized text level promotion banner to increase system engagement.
========================================================================================
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        manager.Start();
    }
}