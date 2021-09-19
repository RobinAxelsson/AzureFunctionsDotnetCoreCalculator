public class Validate
{
    public static void print() { Console.WriteLine("Hello World"); }
}
Validate.print();

string a = null;
string x = a ?? "a was null";
Console.WriteLine(x);
a = "1111.1";
x = a ?? "a was null";
Console.WriteLine(x);

string test = null;
decimal b = Convert.ToDecimal(test); //Gives 0
Console.WriteLine(b);//
decimal c = Convert.ToDecimal("-1.1");
Console.WriteLine(b + c);
