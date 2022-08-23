// using System;
// using System.Collections.Generic;
// using System.Data;
// using System.Data.SqlClient;
// using System.Text;

// namespace RoutineApp.Process
// {
//     public class MCR_AddOperator{

//         private readonly string strConn = "Server=RTHSRVTR01;Database=TRProcessControl;User Id=sa;Password=pwpolicy;MultipleActiveResultSets=true";
//         private SqlConnection objConn;

//         public MCR_AddOperator(){
//             objConn = new SqlConnection(strConn);
//             objConn.Open();
//         }

//         public Boolean MCR_AddOperator_ProcessControl(DataTable empDetail)
//         {

            
            
//             if (objConn == null | objConn.State == ConnectionState.Closed)
//             {
//                 objConn = new SqlConnection(strConn);
//                 objConn.Open();

//             try
//                 {
//                     string strSql;

//                     strSql = "SELECT COUNT(*)
//                               "





//                     strSql = "INSERT INTO Operator";

//                     strSql = "SELECT TOP(50) * "
//                         + "FROM HRMS_Employee ";
                            
//                             //   Where CODEMPID = \'" + (opid.Trim() + "\'")
//                             //     + "and ");

                    
//                     if (!string.IsNullOrEmpty(opid) | !string.IsNullOrEmpty(opName))
//                     {
//                         if (!string.IsNullOrEmpty(opid))
//                         {
//                             if (!strSql.Contains("WHERE"))
//                             {
//                                 strSql += "WHERE ";
//                             }
//                             else
//                             {
//                                 strSql += "and ";
//                             }
//                             strSql += "CODEMPID = \'" + opid.Trim() + "\'";
//                         }

//                         if (!string.IsNullOrEmpty(opName))
//                         {
//                             if (!strSql.Contains("WHERE"))
//                             {
//                                 strSql += "WHERE ";
//                             }
//                             else
//                             {
//                                 strSql += "and ";
//                             }
//                             strSql += "(NAMEMPE like " + "N\'" + "%" + opName.Trim() + "%" + "\'" 
//                                     + "or "
//                                     + "NAMEMPT like " + "N\'" + "%" + opName.Trim() + "%" + "\')";
//                         } 
//                     }

//                     Console.WriteLine(strSql);
                    
//                     SqlDataAdapter mySqlAdapter = new SqlDataAdapter(strSql, objConn);
//                     DataSet myDataset = new DataSet();
//                     DataTable myDataTable;
//                     mySqlAdapter.Fill(myDataset, "EmployeeDetail");
//                     if ((myDataset.Tables["EmployeeDetail"].Rows.Count == 0))
//                     {
//                         return null;
//                     }
//                     else
//                     {
//                         return myDataset;
//                     } 
//                 }
//                 catch (Exception ex)
//                 {
//                     return null;
//                 }
//                 finally
//                 {
//                     objConn.Close();
//                     objConn = null;
//                 }



//             }

//             return true;
//         }
        
//     }

// }