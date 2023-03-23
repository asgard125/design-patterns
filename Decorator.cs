

using System;
using System.Collections.Generic;

namespace ConsoleApp1
{

    interface IBeverage
    {
        string getDescription();
        float getCost();
    }


    class HouseBlend : IBeverage
    {
        public string getDescription()
        {
            return "HouseBlend";
        }
        public float getCost()
        {
            return 100;
        }
    }

    class DarkRoast : IBeverage
    {
        public string getDescription()
        {
            return "DarkRoast";
        }
        public float getCost()
        {
            return 150;
        }
    }

    class Decaf : IBeverage
    {
        public string getDescription()
        {
            return "Decaf";
        }
        public float getCost()
        {
            return 70;
        }
    }

    class Espresso : IBeverage
    {
        public string getDescription()
        {
            return "Espresso";
        }
        public float getCost()
        {
            return 60;
        }
    }

    interface ICondimentDecorator: IBeverage
    {
        
    }

    class MilkDecorator: ICondimentDecorator
    {
        private IBeverage Order;

        public MilkDecorator(IBeverage order)
        {
            Order = order;
        }

        public string getDescription()
        {
            return Order.getDescription() + " Milk";
        }
        public float getCost()
        {
            return Order.getCost() + 30;
        }
    }

    class MochaDecorator : ICondimentDecorator
    {
        private IBeverage Order;

        public MochaDecorator(IBeverage order)
        {
            Order = order;
        }

        public string getDescription()
        {
            return Order.getDescription() + " Mocha";
        }
        public float getCost()
        {
            return Order.getCost() + 100;
        }
    }

    class SoyDecorator : ICondimentDecorator
    {
        private IBeverage Order;

        public SoyDecorator(IBeverage order)
        {
            Order = order;
        }

        public string getDescription()
        {
            return Order.getDescription() + " Soy";
        }
        public float getCost()
        {
            return Order.getCost() + 25;
        }
    }

    class WhipDecorator : ICondimentDecorator
    {
        private IBeverage Order;

        public WhipDecorator(IBeverage order)
        {
            Order = order;
        }

        public string getDescription()
        {
            return Order.getDescription() + " Whip";
        }
        public float getCost()
        {
            return Order.getCost() + 43;
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            IBeverage soywhipmochamilkroast = new SoyDecorator(new WhipDecorator(new MochaDecorator(new MilkDecorator(new DarkRoast()))));
            IBeverage soywhipmilkhouse = new SoyDecorator(new WhipDecorator(new MilkDecorator(new HouseBlend())));
            Console.WriteLine(soywhipmochamilkroast.getDescription() + " price:" + soywhipmochamilkroast.getCost());
            Console.WriteLine(soywhipmilkhouse.getDescription() + " price:" + soywhipmilkhouse.getCost());
        }
    }
}

