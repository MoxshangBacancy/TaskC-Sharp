// See https://aka.ms/new-console-template for more information
using task8;

class program
{
    static void Main(string[] args)
    {
        Human human = new Human();
        human.Work();
        human.Eat();

        Robot robot = new Robot();
        robot.Work();
    }
}
