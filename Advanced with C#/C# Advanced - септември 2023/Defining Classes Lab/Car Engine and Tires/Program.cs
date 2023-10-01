using Car_Engine_and_Tires;

Tire[] tires = new Tire[4]
{
    new Tire(1,2.5),
    new Tire(1,2.1),
    new Tire(2,0.5),
    new Tire(2,2.3),
    
};
Engine engine = new Engine(560,6300);

Car car = new Car("Mercedes","c220",1999,200.0,150.0,engine,tires);
