using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.IO;





namespace linmapwin
{
     
    class Program
    {



      static string workDir = Directory.GetCurrentDirectory();


        public string getWorkDir(){
            return workDir;
        }

        public void setWorkDir(string path)
        {
            workDir = path;
        }

        static void Main(string[] args)
        {
           
             


            
          
            //Directory.SetCurrentDirectory("C:\\");
            // Read in every line in the file.
            // using (StreamReader reader = new StreamReader("input.txt"))


            for (int i = 0; i < args.Length; i++)
            {
                // Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            }


            while (true)
            {
                Console.Write(GlobalClass.GlobalVar + ">");
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



static class GlobalClass
{
     private static string workDir = Directory.GetCurrentDirectory();
    public static string GlobalVar
    {
        get { return workDir; }
        set { workDir = value; }

    }
}

class Parser
{
    string[] validCommands = {"mkdir", "copy", "del", "dir", "cls", "find", "ls", "move", 
    "rmdir", "rename", "replace", "prompt", "exit", "help", "cd"};


    // string fullUserCommand;
    string userCommand;
    string[] userArgs = new string[7];
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
                    
                    Cd changeDir = new Cd();
                    changeDir.cd(userArgs);
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
        else Console.WriteLine("invalid command.");
    }
}




class Mkdir : Command
{
    public void mkdir(string[] args)
    {
        setName("mkdir - Make Directory");
        setDescription("Used for creating Directories");
        setUsage(
            "\nUsage\n" +
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
    public void copy(string[] args)
    {

        setName("Copy");
        setDescription("Allows copying files to another location");
        setUsage("");
        bool agbit = false;
        string sourceFile = null;
        string sourceFileName = null;
        string sourcePath = null;
        string destinationPath = null;
        string destinationFile = null;
        string destinationFileName = null;
        FileAttributes attr;

        /*
         * 
         *  - The following series of if statements checks to verify that all arguments have been entered(not validity verification though)
         *  Poor implementation. I know.
         * 
         */



        if (Object.ReferenceEquals(null, args[0]))
        {
            agbit = true;
            goto missingargumenterror;
        }

        if (Object.ReferenceEquals(null, args[1]))
        {
            agbit = true;
            goto missingargumenterror;
        }

        if (Object.ReferenceEquals(null, args[2]))
        {
            agbit = true;
            goto missingargumenterror;
        }

        if (Object.ReferenceEquals(null, args[3]))
        {
            agbit = true;
            goto missingargumenterror;
        }

        if (Object.ReferenceEquals(null, args[4]))
        {
            agbit = true;
            goto missingargumenterror;
        }

    missingargumenterror:
        if (agbit == true)
        {
            Console.WriteLine("Missing Arguments. Please check help info for proper usage syntax");
            //Console.WriteLine(args.Length);

        }


        /* 
             if (Object.ReferenceEquals(null, args[5]))
             {
                 agbit = true;
                 goto missingargumenterror;
             }

            if (Object.ReferenceEquals(null, args[6]))
             {
                agbit = true;
                 goto missingargumenterror;
             }
           */


        /* Was doing verification like this initially, but, because of it being a loop, it would repeat even though last element was null
        foreach (string arg in args)
        {
            if (Object.ReferenceEquals(null, arg))
            {
                agbit = true;
                goto missingargumenterror;
            }
            else{
                Console.WriteLine("Create a facebook profile");
            }
        }*/


        sourceFileName = args[0];
        sourcePath = args[2];
        destinationPath = args[4];


        Console.WriteLine("Source Path:" + sourcePath + "\n Source File Name:" + sourceFileName + "\n Destination Path:" + destinationPath);













        if (doesPathExist(sourcePath) == true)
        {

            string fileName = null;

            sourceFile = System.IO.Path.Combine(sourcePath, sourceFileName);

            //  is source file  a directory? or is it a file

            attr = File.GetAttributes(sourceFile);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                // Console.WriteLine("Its a directory");

                string[] files = System.IO.Directory.GetFiles(System.IO.Path.Combine(sourcePath, sourceFileName));

                // Copy the files and overwrite destination files if they already exist. 
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);

                    if (!Directory.Exists(destinationPath))
                    {
                        System.IO.Directory.CreateDirectory(destinationPath);
                    }
                    destinationFile = System.IO.Path.Combine(destinationPath, fileName);
                    System.IO.File.Copy(s, destinationFile, true);


                }

                Console.WriteLine(sourceFile + " copied to " + destinationPath);
            }

            else
            {
                //  Console.WriteLine("Its a file");
                string[] files = Directory.GetFiles(sourcePath, "*.*", SearchOption.TopDirectoryOnly);
                if (files.Contains(sourceFile))
                {
                    // Console.WriteLine("File Found");

                    destinationFileName = sourceFileName;
                    destinationFile = System.IO.Path.Combine(destinationPath, destinationFileName);
                    /*****DEBUGGING - LISTING ALL FILES IN DIRECTORY *******/
                    foreach (string file in files)
                    {
                        // Console.WriteLine(file);
                    }
                    /****END OF DEBUGGING*****/

                    if (doesPathExist(destinationPath) == true)
                    {
                        System.IO.File.Copy(sourceFile, destinationFile, true);
                        Console.WriteLine(sourceFile + " copied to " + destinationPath);
                    }

                    else //meaning directory does not exist
                    {


                        if (!System.IO.Directory.Exists(destinationPath))
                        {
                            System.IO.Directory.CreateDirectory(destinationPath);
                            System.IO.File.Copy(sourceFile, destinationFile, true);
                        }


                    }


                }

                else
                {
                    Console.WriteLine("File not found");
                }


                if (doesPathExist(sourcePath) == false)
                {
                    Console.WriteLine("Source Path does not exist");
                }
            }































        }
    }

    private bool doesPathExist(string path)
    {
        if (System.IO.Directory.Exists(path))
        {
            return true;
        }

        else
        {

            return false;
        }
    }




    //Wanted to implement this function, but did it with a series of IF statements instead
    private bool checkIfArgumentsNull(string[] args)
    {
        return true;
    }

}




class Cd : Command
{

    public void cd(string[] args)
    {
        setName("Cd");
        setDescription("Allows changing directory on command line");
        setUsage("");

        
        string path = args[0];






        //Directory.SetCurrentDirectory("C:\\");
      //  string currDirectory = Directory.GetCurrentDirectory();
      //  Console.WriteLine(currDirectory);

        /*
         * 1. Check , see if directory exists
         * 2. If exists, change the prompt to the directory(by appending to current directory
         * 3. Set current working directory to new path
         * 4. Add functionality to go to root.
         * 5. Add functionality to .. go back up 
         * 
         */

        

        if (path.Equals(".."))
        {
            GlobalClass.GlobalVar = Directory.GetParent(path).ToString();
               Directory.SetCurrentDirectory(GlobalClass.GlobalVar);
        }

        else if(path.Equals("\\")){
             GlobalClass.GlobalVar = Directory.GetDirectoryRoot(path);
               Directory.SetCurrentDirectory(GlobalClass.GlobalVar);
        }

        else if (path.Equals("/"))
        {
            GlobalClass.GlobalVar = Directory.GetDirectoryRoot(path);
            Directory.SetCurrentDirectory(GlobalClass.GlobalVar);
        }
        

        else if (Directory.Exists(path))
        {

            //Change directory
            // workDir = 
            //Combine path


            
            GlobalClass.GlobalVar = System.IO.Path.Combine(GlobalClass.GlobalVar, path);
            Directory.SetCurrentDirectory(GlobalClass.GlobalVar);
            
            Console.WriteLine("THIS IS IT:"+GlobalClass.GlobalVar);
        }
        else if (File.Exists(path))
        {
            Console.WriteLine("This is a file.");
        }

        else if (!Directory.Exists(path))
        {
            Console.WriteLine("Folder does not exist");
        }





        /*
         try
         {
             if (!File.Exists(path))
             {
                 // This statement ensures that the file is created, 
                 // but the handle is not kept. 
                 using (FileStream fs = File.Create(path)) { }
             }

           
        

         }
            
         catch (Exception e)
         {
             Console.WriteLine("The process failed: {0}", e.ToString());
         } */
    }
}





/*

class Copy : Command
{

    public void createFolderIfNone(string path)
    {
        if (!System.IO.Directory.Exists(path))
        {
            System.IO.Directory.CreateDirectory(path);
        }
    }
    
    public void copyFileAndOverwrite(string source, string dest){
        System.IO.File.Copy(source, dest, true);
    }
    
    
    
    
    public void copy(string[] args)
    {
        setName("Copy");
        setDescription("Allows copying files to another location");
        setUsage("");
        string fileName = null;
        string sourcePath = null;
        string targetPath = null;
        string destFile = null;




     //   for (int i = 0; i < args.Length; i++)
        int i = 0;
        foreach (string arg in args)
        {
            
            //Console.WriteLine("Arg[{0}] = [{1}]", i, args[i]);
            Console.WriteLine("Arg[" +i + "] = " + arg);
            i++;


            if (Object.ReferenceEquals(null, arg))
                {
                    Console.WriteLine("Missing Arguments. Check Syntax");
                    break;
                
                }
                else
                {


                if (args[1].Equals("from") && args[3].Equals("to"))
                    {


                        fileName = args[0];
                        sourcePath = args[2];
                        targetPath = args[4];
                        destFile = System.IO.Path.Combine(targetPath, fileName);

                       //  Console.WriteLine(fileName + "\n" + sourcePath + "\n" + targetPath + "\n" + destFile);
                    }
                   
                    else
                    {
                       
                        Console.WriteLine("\nInvalid Syntax.");
                        Console.WriteLine("Either do: \tcopy FILENAME from SOURCEPATH to DESTPATH or \n \tcopy FILENAME from SOURCEPATH to DESTHPATH as NEWFILENAME");
                    }


                    
                }
          }




               Console.WriteLine(fileName + "\n" + sourcePath + "\n" + targetPath + "\n" + destFile);







        /*


        string fileName = ; //Name of source file
        string sourcePath = ; 
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




        
        
        //if (!System.IO.Directory.Exists(targetPath))
        //{
            System.IO.Directory.CreateDirectory(targetPath);
//        }


  //      // To copy a file to another location and  
        // overwrite the destination file if it already exists.
    //    System.IO.File.Copy(sourceFile, destFile, true);
     


    }
   


}
*/





abstract class Command
{


    string Name; /*name of command*/
    string Description; /*One line description used for the help file. eg. This command can be used to change directories.*/
    string Usage; /*details the switches used (if any). eg. -a abort, -c compile */






    /****************************
    * 
    * Getters
    * 
    * ***************************/




    public string getName()//name of command
    {
        return Name;
    }


    public string getDescription()//
    {
        return Description;
    }


    public string getUsage()
    {
        return Usage;
    }




    /****************************
     * 
     * Setters
     * 
     * ***************************/
    public void setName(string Name)
    {
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


