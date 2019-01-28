using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_10
{
    class Hotel
    {
        public string name { get; set; }
        public List<Room> HotelRoomList { get; set; }
        public Hotel(string name, List<Room> HotelRoomList)
        {
            this.name = name;
            this.HotelRoomList = HotelRoomList;
        }
    }
    

    class Room
    {
        protected string type { get; set; }
        protected string roomNumber { get; set; }
       
        protected string date { get; set; }
        protected int duration { get; set; }
        //protected bool occupied = false;
        protected Monster reservationHolder { get; set; }
        public Room(string type, string roomNumber)
        {
            this.type = type;
            this.roomNumber = roomNumber;
        }
        public void MakeReservation(Monster reservationHolder, string date, int duration)
        {
            this.duration = duration;
            this.reservationHolder = reservationHolder;
            this.date = date;
        }
        public void ReturnReservationInfo()
        {
            Console.WriteLine("The room number is: " + roomNumber + "\r\n" + "The occupant name is " + reservationHolder.returnName() + "\r\n" + "The reservation day is: " + date + "\r\n" + "The duration of stay is: " + duration);
        }
        public string reservationHolderName()
        {
            return reservationHolder.returnName();
        }
    }
    class Monster
    {
        protected string name { get; set; }
        protected int ID { get; set; }
        protected decimal weight { get; set; }
        public Monster(string name, int ID, decimal weight)
        {
            this.name = name;
            this.ID = ID;
            this.weight = weight;
        }
        public string returnName()
        {
            return name;
        }
        public int returnID()
        {
            return ID;
        }
        public decimal returnWeight()
        {
            return weight;
        }
    }
    class Dracula : Monster, IFlyAbility
    {
        public Dracula(string name, int ID, decimal weight): base(name, ID, weight)
        {
            this.name = name;
            this.ID = ID;
            this.weight = weight;
        }
        public bool isFly { get; set; }
        public void fly()
        {
            isFly = true;
            Console.WriteLine("Dracula is flying");
        }
        public void land()
        {
            isFly = false;
            Console.WriteLine("Dracula is not flying");
        }
    }
    class Winnie: Monster, IBiteAbility
    {
        public Winnie(string name, int ID, decimal weight): base(name, ID, weight)
        {
            this.name = name;
            this.ID = ID;
            this.weight = weight;
        }
        public void bite()
        {
            Console.WriteLine("Winnie bit you!");
        }
    }
    class Frankenstein : Monster, IStrengthAbility
    {
        public Frankenstein(string name, int ID, decimal weight): base(name, ID, weight)
        {
            this.name = name;
            this.ID = ID;
            this.weight = weight;
        }
        public void strength()
        {
            Console.WriteLine("Frankenstein used strength!");
        }
    }
    class Blobby:Monster, ISlimeAbility, IBiteAbility
    {
        public Blobby(string name, int ID, decimal weight): base(name, ID, weight)
        {
            this.name = name;
            this.ID = ID;
            this.weight = weight;
        }
        public void slime()
        {
            Console.WriteLine("Blobby used slime");
        }
        public void bite()
        {
            Console.WriteLine("Blobby used bite");
        }
    }
    public interface IFlyAbility
    {
        void fly();
        void land();
        bool isFly { get; set; }
    }
    public interface IStrengthAbility
    {
        void strength();
    }
    public interface IBiteAbility
    {
        void bite();
    }
    public interface ISlimeAbility
    {
        void slime();
    }
    class Program
    {
        static void Main(string[] args)
        { 
            //Create rooms and add to list
            Room Room1 = new Room("Queen Bed", "111");
            Room Room2 = new Room("Queen Bed", "222");
            Room Room3 = new Room("Queen Bed", "333");
            Room Room4 = new Room("King Bed", "444");
            Room Room5 = new Room("King Bed", "555"); 
            List<Room> hotelRoomList = new List<Room>();
            hotelRoomList.Add(Room1);
            hotelRoomList.Add(Room2);
            hotelRoomList.Add(Room3);
            hotelRoomList.Add(Room4);
            hotelRoomList.Add(Room5);
            //Create hotel with the rooms list that was just made, then create some monsters
            Hotel Transylvania = new Hotel("Hotel Transylvania", hotelRoomList);
            Dracula Phil = new Dracula("Phillip", 1, 240);
            Blobby John = new Blobby("John", 2, 33);
            Winnie Will = new Winnie("Will", 4, 55);
            Frankenstein Frank = new Frankenstein("Frank", 3, 400);
            //Create some reservations
            Transylvania.HotelRoomList[0].MakeReservation(Phil, "4/2/2018", 2);
            Transylvania.HotelRoomList[1].MakeReservation(John, "4/8/2018", 3);
            Transylvania.HotelRoomList[2].MakeReservation(Frank, "4/21/2018", 1);
            Transylvania.HotelRoomList[3].MakeReservation(Will, "5/2/2018", 30);
            Console.WriteLine("Reservation information for John:");
            Transylvania.HotelRoomList[1].ReturnReservationInfo();
            //Use some monster abilities
            Console.WriteLine("Using some monster abilities:" + "\r\n");
            Console.WriteLine("Phil uses Fly and Land:");
            Phil.fly();
            Phil.land();
            Console.WriteLine("John uses bite and slime:");
            John.bite();
            John.slime();
            Console.WriteLine("Will uses bite:");
            Will.bite();
            Console.WriteLine("Frank uses strength:");
            Frank.strength();
            Console.ReadLine();
        }
    }
}
