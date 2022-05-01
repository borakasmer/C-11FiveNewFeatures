// See https://aka.ms/new-console-template for more information

Channel channel = new();

//channel.AddSubscriber("Hasan");
//channel.AddSubscriber(null);
channel.Subscribers.ForEach(s => Console.Write($"{s}, "));
Console.WriteLine();
Console.WriteLine("".ToString().PadRight(50, '*'));
//*****************************************

Console.WriteLine($"First Rank Subscriber With First Letter B is:{channel
    .Subscribers
    .Where(s =>
    s.Substring(0,
    1).ToUpper() == "B")
    .First()}");

Console.WriteLine($"This channel has:{channel.SubCount} subscribers.");

Console.WriteLine("".ToString().PadRight(50, '*'));
//*****************************************

var boraWasFirst =
    channel.Subscribers is ["Bora", ..];

Console.WriteLine($"Bora is first: {boraWasFirst}");

var boraFirstAndBurakLast =
    channel.Subscribers is ["Bora", .., "Mehmet"];

Console.WriteLine($"Bora is first and Mehmet is last: {boraFirstAndBurakLast}");

Console.WriteLine("".ToString().PadRight(50, '*'));
//*****************************************

if (channel.NewStringSubscribers is
    [_, "Veli", .. var subscribersBetweenVeliAndOsman, "Osman"])
{
    foreach
            (var subscriber in subscribersBetweenVeliAndOsman)
    {
        Console.WriteLine($"{subscriber} is between Veli and Osman");
    }
}

if (channel.NumberList is
   [.., [_, .. int[] secretNumbers, _]])
{
    foreach
            (var number in secretNumbers)
    {
        Console.WriteLine($"Secret Number: {number}");
    }
}

var str = new RepeatSequence();

for (int i = 0; i < 10; i++)
    Console.WriteLine(str++);

public class Channel
{
    public int SubCount => Subscribers.Count;
    public List<string> Subscribers = new()
    {
        "Bora",
        "Burak",
        "Engin",
        "Mehmet"
    };

    public string[] NewStringSubscribers = new string[]
    {
        "Ayse",
        "Veli",
        "Ahmet",
        "Burak",
        "Osman"
    };

    public void AddSubscriber(string subscriber!!)
    {
        Subscribers.Add(subscriber);
    }

    public int[][] NumberList = new[] {
        new int[] { 1, 2, 3,4 },
        new[] { 5, 6,7,8 },
        new[] { 9,10,11,12 }
    };
}

public class GenericAttribute<T> : Attribute
{
    private T name { get; set; }
    private T action { get; set; }

    public GenericAttribute(T name, T action)
    {
        this.name = name;
        this.action = action;
    }

    public T Name
    {
        get
        {
            return name;
        }
    }
    public T Action
    {
        get
        {
            return action;
        }
    }
}

public class GenericClass
{
    [GenericAttribute<string>("Generic Example Class", "Get Name of Student")]
    public string GetName() => default;

    [GenericAttribute<int>(3, 4)]
    public string ChildMenuRowOfParrent() => default;
}


public interface IGetNext<T> where T : IGetNext<T>
{
    static abstract T operator ++(T other);
}

public struct RepeatSequence : IGetNext<RepeatSequence>
{
    public RepeatSequence() { }
    private const int Num = 1;
    public string Value = Num.ToString();

    public static RepeatSequence operator ++(RepeatSequence other)
        => other with { Value = other.Value + Num };

    public override string ToString() => Value;
}