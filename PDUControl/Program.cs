using PDUControl;

if (args.Length is < 4 or > 6)
{
    Console.WriteLine("Usage: PDUControl <IP Address> <Username> <Password> [Command]");
    Console.WriteLine("Available commands:");
    Console.WriteLine("s [1-8] [1/0]    switch outlet 0-7 on (1) off (0)");
    Console.WriteLine("n [1-8]          get outlet name (all if no outlet number is supplied)");
    Console.WriteLine("a                get alert status");
    Console.WriteLine("c                get current in Ampere");
    Console.WriteLine("t                get temperature");
    Console.WriteLine("h                get humidity");
    Console.WriteLine("status           get status");
    return;
}



PduController c = new ();
c.Connect(args[0], args[1], args[2]);
switch (args[3].ToLower())
{
    case "s":
    {
        int outlet = Convert.ToInt32(args[4]);
        if (outlet is < 1 or > 8)
        {
            Console.WriteLine("invalid outlet");
            Environment.Exit(1);
        }
        c.Switch(outlet - 1, args[5] == "1");
        break;
    }
    case "n":
    {
        if (args.Length == 5)
        {
            int outlet = Convert.ToInt32(args[4]);
            if (outlet is < 1 or > 8)
            {
                Console.WriteLine("invalid outlet");
                Environment.Exit(1);
            }
            Console.WriteLine(c.GetOutletNames()[outlet-1]);
        }
        else
        {
            string[] names = c.GetOutletNames();
            for (int i = 0; i < 8; i++)
                Console.WriteLine($"Outlet{i}  {names[i]}");
        }
        break;
    }
    case "c":
        Console.WriteLine(c.Status().Current);
        break;
    case "t":
        Console.WriteLine(c.Status().Temperature);
        break;
    case "h":
        Console.WriteLine(c.Status().Humidity);
        break;
    case "a":
        Console.WriteLine(c.Status().AlertState);
        break;
    case "status":
    {
        PduStatus st = c.Status();
        Console.WriteLine($"Current          {st.Current}");
        Console.WriteLine($"Temperature      {st.Temperature}");
        Console.WriteLine($"Humidity         {st.Humidity}");
        Console.WriteLine($"Alert status     {st.AlertState}");
        Console.WriteLine("Outlet1          {0}", st.Outlet0Power ? "on" : "off");
        Console.WriteLine("Outlet2          {0}", st.Outlet1Power ? "on" : "off");
        Console.WriteLine("Outlet3          {0}", st.Outlet2Power ? "on" : "off");
        Console.WriteLine("Outlet4          {0}", st.Outlet3Power ? "on" : "off");
        Console.WriteLine("Outlet5          {0}", st.Outlet4Power ? "on" : "off");
        Console.WriteLine("Outlet6          {0}", st.Outlet5Power ? "on" : "off");
        Console.WriteLine("Outlet7          {0}", st.Outlet6Power ? "on" : "off");
        Console.WriteLine("Outlet8          {0}", st.Outlet7Power ? "on" : "off");
        break;
    }
    default:
        Console.WriteLine("unknown command");
        Environment.Exit(1);
        break;
}
