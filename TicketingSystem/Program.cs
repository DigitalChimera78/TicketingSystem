
var file = "tickets.csv";
var choice = "0";

do
{
    // prompt input
    Console.WriteLine("1) Read data from file");
    Console.WriteLine("2) Create file from data");
    Console.WriteLine("Enter any other key to exit");

    // receive direction from user
    choice = Console.ReadLine();

    // if they want to read from file and file exists, read file and output formatted data
    if (choice == "1" && File.Exists(file))
    {
        StreamReader sr = new(file);

        while (!sr.EndOfStream)
        {
            var line = sr.ReadLine();
            string[] data = line.Split(',');
            string[] watching = data[data.Length - 1].Split('|');

            Console.WriteLine("Ticket #" + data[0]);
            Console.WriteLine("Summary: " + data[1]);
            Console.WriteLine("Status: " + data[2]);
            Console.WriteLine("Priority: " + data[3]);
            Console.WriteLine("Submitted by: " + data[4]);
            Console.WriteLine("Assigned to: " + data[5]);
            Console.Write("Watched by: ");

            for (int i = 0; i < watching.Length; i++)
            {
                if (i == watching.Length - 1)
                {
                    Console.WriteLine(watching[i]);
                }
                else
                {
                    Console.Write(watching[i] + ", ");
                }
            }
        }
        sr.Close();
    }
    // if user wants to read from file but file does not exist, tell them file does not exist
    else if (choice == "1" && !File.Exists(file))
    {
        Console.WriteLine("File does not exist");
    }
    // if user indicates desire to write to file, begin writing to file
    else if (choice == "2")
    {
        StreamWriter sw = new StreamWriter(file);
        int j = 0;
        string resp;

        sw.WriteLine("TicketID,Summary,Status,Priority,Submitter,Assigned,Watching");
        do
        {
            string delimOne = j.ToString();
            Console.WriteLine("Enter ticket summary: ");
            delimOne += "," + Console.ReadLine();
            Console.WriteLine("Enter ticket status: ");
            delimOne += "," + Console.ReadLine();
            Console.WriteLine("Enter ticket priority: ");
            delimOne += "," + Console.ReadLine();
            Console.WriteLine("Enter who submitted this ticket: ");
            delimOne += "," + Console.ReadLine();
            Console.WriteLine("Enter who is assigned this ticket: ");
            delimOne += "," + Console.ReadLine();

            Console.WriteLine("How many users are watching this ticket?");
            int x = int.Parse(Console.ReadLine());
            string delimTwo = "";

            for (int i = 0; i < x; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("Enter user: ");
                    delimTwo = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Enter user: ");
                    delimTwo += "|" + Console.ReadLine();
                }
            }

            sw.WriteLine("{0},{1}", delimOne, delimTwo);

            j++;
            Console.WriteLine("Enter another ticket? y/n");
            resp = Console.ReadLine();
        } while (resp.ToUpper() == "Y");
        sw.Close();
    }
} while (choice == "1" || choice == "2");