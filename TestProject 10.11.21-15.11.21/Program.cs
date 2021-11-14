using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TestProject_10._11._21_15._11._21
{
    class Program
    {
        //Проверка есть ли нужное нам слово БД
        
        static string CheckWordInDB(string _word)
        {
            MySqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                //К какой БД обращаться (ускорил как мог) под каждую букву алфавита отдельная таблица в БД
                MySqlCommand command = connection.CreateCommand();
                command.CommandText = "Select * from "+_word[0]+"_vocabulary where word = '" + _word+"'";
                MySqlDataReader mySqlDataReader = command.ExecuteReader();
                int year = 2008;
                while (mySqlDataReader.Read())
                {
                    Console.WriteLine(_word);
                    return "Finish";
                }
            }
            catch (Exception exc)
            {
                
            }
            finally
            {
                connection.Close();
            }
            return null;
        }
        
        //Перебираем слово убирая последнюю букву и начиная поиск в БД
        public static void WordParsing(string _word)
        {
            string RemainderOfWord="";
            bool check = false;
            if (check == false)
            {
                for(int i = 1; i <= _word.Length; i++)
                {
                    
                    if (CheckWordInDB(_word) == "Finish")
                    {
                        if (RemainderOfWord.Length == 0)
                        {
                            break;
                        }
                        else
                        {
                            
                            WordParsing(RemainderOfWord);
                            break;
                        }
                    }
                    RemainderOfWord = _word[_word.Length - 1] + RemainderOfWord;
                    _word = _word.Remove(_word.Length - 1, 1);
                }
            }
            else
            {

            }
        }
        static void Main(string[] args)
        {
            
            Console.WriteLine("Write word to test -> ");
            string TestWord = Console.ReadLine();
            Console.WriteLine(TestWord + " -> ");
            string check = CheckWordInDB(TestWord);
            if(check == null)
            {
                WordParsing(TestWord);
            }
            Console.ReadLine();
            
        }
    }
}
