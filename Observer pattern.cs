/******************************************************************************

                            Online C# Compiler.
                Code, Compile, Run and Debug C# program online.
Write your code in this editor and press "Run" button to execute it.

*******************************************************************************/

using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    interface Observer
    {
        void update(float temperature, float humidity, float pressure);
    }

    interface Subject
    {
        void registerObserver(Observer observer);
        void removeObserver(Observer observer);
        void notifyObservers();
    }

    class WeatherData : Subject
    {

        private float temperature;
        private float humidity;
        private float pressure;

        private List<Observer> observers = new List<Observer>();


        public void registerObserver(Observer observer)
        {
            observers.Add(observer);
        }


        public void removeObserver(Observer observer)
        {
            int index = observers.IndexOf(observer);
            if (index >= 0)
            {
                observers.RemoveAt(index);
            }
        }

        public void notifyObservers()
        {
            foreach (Observer observer in observers)
            {
                observer.update(getTemperature(), getHumidity(), getPressure());
            }
        }

        float getTemperature()
        {
            return temperature;
        }

        float getHumidity()
        {
            return humidity;
        }

        float getPressure()
        {
            return pressure;
        }

        void measurementsChanged()
        {
            notifyObservers();
        }

        public void setMeasurements(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            measurementsChanged();
        }
    }


    class CurrentConditionsDisplay : Observer
    {

        private float temperature;
        private float humidity;
        private float pressure;


        public CurrentConditionsDisplay(Subject subject)
        {
            subject.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature = temperature;
            this.humidity = humidity;
            this.pressure = pressure;
            display();
        }

        public void display()
        {
            Console.WriteLine("Temperature: " + temperature);
            Console.WriteLine("Humidity: " + humidity);
            Console.WriteLine("Pressure: " + pressure);
        }
    }

    class StatisticsDisplay : Observer
    {

        private List<float> temperature = new List<float>();
        private List<float> humidity = new List<float>();
        private List<float> pressure = new List<float>();

        public StatisticsDisplay(Subject subject)
        {
            subject.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature.Add(temperature);
            this.humidity.Add(humidity);
            this.pressure.Add(pressure);
            this.temperature.Sort();
            this.humidity.Sort();
            this.pressure.Sort();
            display();
        }

        public void display()
        { 
            Console.WriteLine("STATISTIC START------------------");
            Console.WriteLine("Median Temperature: " + temperature[temperature.Count / 2]);
            Console.WriteLine("Median Humidity: " + humidity[humidity.Count / 2]);
            Console.WriteLine("Median Pressure: " + pressure[pressure.Count / 2]);
            Console.WriteLine("Min Temperature: " + temperature[0]);
            Console.WriteLine("Min Humidity: " + humidity[0]);
            Console.WriteLine("Min Pressure: " + pressure[0]);
            Console.WriteLine("Max Temperature: " + temperature[temperature.Count - 1]);
            Console.WriteLine("Max Humidity: " + humidity[humidity.Count - 1]);
            Console.WriteLine("Max Pressure: " + pressure[pressure.Count - 1]);
            Console.WriteLine("STATISTIC END------------------");
        }
    }

    class ForecastDisplay : Observer
    {

        private float temperature;
        private float humidity;
        private float pressure;

        public ForecastDisplay(Subject subject)
        {
            subject.registerObserver(this);
        }

        public void update(float temperature, float humidity, float pressure)
        {
            this.temperature += temperature;
            this.humidity += humidity;
            this.pressure += pressure;
            this.temperature = this.temperature / 2;
            this.humidity = this.humidity / 2;
            this.pressure = this.pressure / 2;
            display();
        }

        public void display()
        {
            Console.WriteLine("Forecast Temperature: " + temperature);
            Console.WriteLine("Forecast Humidity: " + humidity);
            Console.WriteLine("Forecast Pressure: " + pressure);
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            var weatherData = new WeatherData();
            var currentConditionsDisplay = new CurrentConditionsDisplay(weatherData);
            var statisticsDisplay = new StatisticsDisplay(weatherData);
            var forecastDisplay = new ForecastDisplay(weatherData);
            weatherData.setMeasurements(12, 21, 45);
            weatherData.setMeasurements(1000, 21000, 45000);
        }
    }
}

