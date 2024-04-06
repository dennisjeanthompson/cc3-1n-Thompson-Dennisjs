namespace HotelMangementSystem
{
   

   
        internal class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Hello, World!");
            List<HotelRoom> yananRooms = new List<HotelRoom>();
            HotelRoom room1 = new HotelRoom(101, RoomStyle.TwinRoom, 1500);
            HotelRoom room2 = new HotelRoom(102, RoomStyle.KingRoom, 3000);

            yananRooms.Add(room1);
            yananRooms.Add(room2);
            Hotel hotelYanan = new Hotel("Hotel Yanan", "123 GStreet, Takaw City", yananRooms);//hotel

            List<HotelRoom> hotel456Rooms = new List<HotelRoom>();

            HotelRoom hotel456Room1 = new HotelRoom(101, RoomStyle.QueenRoom, 2000);
            HotelRoom hotel456Room2 = new HotelRoom(102, RoomStyle.QueenRoom, 2000);

            hotel456Rooms.Add(hotel456Room1);
            hotel456Rooms.Add(hotel456Room2);
            Hotel hotel456 = new Hotel("Hotel 456", "Session Road, Baguio City", hotel456Rooms);//HOTEL

            HotelManagementSystem hms = new HotelManagementSystem();
            hms.AddHotel(hotelYanan);
            hms.AddHotel(hotel456);
            hms.DisplayHotels();
            hotelYanan.DiplayAvailableRooms();

            Guest terry = new Guest("Terry", "Addr 1", "terry@email.com", 63919129);

            Guest satan = new Guest("XZOM", "Addr 1", "DUF@email.com", 09129);
            hms.RegisterUser(terry);
            hms.RegisterUser(satan);

           Reservation reservation = hms.BookReservation(DateTime.Now, new DateTime(2029, 09, 12),room1,hotelYanan);
            Reservation reservation1 = hms.BookReservation(DateTime.Now, new DateTime(2040, 09, 12), room2, hotel456);
            hotelYanan.DisplayBookeRooms();
            terry.BookReservation(reservation);
            terry.DisplayReservation();
            satan.BookReservation(reservation1);
            satan.DisplayReservation();
            Receptionist anna = new Receptionist("Anna", "Addr 2", "anna@email.com", 67890);
            hms.RegisterUser(anna);

            Reservation res = new Reservation(new DateTime(2024, 05, 01), new DateTime(2024, 05, 06), hotel456Room2,hotel456);
           
            anna.BookReservation(terry, res);
            hotel456.DisplayBookeRooms();

          
            hms.DisplayReservationDetails(1234567890);
            hms.DisplayReservationDetails(1234567891);

        }
     


    }
        public class HotelRoom
        {
          public  int RoomNumber { get; set; }
            RoomStyle RoomStyle { get; set; }
            public bool Status { get; set; }
            decimal BookingPrice { get; set; }
            public HotelRoom(int roomNumber, RoomStyle roomStyle, decimal bookingPrice)
            {
                this.RoomNumber = roomNumber;
                this.RoomStyle = roomStyle;
              //  Status = status;
                BookingPrice = bookingPrice;

            }
            public string DisplayDetails()
            {
                return $"RoomNumber:{RoomNumber}\tRoomstyle:{RoomStyle}\tBookingPrice:{BookingPrice}";
            }
            //  public void ReserveRoom()
            //    {

            // }

        }
        public class Hotel
        {
      //  Hotel hotel;
            string HotelName { get; set; }
            string Location { get; set; }
            List<HotelRoom> _allRooms = new List<HotelRoom>();
            List<HotelRoom> _bookeRooms = new List<HotelRoom>();
            public Hotel(string hotelName, string location,List<HotelRoom> _allrooms)
            {
            this._allRooms = _allrooms;  
            
                HotelName = hotelName;
                Location = location;

            }
            public string DisplayDetails()
            {
                return $"HotelName{HotelName} Location{Location}";
            }
            public void DiplayAvailableRooms()
            {
                foreach (HotelRoom room in _allRooms)

                {
                    Console.WriteLine(room.DisplayDetails());
                }

            }
            public void DisplayBookeRooms()
            {
                foreach (HotelRoom room in _bookeRooms)
                {
                    Console.WriteLine(room.DisplayDetails());
                }
            }
            public void ReserveRoom(HotelRoom room)
            {
                _allRooms.Add(room);  
                                      
                room.Status = false ;

            }




        }
        public class HotelManagementSystem
        {
            List<Hotel> _hotels = new List<Hotel>();
            List<User> _users = new List<User>();
            List<Reservation> reservations = new List<Reservation>();
            public void RegisterUser(User user)
            {
                _users.Add(user);
            }
            public void AddHotel(Hotel hotel)
            {
                _hotels.Add(hotel);
            }

            public Reservation BookReservation(DateTime startTime,DateTime EndTime,HotelRoom room,Hotel hotel)
            {
            Reservation reserve = new Reservation(startTime, EndTime,room,hotel);
            reservations.Add(reserve);
            reserve.DisplayDetails();
            
            return reserve; 
            }
        public void DisplayReservationDetails(int reservationNumber)
        {
            foreach (var reservation in reservations)
            {
                if (reservation.ReservationNumber == reservationNumber)
                {
                    Console.WriteLine(reservation.DisplayDetails());
                    return;
                }
            }
            Console.WriteLine($"Reservation with number {reservationNumber} not found.");
        }


        public void DisplayHotels()
        {
            foreach (Hotel hotel in _hotels)
            {
                Console.WriteLine(hotel.DisplayDetails());
            }
        }



        }
        public class User
        {
            string Name { get; set; }
            string Address { get; set; }
            string Email { get; set; }
            int PhoneNumber { get; set; }
            public User(string name, string address, string email, int phoneNumber)
            {
                Name = name;
                Address = address;
                Email = email;
                PhoneNumber = phoneNumber;

            }


        }
        public class Account
        {
            public string AccountID { get; set; }
            public int Password { get; set; }
            public Account(string acountID, int password)
            {
                AccountID = acountID;
                Password = password;
            }


        }
        public class Receptionist : User
        {
            public Receptionist(string name, string address, string email, int phoneNumber) : base(name, address, email, phoneNumber)
            {

            }
            public void BookReservation(Guest guest, Reservation res)
            {

            }

        }
        public class Guest : User
        {
            int TotalBookedRooms { get; set; }
        private static int totalRooms = 2;
            List<Reservation> _reservations = new List<Reservation>();
            public Guest(string name, string address, string email, int phoneNumber) : base(name, address, email, phoneNumber)
            {


            }
            public void BookReservation(Reservation res)
            {
               // res.DisplayDetails();
            _reservations.Add(res); 
            }
            public void DisplayReservation()
            {
                foreach (Reservation reservation in _reservations)
                {
                    Console.WriteLine(reservation.DisplayDetails());
                }
            }


        }
        public class Reservation
        {

 private static int _reservationNumber = 1234567890;
          public  int ReservationNumber { get; }
       public     DateTime StartTime { get; set; }
       public     DateTime EndTime { get; set; }
           decimal Total { get; set; }
            HotelRoom room { get; set; }
        Hotel hotel { get; set; }
        public int DurationInDays = 10;
            public Reservation(DateTime startTime, DateTime endTime,  HotelRoom room,Hotel hotel)
            {

            // ReservationNumber = reservationNumber;


            this.hotel = hotel;
                StartTime = startTime;
                EndTime = endTime;
            this.ReservationNumber = _reservationNumber++;
             //  Total = startTime + endTime
            
                this.room = room;
            //  DurationInDays = durationIDays;

            }
       

        public string DisplayDetails()
        {
            TimeSpan duration = EndTime - StartTime;
            int durationInDays = duration.Days;
            return $"ReservationNumber: {ReservationNumber}, StartTime: {StartTime}, EndTime: {EndTime},\n DurationInDays: {durationInDays}, Total: {Total}, HotelRoom: {room.RoomNumber}";
        }



    }
    public enum RoomStyle
        {
            TwinRoom,
            QueenRoom,
            KingRoom
        }

    
}
