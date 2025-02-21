using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System.Net;
using System.Reflection;
using LibraryManagementSystem.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem
{
    [TestFixture]
    public class Tests : IDisposable
    {
        public static List<String> failMessage = new List<String>();
        public static String failureMsg = "";
        public static int failcnt = 1;
        public int totalTestcases = 0;

        public int userport;
        public string appURL;
        RestClient client;

        Assembly assem;
        String assemblyName = "LibraryManagementSystem";

        [OneTimeSetUp]
        public void Setup()
        {
            //IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            //DbContextOptions<LibraryContext> options = new DbContextOptionsBuilder<LibraryContext>()
            //.UseSqlServer(configuration.GetConnectionString("DBConnection"))
            //.Options;

            //userport = Int32.Parse(Environment.GetEnvironmentVariable("userport"));
            //client = new RestClient("http://localhost:" + userport);
            client = new RestClient("http://localhost:5139");

            String msg = "";

            try
            {
                assem = Assembly.Load(assemblyName);
            }
            catch (Exception e)
            {
                Assert.Fail(msg + "Could not Load Assembly");
            }
        }

        [OneTimeTearDown]
        public void Dispose()
        {
            if (totalTestcases > 0)
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./FailedTest.txt"))
                {
                    foreach (string line in failMessage)
                    {
                        //Console.WriteLine("line " + line);
                        file.WriteLine(line);
                    }
                }
            }
            else
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"./FailedTest.txt"))
                {
                    file.WriteLine("error");
                }
            }
            //_driver.Quit();
            //_driver.Dispose();
        }

        public void ExceptionCatch(string functionName, string catchMsg, string msg, string msg_name, string exceptionMsg = "")
        {
            failMessage.Add(functionName);

            if (msg == "")
            {
                msg = exceptionMsg + (exceptionMsg != "" ? " - " : "") + catchMsg + "\n";
                msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
            }
            else
                msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

            failureMsg += msg_name;
            failcnt++;
            Assert.Fail(msg);
        }

        IRestResponse response = null;

        [Test, Order(1)]
        public void Test1_Check_Properties_Book() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Models", "Book");
            try
            {
                var IsFound = tb.HasProperty("Id", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Id", propertyType: "int");
                }

                IsFound = tb.HasProperty("Title", "String");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Title", propertyType: "String");
                }

                IsFound = tb.HasProperty("Author", "String");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Author", propertyType: "String");
                }

                IsFound = tb.HasProperty("Rating", "Decimal");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Rating", propertyType: "decimal");
                }

                IsFound = tb.HasProperty("BorrowRecords", "ICollection`1");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "BorrowRecords", propertyType: "ICollection<BorrowRecord>");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(2)]
        public void Test2_Check_Properties_Member()
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Models", "Member");
            try
            {
                var IsFound = tb.HasProperty("Id", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Id", propertyType: "int");
                }

                IsFound = tb.HasProperty("Name", "String");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Name", propertyType: "String");
                }

                IsFound = tb.HasProperty("BorrowRecords", "ICollection`1");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "BorrowRecords", propertyType: "ICollection<BorrowRecord>");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }              

        [Test, Order(3)]
        public void Test3_Check_Properties_BorrowRecord() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Models", "BorrowRecord");
            try
            {
                var IsFound = tb.HasProperty("Id", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Id", propertyType: "int");
                }

                IsFound = tb.HasProperty("BorrowDate", "DateTime");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "BorrowDate", propertyType: "DateTime");
                }

                IsFound = tb.HasProperty("ReturnDate", "DateTime");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "ReturnDate", propertyType: "DateTime");
                }

                IsFound = tb.HasProperty("FineAmount", "Decimal");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "FineAmount", propertyType: "decimal");
                }

                IsFound = tb.HasProperty("BookId", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "BookId", propertyType: "int");
                }

                IsFound = tb.HasProperty("Book", "Book");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Book", propertyType: "Book");
                }

                IsFound = tb.HasProperty("MemberId", "Int32");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "MemberId", propertyType: "int");
                }

                IsFound = tb.HasProperty("Member", "Member");
                if (!IsFound)
                {
                    msg += tb.Messages.GetPropertyNotFoundMessage(propertyName: "Member", propertyType: "Member");
                }


                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }        

        [Test, Order(4)] 
        public void Test4_Check_DataAnnotations_Book() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Models", "Book");

            string PropertyUnderTest_propertyname = "";
            string PropertyUnderTest_attributename = "";

            try
            {
                PropertyUnderTest_propertyname = "Id";
                PropertyUnderTest_attributename = "Key";
                KeyAttributeTest();

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ExceptionCatch(functionName, $"Exception while testing {PropertyUnderTest_propertyname} for {PropertyUnderTest_attributename} attribute in {tb.type.Name}", msg, msg_name);
            }

            #region LocalFunction_KeyAttributeTest
            void KeyAttributeTest()
            {
                string Message = $"Key attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found";
                var keyAttribute = tb.GetAttributeFromProperty<KeyAttribute>(PropertyUnderTest_propertyname, typeof(KeyAttribute));
                var databaseGeneratedAttribute = tb.GetAttributeFromProperty<DatabaseGeneratedAttribute>(PropertyUnderTest_propertyname, typeof(DatabaseGeneratedAttribute));

                if (keyAttribute == null)
                {
                    msg += Message + "\n";
                }

                if (databaseGeneratedAttribute == null || databaseGeneratedAttribute.DatabaseGeneratedOption != DatabaseGeneratedOption.None)
                {
                    msg += $"DatabaseGeneratedOption.None attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found\n";
                }
                #endregion
            }
        }

        [Test, Order(5)]
        public void Test5_Check_DataAnnotations_Member() 
        {
            totalTestcases++; 
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Models", "Member");

            string PropertyUnderTest_propertyname = "";
            string PropertyUnderTest_attributename = "";

            try
            {
                PropertyUnderTest_propertyname = "Id";
                PropertyUnderTest_attributename = "Key";
                KeyAttributeTest();

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ExceptionCatch(functionName, $"Exception while testing {PropertyUnderTest_propertyname} for {PropertyUnderTest_attributename} attribute in {tb.type.Name}", msg, msg_name);
            }

            #region LocalFunction_KeyAttributeTest
            void KeyAttributeTest()
            {
                string Message = $"Key attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found";
                var keyAttribute = tb.GetAttributeFromProperty<KeyAttribute>(PropertyUnderTest_propertyname, typeof(KeyAttribute));
                var databaseGeneratedAttribute = tb.GetAttributeFromProperty<DatabaseGeneratedAttribute>(PropertyUnderTest_propertyname, typeof(DatabaseGeneratedAttribute));

                if (keyAttribute == null)
                {
                    msg += Message + "\n";
                }

                if (databaseGeneratedAttribute == null || databaseGeneratedAttribute.DatabaseGeneratedOption != DatabaseGeneratedOption.None)
                {
                    msg += $"DatabaseGeneratedOption.None attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found\n";
                }
                #endregion
            }
        }

        [Test, Order(6)] 
        public void Test6_Check_DataAnnotations_BorrowRecord() 
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Models", "BorrowRecord");

            string PropertyUnderTest_propertyname = "";
            string PropertyUnderTest_attributename = "";

            try
            {
                PropertyUnderTest_propertyname = "Id";
                PropertyUnderTest_attributename = "Key";
                KeyAttributeTest();

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                ExceptionCatch(functionName, $"Exception while testing {PropertyUnderTest_propertyname} for {PropertyUnderTest_attributename} attribute in {tb.type.Name}", msg, msg_name);
            }

            #region LocalFunction_KeyAttributeTest
            void KeyAttributeTest()
            {
                string Message = $"Key attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found";
                var keyAttribute = tb.GetAttributeFromProperty<KeyAttribute>(PropertyUnderTest_propertyname, typeof(KeyAttribute));
                var databaseGeneratedAttribute = tb.GetAttributeFromProperty<DatabaseGeneratedAttribute>(PropertyUnderTest_propertyname, typeof(DatabaseGeneratedAttribute));

                if (keyAttribute == null)
                {
                    msg += Message + "\n";
                }

                if (databaseGeneratedAttribute == null || databaseGeneratedAttribute.DatabaseGeneratedOption != DatabaseGeneratedOption.None)
                {
                    msg += $"DatabaseGeneratedOption.None attribute on {PropertyUnderTest_propertyname} of {tb.type.Name} is not found\n";
                }
                #endregion
            }
        }           

        [Test, Order(7)]
        public void Test7_Check_Methods_IBook()  
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Interfaces", "IBook");
            try
            {
                var IsFound = tb.HasMethod("AddBook", "System.Threading.Tasks.Task`1[System.Boolean]", new string[] { "LibraryManagementSystem.Models.Book" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "AddBook", methodType: "Task<bool>", new string[] { "Book" }, "IBook");
                }

                IsFound = tb.HasMethod("UpdateBookRating", "System.Threading.Tasks.Task`1[System.Boolean]", new string[] { "System.Int32", "System.Decimal" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "UpdateBookRating", methodType: "Task<bool>", new string[] { "int","decimal" }, "IBook");
                }

                IsFound = tb.HasMethod("DeleteBook", "System.Threading.Tasks.Task`1[System.Boolean]", new string[] { "System.Int32" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "DeleteBook", methodType: "Task<bool>", new string[] { "int" }, "IBook");
                }

                IsFound = tb.HasMethod("GetBookWithMostRecentBorrow", "System.Threading.Tasks.Task`1[LibraryManagementSystem.Models.Book]", new string[] {  });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetBookWithMostRecentBorrow", methodType: "Task<Book>", new string[] { }, "IBook");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(8)]
        public void Test8_Check_Methods_IMember()  
        {
            totalTestcases++;
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Interfaces", "IMember");
            try
            {

                var IsFound = tb.HasMethod("GetMembersWhoBorrowedBook", "System.Threading.Tasks.Task`1[System.Collections.Generic.IEnumerable`1[LibraryManagementSystem.Models.Member]]", new string[] { "System.Int32" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetMembersWhoBorrowedBook", methodType: "Task<IEnumerable<Member>>", new string[] { "int" }, "IMember");
                }

                IsFound = tb.HasMethod("GetMemberWithMostBorrowedBooks", "System.Threading.Tasks.Task`1[LibraryManagementSystem.Models.Member]", new string[] { });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetMemberWithMostBorrowedBooks", methodType: "Task<Member>", new string[] { }, "IMember");
                }

                IsFound = tb.HasMethod("GetMembersWithMostFrequentBorrowing", "System.Threading.Tasks.Task`1[System.Collections.Generic.IEnumerable`1[LibraryManagementSystem.Models.Member]]", new string[] { "System.DateTime", "System.DateTime" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetMembersWithMostFrequentBorrowing", methodType: "Task<IEnumerable<Member>>", new string[] { "DateTime", "DateTime" }, "IMember");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(9)]
        public void Test9_Check_Methods_IBorrowRecord() 
        {
            totalTestcases++; 
            string msg = "";
            string msg_name = "";
            string functionName = TestContext.CurrentContext.Test.Name;
            TestBase tb = new TestBase("LibraryManagementSystem", "LibraryManagementSystem.Interfaces", "IBorrowRecord");
            try
            {

                var IsFound = tb.HasMethod("GetBorrowRecordsByDateRange", "System.Threading.Tasks.Task`1[System.Collections.Generic.IEnumerable`1[LibraryManagementSystem.Models.BorrowRecord]]", new string[] { "System.DateTime", "System.DateTime" });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetBorrowRecordsByDateRange", methodType: "Task<IEnumerable<BorrowRecord>>", new string[] { "DateTime", "DateTime" }, "IBorrowRecord");
                }

                IsFound = tb.HasMethod("GetBorrowRecordWithHighestFine", "System.Threading.Tasks.Task`1[LibraryManagementSystem.Models.BorrowRecord]", new string[] { });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetBorrowRecordWithHighestFine", methodType: "Task<IEnumerable<BorrowRecord>>", new string[] { }, "IBorrowRecord");
                }

                IsFound = tb.HasMethod("GetLongestBorrowDuration", "System.Threading.Tasks.Task`1[LibraryManagementSystem.Models.BorrowRecord]", new string[] { });

                if (!IsFound)
                {
                    msg += tb.Messages.GetMethodNotFoundMessage(methodName: "GetLongestBorrowDuration", methodType: "Task<BorrowRecord>", new string[] { }, "IBorrowRecord");
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                //Assert.Fail(tb.Messages.GetExceptionMessage(ex, fieldName: "context"));
                ExceptionCatch(functionName, tb.Messages.GetExceptionMessage(ex), msg, msg_name);
            }
        }

        [Test, Order(10)]
        public void Test10_CheckForInheritance_BookRepository()  
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            String testcase = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            String className = "BookRepository";

            Type repClass = assem.GetType("LibraryManagementSystem.Repositories.BookRepository");

            try
            {
                if (repClass != null)
                {
                    if (repClass.GetInterface("IBook") == null)
                    {
                        msg += className + " Class is NOT inherting the 'IBook' interface.\n";
                    }
                }
                else
                {
                    msg += className + " Class NOT declared OR Check Spelling.\n";
                }

                if (msg != "")
                    throw new Exception();
            }
            catch (Exception e)
            {
                failMessage.Add(testcase);

                if (msg != "")
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                else
                {
                    msg = className + " Class is NOT implemented correctly, Check for the Usage of Inheritance. Exception thrown.\nException : " + e.Message + ".\n";
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                }
                failureMsg += msg_name;
                failcnt++;
                Assert.Fail(msg);
            }
        }

        [Test, Order(11)]
        public void Test11_CheckForInheritance_MemberRepository() 
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            String testcase = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            String className = "MemberRepository";

            Type repClass = assem.GetType("LibraryManagementSystem.Repositories.MemberRepository");

            try
            {
                if (repClass != null)
                {
                    if (repClass.GetInterface("IMember") == null)
                    {
                        msg += className + " Class is NOT inherting the 'IMember' interface.\n";
                    }
                }
                else
                {
                    msg += className + " Class NOT declared OR Check Spelling.\n";
                }

                if (msg != "")
                    throw new Exception();
            }
            catch (Exception e)
            {
                failMessage.Add(testcase);

                if (msg != "")
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                else
                {
                    msg = className + " Class is NOT implemented correctly, Check for the Usage of Inheritance. Exception thrown.\nException : " + e.Message + ".\n";
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                }
                failureMsg += msg_name;
                failcnt++;
                Assert.Fail(msg);
            }
        }

        [Test, Order(12)]
        public void Test12_CheckForInheritance_BorrowRecordRepository() 
        {
            totalTestcases++; 
            String msg = ""; 
            String msg_name = "";
            String testcase = NUnit.Framework.TestContext.CurrentContext.Test.Name;
            String className = "BorrowRecordRepository";

            Type repClass = assem.GetType("LibraryManagementSystem.Repositories.BorrowRecordRepository");

            try
            {
                if (repClass != null)
                {
                    if (repClass.GetInterface("IBorrowRecord") == null)
                    {
                        msg += className + " Class is NOT inherting the 'IBorrowRecord' interface.\n";
                    }
                }
                else
                {
                    msg += className + " Class NOT declared OR Check Spelling.\n";
                }

                if (msg != "")
                    throw new Exception();
            }
            catch (Exception e)
            {
                failMessage.Add(testcase);

                if (msg != "")
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                else
                {
                    msg = className + " Class is NOT implemented correctly, Check for the Usage of Inheritance. Exception thrown.\nException : " + e.Message + ".\n";
                    msg_name += "Fail " + failcnt + " -- " + testcase + "::\n" + msg;
                }
                failureMsg += msg_name;
                failcnt++;
                Assert.Fail(msg);
            }
        }

        [Test, Order(33)]
        public void Test13_AddBook_StatusCodeTest()  
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/AddBook", Method.POST);

                request.AddJsonBody(new
                {
                    id = 15,
                    title = "The Alchemist",
                    author = "Paulo Coelho",
                    rating = 8.88, 
                    borrowRecords = new object[] { } 
                });

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Book/AddBook' is NOT correct.\n";
                }

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.BadRequest)
                {
                    msg += "HttpStatusCode for the URI 'api/Book/AddBook' is NOT correct when the Book is already exists.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Book/AddBook' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(34)]
        public void Test14_AddBook_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/AddBook", Method.POST);

                request.AddJsonBody(new
                {
                    id = 16,
                    title = "The Shining",
                    author = "Stephen King",
                    rating = 9.99,
                    borrowRecords = new object[] { }
                });

                response = client.Execute(request);
                var content = response.Content;

                RestRequest requestActual = new RestRequest("api/Test/GetAllBooks", Method.GET);
                response = client.Execute(requestActual);

                //var responseActual = JsonConvert.DeserializeObject<List<Course>>(response.ISSN);

                List<Book> responseActual = new JsonDeserializer().Deserialize<List<Book>>(response);

                if (responseActual.Count > 0)
                {
                    if (response.StatusCode != HttpStatusCode.OK || (!response.Content.Contains("16") ||
                        !response.Content.Contains("The Shining") || !response.Content.Contains("Stephen King")))
                    {
                        msg += "POST service is not working correctly. Check logic in 'AddBook'.\n";
                    }
                }
                else msg += "POST service is not working correctly. Check logic in 'AddBook'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'AddBook' POST service. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(35)]
        public void Test15_UpdateBookRating_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/UpdateRating/2/15.55", Method.PUT);                

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Book/UpdateRating/{id}/{rating}' is NOT correct when the Book is available.\n";
                }

                RestRequest request1 = new RestRequest("api/Book/UpdateRating/1011/500.00", Method.PUT);                

                response = client.Execute(request1);

                if (response.StatusCode != HttpStatusCode.BadRequest)
                {
                    msg += "HttpStatusCode for the URI 'api/Book/UpdateRating/{id}/{rating}' is NOT correct when the Book is unavailable.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Book/UpdateRating/{id}/{rating}' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(36)]
        public void Test16_UpdateBookRating_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/UpdateRating/2/18.80", Method.PUT);              

                response = client.Execute(request);
                var content = response.Content;

                RestRequest requestActual = new RestRequest("api/Test/GetAllBooks", Method.GET);
                response = client.Execute(requestActual);

                if (!response.Content.Contains("2") || !response.Content.Contains("18.80") || !response.Content.Contains("Brave New World") || !response.Content.Contains("Aldous Huxley"))
                {
                    msg += "Put service is not working correctly. Check logic in 'UpdateBookRating'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'UpdateBookRating' PUT service. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(37)]
        public void Test17_DeleteBook_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/DeleteBook/4", Method.DELETE);

                response = client.Execute(request);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Book/DeleteBook/{id}' is NOT correct when the id is available.\n";
                }

                RestRequest request1 = new RestRequest("api/Book/DeleteBook/112", Method.DELETE);

                response = client.Execute(request1);

                if (response.StatusCode != HttpStatusCode.BadRequest)
                {
                    msg += "HttpStatusCode for the URI 'api/Book/DeleteBook/{id}' is NOT correct when the id is unavailable.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Book/DeleteBook/{id}' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(38)]
        public void Test18_DeleteBook_LogicReturnDataTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/DeleteBook/3", Method.DELETE);

                response = client.Execute(request);

                RestRequest requestActual = new RestRequest("api/Test/GetAllBooks", Method.GET);
                response = client.Execute(requestActual);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.OK || content.Contains("The Hobbit") || content.Contains("J.R.R. Tolkien"))
                {
                    msg += "DELETE service is not working correctly. Check logic in 'DeleteBook'.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'DeleteBook' DELETE service. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(19)]  
        public void Test19_GetBookWithMostRecentBorrow_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/most-recent-borrow", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Book/most-recent-borrow' is NOT correct.\n";
                }               

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Book/most-recent-borrow' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(20)]
        public void Test20_GetBookWithMostRecentBorrow_LogicReturnDataTest()
        {
            totalTestcases++;  
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Book/most-recent-borrow", Method.GET);

                response = client.Execute(request);

                List<Book> responseActual = new JsonDeserializer().Deserialize<List<Book>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("Catch-22") || !response.Content.Contains("Joseph Heller"))
                        msg += "Get service is not working correctly. Check logic in 'GetBookWithMostRecentBorrow'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetBookWithMostRecentBorrow'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetBookWithMostRecentBorrow' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }
         
        [Test, Order(21)] 
        public void Test21_GetMembersWhoBorrowedBook_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Member/members-by-book/2", Method.GET);               

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Member/members-by-book/{bookId}' is NOT correct when the Members are available.\n";
                }

                RestRequest request1 = new RestRequest("api/Member/members-by-book/111", Method.GET);               

                response = client.Execute(request1);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.NotFound || !content.Contains("No records found"))
                {
                    msg += "HttpStatusCode for the URI 'api/Member/members-by-book/{bookId}' is NOT correct when the Members are not available.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Member/members-by-book/{bookId}' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(22)] 
        public void Test22_GetMembersWhoBorrowedBook_LogicReturnDataTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Member/members-by-book/3", Method.GET);              

                response = client.Execute(request);

                List<Member> responseActual = new JsonDeserializer().Deserialize<List<Member>>(response);

                if (responseActual.Count == 2)
                {
                    if (!response.Content.Contains("Helen Clark") || !response.Content.Contains("Mia Robinson"))
                        msg += "Get service is not working correctly. Check logic in 'GetMembersWhoBorrowedBook'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetMembersWhoBorrowedBook'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetMembersWhoBorrowedBook' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }
         
        [Test, Order(23)] 
        public void Test23_GetMemberWithMostBorrowedBooks_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Member/most-borrowed-books", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Member/most-borrowed-books' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Member/most-borrowed-books' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(24)] 
        public void Test24_GetMemberWithMostBorrowedBooks_LogicReturnDataTest() 
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Member/most-borrowed-books", Method.GET);

                response = client.Execute(request);

                List<Member> responseActual = new JsonDeserializer().Deserialize<List<Member>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("Lucas Gray") || !response.Content.Contains("6"))
                        msg += "Get service is not working correctly. Check logic in 'GetMemberWithMostBorrowedBooks'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetMemberWithMostBorrowedBooks'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetMemberWithMostBorrowedBooks' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(25)]  
        public void Test25_GetMembersWithMostFrequentBorrowing_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Member/most-frequent-borrowing", Method.GET);
                request.AddQueryParameter("startDate", "2023-11-01");
                request.AddQueryParameter("endDate", "2023-12-01");

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/Member/most-frequent-borrowing' is NOT correct when the Members are available.\n";
                }

                RestRequest request1 = new RestRequest("api/Member/most-frequent-borrowing", Method.GET);
                request1.AddQueryParameter("startDate", "2025-06-01");
                request1.AddQueryParameter("endDate", "2025-06-05");

                response = client.Execute(request1);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.NotFound || !content.Contains("No records found"))
                {
                    msg += "HttpStatusCode for the URI 'api/Member/most-frequent-borrowing' is NOT correct when the Members are not available.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/Member/most-frequent-borrowing' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(26)] 
        public void Test26_GetMembersWithMostFrequentBorrowing_LogicReturnDataTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/Member/most-frequent-borrowing", Method.GET);
                request.AddQueryParameter("startDate", "2023-11-01");
                request.AddQueryParameter("endDate", "2023-12-01");

                response = client.Execute(request);

                List<Member> responseActual = new JsonDeserializer().Deserialize<List<Member>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("Lucas Gray") || !response.Content.Contains("6"))
                        msg += "Get service is not working correctly. Check logic in 'GetMembersWithMostFrequentBorrowing'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetMembersWithMostFrequentBorrowing'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetMembersWithMostFrequentBorrowing' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(27)]  
        public void Test27_GetBorrowRecordsByDateRange_StatusCodeTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/BorrowRecord/by-date-range", Method.GET);
                request.AddQueryParameter("startDate", "2023-05-01");
                request.AddQueryParameter("endDate", "2023-06-01");

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/BorrowRecord/by-date-range' is NOT correct when the Borrow Records are available.\n";
                }

                RestRequest request1 = new RestRequest("api/BorrowRecord/by-date-range", Method.GET);
                request1.AddQueryParameter("startDate", "2025-06-01");
                request1.AddQueryParameter("endDate", "2025-06-05");

                response = client.Execute(request1);
                var content = response.Content;

                if (response.StatusCode != HttpStatusCode.NotFound || !content.Contains("No records found"))
                {
                    msg += "HttpStatusCode for the URI 'api/BorrowRecord/by-date-range' is NOT correct when the Borrow Records are not available.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/BorrowRecord/by-date-range' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(28)]  
        public void Test28_GetBorrowRecordsByDateRange_LogicReturnDataTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/BorrowRecord/by-date-range", Method.GET);
                request.AddQueryParameter("startDate", "2023-05-01");
                request.AddQueryParameter("endDate", "2023-06-01");

                response = client.Execute(request);

                List<BorrowRecord> responseActual = new JsonDeserializer().Deserialize<List<BorrowRecord>>(response);

                if (responseActual.Count == 3)
                {
                    if (!response.Content.Contains("5") || !response.Content.Contains("6") || !response.Content.Contains("17") 
                        || !response.Content.Contains("2023-05-15") || !response.Content.Contains("2023-06-01") || !response.Content.Contains("2023-06-15"))
                        msg += "Get service is not working correctly. Check logic in 'GetBorrowRecordsByDateRange'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetBorrowRecordsByDateRange'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetBorrowRecordsByDateRange' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(29)] 
        public void Test29_GetBorrowRecordWithHighestFine_StatusCodeTest()
        {
            totalTestcases++; 
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/BorrowRecord/highest-fine", Method.GET);              

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/BorrowRecord/highest-fine' is NOT correct.\n";
                }                

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/BorrowRecord/highest-fine' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(30)] 
        public void Test30_GetBorrowRecordWithHighestFine_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/BorrowRecord/highest-fine", Method.GET);               

                response = client.Execute(request);

                List<BorrowRecord> responseActual = new JsonDeserializer().Deserialize<List<BorrowRecord>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("18") || !response.Content.Contains("50") ||!response.Content.Contains("2023-06-10") || !response.Content.Contains("2023-06-20"))
                        msg += "Get service is not working correctly. Check logic in 'GetBorrowRecordWithHighestFine'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetBorrowRecordWithHighestFine'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetBorrowRecordWithHighestFine' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(31)] 
        public void Test31_GetLongestBorrowDuration_StatusCodeTest() 
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/BorrowRecord/longest-borrow-duration", Method.GET);

                response = client.Execute(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    msg += "HttpStatusCode for the URI 'api/BorrowRecord/longest-borrow-duration' is NOT correct.\n";
                }

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName); 

                if (msg == "")
                {
                    msg += "HttpStatusCode for the URI 'api/BorrowRecord/longest-borrow-duration' is NOT correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

        [Test, Order(32)]  
        public void Test32_GetLongestBorrowDuration_LogicReturnDataTest()
        {
            totalTestcases++;
            String msg = "";
            String msg_name = "";
            string functionName = NUnit.Framework.TestContext.CurrentContext.Test.FullName;

            try
            {
                RestRequest request = new RestRequest("api/BorrowRecord/longest-borrow-duration", Method.GET);

                response = client.Execute(request);

                List<BorrowRecord> responseActual = new JsonDeserializer().Deserialize<List<BorrowRecord>>(response);

                if (responseActual.Count == 1)
                {
                    if (!response.Content.Contains("14") || !response.Content.Contains("2023-02-15") || !response.Content.Contains("2023-04-25") || !response.Content.Contains("40"))
                        msg += "Get service is not working correctly. Check logic in 'GetLongestBorrowDuration'.\n";
                }
                else msg += "Get service is not working correctly. Check logic in 'GetLongestBorrowDuration'.\n";

                if (msg != "")
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                failMessage.Add(functionName);

                if (msg == "")
                {
                    msg += "Check logic in 'GetLongestBorrowDuration' GET service Fetched data is not correct.. Exception Thrown." + e.Message + e.InnerException + "\n";
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;
                }
                else
                    msg_name += "Fail " + failcnt + " -- " + functionName + "::\n" + msg;

                failureMsg += msg_name;
                failcnt++;

                Assert.Fail(msg);
            }
        }

    }

    public class AssertFailureMessages
    {
        private string TypeName;
        public AssertFailureMessages(string typeName)
        {
            TypeName = typeName;
        }
        public string GetAssemblyNotFoundMessage(string assemblyName)
        {
            return $"Could not find {assemblyName}.dll";
        }
        public string GetTypeNotFoundMessage(string assemblyName, string typeName = null)
        {
            return $"Could not find {typeName ?? TypeName} in  {assemblyName}.dll";
        }
        public string GetFieldNotFoundMessage(string fieldName, string fieldType, string typeName = null)
        {
            return $"Could not find public field {fieldName} of {fieldType} type in {typeName ?? TypeName} class\n";
        }
        public string GetPropertyNotFoundMessage(string propertyName, string propertyType, string typeName = null)
        {
            return $"Could not find public property {propertyName} of {propertyType} type in {typeName ?? TypeName} class\n";
        }
        public string GetMethodNotFoundMessage(string methodName, string methodType, string[] parameters, string typeName = null)
        {
            string temp = "";
            foreach (var item in parameters)
            {
                temp += item.ToString() + ", ";
            }
            if (temp != string.Empty)
            {
                string errMessage = temp.Substring(0, temp.Length - 2);
                return $"Could not find public method {methodName} of return type {methodType} with parameters {errMessage} in {typeName ?? TypeName} class\n";
            }
            return $"Could not find public method {methodName} of return type {methodType} in {typeName ?? TypeName} class\n";

        }
        public string GetFieldTypeMismatchMessage(string fieldName, string expectedFieldType, string typeName = null)
        {
            return $"{fieldName} is not of {expectedFieldType} data type in {typeName ?? TypeName} class";
        }
        public string GetExceptionTestFailureMessage(string methodName, string customExceptionTypeName, string propertyName, Exception exception, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot throws exception of type {customExceptionTypeName} on validation failure for {propertyName}.\nException Message: {exception.InnerException?.Message}\nStack Trace:{exception.InnerException?.StackTrace}";
        }

        public string GetExceptionMessage(Exception ex, string methodName = null, string fieldName = null, string propertyName = null, string typeName = null)
        {
            string testFor = methodName != null ? methodName + " method" : fieldName != null ? fieldName + " field" : propertyName != null ? propertyName + " property" : "undefined";
            //return $" Exception while testing {testFor} of {typeName ?? TypeName} class.\nException message : {ex.InnerException?.Message}\nStack Trace : {ex.InnerException?.StackTrace}";
            return $" Exception while testing {testFor} of {typeName ?? TypeName} class.\n";
        }

        public string GetReturnTypeAssertionFailMessage(string methodName, string expectedTypeName, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return value of {expectedTypeName} data type";
        }
        public string GetReturnValueAssertionFailMessage(string methodName, object expectedValue, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return the value {expectedValue}";
        }

        public string GetValidationFailureMessage(string methodName, string expectedValidationMessage, string propertyName, string typeName = null)
        {
            return $"{methodName} method of {typeName ?? TypeName} class doesnot return '{expectedValidationMessage}' on validation failure for property {propertyName}";
        }

    }

    public class TestBase : ATestBase
    {
        public TestBase(string assemblyName, string namespaceName, string typeName)
        {
            Messages = new AssertFailureMessages(typeName);
            this.assemblyName = assemblyName;
            this.namespaceName = namespaceName;
            this.typeName = typeName;

            Messages = new AssertFailureMessages(typeName);
            assembly = Assembly.Load(assemblyName);
            type = assembly.GetType($"{namespaceName}.{typeName}");
        }
    }

    public abstract class ATestBase
    {
        public string assemblyName;
        public string namespaceName;
        public string typeName;
        public string controllerName;

        public AssertFailureMessages Messages;

        protected Assembly assembly;
        public Type type;


        protected object typeInstance = null;
        protected void CreateNewTypeInstance()
        {
            typeInstance = assembly.CreateInstance(type.FullName);
        }
        public object GetTypeInstance()
        {
            if (typeInstance == null)
                CreateNewTypeInstance();
            return typeInstance;
        }
        public object InvokeMethod(string methodName, Type type, params object[] parameters)
        {
            var method = type.GetMethod(methodName);
            var instance = GetTypeInstance();
            var result = method.Invoke(instance, parameters);
            return result;
        }
        public T InvokeMethod<T>(string methodName, Type type, params object[] parameters)
        {
            var result = InvokeMethod(methodName, type, parameters);
            return (T)Convert.ChangeType(result, typeof(T));
        }

        public bool HasField(string fieldName, string fieldType)
        {
            bool Found = false;
            var field = type.GetField(fieldName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (field != null)
            {
                Found = field.FieldType.Name == fieldType;
            }
            return Found;
        }

        public bool HasProperty(string propertyName, string propertyType)
        {
            bool Found = false;
            var property = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);
            if (property != null)
            {
                Found = property.PropertyType.Name == propertyType;
            }
            return Found;
        }
        public bool HasMethod(string methodName, string methodType, string[] parameters)
        {
            bool Found = false;
            bool Type = false;
            bool Count = false;
            int flag = 0;

            var method = type.GetMethod(methodName);
            if (method != null)
            {
                string returnType = method.ReturnType.ToString();
                Found = method.Name == methodName;
                Type = methodType == returnType;
                ParameterInfo[] info = method.GetParameters();
                int param = 0;
                foreach (ParameterInfo p in info)
                {
                    if (p.ParameterType.FullName == parameters[param])
                    {
                        param++;
                    }
                    else
                    {
                        flag = 1;
                        break;
                    }
                }

                if (flag == 0 && param == parameters.Length)
                {
                    Count = true;
                }
            }
            if (Found && Type && Count)
            {
                return true;
            }
            return false;
        }
        public T GetAttributeFromProperty<T>(string propertyName, Type attribute)
        {

            var attr = type.GetProperty(propertyName).GetCustomAttribute(attribute, false);
            return (T)Convert.ChangeType(attr, typeof(T));
        }
    }
}