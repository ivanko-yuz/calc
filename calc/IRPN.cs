namespace calc
{
    public interface IRPN
    {
        string Calculate(string input);
        double DoAction(char c, double a, double b);
        bool IsOperandus(char c);
        bool IsOperator(char c);
        string LengyelFormaKonvertalas(string input);
        int Prior(char c);
    }
}