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
                return ctx.Utenti.ToList();
            }
        }
    }
}
