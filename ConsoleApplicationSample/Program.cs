using ConsoleApplicationSample.EAMService2;
using System;
using System.Linq;

namespace ConsoleApplicationSample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                UpdateItem("ACAP002");

                UpdateSupplier("F1");

                Console.ReadKey();

            }
            catch (Exception ex)
            {

            }

        }


        public static IQueryable<as_assets> GetAssets(int as_id)
        {
            EAMEntities2 context = new EAMEntities2(new Uri("http://localhost:4490/EAMService2.svc"));
            context.IgnoreResourceNotFoundException = true;

            var q = context.as_assets
                    .Where(o => o.as_id > as_id)
                    .Select(o => o);

            return q;

        }

        /// <summary>
        /// Atualizar o registo com determinado ID
        /// </summary>
        /// <param name="id">Chave primaria da entidade</param>
        /// <returns></returns>
        public static bool UpdateItem(string lo_id)
        {
            EAMEntities2 context = new EAMEntities2(new Uri("http://localhost:4490/EAMService2.svc"));
            context.IgnoreResourceNotFoundException = true;
            string dsg = "Travão";

            st_itemcla u = context.st_itemcla
                    .Where(o => o.lo_id.Equals(lo_id))
                    .FirstOrDefault();

            if (u != null)
            {
                //Set valores novos
                u.lo_name = dsg;
                try
                {
                    context.UpdateObject(u);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    dsg = ex.ToString();
                    return false;
                }
            }
            else
            {
                //Entidade nova
                st_itemcla i = new st_itemcla();
                i.lo_id = lo_id;
                i.lo_name = dsg;
                try
                {
                    context.AddTost_itemcla(i);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    dsg = ex.ToString();
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Atualizar o registo com determinado ID
        /// </summary>
        /// <param name="id">Chave primaria da entidade</param>
        /// <returns></returns>
        public static bool UpdateSupplier(string su_nbr2)
        {
            EAMEntities2 context = new EAMEntities2(new Uri("http://localhost:4490/EAMService2.svc"));
            context.IgnoreResourceNotFoundException = true;
            string dsg = string.Empty;

            pr_suplier u = context.pr_suplier
                    .Where(o => o.su_nbr2.Equals(su_nbr2))
                    .FirstOrDefault();

            if (u != null)
            {
                //Set valores novos
                u.su_nbr2 = su_nbr2;
                try
                {
                    context.UpdateObject(u);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    dsg = ex.ToString();
                    return false;
                }
            }
            else
            {
                //Entidade nova
                pr_suplier i = new pr_suplier();

                i.su_nbr2 = su_nbr2;
                i.su_name = "Nome Fornecedor";
                i.su_name2 = "Nome abreviado Fornecedor";
                i.ac_discnt = 0;
                i.ac_dis = 0;
                i.ac_payterm = 0;
                try
                {
                    context.AddTopr_suplier(i);
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    dsg = ex.ToString();
                    return false;
                }
            }

            return true;
        }


    }
}
