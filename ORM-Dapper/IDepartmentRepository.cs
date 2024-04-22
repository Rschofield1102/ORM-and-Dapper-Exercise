using System;
namespace ORM_Dapper
{
	public interface IDepartmentRepository
	{
        
        public IEnumerable<Department> GetAllDepartments();

        //stubbed out method for interface
        public void InsertDepartment(string newDepartmentName);
    }
}

