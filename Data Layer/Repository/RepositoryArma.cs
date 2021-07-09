using Data_Layer.Context;
using Data_Layer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Layer.Repository
{
    public class RepositoryArma:IRepositoryArma
    {
        public Arma Create(Arma item)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Arma>(item).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return null;
                    }

                }
            }
            return item;
        }

        public ICollection<Arma> GetAll()
        {
            using (var ctx = new FinalFantasyContext())
            {
                return ctx.Armi.ToList();
            }
        }
        public Arma GetById(int id)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if (id < 0)
                {
                    return null;
                }
                var armi = ctx.Armi
                                      .FirstOrDefault(x => x.id == id);
                return armi;
            }
        }
    }
}
