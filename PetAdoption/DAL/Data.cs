namespace PetAdoption.DAL
{
    public class Data
    {
        // מחרוזת החיבור למסד הנתונים
        string ConnectionString = "server=YITAV\\SQLEXPRESS;initial catalog=AdoptPet; user id=sa;" +
            "password=1234;TrustServerCertificate=Yes";

        //בניית בנאי פרטי למניעת יצירת מופעים חדשים

        static Data _data;

        private DataLayer DataLayer;

        //בוב הבנאי
        private Data()
        {
            DataLayer = new DataLayer(ConnectionString);
        }

        //מאפיין סטטי לקבלת מופע יחיד בלבד סינגלטון
        public static DataLayer GetData
        {
            get
            {
                //אם אין מופע קיים, צור אחד חדש
                if (_data == null) _data = new Data();
                return _data.DataLayer;
            }

        }
    }
}
