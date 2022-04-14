namespace api
{
    public class connectionstring
    {
          public string cs  {get;set;}

        public void ConnectionString()
        {
            string server = "qz8si2yulh3i7gl3.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "	q1kqpauwh9p1bdnb";
            string port = "3306";
            string username= "notrxf94ewo1aeqa";
            string password = "orm12n9wd9wlgo3b";

            cs =$@"server ={server}; user = {username};database ={database}; port = {port};password={password};";
        }
    }
}