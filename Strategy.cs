using System;

namespace ConsoleApp1
{

    interface IQuackStrategy
    {
        void quack();
    }

    class NormalQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("quack");
        }
    }

    class SquiqQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("squiq");
        }
    }

    class SilentQuack : IQuackStrategy
    {
        public void quack()
        {
            Console.WriteLine("silent sound");
        }
    }

    interface ISwimStrategy
    {
        void swim();
    }

    class NormalSwim: ISwimStrategy
    {
        public void swim()
        {
            Console.WriteLine("angry swimming splashes");
        }
    }

    class CuteSwim: ISwimStrategy
    {
        public void swim()
        {
            Console.WriteLine("cute swimming splashes");
        }
    }

    class NoSwim: ISwimStrategy
    {
        public void swim()
        {
          Console.WriteLine("I can't swim");
        }
    }

    interface IFlyStrategy
    {
        void fly();
    }

    class NoFly: IFlyStrategy
    {
        public void fly()
        {
            Console.WriteLine("I can't fly");
        }
    }

    class NormalFly: IFlyStrategy
    {
        public void fly()
        {
            Console.WriteLine("Flying duck sounds");
        }
    }
  
    interface IDisplayStrategy
    {
        void display();
    }

    class NormalDisplay: IDisplayStrategy
    {
        public void display()
        {
            Console.WriteLine("duck display");
        }
    }

    class Duck
    {
        private IQuackStrategy quackStrategy;
        private ISwimStrategy swimStrategy;
        private IFlyStrategy flyStrategy;
        private IDisplayStrategy displaStrategy;
      
        public Duck(IQuackStrategy quackStrategy, ISwimStrategy swimStrategy, IFlyStrategy flyStrategy, IDisplayStrategy displaStrategy)
        {
            this.quackStrategy = quackStrategy;
            this.swimStrategy = swimStrategy;
            this.flyStrategy = flyStrategy;
            this.displaStrategy = displaStrategy;
        }

        public void Quack()
        {
            quackStrategy.quack();
        }

        public void Swim()
        {
            swimStrategy.swim();
        }
      
        public void Fly()
        {
            flyStrategy.fly();
        }
      
        public void Display()
        {
            displaStrategy.display();
        }
    }


    class Program
    {
        static void TestDuck(Duck duck)
        {
            duck.Quack();
            duck.Swim();
            duck.Fly();
            duck.Display();
        }

        static void Main(string[] args)
        {
            Duck marlladDuck = new Duck(new NormalQuack(), new NormalSwim(), new NormalFly(), new NormalDisplay());
            Duck silentDuck = new Duck(new SilentQuack(), new NormalSwim(), new NormalFly(), new NormalDisplay());
            Duck rubberDuck = new Duck(new SquiqQuack(), new NormalSwim(), new NoFly(), new NormalDisplay());
            Program.TestDuck(marlladDuck);
            Program.TestDuck(silentDuck);
            Program.TestDuck(rubberDuck);
        }
    }
}