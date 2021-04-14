using LINQDbToCode.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using LINQDbToCode.DbClass;
namespace LINQDbToCode
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new CustomNorthWindContext())
            {
                DbClass.Dersler.Ders9RawSql(db);
            }
            //using (var db = new NorthWindContext())
            //{
            //    ////DbClass.Dersler.Ders1SelectWhere(db);
            //    ////DbClass.Dersler.Ders2Alistirmalar(db);                
            //    ////DbClass.Dersler.Ders3CountOrderBy(db);
            //    ////DbClass.Dersler.Ders4Add(db);
            //    ////DbClass.Dersler.Ders5Update(db);
            //    ////DbClass.Dersler.Ders6Delete(db);
            //    ////DbClass.Dersler.Ders7BirdenCok1(db);
            //    //DbClass.Dersler.Ders8BirdenCok2(db);
            //}

        }
    }
}
