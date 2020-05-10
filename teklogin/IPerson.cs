using System.Data;
namespace teklogin
{
    interface IPerson
    {

        int Id { get; set; }
        string First_name { get; set; }
        string Last_name { get; set; }
        string Address { get; set; }
        bool Insert();
        bool Update();
        bool Delete();
        DataTable Search( string s);
      
    }
}
