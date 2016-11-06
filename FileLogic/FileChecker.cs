using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Xml;

namespace FileLogic
{
    class FileChecker
    {
        string path = "";

        public FileChecker(string path)
        {
            try
            {
                this.path = path;

                if (Directory.Exists(path) == false)
                    Directory.CreateDirectory(path);
            }
            catch (Exception e)
            {

            }
        }

        public void AddFilesToDatabase()
        {
            DirectoryInfo fileList = new DirectoryInfo(path);
            FileInfo[] files = fileList.GetFiles();
            if (files.Length == 0)
                Console.WriteLine("No files found");

            SqlConnection db = new SqlConnection();


            foreach (FileInfo item in files)
            {
                DataSet data = new DataSet();
                data.ReadXml(XmlReader.Create(item.FullName));
                SqlDataAdapter adapter = new SqlDataAdapter();


                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    db.ConnectionString = "(LocalDb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\MusicMattersDb.mdf";
                    db.Open();

                    string artistName = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    string artistImagePath = data.Tables[0].Rows[i].ItemArray[1]?.ToString();
                    string artistDescription = data.Tables[0].Rows[i].ItemArray[2]?.ToString();
                    string artistActiveFrom = data.Tables[0].Rows[i].ItemArray[3]?.ToString();
                    string artistActiveUntil = data.Tables[0].Rows[i].ItemArray[4]?.ToString();
                    int artistApproved = 1;

                    string query = "INSERT INTO Artist VALUES(" + artistName + ", " + artistImagePath + ", " + artistDescription
                        + ", " + artistActiveFrom + ", " + artistActiveUntil + ", " + artistApproved + ")";

                    SqlCommand command = new SqlCommand(query);
                    adapter.InsertCommand = command;
                    adapter.InsertCommand.ExecuteNonQuery();
                }
            }
        }
    }
}
