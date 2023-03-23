using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public class Amplifier
    {
        int volume = 0;
        public void on()
        {
            Console.WriteLine("Amplifier is on");
        }

        public void off()
        {
            Console.WriteLine("Amplifier is off");
        }

        public void set_volume(int volume)
        {
            this.volume = volume;
            Console.WriteLine("Amplifier volume is set on " + volume);
        }
    }

    public class Tuner
    {
        public Amplifier amplifier;

        int Am = 0;
        int Fm = 0;
        int frequency;

        public Tuner(Amplifier amplifier)
        {
            this.amplifier = amplifier;
        }
        public void on()
        {
            Console.WriteLine("Tuner is on");
        }

        public void off()
        {
            Console.WriteLine("Tuner is off");
        }

        public void set_frequency(int frequency)
        {
            this.frequency = frequency;
            Console.WriteLine("Tuner frequency is set on", frequency);
        }

        public void set_Am(int Am)
        {
            this.Am = Am;
            Console.WriteLine("Tuner Am is set on", Am);
        }

        public void set_Fm(int Fm)
        {
            this.Fm = Fm;
            Console.WriteLine("Tuner Fm is set on", Fm);
        }

    }

    public class DvDPlayer
    {
        public Amplifier amplifier;

        public String move = "";

        public DvDPlayer(Amplifier amplifier)
        {
            this.amplifier = amplifier;
        }
        public void on()
        {
            Console.WriteLine("DvDPlayer is on");
        }

        public void off()
        {
            Console.WriteLine("DvDPlayer is off");
        }

        public void set_dvd(String move)
        {
            this.move = move;
            Console.WriteLine("dvd is set " + this.move);
        }

        public void play()
        {
            if (this.move != "")
            {
                Console.WriteLine("DvDPlayer is playing " + this.move);
            }
            else
            {
                Console.WriteLine("no dvd, nothing to play");
            }
        }

        public void eject()
        {
            this.move = "";
            Console.WriteLine("dvd is ejected");
        }

        public void pause()
        {
            Console.WriteLine("DvDPlayer is paused");
        }

    }

    public class Projector
    {
        public DvDPlayer dvdPlayer;
        public Projector(DvDPlayer dvdPlayer)
        {
            this.dvdPlayer = dvdPlayer;
        }

        public void on()
        {
            Console.WriteLine("projector is on");
            if (this.dvdPlayer.move != "")
            {
                Console.WriteLine("projector is showing " + this.dvdPlayer.move);
            }
        }

        public void off()
        {
            Console.WriteLine("projector is off");
        }
    }

    public class PopcornPopper
    {
        public void on()
        {
            Console.WriteLine("popcorn popper is on");
        }

        public void off()
        {
            Console.WriteLine("popcorn popper is off");
        }

        public void pop()
        {
            Console.WriteLine("popcorn popper dropped some popcorn");
        }
    }


    public class HomeTheatreFacade
    {
        Amplifier amplifier;
        DvDPlayer DvDplayer;
        Tuner tuner;
        PopcornPopper popcornpopper;
        Projector projector;

        public HomeTheatreFacade(Amplifier amplifier, DvDPlayer DvDplayer, Projector projector, Tuner tuner, PopcornPopper popcornpopper)
        {
            this.amplifier = amplifier;
            this.DvDplayer = DvDplayer;
            this.tuner = tuner;
            this.projector = projector;
            this.popcornpopper = popcornpopper;
        }

        public void watch_move(String move)
        {
            this.amplifier.on();
            this.DvDplayer.on();
            this.DvDplayer.set_dvd(move);
            this.projector.on();
            this.tuner.on();
            this.amplifier.set_volume(50);
            this.popcornpopper.on();
            this.popcornpopper.pop();
            this.DvDplayer.play();
        }

        public void end_move()
        {
            this.DvDplayer.pause();
            this.DvDplayer.eject();
            this.projector.off();
            this.DvDplayer.off();
            this.tuner.off();
            this.amplifier.off();
            this.popcornpopper.off();
        }
    }

    class Program
    {
        public static void Main(String[] args)
        {
            Amplifier amp = new Amplifier();
            DvDPlayer DvD = new DvDPlayer(amp);
            Tuner tuner = new Tuner(amp);
            PopcornPopper popcorn = new PopcornPopper();
            Projector projector = new Projector(DvD);
            HomeTheatreFacade cinema = new HomeTheatreFacade(amp, DvD, projector, tuner, popcorn);
            cinema.watch_move("Avengers");
            cinema.end_move();

        }
    }
}

