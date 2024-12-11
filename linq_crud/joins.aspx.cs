using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class joins : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    string cs = ConfigurationManager.ConnectionStrings["Emp"].ConnectionString;

    protected void btnInnerJoin_Click(object sender, EventArgs e)
    {
        using(EmployeeDBDataContext context = new EmployeeDBDataContext(cs))
        {
            var query = from e1 in context.EMPLOYEEs
                        join d in context.DEPARTMENTs
                        on e1.DEPARTMENTID equals d.DEPARTMENTID
                        select new
                        {
                            e1.EMPLOYEEID,
                            e1.FIRSTNAME,
                            e1.LASTNAME,
                            e1.DEPARTMENTID,
                            d.DEPARTMENTNAME
                        };

            GridViewInnerJoin.DataSource = query;
            GridViewInnerJoin.DataBind();
        }
    }

    protected void btnLeftJoin_Click(object sender, EventArgs e)
    {
        using (EmployeeDBDataContext context = new EmployeeDBDataContext(cs))
        {
            //var query = from e1 in context.EMPLOYEEs
            //            join d in context.DEPARTMENTs
            //            on e1.DEPARTMENTID equals d.DEPARTMENTID into departmentGroup
            //            from d in departmentGroup.DefaultIfEmpty()
            //            join p in context.PROJECTs
            //            on e1.DEPARTMENTID equals p.DEPARTMENTID into projectGroup
            //            from p in projectGroup.DefaultIfEmpty()
            //            select new
            //            {
            //                e1.EMPLOYEEID,
            //                e1.FIRSTNAME,
            //                e1.LASTNAME,
            //                d.DEPARTMENTNAME,
            //                d.LOCATION,
            //                p.PROJECTNAME
            //            };

            var query = from e1 in context.EMPLOYEEs
                        join d in context.DEPARTMENTs
                        on e1.DEPARTMENTID equals d.DEPARTMENTID into departmentGroup
                        from d in departmentGroup.DefaultIfEmpty()
                        join p in context.PROJECTs
                        on e1.DEPARTMENTID equals p.DEPARTMENTID into projectGroup
                        from p in projectGroup.DefaultIfEmpty()
                        select new
                        {
                            e1.EMPLOYEEID,
                            e1.FIRSTNAME,
                            e1.LASTNAME,
                            e1.GENDER,
                            e1.SALARY,
                            DepartmentName = d.DEPARTMENTNAME ?? "No Department",
                            Location = d.LOCATION ?? "No Location",
                            ProjectName = p.PROJECTNAME ?? "No Project", 
                            ProjectStartDate = p.STARTDATE,
                            ProjectEndDate = p.ENDDATE 
                        };


            GridViewLeftJoin.DataSource = query;
            GridViewLeftJoin.DataBind();
        }
    }

    protected void btnRightJoin_Click(object sender, EventArgs e)
    {
        using (EmployeeDBDataContext context = new EmployeeDBDataContext(cs))
        {
            //var rightJoinQuery = from p in context.PROJECTs
            //                     join e1 in context.EMPLOYEEs
            //                     on p.DEPARTMENTID equals e1.DEPARTMENTID into employeeGroup
            //                     from e1 in employeeGroup.DefaultIfEmpty() 
            //                     join d in context.DEPARTMENTs
            //                     on p.DEPARTMENTID equals d.DEPARTMENTID into departmentGroup
            //                     from d in departmentGroup.DefaultIfEmpty()
            //                     select new
            //                     {
            //                         p.PROJECTID,
            //                         p.PROJECTNAME,
            //                         p.STARTDATE,
            //                         p.ENDDATE,
            //                         DepartmentName = d.DEPARTMENTNAME ?? "No Department",
            //                         Location = d.LOCATION ?? "No Location",
            //                         EmployeeFirstName = e1.FIRSTNAME ?? "No Employee",
            //                         EmployeeLastName = e1.LASTNAME ?? "No Employee",
            //                         EmployeeGender = e1.GENDER ?? "No Gender",
            //                         EmployeeSalary = e1.SALARY
            //                     };

            //var result = rightJoinQuery.ToList().Select(x => new
            //{
            //    x.PROJECTID,
            //    x.PROJECTNAME,
            //    ProjectStartDate = x.STARTDATE,
            //    ProjectEndDate = x.ENDDATE,
            //    x.DepartmentName,
            //    x.Location,
            //    x.EmployeeFirstName,
            //    x.EmployeeLastName,
            //    x.EmployeeGender,
            //    EmployeeSalary = x.EmployeeSalary.ToString("C")
            //}).ToList(); 

            //var result = 

            //GridViewRightJoin.DataSource = result;
            //GridViewRightJoin.DataBind();
        }
    }

    protected void btnOuterJoin_Click(object sender, EventArgs e)
    {

    }

    protected void btnCrossJoin_Click(object sender, EventArgs e)
    {
        using (EmployeeDBDataContext context = new EmployeeDBDataContext(cs))
        {
            var query = from p in context.PROJECTs
                        join d in context.DEPARTMENTs
                        on p.DEPARTMENTID equals d.DEPARTMENTID
                        select new
                        {
                            d.DEPARTMENTNAME,
                            d.DEPARTMENTID,
                            p.PROJECTNAME,
                            p.STARTDATE, 
                            p.ENDDATE
                        };

            GridView1.DataSource = query;
            GridView1.DataBind();
        }
    }
}