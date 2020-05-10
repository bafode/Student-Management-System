using System.Data;

namespace teklogin
{
    abstract class SuperClass
    {
        // Alanlar (Fields)
        private string _description;

        // Özellikler (Properties)
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        //---------------------Metodlar(Methods)----------------------------
        public virtual bool Insert()
        { 
            return true;
        }
        public virtual bool Delete()
        {
            return true;
        }

        public virtual DataTable GetAll()
        {
            DataTable table = new DataTable();
            return table;
        }
        public virtual bool Check()
        {
            return true;
        }
    }
}
