using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace TermWork
{
    public class DataAccess
    {
        public List<CalcData> GetData(double m)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("TermWorkDB")))
            {
                var output = connection.Query<CalcData>("dbo.CalcData1 @m", new { m = m }).ToList();
                return output;
            }
        }

        public void InsertPerson(double m, double z1, double z2, double u, double amin, double amax, double a, double tp, double zp, double Lp, double lambda, double delta, double truea, double lb, double i, double T1, double N, double n1, double F, double b, double C1, double C2, double da1, double da2)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("TermWorkDB")))
            {
                //CalcData newCalcData = new CalcData { m = m, u = u };
                List<CalcData> calcdata = new List<CalcData>();
                calcdata.Add(new CalcData { m = m, z1 = z1, z2 = z2, u = u, amin = amin, amax = amax, a = a, tp = tp, zp = zp, Lp = Lp, lambda = lambda, delta = delta, truea = truea, lb = lb, i = i, T1 = T1, N = N, n1 = n1, F = F, b = b, C1 = C1, C2 = C2, da1 = da1, da2 = da2 });
                connection.Execute("dbo.CalcData_Insert @m, @z1, @z2, @u, @amin, @amax, @a, @tp, @zp, @Lp, @lambda, @delta, @truea, @lb, @i, @T1, @N, @n1, @F, @b, @C1, @C2, @da1, @da2", calcdata);
            }
        }
    }
}
