﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Dapper
{
    public class DapperDepartmentRepository : IDepartmentRepository
    {
        private readonly IDbConnection _connection;
        //Constructor
        public DapperDepartmentRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _connection.Query<Department>("SELECT * FROM DEPARTMENTS;").ToList();
        }
        public void InsertDepartment(String newDepartmentName)
        {
            _connection.Execute("INSERT INTO DEPARTMENTS (Name) Values (@departmentName);",
                new {DepartmentName = newDepartmentName});
        }
    }
}
