using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookLINQ
{
    class ABDataTable
    {
        public readonly DataTable dataTable = new DataTable();
        public DataTable CreateTable(AddressBookModel model)
        {
            var taleColumn1 = new DataColumn("First_Name");
            dataTable.Columns.Add(taleColumn1);
            var taleColumn2 = new DataColumn("Last_Name");
            dataTable.Columns.Add(taleColumn2);
            var taleColumn3 = new DataColumn("Address");
            dataTable.Columns.Add(taleColumn3);
            var taleColumn4 = new DataColumn("City");
            dataTable.Columns.Add(taleColumn4);
            var taleColumn5 = new DataColumn("State");
            dataTable.Columns.Add(taleColumn5);
            var taleColumn6 = new DataColumn("Zip");
            dataTable.Columns.Add(taleColumn6);
            var taleColumn7 = new DataColumn("Phone_Number");
            dataTable.Columns.Add(taleColumn7);
            var taleColumn8 = new DataColumn("Email");
            dataTable.Columns.Add(taleColumn8);
            var tableColumn9 = new DataColumn("BookName");
            dataTable.Columns.Add(tableColumn9);
            var tableColumn10 = new DataColumn("BookType");
            dataTable.Columns.Add(tableColumn10);

            dataTable.Rows.Add("Sudhanshu", "Yadav", "Pitampura", "Delhi", "New Delhi", "09", "943657", "Subbo@gmail.com", "Friends", "Office");


            return dataTable;
        }
        public void AddContact(AddressBookModel model)
        {
            dataTable.Rows.Add(model.First_Name, model.Last_Name, model.Address, model.City,
                model.State, model.Zip, model.Phone_Number, model.Email);
            Console.WriteLine("Contact Added Succesfully...");
        }
        public void EditContact(AddressBookModel model)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("First_Name") == model.First_Name).First();
            if (recordData != null)
            {
                recordData.SetField("Last_Name", model.Last_Name);
                recordData.SetField("Address", model.Address);
                recordData.SetField("City", model.City);
                recordData.SetField("State", model.State);
                recordData.SetField("Zip", model.Zip);
                recordData.SetField("Phone_Number", model.Phone_Number);
                recordData.SetField("Email", model.Email);
                recordData.SetField("AddressBookType", model.BookType);
                recordData.SetField("AddressBookName", model.BookName);
            }
        }
        public void Display()
        {
            foreach (var table in dataTable.AsEnumerable())
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name") + " || LastName: " + table.Field<string>("Last_Name") + " || Address: " + table.Field<string>("Address")
                + " || City: " + table.Field<string>("City") + " || State: " + table.Field<string>("State") + " || ZipCode: " + table.Field<string>("Zip") + " || PhoneNumber: " + table.Field<string>("Phone_Number")
                + " || E-mail: " + table.Field<string>("Email") + " || Address Book Type : " + table.Field<string>("BookType") + " || Address Book Name : " + table.Field<string>("BookName"));
            }
        }
        public void DeleteContact(AddressBookModel model)
        {
            var recordData = dataTable.AsEnumerable().Where(data => data.Field<string>("First_Name") == model.First_Name).First();
            if (recordData != null)
            {
                recordData.Delete();
                Console.WriteLine("Contact Deleted Successfully....");
            }
        }
        public void RetrievePersonByUsingState(AddressBookModel model)
        {
            var selectdData = from dataTable in dataTable.AsEnumerable().Where((dataTable => dataTable.Field<string>("State") == model.State)) select dataTable;
            foreach (var table in selectdData.AsEnumerable())
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name") + " || LastName: " + table.Field<string>("Last_Name") + " || Address: " + table.Field<string>("Address")
                               + " || City: " + table.Field<string>("City") + " || State: " + table.Field<string>("State") + " || ZipCode: " + table.Field<string>("Zip") + " || PhoneNumber: " + table.Field<string>("Phone_Number")
                               + " || E-mail: " + table.Field<string>("Email") + " || Address Book Type : " + table.Field<string>("BookType") + " || Address Book Name : " + table.Field<string>("BookName"));
            }
        }
        public void RetrievePersonByUsingCity(AddressBookModel model)
        {
            var selectdData = from dataTable in dataTable.AsEnumerable().Where(dataTable => dataTable.Field<string>("City") == model.City) select dataTable;
            foreach (var table in selectdData.AsEnumerable())
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name") + " || LastName: " + table.Field<string>("Last_Name") + " || Address: " + table.Field<string>("Address")
                               + " || City: " + table.Field<string>("City") + " || State: " + table.Field<string>("State") + " || ZipCode: " + table.Field<string>("Zip") + " || PhoneNumber: " + table.Field<string>("Phone_Number")
                               + " || E-mail: " + table.Field<string>("Email") + " || Address Book Type : " + table.Field<string>("BookType") + " || Address Book Name : " + table.Field<string>("BookName"));
            }
        }
        public void CountByCityAndState()
        {
            var countByCityAndState = from row in dataTable.AsEnumerable()
                                      group row by new { City = row.Field<string>("City"), State = row.Field<string>("State") } into groups
                                      select new
                                      {
                                          City = groups.Key.City,
                                          State = groups.Key.State,
                                          Count = groups.Count()
                                      };
            foreach (var row in countByCityAndState)
            {
                Console.WriteLine(row.City + "  " + row.State + "--->" + row.Count);
            }
        }
        public void SortContactAlphabeticallyForGivenCity(AddressBookModel model)
        {
            var records = dataTable.AsEnumerable().Where(x => x.Field<string>("City") == model.City).OrderBy(x => x.Field<string>("First_Name")).ThenBy(x => x.Field<string>("Last_Name"));
            foreach (var table in records)
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name") + " || LastName: " + table.Field<string>("Last_Name") + " || Address: " + table.Field<string>("Address")
                               + " || City: " + table.Field<string>("City") + " || State: " + table.Field<string>("State") + " || ZipCode: " + table.Field<string>("Zip") + " || PhoneNumber: " + table.Field<string>("Phone_Number")
                               + " || E-mail: " + table.Field<string>("Email") + " || Address Book Type : " + table.Field<string>("BookType") + " || Address Book Name : " + table.Field<string>("BookName"));
            }
        }
        public void GetCountByAddressBookType()
        {
            var countData = dataTable.AsEnumerable().GroupBy(BookType => BookType.Field<string>("BookType")).
                Select(BookType => new
                {
                    BookType = BookType.Key,
                    BookTypeCount = BookType.Count()
                });
            foreach (var contactlist in countData)
            {
                Console.WriteLine("AddressBook Type =" + contactlist.BookType + " --> " + "AddressBook_Count = " + contactlist.BookTypeCount);
            }
        }
        public void RetrieveByUsingBookType(AddressBookModel model)
        {
            var selectdData = from dataTable in dataTable.AsEnumerable().Where(dataTable => dataTable.Field<string>("BookType") == model.BookType) select dataTable;
            foreach (var table in selectdData.AsEnumerable())
            {
                Console.WriteLine("\nFirstName: " + table.Field<string>("First_Name") + " || LastName: " + table.Field<string>("Last_Name") + " || Address: " + table.Field<string>("Address")
                               + " || City: " + table.Field<string>("City") + " || State: " + table.Field<string>("State") + " || ZipCode: " + table.Field<string>("Zip") + " || PhoneNumber: " + table.Field<string>("Phone_Number")
                               + " || E-mail: " + table.Field<string>("Email") + " || Address Book Type : " + table.Field<string>("BookType") + " || Address Book Name : " + table.Field<string>("BookName"));
            }
        }
    }
}