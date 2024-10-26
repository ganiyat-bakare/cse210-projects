// To show creativity, I added the following functionalities:
// 1. Visual separators or stylized output for the welcome message.
// 2. Method for showing goal statistics and I included it in the menu option as well.


using System;  

namespace EternalQuest  
{  
    class Program  
    {  
        static void Main(string[] args)  
        {  
            GoalManager goalManager = new GoalManager();  
            goalManager.Start();  
        }  
    }  
}