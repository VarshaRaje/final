using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
namespace WebApplication1.Model
{
	public class StudentRepository
	{
		private string ConnectionString;

		public StudentRepository()
		{
			ConnectionString = @"Persist Security Info = False; User ID=sa;Password='sql@2021'; Data Source = 'DESKTOP-MV1KNFN'; initial catalog = 'StudentProj'; integrated security=true";
		}


		public IDbConnection Connection
		{
			get
			{
				return new SqlConnection(ConnectionString);
			}
		}

		public void Add(StudentInfo stud)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string Squery = @"Insert Into Student (FirstName,LastName,Address,EmailId,className,Division) values(@FirstName,@LastName,@Address,@EmailId,@className,@Division)";
				dbConnection.Open();
				dbConnection.Execute(Squery, stud);

			}
		}

		public IEnumerable<StudentInfo> GetAll()
		{
			using (IDbConnection dbConnection = Connection)
			{
				string Squery = @"Select * from Student";
				dbConnection.Open();
				return dbConnection.Query<StudentInfo>(Squery);
			}
		}

		public StudentInfo GetById(int id)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string Squery = @"Select * from Student where StudeId=@Id";
				dbConnection.Open();
				return dbConnection.Query<StudentInfo>(Squery, new { Id = id }).FirstOrDefault();
			}
		}

		public void Delete(int id)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string Squery = @"Delete * from Student where StudeId=@Id";
				dbConnection.Open();
				dbConnection.Execute(Squery, new { Id = id });
			}

		}

		public void Update(StudentInfo stud)
		{
			using (IDbConnection dbConnection = Connection)
			{
				string Squery = @"Update Student set FirstName=@FirstName,LastName=@LastName,Address=@Address,EmailId=@EmailId,className=@className,Division=@Division where StudeId=@Id";
				dbConnection.Open();
				dbConnection.Query(Squery, stud);
			}

		}

	}
}
