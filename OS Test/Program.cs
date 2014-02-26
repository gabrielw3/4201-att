using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace linmapwin
{
    class Program
    {
        static void Main(string[] args)
        {

             // Read in every line in the file.
       // using (StreamReader reader = new StreamReader("input.txt"))

            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            } 

        while(true){
            Console.Write("\nOS:>");
            string line = "hey";
            line = Console.ReadLine();
            
            
            Parser p = new Parser();
            p.parse(line);
            p.isValidCommand();
            
            
            
            //Console.ReadLine();
        }
    }
        }
    
}

class Parser
{
    string[] validCommands = {"mkdir", "copy", "del", "dir", "cls", "find", "ls", "move", 
    "rmdir", "rename", "replace", "prompt", "exit", "help"};

    // string fullUserCommand;
    string userCommand;
    string[] userArgs = new string[6];
    bool valid = false;

    public void parse(string fullUserCommand)
    {

        char[] delim = { ' ' };

        string[] tokens = fullUserCommand.Split(delim);
        int commandLength = tokens.Length;

        userCommand = tokens[0];
        for (int i = 1; i < commandLength; i++)
        {
            userArgs[i - 1] = tokens[i];
        }


    }

    public string[] getArgs()
    {
        return userArgs;
    }

    public string getCommand()
    {
        return userCommand;
    }

    public void isValidCommand()
    {

        foreach (string command in validCommands)
        {
            if (String.Compare(getCommand(), command, true) == 0)
            {
                valid = true;




            }

        }
        if (valid)
        {
            switch (getCommand().ToLower())
            {
                case "mkdir":
                   
                    Mkdir m = new Mkdir();
                    m.mkdir(userArgs);
                    Console.WriteLine(m.getUsage());
             
                    break;
                case "dir":
                    Console.WriteLine("Dir implemented");
                    break;

                case "copy":
                    Console.WriteLine("Copy implemented");
                    Copy c = new Copy();
                    c.copy(userArgs);
                    break;

                case "del":
                    Console.WriteLine("Delete implemented");
                    break;

                case "cls":
                    Console.Clear();
                    break;

                case "cd":
                    Console.WriteLine("Change Directory");
                    break;

                case "find":
                    Console.WriteLine("Find implemented");
                    break;

                case "ls":
                    Console.WriteLine("LS implemented");
                    break;

                case "move":
                    Console.WriteLine("move implemented");
                    break;

                case "rmdir":
                    Console.WriteLine("rmdir implemented");
                    break;

                case "rename":
                    Console.WriteLine("rename implemented");
                    break;

                case "replace":
                    Console.WriteLine("replace implemented");
                    break;

                case "exit":
                    Console.WriteLine("OS will now close.Goodbye");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;

                case "help":
                    Console.WriteLine("help");
                    break;  

                default:
                    Console.WriteLine("Nothing happened");
                    break;
            }







        }
        else Console.WriteLine("invalid");
    }
}


class Mkdir : Command
{
    public void mkdir(string[] args) 
    {
        setName("mkdir - Make Directory");
        setDescription("Used for creating Directories");
        setUsage(
            "\nUsage\n"+
            "Examples\n" +
"\nmkdir helloworld - Creates subdirectory in current folder\n" +
"mkdir C:\\helloworld  - Creates 'helloworld' directory on 'C' drive\n" +
"mkdir helloworld\\helloboy\\hellogirl - Creates helloworld,helloboy,hellogirl folders recursively\n" +
"mkdir helloboy hellogirl helloworld - Creates 3 separate folders in current directory "

            );
        
        
        Console.WriteLine("Mkdir implemented");
        // Specify a "currently active folder"
        //string activeDir = @"C:\Users\Nerisha\Documents\OS_public\New folder";
        string activeDir = Directory.GetCurrentDirectory();
        //Create a new subfolder under the current active folder


        foreach (string path in args)
        {
            if (Object.ReferenceEquals(null, path))
            {
                break;
            }
            else
            {
                string newPath = Path.Combine(activeDir, path);
                if (Directory.Exists(activeDir + "\\" + path))
                {
                    Console.WriteLine("I'm sorry. The" + " '" + path + "'" + " Directory Already Exists. Please use another name.");
                }
                else
                {
                    Directory.CreateDirectory(newPath);
                    //Console.WriteLine("\n" + activeDir + "'\'" + args[0]);
                    Console.WriteLine("\n" + path + " Directory created. \nLocation: " + newPath);

                }


            }
            }
                
       
    }
}



class Copy : Command
{
    public void copy(string[] args){
        setName("Copy");
        setDescription("Allows copying files to another location");
        setUsage("");
        /*

        string fileName = "test.txt";
        string sourcePath = Directory.GetCurrentDirectory(); 
        //string targetPath = Path.Combine(sourcePath, path);
        string targetPath;
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile;

        foreach (string arg in args){

            if (arg.Substring(0, 3).Contains(":") | arg.Substring(0, 3).Contains("\\")) // Treat argument as a path if the argument contains colon or backslash
            {
                targetPath = arg;
               destFile = System.IO.Path.Combine(targetPath, fileName);
               System.IO.File.Copy(sourceFile, destFile, true);
            }


        }


        */
        /*
        if (!System.IO.Directory.Exists(targetPath))
        {
            System.IO.Directory.CreateDirectory(targetPath);
        }

        // To copy a file to another location and  
        // overwrite the destination file if it already exists.
        System.IO.File.Copy(sourceFile, destFile, true);
        */
    }
}






abstract class Command{

    string Name; /*name of command*/
    string Description; /*One line description used for the help file. eg. This command can be used to change directories.*/
    string Usage; /*details the switches used (if any). eg. -a abort, -c compile */



    /****************************
    * 
    * Getters
    * 
    * ***************************/


    public string getName(){
        return Name;
    }

    public string getDescription(){
        return Description;
    }

    public string getUsage(){
        return Usage;
    }


    /****************************
     * 
     * Setters
     * 
     * ***************************/
    public void setName(string Name){
        this.Name = Name;
    }

    public void setDescription(string Description)
    {
        this.Description = Description;
    }

    public void setUsage(string Usage)
    {
        this.Usage = Usage;
    }



   
}