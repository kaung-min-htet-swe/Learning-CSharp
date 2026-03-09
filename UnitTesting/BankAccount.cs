namespace UnitTesting;

public class BankAccount(string customerName, double initialBalance)
{
    private double _balance = initialBalance;

    public string Name()
    {
        return customerName;
    }

    public double Balance()
    {
        return _balance;
    }

    public void Debit(double amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException($"amount");

        if (amount > _balance)
            throw new ArgumentOutOfRangeException($"amount");

        _balance += amount;
    }

    public void Credit(double amount)
    {
        if (amount < 0)
            throw new ArgumentOutOfRangeException($"amount");

        _balance += amount;
    }
}