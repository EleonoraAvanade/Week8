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
    public class RepositoryMostro : IRepositoryMostro
    {
        public Mostro Create(Mostro item)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if (item != null)
                {
                    try
                    {
                        ctx.Entry<Mostro>(item).State = EntityState.Added;
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

        public ICollection<Mostro> GetAll()
        {
            using (var ctx = new FinalFantasyContext())
            {
                return ctx.Mostri.ToList();
            }
        }
        public Mostro GetById(int id)
        {
            using (var ctx = new FinalFantasyContext())
            {
                if (id < 0)
                {
                    return null;
                }
                var mostro = ctx.Mostri
                                      .FirstOrDefault(x => x.id == id);
                return mostro;
            }
        }
    }

}
