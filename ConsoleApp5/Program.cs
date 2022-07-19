using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 7;
            int y = 25;
            Swap<int>(ref x, ref y);
            Console.WriteLine($"x={x},y={y}");
            string s1 = "hello";
            string s2 = "bye";
            Swap<string>(ref s1, ref s2);
            Console.WriteLine($"s1={s1}s2={s2}");
            void Swap<P>(ref P x, ref P y)
            {
                P temp = x;
                x = y;
                y = temp;
            }
            Console.WriteLine("Hello World!");
            Person person=new Person("Tom");
            person.Print();
            //Person<T> person1=new Person(55,"Tom")
            Console.WriteLine(person.ToString());
            person = new Employee("Sam","Microsoft");
            person.Print();
            Employee employee = new Employee();
            Employee employee1 = (Employee)person;
            if(person is Employee)
            {
                Console.WriteLine("Presents class Employee");
            }
            Transport car = new Car();
            Transport ship = new Ship();
            Transport aircraft = new Aircraft();
            car.Move();
            ship.Move();
            aircraft.Move();
            Shape rectangle = new Rectangle { Width = 20, Height = 20 } ;
            Shape circle = new Circle { Radius = 200 };
            PrintShape(rectangle);
            PrintShape(circle);
            void PrintShape(Shape shape)
            {
                Console.WriteLine($"Perimeter{shape.GetPerimeter()} Area{shape.GetArea()}");
            }
            Clock clock = new Clock(15,24,56) ;

        }
        
        

    } }
class Clock
{
    public int hours { get; set; }
    public int minutes { get; set; }
    public int seconds { get; set; }
    public Clock(int hours,int minutes,int seconds){
        }
    public override string ToString()
    {
        return $"{hours}:{minutes}:{seconds}";
    }
}
class Person
{
    //public T Id { get; set; }
    public string Name1 { get; set; }
    /*public Person(T id, string name){
        Id=id;
        Name1=name;
    }*/
        
    int age = 1;
    public virtual int Age
    {
        get => age;
        set { if(value > 0 && value < 110) 
                age=value; }
    }

    private string name = "";
    public string Name
    {
        get; set;
    }
    public Person(string name)
    {
        Name = name;
    }
    public virtual void Print()
    {
        Console.WriteLine($"Name {Name}");
    }
    public Person(){}
    public override string ToString()
    {
        if (string.IsNullOrEmpty(Name))
        return base.ToString();
        return Name;
    }
    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

}
class Employee : Person
{   
    public void PrintName()
    {
        Console.WriteLine(Name);
    }
    public override int Age { get => base.Age; set { if (value > 17 && value < 110) base.Age = value; } }
    public string Company
    {
        get; set;
    }
    public Employee()
    {

    }
    public Employee(string name, string company)

       : base(name) 
    { 
        Company = company;
        base.Age = 18;
    }
    public override void Print()
    {
        Console.WriteLine($"Name{ Name} Company{Company}");
    }
    
}
class Client : Person
{
    public string Bank
    {
        get; set;
    }
    public Client(string name, string bank)
        : base(name) 
    { Bank=bank; }}
abstract class Transport
{
    public abstract int speed
    {
        get;set;
    }

    public abstract void Move();
    
}
class Car : Transport {
    public override int speed { get => speed; set => speed = value; }

    public override void Move()
    {
        Console.WriteLine("Car is driven");
    }
}
class Auto : Car
{
    public override void Move()
    {
        Console.WriteLine("Car is driven");
    }
}
class Ship : Transport {
    public override int speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override void Move()
    {
        Console.WriteLine("Ship is swum");
    }
}
class Aircraft : Transport
{
    public override int speed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public override void Move()
    {
        Console.WriteLine("Aircraft is flown");
    }
}
abstract class Shape
{
    public abstract double GetPerimeter();
    public abstract double GetArea();
}
class Rectangle : Shape
{
    public float Width { get; set; }
    public float Height { get; set; }
    public override double GetPerimeter() => Width * 2 + Height * 2;
    public override double GetArea() => Width * Height;
}
class Circle : Shape
{
    public double Radius
    {
        get; set;
    }
    public override double GetPerimeter() => Radius * 2 * 3.14;
    public override double GetArea() => Radius * Radius * 3.14;
}



