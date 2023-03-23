using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Dough { }
    public class Sauce { }
    public class Cheese { }
    public class Veggies { }
    public class Sausage { }

    public class ThinCrustDough : Dough { }
    public class ThickCrustDough : Dough { }

    public class MayonaiseSauce : Sauce { }
    public class TomatoSauce : Sauce { }

    public class YellowCheese : Cheese { }
    public class WhiteCheese : Cheese { }

    public class GreenVeggie : Veggies { }
    public class RedVeggie : Veggies { }
    public class YellowVeggie : Veggies { }

    public class FreshSausage : Sausage { }
    public class FrozenSausage : Sausage { }

    public abstract class Pizza
    {
        public String name;
        public Dough dough;
        public Sauce sause;
        public Cheese cheese;
        public Veggies[] veggies;
        public Sausage sausage;

        public abstract void prepare();

        public void bake()
        {
            name += " baked";
        }

        public void cut()
        {
            name += " cutted";
        }

        public void box()
        {
            name += " packed";
        }

        public void print_pizza_data()
        {
            Console.WriteLine(name);
        }

    }

    public interface PizzaIngredientFactory
    {
        public Dough createDough();
        public Sauce createSause();
        public Cheese createCheese();
        public Veggies[] createVeggies();
        public Sausage createSausage();
    }

    public class NyPizzaIngredientsFactory: PizzaIngredientFactory
    {
        public Dough createDough()
        {
            return new ThinCrustDough();
        }

        public Sauce createSause()
        {
            return new MayonaiseSauce();
        }

        public Cheese createCheese()
        {
            return new YellowCheese();
        }

        public Veggies[] createVeggies()
        {
            var veggies = new Veggies[2];
            veggies[0] = new GreenVeggie();
            veggies[1] = new RedVeggie();
            return veggies;
        }

        public Sausage createSausage()
        {
            return new FreshSausage();
        }
    }

    public class ChicagoPizzaIngredientsFactory : PizzaIngredientFactory
    {
        public Dough createDough()
    {
        return new ThickCrustDough();
    }

        public Sauce createSause()
        {
            return new TomatoSauce();
        }

        public Cheese createCheese()
        {
            return new WhiteCheese();
        }

        public Veggies[] createVeggies()
        {
            var veggies = new Veggies[3];
            veggies[0] = new GreenVeggie();
            veggies[1] = new RedVeggie();
            veggies[2] = new YellowVeggie();
            return veggies;
        }

        public Sausage createSausage()
        {
            return new FrozenSausage();
        }
        }


    public class CheesePizza: Pizza
    {
        private PizzaIngredientFactory ingredientFactory;

        public CheesePizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        public override void prepare()
        {
            this.dough = ingredientFactory.createDough();
            this.sause = ingredientFactory.createSause();
            this.cheese = ingredientFactory.createCheese();
            this.veggies = ingredientFactory.createVeggies();
            this.name = "cheese";
        }
       }

    public class PepperoniPizza : Pizza
    {
        private PizzaIngredientFactory ingredientFactory;

        public PepperoniPizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        public override void prepare()
        {
            this.dough = ingredientFactory.createDough();
            this.sause = ingredientFactory.createSause();
            this.cheese = ingredientFactory.createCheese();
            this.veggies = ingredientFactory.createVeggies();
            this.name = "pepperoni";
        }
    }

    public class GreekPizza : Pizza
    {
        private PizzaIngredientFactory ingredientFactory;

        public GreekPizza(PizzaIngredientFactory ingredientFactory)
        {
            this.ingredientFactory = ingredientFactory;
        }

        public override void prepare()
        {
            this.dough = ingredientFactory.createDough();
            this.sause = ingredientFactory.createSause();
            this.cheese = ingredientFactory.createCheese();
            this.veggies = ingredientFactory.createVeggies();
            this.name = "greek";
        }
    }

    public abstract class PizzaStore
    {
        public Pizza orderPizza(string type)
        {
            Pizza pizza = createPizza(type);

            pizza.prepare();
            pizza.bake();
            pizza.cut();
            pizza.box();
            return pizza;
        }

        public Pizza choosePizza(string type, PizzaIngredientFactory ingredientFactory)
        {
            Pizza pizza = null;
            if (type == "cheese")
            {
                pizza =  new CheesePizza(ingredientFactory);
            }
            else if (type == "greek")
            {
                pizza = new GreekPizza(ingredientFactory);
            }
            else if (type == "pepperoni")
            {
                pizza = new PepperoniPizza(ingredientFactory);
            }
            return pizza;

        }

        public abstract Pizza createPizza(String type);

}


    public class NyPizzaStore : PizzaStore
    {
        public override Pizza createPizza(String type) {
            Pizza pizza = null;
            PizzaIngredientFactory ingredientFactory = new NyPizzaIngredientsFactory();
            pizza = choosePizza(type, ingredientFactory);
            return pizza;
        }

    }

    public class ChicagoPizzaStore: PizzaStore
    {

        public override Pizza createPizza(String type)
        {
            Pizza pizza = null;
            PizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientsFactory();
            pizza = choosePizza(type, ingredientFactory);
            return pizza;
        }

    }


class Program
    {
        public static void Main(String[] args)
        {
            var newPizzaStore = new NyPizzaStore();
            var pizza = newPizzaStore.orderPizza("greek");
            pizza.print_pizza_data();
        }
    }
}

